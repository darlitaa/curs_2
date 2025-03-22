USE L_MyBASE;

--TASK1
SELECT I.IndicatorName,
		MAX(FM.Value) AS [MAX çíà÷åíèå],
		MIN(FM.Value) AS [MIN çíà÷åíèå],
		AVG(FM.Value) AS [AVG çíà÷åíèå],
		SUM(FM.Value) AS [SUM çíà÷åíèå],
		COUNT(*) AS [êîëè÷åñòâî çàïèñåé]
	FROM Indicators AS I
	INNER JOIN FinancialMetrics AS FM ON I.IndicatorID = FM.IndicatorID
	GROUP BY I.IndicatorName;

--TASK3
SELECT * 
FROM (
    SELECT CASE
        WHEN (FM.Value < 50000) THEN 'Íèçêèå'
        WHEN (FM.Value BETWEEN 50000 AND 150000) THEN 'Ñðåäíèå'
        WHEN (FM.Value > 150000) THEN 'Âûñîêèå'
    END AS [èíòåðâàë],
    COUNT(*) AS [êîëè÷åñòâî]
    FROM FinancialMetrics AS FM
    GROUP BY CASE
        WHEN (FM.Value < 50000) THEN 'Íèçêèå'
        WHEN (FM.Value BETWEEN 50000 AND 150000) THEN 'Ñðåäíèå'
        WHEN (FM.Value > 150000) THEN 'Âûñîêèå'
    END
) AS a
ORDER BY CASE a.[èíòåðâàë] 
    WHEN 'Íèçêèå' THEN 1
    WHEN 'Ñðåäíèå' THEN 2
    WHEN 'Âûñîêèå' THEN 3
END;

--TASK4
SELECT E.Name AS [Ïðåäïðèÿòèå],
		ROUND(AVG(FM.Value), 2) AS [AVG çíà÷åíèå]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
		GROUP BY E.Name
		ORDER BY [AVG çíà÷åíèå] DESC;

--TASK5
SELECT E.Name AS [Ïðåäïðèÿòèå],
		ROUND(AVG(FM.Value), 2) AS [AVG çíà÷åíèå]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	WHERE FM.IndicatorID IN (1, 3)  
		GROUP BY E.Name
		ORDER BY [AVG çíà÷åíèå] DESC;

--TASK6
SELECT E.Name AS [Ïðåäïðèÿòèå], I.IndicatorName AS [Èíäèêàòîð],
		AVG(FM.Value) AS [AVG çíà÷åíèå]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
		WHERE E.Name LIKE 'Ïðåäïðèÿòèå A' 
		GROUP BY E.Name, I.IndicatorName;

--TASK7
SELECT I.IndicatorName, COUNT(*) AS [COUNT Ïðåäïðèÿòèÿ]
	FROM FinancialMetrics AS FM
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE FM.Value BETWEEN 100000 AND 300000
	GROUP BY I.IndicatorName;
