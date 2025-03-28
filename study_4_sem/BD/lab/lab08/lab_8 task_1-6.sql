--TASK1
CREATE VIEW Преподаватель
AS SELECT T.TEACHER [код],
		  T.TEACHER_NAME [имя преподавателя],
		  T.GENDER [пол],
		  T.PULPIT [код кафедры]
	FROM TEACHER AS T;
go

SELECT * FROM Преподаватель
go

--TASK2
CREATE VIEW [Количество кафедр]
AS SELECT F.FACULTY_NAME [факультет],
		  COUNT(P.PULPIT) [количество кафедр]
	FROM FACULTY AS F INNER JOIN PULPIT AS P ON F.FACULTY = P.FACULTY
	GROUP BY F.FACULTY_NAME
go

SELECT * FROM [Количество кафедр]
go

--TASK3
CREATE VIEW Аудитории (код, [наименование аудитории])
AS SELECT A.AUDITORIUM, A.AUDITORIUM_TYPE
	FROM AUDITORIUM AS A
	WHERE A.AUDITORIUM_TYPE LIKE 'ЛК%' WITH CHECK OPTION
go

SELECT * FROM Аудитории

INSERT Аудитории VALUES('100-3a', 'ЛК')
DELETE Аудитории WHERE код = '100-3a'
UPDATE Аудитории SET [наименование аудитории] = 'ЛК-К' WHERE код =  '236-1'
go

--TASK5
CREATE VIEW Дисциплины (код, наименование_дисциплины, код_кафедры)
AS SELECT TOP 100 PERCENT S.SUBJECT, S.SUBJECT_NAME, S.PULPIT
	FROM SUBJECT AS S
	ORDER BY S.SUBJECT
go

SELECT * FROM Дисциплины
go

--TASK6
CREATE VIEW [Количество кафедр2] WITH SCHEMABINDING
AS SELECT F.FACULTY_NAME [факультет],
		  COUNT(P.PULPIT) [количество кафедр]
	FROM dbo.FACULTY AS F INNER JOIN dbo.PULPIT AS P ON F.FACULTY = P.FACULTY
	GROUP BY F.FACULTY_NAME
go

ALTER TABLE dbo.FACULTY DROP COLUMN FACULTY
