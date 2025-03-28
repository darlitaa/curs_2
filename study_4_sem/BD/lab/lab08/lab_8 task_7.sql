USE L_MyBASE
GO

--TASK1
CREATE VIEW Estimations
AS SELECT 
    f.Date AS [����_������], 
    e.Name AS [�����������], 
    i.IndicatorName AS [����������]
	FROM FinancialMetrics f 
	INNER JOIN Enterprises e ON f.EnterpriseID = e.EnterpriseID
	INNER JOIN Indicators i ON f.IndicatorID = i.IndicatorID;
go

SELECT * FROM Estimations
go

--TASK2
CREATE VIEW EstimationsImp
AS SELECT 
    i.IndicatorName AS [��������_����������], 
    SUM(f.Value) AS [�������� ����������],
    AVG(i.ImportanceLevel) AS [��������_����������]
	FROM FinancialMetrics f INNER JOIN Indicators i ON f.IndicatorID = i.IndicatorID
	GROUP BY i.IndicatorName;
go

SELECT * FROM EstimationsImp
go

--TASK3
CREATE VIEW Factory
AS SELECT 
    e.Name AS [��������], 
    e.BankDetails AS [����������_���������], 
    e.Phone AS [�������], 
    e.ContactPerson AS [����������_����]
	FROM Enterprises e;
go

SELECT * FROM Factory
go

--TASK5
CREATE VIEW Indicator
AS SELECT TOP 100 PERCENT
    i.IndicatorName AS [��������_����������], 
    i.ImportanceLevel AS [��������_����������]
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
    i.IndicatorName AS [��������_����������], 
    SUM(f.Value) AS [�������� ����������],
    AVG(i.ImportanceLevel) AS [��������_����������]
	FROM dbo.FinancialMetrics f INNER JOIN dbo.Indicators i ON f.IndicatorID = i.IndicatorID
	GROUP BY i.IndicatorName;

go
ALTER TABLE dbo.Indicators DROP COLUMN ImportanceLevel;