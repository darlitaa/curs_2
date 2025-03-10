use L_MyBASE

SELECT E.Name, I.IndicatorName
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID;


use L_MyBASE

SELECT E.Name, I.IndicatorName
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE I.IndicatorName LIKE '%Прибыль%'; 


use L_MyBASE;

SELECT E.Name, I.IndicatorName, FM.Date, FM.Value,
    CASE
        WHEN (FM.Value < 50000) THEN 'Низкий'
        WHEN (FM.Value BETWEEN 50000 AND 100000) THEN 'Средний'
        WHEN (FM.Value > 100000) THEN 'Высокий'
    END AS [Классификация]
	FROM FinancialMetrics AS FM
	INNER JOIN Enterprises AS E ON FM.EnterpriseID = E.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE FM.Value BETWEEN 0 AND 200000 ORDER BY FM.Value DESC;


use L_MyBASE

SELECT E.Name, ISNULL(FM.Value, 0)
	FROM Enterprises AS E LEFT OUTER JOIN FinancialMetrics AS FM 
	ON E.EnterpriseID = FM.EnterpriseID;


use L_MyBASE

SELECT Enterprises.Name, Indicators.IndicatorName
	FROM Enterprises CROSS JOIN Indicators;