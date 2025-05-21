-- TASK1
CREATE PROCEDURE GetFinancialMetricsCount
AS
BEGIN
    DECLARE @n INT = (SELECT COUNT(*) FROM FinancialMetrics);
    SELECT * FROM FinancialMetrics;
    RETURN @n;
END;
GO

-- TASK2
CREATE PROCEDURE GetMetricsByIndicator
    @p VARCHAR(100), 
    @c INT OUTPUT
AS
BEGIN
    DECLARE @n INT = (SELECT COUNT(*) FROM FinancialMetrics);
    SELECT * FROM FinancialMetrics WHERE IndicatorID = (SELECT IndicatorID FROM Indicators WHERE IndicatorName = @p);
    SET @c = @@ROWCOUNT;
    RETURN @n;
END;
GO

-- TASK3
CREATE PROCEDURE InsertIndicator
    @a VARCHAR(100), 
    @c INT
AS
BEGIN TRY
    INSERT INTO Indicators (IndicatorName, ImportanceLevel) VALUES(@a, @c);
    RETURN 1;
END TRY
BEGIN CATCH
    PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(6));
    PRINT 'Message: ' + ERROR_MESSAGE();
    PRINT 'Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(6));
    PRINT 'State: ' + CAST(ERROR_STATE() AS VARCHAR(8));
    PRINT 'Line Number: ' + CAST(ERROR_LINE() AS VARCHAR(8));
    IF ERROR_PROCEDURE() IS NOT NULL
        PRINT 'Procedure Name: ' + ERROR_PROCEDURE();
    RETURN -1; 
END CATCH;
GO

-- TASK4
CREATE PROCEDURE FinancialMetricsReport 
    @p VARCHAR(100)
AS
BEGIN
    DECLARE @rc INT = 0;
    DECLARE @indicator VARCHAR(100), @indicators VARCHAR(MAX) = '';
    
    BEGIN TRY
        DECLARE indicator CURSOR FOR 
            SELECT i.IndicatorName 
            FROM FinancialMetrics fm
            JOIN Indicators i ON fm.IndicatorID = i.IndicatorID
            WHERE fm.EnterpriseID = (SELECT EnterpriseID FROM Enterprises WHERE Name = @p);
        
        OPEN indicator;
        FETCH NEXT FROM indicator INTO @indicator;
        PRINT 'Indicators for Enterprise ' + @p + ': ';
        
        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @indicators = RTRIM(@indicator) + ', ' + @indicators;
            SET @rc = @rc + 1;
            FETCH NEXT FROM indicator INTO @indicator;
        END;
        
        PRINT @indicators;
        CLOSE indicator;

        IF (@rc = 0)
        BEGIN
            RAISERROR('No indicators found for this enterprise.', 16, 1);
            RETURN -1;
        END
        ELSE
            RETURN @rc;
    END TRY
    BEGIN CATCH
        PRINT 'Error: ' + CAST(ERROR_NUMBER() AS VARCHAR(6));
        PRINT 'Message: ' + ERROR_MESSAGE();
        RETURN -1;
    END CATCH;
END;
GO

-- TASK5
CREATE PROCEDURE InsertIndicatorAndMetric 
    @a VARCHAR(100), 
    @c INT = 0, 
    @enterpriseName VARCHAR(100), 
    @value DECIMAL(18, 2)
AS
BEGIN TRY
    BEGIN TRANSACTION
        EXEC InsertIndicator @a, @c;
        INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) 
        VALUES(
            (SELECT EnterpriseID FROM Enterprises WHERE Name = @enterpriseName),
            (SELECT IndicatorID FROM Indicators WHERE IndicatorName = @a),
            GETDATE(),
            @value
        );
    COMMIT TRANSACTION;
    RETURN 1;
END TRY
BEGIN CATCH
    PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(6));
    PRINT 'Message: ' + ERROR_MESSAGE();
    PRINT 'Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(6));
    PRINT 'State: ' + CAST(ERROR_STATE() AS VARCHAR(8));
    PRINT 'Line Number: ' + CAST(ERROR_LINE() AS VARCHAR(8));
    IF ERROR_PROCEDURE() IS NOT NULL
        PRINT 'Procedure Name: ' + ERROR_PROCEDURE();
    RETURN -1; 
END CATCH;
GO

-- TASK6
DECLARE @ret INT;
EXEC @ret = GetFinancialMetricsCount;
PRINT 'Total financial metrics: ' + CAST(@ret AS VARCHAR(10));

DECLARE @rows INT;
EXEC @ret = GetMetricsByIndicator @p = 'Прибыль', @c = @rows OUTPUT;
PRINT 'Total rows for Прибыль: ' + CAST(@rows AS VARCHAR(10));

EXEC @ret = FinancialMetricsReport @p = 'Предприятие А';
PRINT 'Number of indicators: ' + CAST(@ret AS VARCHAR(10));

EXEC @ret = InsertIndicatorAndMetric @a = 'Доход', @c = 5, @enterpriseName = 'Предприятие А', @value = 150000.00;
PRINT 'Insert return value: ' + CAST(@ret AS VARCHAR(10));