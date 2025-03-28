USE L_MyBASE
GO

--TASK1
CREATE VIEW Estimations
AS SELECT 
    f.Date AS [Дата_оценки], 
    e.Name AS [Предприятие], 
    i.IndicatorName AS [Показатель]
	FROM FinancialMetrics f 
	INNER JOIN Enterprises e ON f.EnterpriseID = e.EnterpriseID
	INNER JOIN Indicators i ON f.IndicatorID = i.IndicatorID;
go

SELECT * FROM Estimations
go

--TASK2
CREATE VIEW EstimationsImp
AS SELECT 
    i.IndicatorName AS [Название_показателя], 
    SUM(f.Value) AS [Значение Показателя],
    AVG(i.ImportanceLevel) AS [Важность_показателя]
	FROM FinancialMetrics f INNER JOIN Indicators i ON f.IndicatorID = i.IndicatorID
	GROUP BY i.IndicatorName;
go

SELECT * FROM EstimationsImp
go

--TASK3
CREATE VIEW Factory
AS SELECT 
    e.Name AS [Название], 
    e.BankDetails AS [Банковские_реквизиты], 
    e.Phone AS [Телефон], 
    e.ContactPerson AS [Контактное_лицо]
	FROM Enterprises e;
go

SELECT * FROM Factory
go

--TASK5
CREATE VIEW Indicator
AS SELECT TOP 100 PERCENT
    i.IndicatorName AS [Название_показателя], 
    i.ImportanceLevel AS [Важность_показателя]
	FROM Indicators i
	WHERE i.ImportanceLevel > 0
	ORDER BY i.ImportanceLevel DESC;
go

SELECT * FROM Indicator
go

--TASK6
CREATE VIEW EstimationsImp2
WITH SCHEMABINDING
AS SELECT 
    i.IndicatorName AS [Название_показателя], 
    SUM(f.Value) AS [Значение Показателя],
    AVG(i.ImportanceLevel) AS [Важность_показателя]
	FROM dbo.FinancialMetrics f INNER JOIN dbo.Indicators i ON f.IndicatorID = i.IndicatorID
	GROUP BY i.IndicatorName;

go
ALTER TABLE dbo.Indicators DROP COLUMN ImportanceLevel;