--TASK 4
--������ ����������������, ��������������� � ��������� ������
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('����','���������� ���������������� � ��������','����');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '30' WHERE AUDITORIUM_NAME='301-1';	
INSERT INTO AUDITORIUM VALUES('444-1', '��-�', 60, '444-1');
-------------------------- t1 ------------------
-------------------------- t2 ------------------
rollback;



--TASK 5
--���������������� ������
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('����','���������� ���������������� � ��������','����');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '15' WHERE AUDITORIUM_NAME='301-1';	
INSERT INTO AUDITORIUM VALUES('444-1', '��-�', 60, '444-1');
-------------------------- t1 ------------------
-------------------------- t2 ------------------
commit;

DELETE SUBJECT WHERE SUBJECT = '����';
DELETE AUDITORIUM WHERE AUDITORIUM_NAME='444-1';

--������ ���������� � ���������������� ������
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '70' WHERE AUDITORIUM_NAME='325-1';	
INSERT INTO AUDITORIUM VALUES('444-1', '��-�', 60, '444-1');
-------------------------- t1 ------------------
-------------------------- t2 ------------------
commit;


--TASK 6

DELETE SUBJECT WHERE SUBJECT = '����';
--�� ������ ���������������� � ���������������� ������
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('����','���������� ���������������� � ��������','����');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '15' WHERE AUDITORIUM_NAME='301-1';	
rollback;


DELETE AUDITORIUM WHERE AUDITORIUM_NAME='444-1';
--������ ���������� ������
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO AUDITORIUM VALUES('444-1', '��-�', 60, '444-1');
commit;



--TASK 7

DELETE SUBJECT WHERE SUBJECT = '����';
--�� ������ ����������������, ���������������� � ���������� ������
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('����','���������� ���������������� � ��������','����');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '35' WHERE AUDITORIUM_NAME='301-1';	
rollback;
