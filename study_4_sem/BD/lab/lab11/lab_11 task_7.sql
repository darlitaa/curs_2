USE L_MyBASE;

-- Курсор для получения названий показателей
DECLARE Task1Cursor CURSOR LOCAL
    FOR SELECT IndicatorName FROM Indicators;

DECLARE @IndicatorName VARCHAR(100), @Result VARCHAR(1000) = '';
OPEN Task1Cursor;
PRINT 'Indicators: ';
FETCH NEXT FROM Task1Cursor INTO @IndicatorName;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @Result = TRIM(@IndicatorName) + ', ' + @Result;
    FETCH NEXT FROM Task1Cursor INTO @IndicatorName;
END;
PRINT @Result;
CLOSE Task1Cursor;
DEALLOCATE Task1Cursor;

-- Курсор для получения финансовых метрик
DECLARE Task2Cursor CURSOR LOCAL
    FOR SELECT EnterpriseID, IndicatorID, Date, Value FROM FinancialMetrics;

DECLARE @EnterpriseID INT, @IndicatorID INT, @Date DATE, @Value DECIMAL(18, 2);
OPEN Task2Cursor;
PRINT 'Financial Metrics: ';
FETCH NEXT FROM Task2Cursor INTO @EnterpriseID, @IndicatorID, @Date, @Value;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'EnterpriseID: ' + CAST(@EnterpriseID AS VARCHAR(10)) + 
          ', IndicatorID: ' + CAST(@IndicatorID AS VARCHAR(10)) + 
          ', Date: ' + CAST(@Date AS VARCHAR(10)) + 
          ', Value: ' + CAST(@Value AS VARCHAR(18));
    FETCH NEXT FROM Task2Cursor INTO @EnterpriseID, @IndicatorID, @Date, @Value;
END;
CLOSE Task2Cursor;
DEALLOCATE Task2Cursor;

-- Курсор для обновления уровня важности показателей
DECLARE Task3Cursor CURSOR LOCAL
    FOR SELECT IndicatorID, ImportanceLevel FROM Indicators FOR UPDATE;

DECLARE @IndID INT, @Importance INT;
OPEN Task3Cursor;
FETCH NEXT FROM Task3Cursor INTO @IndID, @Importance;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE Indicators SET ImportanceLevel = @Importance + 1 WHERE CURRENT OF Task3Cursor;
    FETCH NEXT FROM Task3Cursor INTO @IndID, @Importance;
END;
CLOSE Task3Cursor;
DEALLOCATE Task3Cursor;
go

--4

DECLARE FinancialMetricsCursor CURSOR LOCAL DYNAMIC SCROLL
    FOR SELECT ROW_NUMBER() OVER (ORDER BY Date) AS RowNum, 
               EnterpriseID, 
               Value
        FROM FinancialMetrics;

DECLARE @RowNum INT, @EnterpriseID INT, @Value DECIMAL(18, 2);

OPEN FinancialMetricsCursor;

FETCH FIRST FROM FinancialMetricsCursor INTO @RowNum, @EnterpriseID, @Value;
PRINT 'Первая строка: ' + CAST(@RowNum AS CHAR(10)) + ', Предприятие: ' + CAST(@EnterpriseID AS CHAR(10)) + 
      ', Значение: ' + CAST(@Value AS CHAR(18));

FETCH NEXT FROM FinancialMetricsCursor INTO @RowNum, @EnterpriseID, @Value;
PRINT 'Следующая строка: ' + CAST(@RowNum AS CHAR(10)) + ', Предприятие: ' + CAST(@EnterpriseID AS CHAR(10)) + 
      ', Значение: ' + CAST(@Value AS CHAR(18));

CLOSE FinancialMetricsCursor;
DEALLOCATE FinancialMetricsCursor;