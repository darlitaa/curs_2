--TASK4 �������, ���������������� ������ ��� TASK5
-- ���������������� ������
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
INSERT INTO Indicators VALUES('�����', 10);
UPDATE FinancialMetrics SET Value = 1 WHERE MetricID = 2;
-------------------------- t1 --------------------
-------------------------- t2 --------------------
WAITFOR DELAY '00:00:05';
INSERT INTO FinancialMetrics VALUES(1, 1, '2024-02-21', 1.5);
WAITFOR DELAY '00:00:05';
ROLLBACK;

DELETE FROM FinancialMetrics WHERE MetricID = 10;

-- ������ � ��������� � ��������������� �������
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
UPDATE FinancialMetrics SET Value = 1.1 WHERE MetricID = 2;
INSERT INTO FinancialMetrics VALUES(1, 1, '2024-02-21', 1.5);
COMMIT;


--TASK6
DELETE FROM Indicators WHERE IndicatorName = '�����';

-- ���������������� ������ (�� ��������)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
INSERT INTO Indicators VALUES('�����', 10);
UPDATE FinancialMetrics SET Value = 1 WHERE MetricID = 2;
WAITFOR DELAY '00:00:05';
ROLLBACK;

-- ��������������� ������ (�� ��������)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
UPDATE FinancialMetrics SET Value = 1.1 WHERE MetricID = 2;
COMMIT;

DELETE FROM FinancialMetrics WHERE MetricID = 10;

-- ��������� ������ (��������)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
INSERT INTO FinancialMetrics VALUES(10, 1, '2024-02-21', 1.5);
COMMIT;


--TASK7
DELETE FROM Indicators WHERE IndicatorName = '�����';

-- ���������������� ������ (�� ��������)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
INSERT INTO Indicators VALUES('�����', 10);
UPDATE FinancialMetrics SET Value = 1 WHERE MetricID = 2;
WAITFOR DELAY '00:00:05';
ROLLBACK;

-- ��������������� ������ (�� ��������)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
UPDATE FinancialMetrics SET Value = 1.2 WHERE MetricID = 2;
COMMIT;

DELETE FROM FinancialMetrics WHERE MetricID = 10;

-- ��������� ������ (�� ��������)
BEGIN TRANSACTION;
SELECT @@SPID AS 'SID';
WAITFOR DELAY '00:00:05';
INSERT INTO FinancialMetrics VALUES(10, 1, '2024-02-21', 1.5);
COMMIT;