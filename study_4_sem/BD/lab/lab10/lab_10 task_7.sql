CREATE TABLE #Enterprises (
    EnterpriseID INT IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    BankDetails VARCHAR(150),
    Phone VARCHAR(15),
    ContactPerson VARCHAR(100)
);

CREATE TABLE #Indicators (
    IndicatorID INT IDENTITY(1,1),
    IndicatorName VARCHAR(100) NOT NULL,
    ImportanceLevel INT NOT NULL 
);

CREATE TABLE #FinancialMetrics (
    MetricID INT IDENTITY(1,1),
    EnterpriseID INT,
    IndicatorID INT,
    Date DATE NOT NULL,
    Value DECIMAL(18, 2) NOT NULL
);

INSERT INTO #Enterprises (Name, BankDetails, Phone, ContactPerson) VALUES
('Предприятие А', 'Реквизиты 1', '111-222-333', 'Иванов И.И.'),
('Предприятие Б', 'Реквизиты 2', '444-555-666', 'Петров П.П.'),
('Предприятие В', 'Реквизиты 3', '777-888-999', 'Сидоров С.С.'),
('Предприятие Г', 'Реквизиты 4', '666-222-444', 'Кравченко С.С.');

INSERT INTO #Indicators (IndicatorName, ImportanceLevel) VALUES
('Прибыль', 5),
('Себестоимость', 4),
('Выручка', 5),
('Рентабельность', 3);

INSERT INTO #FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES
(1, 1, '2023-01-01', 100000.00),
(1, 2, '2023-01-01', 75000.00),
(2, 2, '2023-01-02', 150000.00),
(2, 3, '2023-01-03', 200000.00),
(3, 4, '2023-01-03', 0.20),
(1, 4, '2023-01-03', 300000.00),
(3, 1, '2023-01-04', 70000.00),
(2, 1, '2023-01-04', 300000.00),
(2, 3, '2023-01-05', 50000.00),
(3, 4, '2023-01-05', 0.80);

EXEC SP_HELPINDEX '#FinancialMetrics';
EXEC SP_HELPINDEX '#Indicators';
EXEC SP_HELPINDEX '#Enterprises';

SELECT * FROM #FinancialMetrics;
SELECT * FROM #Indicators;
SELECT * FROM #Enterprises;

CHECKPOINT;
DBCC DROPCLEANBUFFERS;

CREATE INDEX #FinMetrics_NONCLU ON #FinancialMetrics(EnterpriseID, Date);
SELECT * FROM #FinancialMetrics ORDER BY EnterpriseID, Date;
SELECT * FROM #FinancialMetrics WHERE EnterpriseID > 1 AND Date = '2023-01-03';

CREATE INDEX #FinMetrics_EstNum_X ON #FinancialMetrics(MetricID) INCLUDE(Date);
SELECT Date FROM #FinancialMetrics WHERE MetricID > 4;

CREATE INDEX #FinMetrics_WHERE ON #FinancialMetrics(Value) WHERE Value > 0.8 AND Value < 200000.00;
SELECT * FROM #FinancialMetrics WHERE Value BETWEEN 6000 AND 120000;
SELECT * FROM #FinancialMetrics WHERE Value = 50000.00;

CREATE INDEX #FinancialMetrics_1 ON #FinancialMetrics(Value)
ALTER INDEX #FinancialMetrics_1 ON #FinancialMetrics REORGANIZE;
ALTER INDEX #FinancialMetrics_1 ON #FinancialMetrics REBUILD WITH (ONLINE = OFF);

CREATE INDEX #FinancialMetrics_2 ON #FinancialMetrics(Value) WITH (FILLFACTOR = 52);

INSERT INTO #FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES
(1, 1, '2023-01-01', 100000.00),
(1, 2, '2023-01-01', 75000.00),
(2, 2, '2023-01-02', 150000.00),
(2, 3, '2023-01-03', 200000.00),
(3, 4, '2023-01-03', 0.20),
(1, 4, '2023-01-03', 300000.00),
(3, 1, '2023-01-04', 70000.00),
(2, 1, '2023-01-04', 300000.00),
(2, 3, '2023-01-05', 50000.00),
(3, 4, '2023-01-05', 0.80);

SELECT name AS [Индекс], avg_fragmentation_in_percent AS [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
OBJECT_ID(N'##FinancialMetrics'), NULL, NULL, NULL) ss  
JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id  
WHERE name IS NOT NULL;