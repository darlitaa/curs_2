--TASK1
CREATE VIEW �������������
AS SELECT T.TEACHER [���],
		  T.TEACHER_NAME [��� �������������],
		  T.GENDER [���],
		  T.PULPIT [��� �������]
	FROM TEACHER AS T;
go

SELECT * FROM �������������
go

--TASK2
CREATE VIEW [���������� ������]
AS SELECT F.FACULTY_NAME [���������],
		  COUNT(P.PULPIT) [���������� ������]
	FROM FACULTY AS F INNER JOIN PULPIT AS P ON F.FACULTY = P.FACULTY
	GROUP BY F.FACULTY_NAME
go

SELECT * FROM [���������� ������]
go

--TASK3
CREATE VIEW ��������� (���, [������������ ���������])
AS SELECT A.AUDITORIUM, A.AUDITORIUM_TYPE
	FROM AUDITORIUM AS A
	WHERE A.AUDITORIUM_TYPE LIKE '��%' WITH CHECK OPTION
go

SELECT * FROM ���������

INSERT ��������� VALUES('100-3a', '��')
DELETE ��������� WHERE ��� = '100-3a'
UPDATE ��������� SET [������������ ���������] = '��-�' WHERE ��� =  '236-1'
go

--TASK5
CREATE VIEW ���������� (���, ������������_����������, ���_�������)
AS SELECT TOP 100 PERCENT S.SUBJECT, S.SUBJECT_NAME, S.PULPIT
	FROM SUBJECT AS S
	ORDER BY S.SUBJECT
go

SELECT * FROM ����������
go

--TASK6
CREATE VIEW [���������� ������2] WITH SCHEMABINDING
AS SELECT F.FACULTY_NAME [���������],
		  COUNT(P.PULPIT) [���������� ������]
	FROM dbo.FACULTY AS F INNER JOIN dbo.PULPIT AS P ON F.FACULTY = P.FACULTY
	GROUP BY F.FACULTY_NAME
go

ALTER TABLE dbo.FACULTY DROP COLUMN FACULTY
