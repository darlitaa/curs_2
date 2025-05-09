--TASK1
DECLARE @charVar CHAR(10) = 'Hello',
		@varcharVar VARCHAR(20) = 'World',
		@datetimeVar DATETIME,
		@timeVar TIME,
		@intVar INT,
		@smallIntVar SMALLINT,
		@tinyIntVar TINYINT,
		@numericVar NUMERIC(12, 5);

SET @datetimeVar = GETDATE();
SET @timeVar = GETDATE();
SET @intVar = 52;
SET @smallIntVar = 25;
SET @tinyIntVar = 5;
SET @numericVar = 1234.12345;

SELECT @charVar charVar,
		@varcharVar varcharVar,
		@datetimeVar datetimeVar,
		@timeVar timeVar,
		@intVar intVar,
		@smallIntVar smallIntVar,
		@tinyIntVar tinyIntVar,
		@numericVar numericVar;

PRINT '@charVar: ' + @charVar;
PRINT '@varcharVar: ' + @varcharVar;
PRINT '@datetimeVar: ' + CONVERT(VARCHAR, @datetimeVar, 120);
PRINT '@timeVar: ' + CONVERT(VARCHAR, @timeVar, 108);
PRINT '@intVar: ' + CAST(@intVar AS VARCHAR);
PRINT '@smallIntVar: ' + CAST(@smallIntVar AS VARCHAR);
PRINT '@@tinyIntVar: ' + CAST(@tinyIntVar AS VARCHAR);
PRINT '@numericVar: ' + CAST(@numericVar AS VARCHAR);


--TASK2
DECLARE @commonCaracity INT = (SELECT SUM(AUDITORIUM_CAPACITY) FROM AUDITORIUM), 
		@auditoriumAmount INT, 
		@averageCapacity REAL,
		@lessAverageAuditoriumCapacity REAL
IF @commonCaracity > 200
BEGIN 
	SELECT @auditoriumAmount = (SELECT COUNT(*) FROM AUDITORIUM),
		@averageCapacity = (SELECT AVG(AUDITORIUM_CAPACITY) FROM AUDITORIUM)
	SET @lessAverageAuditoriumCapacity = (SELECT COUNT(*) FROM AUDITORIUM
				WHERE AUDITORIUM_CAPACITY < @averageCapacity );
	SELECT @auditoriumAmount 'êîëè÷åñòâî àóäèòîðèé',
		@averageCapacity 'ñðåäíÿÿ âìåñòèìîñòü', 
		@lessAverageAuditoriumCapacity 'ìåíüøå ñðåäíåé ', 
		@lessAverageAuditoriumCapacity /@auditoriumAmount*100 '% ìåíüøå ñðåäíåé'
END 
ELSE
	PRINT 'Îáùàÿ âìåñòèìîñòü àóäèòîðèè: ' + @commonCaracity;


--TASK3
PRINT @@ROWCOUNT;
PRINT @@VERSION;
PRINT @@SPID;
PRINT @@ERROR;
PRINT @@SERVERNAME;
PRINT @@TRANCOUNT;
PRINT @@FETCH_STATUS;
PRINT @@NESTLEVEL;


--TASK4

--1
DECLARE @z REAL, @t REAL = 6, @x REAL = 5;
IF (@t > @x)
	SET @z = POWER(SIN(@t), 2);
ELSE IF (@t < @x)
	SET @z = 4.0 * (@t + @x)
ELSE IF (@t = @x)
	SET @z = 1 - POWER(EXP(1), @x - 2)
PRINT 'z = ' + CAST(@z AS VARCHAR);


--2
DECLARE @fullName NVARCHAR(100) = 'Литвинчук Дарья Валерьевна',
        @shortName NVARCHAR(40),
        @firstSpace INT,
        @secondSpace INT;

SET @firstSpace = CHARINDEX(' ', @fullName);
SET @secondSpace = CHARINDEX(' ', @fullName, @firstSpace + 1);

SET @shortName = SUBSTRING(@fullName, 1, @firstSpace) + 
                 SUBSTRING(@fullName, @firstSpace + 1, 1) + '. ' +
                 SUBSTRING(@fullName, @secondSpace + 1, 1) + '. ';

PRINT 'Полное ФИО: ' + @fullName;
PRINT 'Сокращенное ФИО: ' + @shortName;


--3
DECLARE @NextMonth DATE = DATEADD(MONTH, 1, GETDATE())
SELECT S.NAME, S.BDAY, DATEDIFF(YEAR, S.BDAY, @NextMonth) AS YEARS
	FROM STUDENT AS S
	WHERE MONTH(s.BDAY) >= MONTH(@NextMonth) AND MONTH(s.BDAY) <= MONTH(@NextMonth);


--4
SELECT S.IDGROUP, P.SUBJECT, P.PDATE, DATENAME(WEEKDAY, P.PDATE) AS [WEEKDAY]
	FROM PROGRESS AS P INNER JOIN STUDENT AS S ON P.IDSTUDENT = S.IDSTUDENT
	GROUP BY S.IDGROUP, P.SUBJECT, P.PDATE
	HAVING P.SUBJECT = 'ÁÄ';


--TASK5
DECLARE @avarageNote REAL = (SELECT CAST(AVG(P.NOTE) AS REAL) FROM PROGRESS AS P)
IF @avarageNote >= 8
	PRINT 'ñòóäåíòû îòë÷èíî ó÷àòñÿ, èìåþò ñðåäíþþ îöåíêó ' + CAST(@avarageNote AS VARCHAR)
ELSE IF @avarageNote < 8 AND @avarageNote >= 6
	PRINT 'ñòóäåíòû õîðîøî ó÷àòñÿ, èìåþò ñðåäíþþ îöåíêó ' + CAST(@avarageNote AS VARCHAR)
ELSE 
	PRINT 'ñòóäåíòû ïëîõî ó÷àòñÿ, èìåþò ñðåäíþþ îöåíêó ' + CAST(@avarageNote AS VARCHAR)


--TASK6
SELECT G.FACULTY, COUNT(P.NOTE) AS AMOUNT_STUDENT,
	CASE 
		WHEN P.NOTE BETWEEN 0 AND 4 THEN 'ïëîõî'
		WHEN P.NOTE BETWEEN 5 AND 7 THEN 'íîðìàëüíî'
		WHEN P.NOTE BETWEEN 8 AND 10 THEN 'õîðîøî'
	END AS INFORMATION
		FROM PROGRESS AS P
		INNER JOIN STUDENT AS S ON P.IDSTUDENT = S.IDSTUDENT
		INNER JOIN GROUPS AS G ON S.IDGROUP = G.IDGROUP
	GROUP BY G.FACULTY,
		CASE 
			WHEN P.NOTE BETWEEN 0 AND 4 THEN 'ïëîõî'
			WHEN P.NOTE BETWEEN 5 AND 7 THEN 'íîðìàëüíî'
			WHEN P.NOTE BETWEEN 8 AND 10 THEN 'õîðîøî'
		END
	HAVING G.FACULTY = 'ÕÒèÒ'


--TASK7
CREATE TABLE #CAT (ID_CAT INT, CAT_NAME VARCHAR(10),  MONTHS INT);

DECLARE @a INT = 0;
WHILE @a < 10
	BEGIN
		INSERT #CAT 
			VALUES(@a, 'CAT_' + CAST(@a AS VARCHAR(10)), FLOOR(100*RAND())); 
		SET @a += 1;
	END;

SELECT * FROM #CAT;


--TASK8
DECLARE @b INT = 0
WHILE @b < 10
	BEGIN
		PRINT 'MEOW' + CAST(@b AS VARCHAR(10))
		SET @b += 1
		IF @b = 5
			RETURN 
	END;


--TASK9
DECLARE @num INT
BEGIN TRY
	SET @num = 13 / 0;
END TRY
BEGIN CATCH
	PRINT ERROR_NUMBER();
	PRINT ERROR_MESSAGE();
	PRINT ERROR_LINE();
	PRINT ERROR_PROCEDURE();
	PRINT ERROR_SEVERITY();
	PRINT ERROR_STATE();
END CATCH
