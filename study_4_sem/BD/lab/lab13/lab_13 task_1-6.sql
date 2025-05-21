--TASK1
DROP PROCEDURE PSUBJECT

go
CREATE PROCEDURE PSUBJECT
AS
BEGIN
	declare @count int = (select COUNT(*) from SUBJECT);
	select * from SUBJECT;
	return @count;
END

go
declare @count int = 0;
EXEC @count = PSUBJECT;
print 'кол-во предметов = ' + cast(@count as varchar(5));


--TASK2
go
declare @count int = 0, @p varchar(20), @r int = 0;
EXEC @count = PSUBJECT @p = 'ИСиТ', @c = @r output;
print 'кол-во предметов всего = ' + cast(@count as varchar(5));


--TASK3
go
ALTER PROCEDURE PSUBJECT @p varchar(20)
AS
BEGIN
	select * from SUBJECT where SUBJECT.PULPIT = @p;
	print 'параметр: @p = ' + @p;
END

CREATE table #SUBJECT
				(SUBJECT char(10) primary key,
				SUBJECT_NAME nvarchar(100) not null, 
				PULPIT char(20));
insert #SUBJECT exec PSUBJECT @p = 'ИСиТ'
select * from #SUBJECT


--TASK4
DROP PROCEDURE PAUDITORIUM_INSERT

select * from AUDITORIUM
delete AUDITORIUM where AUDITORIUM = '555-1'

go
CREATE PROCEDURE PAUDITORIUM_INSERT 
	@a char(20), @n varchar(50), @c int = 0, @t char(10)
AS
BEGIN
	BEGIN TRY
		insert into AUDITORIUM VALUES (@a, @t, @c, @n)
		RETURN 1;
	END TRY
	BEGIN CATCH
		print 'Номер ошибка:  ' + cast(ERROR_NUMBER() as varchar(20))
		print 'Уровень: ' + cast(ERROR_SEVERITY() as varchar(20))
		print 'Сообщение:   ' + ERROR_MESSAGE()
		RETURN -1;
	END CATCH
END

go
declare @return int
exec @return = PAUDITORIUM_INSERT @a = '555-1', @t = 'ЛК', @c = 30, @n = '555-1'
--exec @return = PAUDITORIUM_INSERT @a = '555-1', @t = 'TT', @c = 30, @n = '555-1'
print 'Процедура завершилась с кодом ' + cast(@return as varchar)


--TASK5
DROP PROCEDURE SUBJECT_REPORT

go
CREATE PROCEDURE SUBJECT_REPORT @p varchar(20)
AS
BEGIN
	BEGIN TRY
		DECLARE @n int = 0, @sub varchar(20) = '', @result varchar(200) = '';
		DECLARE subCur CURSOR local static for 
					  (select S.SUBJECT from SUBJECT as S where S.PULPIT = @p);
		if not exists (select S.SUBJECT from SUBJECT as S where S.PULPIT = @p)
				raiserror('ошибка! ', 11 , 1);
		else
				open subCur;
				fetch subCur into @sub;
				print 'Дисциплины кафедры ' + @p
				while @@FETCH_STATUS = 0
				begin
					set @result += rtrim(@sub) + ','
					set @n = @n + 1
					fetch subCur into @sub
				end;
				print @result
				close subCur
		return @n 
	END TRY
	BEGIN CATCH
		print 'Ошибка в параметрах!'
		print 'Сообщение: ' + cast(ERROR_MESSAGE() as varchar(300))
	END CATCH;
END

go
declare @n int = 0
exec @n = SUBJECT_REPORT @p = 'ИСиТ';
--exec @n = SUBJECT_REPORT @p = 'ИСииииТ';
print 'кол-во дисциплин = ' + cast(@n as varchar)


--TASK6
DROP PROCEDURE PAUDITORIUM_INSERTX
delete AUDITORIUM where AUDITORIUM = '555-1'
delete AUDITORIUM_TYPE where AUDITORIUM_TYPE = 'НТ'

select * from AUDITORIUM
select * from AUDITORIUM_TYPE

go
CREATE PROCEDURE PAUDITORIUM_INSERTX
	@a char(20), @n varchar(50), @c int = 0, @t char(10), @tn varchar(50)
AS
BEGIN
	BEGIN TRY
		set transaction isolation level SERIALIZABLE;
		BEGIN TRAN
			insert into AUDITORIUM_TYPE VALUES (@t, @tn)
			EXEC PAUDITORIUM_INSERT @a, @n, @c, @t;
		COMMIT TRAN
		RETURN 1;
	END TRY
	BEGIN CATCH
		print 'Номер ошибка:  ' + cast(ERROR_NUMBER() as varchar(20))
		print 'Уровень: ' + cast(ERROR_SEVERITY() as varchar(20))
		print 'Сообщение:   ' + ERROR_MESSAGE()
		if ERROR_PROCEDURE() is not null
			PRINT 'имя процедуры: ' + error_procedure();
		RETURN -1;
	END CATCH
END

go
declare @return int
exec @return = PAUDITORIUM_INSERTX @a = '555-1', @t = 'НТ', @c = 30, @n = '555-1', @tn = 'Новый тип';
print 'Процедура завершилась с кодом ' + cast(@return as varchar)