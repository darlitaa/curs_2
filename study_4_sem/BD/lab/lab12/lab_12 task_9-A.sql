SELECT * FROM FinancialMetrics;

BEGIN TRY
    BEGIN TRANSACTION;
    INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (2, 1, '2024-02-25', 100000.00);
    INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (3, 1, '2024-02-25', 150000.00);
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH --547
    PRINT 'Error: ' + CASE
        WHEN ERROR_NUMBER() = 547 THEN 'Foreign key conflict'
        ELSE 'Unknown error: ' + CAST(ERROR_NUMBER() AS VARCHAR(5))
    END;
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
END CATCH;

DELETE FROM FinancialMetrics WHERE MetricID = 1;
SELECT * FROM FinancialMetrics;

DECLARE @point VARCHAR(32);
BEGIN TRY
    BEGIN TRANSACTION;
    INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (2, 1, '2024-02-25', 100000.00);
    SET @point = 'p1'; SAVE TRANSACTION @point;
    INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (3, 1, '2024-02-25', 150000.00);
    SET @point = 'p2'; SAVE TRANSACTION @point;
    INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (1, 1, '2024-02-25', 75000.00);
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    PRINT 'Error: ' + CASE
        WHEN ERROR_NUMBER() = 547 THEN 'Foreign key conflict'
        ELSE 'Unknown error: ' + CAST(ERROR_NUMBER() AS VARCHAR(5))
    END;

    IF @@TRANCOUNT > 0
    BEGIN
        PRINT 'checkpoint: ' + @point;
        ROLLBACK TRANSACTION @point;
        COMMIT TRANSACTION;
    END
END CATCH;

SELECT * FROM FinancialMetrics;

-- A ---
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;
-------------------------- t1 ------------------
SELECT @@SPID AS 'SID', 'Insert' AS 'Result', * FROM Indicators 
    WHERE IndicatorName = 'Прибыль';

SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;

SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;

WAITFOR DELAY '00:00:05';
SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;
COMMIT; 
-------------------------- t2 -----------------

DELETE FROM Indicators WHERE IndicatorName = 'Прибыль';

--TASK 5

-- неподтвержденное чтение
-- A ---
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;
-------------------------- t1 ------------------
SELECT @@SPID AS 'SID', 'Insert' AS 'Result', * FROM Indicators 
    WHERE IndicatorName = 'Прибыль';

SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;

WAITFOR DELAY '00:00:05';
COMMIT; 

-- работа фантомного и неповторяющегося чтения
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;

SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;

WAITFOR DELAY '00:00:05';

SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;

SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;
COMMIT;

--TASK 6

-- не работа неподтвержденного чтения
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Insert' AS 'Result', * FROM Indicators 
    WHERE IndicatorName = 'Прибыль';

SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;
COMMIT;

-- не работа неповторяющегося чтения
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;
WAITFOR DELAY '00:00:05';
SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;
COMMIT;

-- работа фантомного чтения
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;

WAITFOR DELAY '00:00:05';

SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;
COMMIT;

--TASK 7
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Insert' AS 'Result', * FROM Indicators 
    WHERE IndicatorName = 'Прибыль';

SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;
COMMIT;

-- не работа неповторяющегося чтения
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;
WAITFOR DELAY '00:00:05';
SELECT @@SPID AS 'SID', 'Update' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE MetricID = 2;
COMMIT;

-- не работа фантомного чтения
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;

WAITFOR DELAY '00:00:05';

SELECT @@SPID AS 'SID', 'Select' AS 'Result', MetricID, Date, EnterpriseID,
    IndicatorID, Value FROM FinancialMetrics WHERE Value = 1.5;
COMMIT;

SELECT * FROM FinancialMetrics;

BEGIN TRANSACTION;
    INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (2, 1, '2024-02-21', 70000.00);
    BEGIN TRANSACTION;
    UPDATE FinancialMetrics SET IndicatorID = 2 WHERE MetricID = 11;
    COMMIT;  
    IF @@TRANCOUNT > 0 ROLLBACK;
SELECT COUNT(*) AS 'amount' FROM FinancialMetrics WHERE MetricID = 7;