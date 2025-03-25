USE L_MyBASE

--TASK1
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM
	GROUP BY FM.EnterpriseID, FM.IndicatorID WITH ROLLUP

--TASK2
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM
	GROUP BY FM.EnterpriseID, FM.IndicatorID WITH CUBE

--TASK3
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel > 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 
UNION
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel <= 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 


SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel > 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 
UNION ALL
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel <= 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 

--TASK4
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel > 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 
INTERSECT
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel <= 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 

--TASK5
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel > 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 
EXCEPT
SELECT FM.EnterpriseID, FM.IndicatorID, AVG(FM.Value) AS AVR, COUNT(*) AS AMOUNT
	FROM FinancialMetrics AS FM INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel <= 4
	GROUP BY FM.EnterpriseID, FM.IndicatorID 