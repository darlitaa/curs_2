--TASK4 задание, неподтвержденное чтения для TASK5
-- Неподтвержденное чтение
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
INSERT INTO Indicators VALUES('Доход', 10);
UPDATE FinancialMetrics SET Value = 1 WHERE MetricID = 2;
-------------------------- t1 --------------------
-------------------------- t2 --------------------
WAITFOR DELAY '00:00:05';
INSERT INTO FinancialMetrics VALUES(1, 1, '2024-02-21', 1.5);
WAITFOR DELAY '00:00:05';
ROLLBACK;

DELETE FROM FinancialMetrics WHERE MetricID = 10;

-- Работа с фантомным и неповторяющимся чтением
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
UPDATE FinancialMetrics SET Value = 1.1 WHERE MetricID = 2;
INSERT INTO FinancialMetrics VALUES(1, 1, '2024-02-21', 1.5);
COMMIT;


--TASK6
DELETE FROM Indicators WHERE IndicatorName = 'Доход';

-- Неподтвержденное чтение (не работает)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
INSERT INTO Indicators VALUES('Доход', 10);
UPDATE FinancialMetrics SET Value = 1 WHERE MetricID = 2;
WAITFOR DELAY '00:00:05';
ROLLBACK;

-- Неповторяющееся чтение (не работает)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
UPDATE FinancialMetrics SET Value = 1.1 WHERE MetricID = 2;
COMMIT;

DELETE FROM FinancialMetrics WHERE MetricID = 10;

-- Фантомное чтение (работает)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
INSERT INTO FinancialMetrics VALUES(10, 1, '2024-02-21', 1.5);
COMMIT;


--TASK7
DELETE FROM Indicators WHERE IndicatorName = 'Доход';

-- Неподтвержденное чтение (не работает)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
INSERT INTO Indicators VALUES('Доход', 10);
UPDATE FinancialMetrics SET Value = 1 WHERE MetricID = 2;
WAITFOR DELAY '00:00:05';
ROLLBACK;

-- Неповторяющееся чтение (не работает)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
UPDATE FinancialMetrics SET Value = 1.2 WHERE MetricID = 2;
COMMIT;

DELETE FROM FinancialMetrics WHERE MetricID = 10;

-- Фантомное чтение (не работает)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
INSERT INTO FinancialMetrics VALUES(10, 1, '2024-02-21', 1.5);
COMMIT;