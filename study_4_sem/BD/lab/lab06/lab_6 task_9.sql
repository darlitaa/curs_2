USE L_MyBASE;

--TASK1
SELECT I.IndicatorName,
		MAX(FM.Value) AS [MAX ��������],
		MIN(FM.Value) AS [MIN ��������],
		AVG(FM.Value) AS [AVG ��������],
		SUM(FM.Value) AS [SUM ��������],
		COUNT(*) AS [���������� �������]
	FROM Indicators AS I
	INNER JOIN FinancialMetrics AS FM ON I.IndicatorID = FM.IndicatorID
	GROUP BY I.IndicatorName;

--TASK3
SELECT * 
FROM (
    SELECT CASE
        WHEN (FM.Value < 50000) THEN '������'
        WHEN (FM.Value BETWEEN 50000 AND 150000) THEN '�������'
        WHEN (FM.Value > 150000) THEN '�������'
    END AS [��������],
    COUNT(*) AS [����������]
    FROM FinancialMetrics AS FM
    GROUP BY CASE
        WHEN (FM.Value < 50000) THEN '������'
        WHEN (FM.Value BETWEEN 50000 AND 150000) THEN '�������'
        WHEN (FM.Value > 150000) THEN '�������'
    END
) AS a
ORDER BY CASE a.[��������] 
    WHEN '������' THEN 1
    WHEN '�������' THEN 2
    WHEN '�������' THEN 3
END;

--TASK4
SELECT E.Name AS [�����������],
		ROUND(AVG(FM.Value), 2) AS [AVG ��������]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
		GROUP BY E.Name
		ORDER BY [AVG ��������] DESC;

--TASK5
SELECT E.Name AS [�����������],
		ROUND(AVG(FM.Value), 2) AS [AVG ��������]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	WHERE FM.IndicatorID IN (1, 3)  
		GROUP BY E.Name
		ORDER BY [AVG ��������] DESC;

--TASK6
SELECT E.Name AS [�����������], I.IndicatorName AS [���������],
		AVG(FM.Value) AS [AVG ��������]
	FROM Enterprises AS E
	INNER JOIN FinancialMetrics AS FM ON E.EnterpriseID = FM.EnterpriseID
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
		WHERE E.Name LIKE '����������� A' 
		GROUP BY E.Name, I.IndicatorName;

--TASK7
SELECT I.IndicatorName, COUNT(*) AS [COUNT �����������]
	FROM FinancialMetrics AS FM
	INNER JOIN Indicators AS I ON FM.IndicatorID = I.IndicatorID
	WHERE FM.Value BETWEEN 100000 AND 300000
	GROUP BY I.IndicatorName;
