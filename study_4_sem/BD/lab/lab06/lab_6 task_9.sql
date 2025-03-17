USE L_MyBASE;

--TASK1
SELECT I.IndicatorName,
		MAX(FM.Value) AS [MAX значение],
		MIN(FM.Value) AS [MIN значение],
		AVG(FM.Value) AS [AVG значение],
		SUM(FM.Value) AS [SUM значение],
		COUNT(*) AS [количество записей]
	FROM Indicators AS I
	INNER JOIN FinancialMetrics AS FM ON I.IndicatorID = FM.IndicatorID
	GROUP BY I.IndicatorName;

--TASK3
SELECT * 
FROM (
    SELECT CASE
        WHEN (FM.Value < 50000) THEN 'Низкие'
        WHEN (FM.Value BETWEEN 50000 AND 150000) THEN 'Средние'
        WHEN (FM.Value > 150000) THEN 'Высокие'
    END AS [интервал],
    COUNT(*) AS [количество]
    FROM FinancialMetrics AS FM
    GROUP BY CASE
        WHEN (FM.Value < 50000) THEN 'Низкие'
        WHEN (FM.Value BETWEEN 50000 AND 150000) THEN 'Средние'
        WHEN (FM.Value > 150000) THEN 'Высокие'
    END
) AS a
ORDER BY CASE a.[интервал] 
    WHEN 'Низкие' THEN 1
    WHEN 'Средние' THEN 2
    WHEN 'Высокие' THEN 3
END;

--TASK4
SELECT E.Name AS [Предприятие],
		ROUND(AVG(FM.Value), 2) AS [AVG значение]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
		GROUP BY E.Name
		ORDER BY [AVG значение] DESC;

--TASK5
SELECT E.Name AS [Предприятие],
		ROUND(AVG(FM.Value), 2) AS [AVG значение]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	WHERE FM.IndicatorID IN (1, 3)  
		GROUP BY E.Name
		ORDER BY [AVG значение] DESC;

--TASK6
SELECT E.Name AS [Предприятие], I.IndicatorName AS [Индикатор],
		AVG(FM.Value) AS [AVG значение]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
		WHERE E.Name LIKE 'Предприятие A' 
		GROUP BY E.Name, I.IndicatorName;

--TASK7
SELECT I.IndicatorName, COUNT(*) AS [COUNT Предприятия]
	FROM FinancialMetrics AS FM
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE FM.Value BETWEEN 100000 AND 300000
	GROUP BY I.IndicatorName;
