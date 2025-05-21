--TASK 1
if exists (SELECT * from SYS.OBJECTS 
			where object_id = object_id(N'dbo.TEST_TABLE_1'))
drop table TEST_TABLE_1

DECLARE @num_1 int, @flag_1 char = 't';
SET IMPLICIT_TRANSACTIONS ON
CREATE table TEST_TABLE_1 (number int);
	INSERT TEST_TABLE_1 values (1),(2),(3),(4),(5);
	set @num_1 = (SELECT count(*) from TEST_TABLE_1);
	PRINT '���-�� ����� � �������: ' + cast(@num_1 as varchar(4))
	if @flag_1 = 't' commit
	else rollback
SET IMPLICIT_TRANSACTIONS OFF

if exists (SELECT * from SYS.OBJECTS 
			where object_id = object_id(N'dbo.TEST_TABLE_1'))
PRINT 'TEST_TABLE_1 ����������'
else PRINT 'TEST_TABLE_1 �� ����������'



--TASK 2
SELECT * from AUDITORIUM

begin try
	begin tran
		delete AUDITORIUM where AUDITORIUM_CAPACITY = 60;
		insert AUDITORIUM values ('333-1', '��', 60, '333-1')
		insert AUDITORIUM values (null, '��-�', 15, '327-1')
	commit tran
end try
begin catch
	PRINT '������ ' + cast(error_number() as varchar(10)) + ' '+ error_message()
	if @@TRANCOUNT > 0 rollback tran;
end catch;



--TASK 3
delete AUDITORIUM where AUDITORIUM = '326-1';
insert AUDITORIUM values ('329-1', '��-�', 45, '329-1')

SELECT * from AUDITORIUM

DECLARE @point varchar(10);
begin try
	begin tran
		delete AUDITORIUM where AUDITORIUM_CAPACITY = 45;
		set @point = 'p1'; save tran @point;
		insert AUDITORIUM values ('326-1', '��', 60, '326-1')
		set @point = 'p2'; save tran @point;
		insert AUDITORIUM values (null, '��-�', 15, '327-1')
	commit tran
end try
begin catch
	PRINT '������ ' + cast(error_number() as varchar(10)) + ' '+ error_message()
	if @@TRANCOUNT > 0 
	begin
		PRINT '����������� �����: ' + @point
		rollback tran @point;
		commit tran;
	end
end catch;



--TASK 4
----A----
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
-------------------------- t1 ------------------
SELECT @@SPID 'SID', 'insert SUBJECT' '���������', * FROM SUBJECT 
	            WHERE SUBJECT = '����';							
SELECT @@SPID 'SID', 'update AUDITORIUM'  '���������', * FROM AUDITORIUM   
				WHERE  AUDITORIUM_NAME='301-1';
SELECT @@SPID 'SID', 'SELECT AUDITORIUM' '���������', * FROM AUDITORIUM   
				WHERE  AUDITORIUM_CAPACITY=60;
commit;
-------------------------- t2 -----------------



--TASK 5
--���������������� ������
----A----
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
-------------------------- t1 ------------------
SELECT @@SPID 'SID', 'insert SUBJECT' '���������', * FROM SUBJECT 
				WHERE SUBJECT = '����';												
SELECT @@SPID 'SID', 'update AUDITORIUM'  '���������', * FROM AUDITORIUM
				WHERE  AUDITORIUM_NAME='301-1';
SELECT @@SPID 'SID', 'SELECT AUDITORIUM' '���������', * FROM AUDITORIUM 
				WHERE  AUDITORIUM_CAPACITY=60;
commit;
-------------------------- t2 -----------------

--������ ���������� � ���������������� ������
----A----
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
SELECT @@SPID 'SID', 'update AUDITORIUM'  '���������', * FROM AUDITORIUM   
				WHERE  AUDITORIUM_NAME='325-1';
SELECT @@SPID 'SID', 'SELECT AUDITORIUM' '���������', * FROM AUDITORIUM		
				WHERE  AUDITORIUM_CAPACITY=60;
-------------------------- t1 -----------------
commit;
-------------------------- t2 -----------------



--TASK 6

--�� ������ ����������������� � ���������������� ������
----A----
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRANSACTION
-------------------------- t1 ------------------
SELECT @@SPID 'SID', 'insert SUBJECT' '���������', * FROM SUBJECT 
	            WHERE SUBJECT = '����';											
SELECT @@SPID 'SID', 'update AUDITORIUM'  '���������',  * FROM AUDITORIUM   
				WHERE  AUDITORIUM_NAME='301-1';
commit;


--������ ���������� ������
----A----
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRANSACTION
-------------------------- t1 ------------------
SELECT @@SPID 'SID', 'SELECT AUDITORIUM' '���������', * FROM AUDITORIUM   
				WHERE  AUDITORIUM_CAPACITY=60;
commit;




--TASK 7
--�� ������ ����������������, ���������������� � ���������� ������
----A----
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
-------------------------- t1 ------------------
SELECT @@SPID 'SID', 'insert AUDITORIUM' '���������', * FROM SUBJECT 
				WHERE SUBJECT = '����';			
SELECT @@SPID 'SID', 'update AUDITORIUM'  '���������',  * FROM AUDITORIUM   
				WHERE  AUDITORIUM_NAME='301-1';
SELECT @@SPID 'SID', 'SELECT AUDITORIUM' '���������', * FROM AUDITORIUM 
				WHERE  AUDITORIUM_CAPACITY=60;
commit;



--TASK 8
delete SUBJECT where SUBJECT = '����';

begin tran
		INSERT into SUBJECT values('����','���������� ���������������� � ��������','����');   ;
		begin tran
		update SUBJECT set SUBJECT_NAME='����' where SUBJECT='����';
		commit  
		if @@TRANCOUNT > 0 rollback;
SELECT count(*) 'amount' from SUBJECT where SUBJECT='����'