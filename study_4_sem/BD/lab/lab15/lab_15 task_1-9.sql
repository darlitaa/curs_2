drop table TR_AUDIT
drop trigger TR_TEACHER_INS
drop trigger TR_TEACHER_DEL
drop trigger TR_TEACHER_UPD
drop trigger TR_TEACHER
drop trigger TR_TEACHER_DEL1
drop trigger TR_TEACHER_DEL2
drop trigger TR_TEACHER_DEL3
drop trigger TEACH_TRAN
drop trigger FACULTY_INSTEAD_OF
drop trigger DDL_UNIVER ON DATABASE


select * from TEACHER
--TASK 1
go
create table TR_AUDIT
(
	ID int identity(1, 1),										-- номер
	STMT varchar(20) check (STMT in ('INS', 'DEL', 'UPD')),		-- DML название оператора
	TRNAME varchar(50),											-- имя триггера
	CC varchar(300)												-- комментарий
)

go
create trigger TR_TEACHER_INS on TEACHER after insert
as 
declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)
print 'Выполнена операция INSERT'
set @TEACHER = (select TEACHER from INSERTED)
set @TEACHER_NAME = (select TEACHER_NAME from INSERTED)
set @GENDER = (select GENDER from INSERTED)
set @PULPIT = (select PULPIT from INSERTED)
set @IN = ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
		  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT))
insert into TR_AUDIT (STMT, TRNAME, CC) values ('INS', 'TR_TEACHER_INS', @IN)
return;

go
insert into TEACHER values ('ИВНВ', 'Иванов Иван Иванович', 'м', 'ИСиТ')
select * from TR_AUDIT order by ID


--TASK 2
go
create trigger TR_TEACHER_DEL on TEACHER after delete
as 
declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)
print 'Выполнена операция DELETE'
set @TEACHER = (select TEACHER from DELETED)
set @TEACHER_NAME = (select TEACHER_NAME from DELETED)
set @GENDER = (select GENDER from DELETED)
set @PULPIT = (select PULPIT from DELETED)
set @IN = ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
		  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT))
insert into TR_AUDIT (STMT, TRNAME, CC) values ('DEL', 'TR_TEACHER_DEL', @IN)
return;

go
delete from TEACHER where TEACHER = 'ИВНВ'
select * from TR_AUDIT order by ID


--TASK 3
go
create trigger TR_TEACHER_UPD on TEACHER after update
as 
declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)
print 'Выполнена операция UPDATE'

set @TEACHER = (select TEACHER from DELETED)
set @TEACHER_NAME = (select TEACHER_NAME from DELETED)
set @GENDER = (select GENDER from DELETED)
set @PULPIT = (select PULPIT from DELETED)
set @IN = ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
		  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT)) + ' -> '

set @TEACHER = (select TEACHER from INSERTED)
set @TEACHER_NAME = (select TEACHER_NAME from INSERTED)
set @GENDER = (select GENDER from INSERTED)
set @PULPIT = (select PULPIT from INSERTED)
set @IN = @IN + ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
		  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT))
insert into TR_AUDIT (STMT, TRNAME, CC) values ('UPD', 'TR_TEACHER_UPD', @IN)
return;

go
update TEACHER set GENDER = 'м' where TEACHER='РЖК'
select * from TR_AUDIT;


--TASK 4
go
create trigger TR_TEACHER on TEACHER after insert, update, delete
as declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)

if (select count(*) from INSERTED) > 0 and (select count(*) from DELETED) > 0
begin
	print 'Выполнена операция UPDATE'
	set @TEACHER = (select TEACHER from DELETED)
	set @TEACHER_NAME = (select TEACHER_NAME from DELETED)
	set @GENDER = (select GENDER from DELETED)
	set @PULPIT = (select PULPIT from DELETED)
	set @IN = ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
			  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT)) + ' -> '

	set @TEACHER = (select TEACHER from INSERTED)
	set @TEACHER_NAME = (select TEACHER_NAME from INSERTED)
	set @GENDER = (select GENDER from INSERTED)
	set @PULPIT = (select PULPIT from INSERTED)
	set @IN = @IN + ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
			  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT))
	insert into TR_AUDIT (STMT, TRNAME, CC) values ('UPD', 'TR_TEACHER', @IN)
end

if (select count(*) from INSERTED) > 0 and (select count(*) from DELETED) = 0
begin
	print 'Выполнена операция INSERT'
	set @TEACHER = (select TEACHER from INSERTED)
	set @TEACHER_NAME = (select TEACHER_NAME from INSERTED)
	set @GENDER = (select GENDER from INSERTED)
	set @PULPIT = (select PULPIT from INSERTED)
	set @IN = ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
			  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT))
	insert into TR_AUDIT (STMT, TRNAME, CC) values ('INS', 'TR_TEACHER', @IN)
end

if (select count(*) from INSERTED) = 0 and (select count(*) from DELETED) > 0
begin
	print 'Выполнена операция DELETE'
	set @TEACHER = (select TEACHER from DELETED)
	set @TEACHER_NAME = (select TEACHER_NAME from DELETED)
	set @GENDER = (select GENDER from DELETED)
	set @PULPIT = (select PULPIT from DELETED)
	set @IN = ltrim(rtrim(@TEACHER)) + ' ' + ltrim(rtrim(@TEACHER_NAME)) + 
			  ' ' + ltrim(rtrim(@GENDER)) + ' ' + ltrim(rtrim(@PULPIT))
	insert into TR_AUDIT (STMT, TRNAME, CC) values ('DEL', 'TR_TEACHER', @IN)
end

go
update TEACHER set GENDER = 'м' where TEACHER='РЖК'
insert into TEACHER values ('ЛИДВ', 'Литвичнук Дарья Валерьевна', 'ж', 'ИСиТ')
delete from TEACHER where TEACHER = 'ЛИДВ'
select * from TR_AUDIT;


--TASK 5
go
insert into TEACHER values ('ЛИДВ', 'Литвичнук Дарья Валерьевна', 'н', 'ИСиТ')
select * from TR_AUDIT


--TASK 6
go
create trigger TR_TEACHER_DEL1 on TEACHER after delete
as declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)
print 'DELETE Trigger 1'
set @IN = 'Trigger Normal Priority'
insert into TR_AUDIT (STMT, TRNAME, CC) values ('DEL', 'TR_TEACHER_DEL1', @IN)

go
create trigger TR_TEACHER_DEL2 on TEACHER after delete
as declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)
print 'DELETE Trigger 2'
set @IN = 'Trigger Low Priority'
insert into TR_AUDIT (STMT, TRNAME, CC) values ('DEL', 'TR_TEACHER_DEL2', @IN)

go
create trigger TR_TEACHER_DEL3 on TEACHER after delete
as declare @TEACHER char(10), @TEACHER_NAME varchar(100),
		   @GENDER char(1), @PULPIT char(20), @IN varchar(300)
print 'DELETE Trigger 3'
set @IN = 'Trigger Highest Priority'
insert into TR_AUDIT (STMT, TRNAME, CC) values ('DEL', 'TR_TEACHER_DEL3', @IN)

go
select t.name, e.type_desc 
	from sys.triggers t join  sys.trigger_events e  
	on t.object_id = e.object_id  
	where OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE'

go
exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', @order = 'First', @stmttype = 'DELETE'
exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', @order = 'Last',  @stmttype = 'DELETE'

go
insert into TEACHER values ('ЛИДВ', 'Литвичнук Дарья Валерьевна', 'ж', 'ИСиТ')
delete from TEACHER where TEACHER = 'ЛИДВ'
select * from TR_AUDIT


--TASK 7
go
create trigger TEACH_TRAN 
	on TEACHER after insert, delete, update
as
declare @c int = (select COUNT(TEACHER) from TEACHER);
		if(@c > 10)
			begin
				raiserror('Учителей не может быть больше 10', 10, 1);
				rollback;
			end;
		return;


go
insert into TEACHER values ('ТЕСТ', 'ТЕСТ', 'ж', 'ИСиТ')
select * from TR_AUDIT


--TASK 8
go
create trigger FACULTY_INSTEAD_OF on FACULTY instead of delete
	as raiserror('Удаление запрещено', 10, 1)
return;

go
delete from FACULTY where FACULTY = 'ТОВ';

--TASK 9
go
CREATE TRIGGER DDL_UNIVER ON database for DDL_DATABASE_LEVEL_EVENTS
AS
	DECLARE @t0 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
	DECLARE @t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
	DECLARE @t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)');

	PRINT 'Тип события: ' + @t0;
	PRINT 'Имя объекта: ' + @t1;
	PRINT 'Тип объекта: ' + @t2;
	raiserror('Операции с базой данных UNIVER запрещены', 16, 1);
	rollback;
RETURN;

CREATE TABLE test_table(
	a int,
	b real
);