--для подсчета оценок
GO
CREATE FUNCTION COUNT_ESTIMATIONS(@enterpriseName VARCHAR(100), @indicatorName VARCHAR(100)) RETURNS INT
AS BEGIN
    DECLARE @rc INT = 0;
    SET @rc = (SELECT COUNT(*) FROM FinancialMetrics fm
               JOIN Enterprises e ON fm.EnterpriseID = e.EnterpriseID
               JOIN Indicators i ON fm.IndicatorID = i.IndicatorID
               WHERE e.Name = @enterpriseName AND i.IndicatorName = @indicatorName);
    RETURN @rc;
END;

GO
DECLARE @f INT = dbo.COUNT_ESTIMATIONS('Предприятие А', 'Прибыль');
PRINT 'Number of estimations: ' + CAST(@f AS VARCHAR(4));


--для поиска индикаторов
GO
CREATE FUNCTION FIND_INDICATORS(@enterpriseName VARCHAR(100)) RETURNS VARCHAR(300)
AS BEGIN
    DECLARE @indicatorRet VARCHAR(300) = '';
    SELECT @indicatorRet = STRING_AGG(i.IndicatorName, ', ')
    FROM FinancialMetrics fm
    JOIN Enterprises e ON fm.EnterpriseID = e.EnterpriseID
    JOIN Indicators i ON fm.IndicatorID = i.IndicatorID
    WHERE e.Name = @enterpriseName;

    RETURN 'Indicators: ' + ISNULL(@indicatorRet, 'None');
END;

GO
SELECT e.Name, dbo.FIND_INDICATORS(e.Name) AS [Indicators] FROM Enterprises e;


--для задачи 3
GO
CREATE FUNCTION TASK3(@enterpriseName VARCHAR(100), @importanceLevel INT) RETURNS TABLE
AS RETURN
SELECT i.IndicatorName, i.ImportanceLevel 
FROM FinancialMetrics fm 
JOIN Indicators i ON fm.IndicatorID = i.IndicatorID
JOIN Enterprises e ON fm.EnterpriseID = e.EnterpriseID
WHERE e.Name = ISNULL(@enterpriseName, e.Name)
AND i.ImportanceLevel = ISNULL(@importanceLevel, i.ImportanceLevel);

GO
SELECT * FROM dbo.TASK3(NULL, NULL);
SELECT * FROM dbo.TASK3('Предприятие А', NULL);
SELECT * FROM dbo.TASK3(NULL, 5);
SELECT * FROM dbo.TASK3('Предприятие А', 5);


--для подсчета оценок по предприятиям
GO
CREATE FUNCTION FESTIMATION(@enterpriseName VARCHAR(100)) RETURNS INT
AS BEGIN
    DECLARE @result INT = 0;
    SET @result = (SELECT COUNT(*) 
                   FROM Enterprises e 
                   JOIN FinancialMetrics fm ON e.EnterpriseID = fm.EnterpriseID
                   WHERE e.Name = ISNULL(@enterpriseName, e.Name));
    RETURN @result;
END;

GO
SELECT e.Name, dbo.FESTIMATION(e.Name) AS 'Number of estimations' FROM Enterprises e;
SELECT dbo.FESTIMATION('Предприятие А');