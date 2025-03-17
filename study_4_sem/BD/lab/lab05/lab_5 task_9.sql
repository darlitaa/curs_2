--TASK1
USE L_MyBASE
SELECT E.EnterpriseID, E.Name
	FROM Enterprises AS E, FinancialMetrics AS FM
	WHERE E.EnterpriseID = FM.EnterpriseID
		AND 
		FM.IndicatorID IN (SELECT I.IndicatorID
							FROM Indicators AS I
							WHERE I.ImportanceLevel = 5)

--TASK2
SELECT E.EnterpriseID, E.Name
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	WHERE FM.IndicatorID IN (SELECT I.IndicatorID
							FROM Indicators AS I
							WHERE I.ImportanceLevel = 5)
--TASK3
SELECT E.EnterpriseID, E.Name
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
		WHERE I.ImportanceLevel = 5

--TASK4
SELECT E.Name, I.IndicatorName, I.ImportanceLevel
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.ImportanceLevel = (
				SELECT TOP(1) I2.ImportanceLevel
					FROM FinancialMetrics AS FM2
					INNER JOIN Indicators AS I2 ON FM2.IndicatorID = I2.IndicatorID
					WHERE FM2.EnterpriseID = E.EnterpriseID
					ORDER BY I2.ImportanceLevel DESC)

--TASK5
SELECT E.Name
	FROM Enterprises AS E
	WHERE NOT EXISTS (SELECT *
						FROM FinancialMetrics AS FM
						WHERE FM.EnterpriseID = E.EnterpriseID)

--TASK6
SELECT TOP 1
	(SELECT AVG(Value) FROM FinancialMetrics
		WHERE FinancialMetrics.EnterpriseID = 1)[Предприятие А],
	(SELECT AVG(Value) FROM FinancialMetrics
		WHERE FinancialMetrics.EnterpriseID = 2)[Предприятие Б],
	(SELECT AVG(Value) FROM FinancialMetrics
		WHERE FinancialMetrics.EnterpriseID = 3)[Предприятие В]

SELECT * FROM FinancialMetrics

--TASK7
SELECT I.IndicatorName, I.ImportanceLevel
	FROM Indicators AS I
	WHERE I.ImportanceLevel > ALL (SELECT I.ImportanceLevel
									FROM Indicators AS I
									WHERE I.IndicatorName LIKE '%о%')

SELECT * 
	FROM Indicators AS I
	WHERE I.IndicatorName LIKE '%о%'

--TASK8
SELECT I.IndicatorName, I.ImportanceLevel
	FROM Indicators AS I
	WHERE I.ImportanceLevel > ANY (SELECT I.ImportanceLevel
									FROM Indicators AS I
									WHERE I.IndicatorName LIKE '%о%')

SELECT * 
	FROM Indicators AS I
	WHERE I.IndicatorName LIKE '%о%'