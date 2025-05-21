select * from FACULTY
select * from GROUPS
select * from STUDENT
select * from PROFESSION
select * from SUBJECT
select * from PULPIT
select * from TEACHER


--TASK 1-1
go
create function COUNT_STUDENTS (@faculty varchar(20)) returns int
as begin 
	declare @count int = 0;
	set @count = (select count(*) from STUDENT as s 
		join GROUPS as g on s.IDGROUP=g.IDGROUP
		join FACULTY as f on g.FACULTY=f.FACULTY
		where f.FACULTY = @faculty)
	return @count;
end;


go
declare @f int = dbo.COUNT_STUDENTS('ХТиТ');
print 'кол-во студентов ' + cast(@f as varchar(5));

select g.FACULTY, dbo.COUNT_STUDENTS(g.FACULTY) [кол-во студентов] 
	from GROUPS g group by g.FACULTY


--TASK 1-2
go
create function COUNT_STUDENTS2 (@faculty varchar(20)) returns int
as begin 
	declare @count int = 0;
	set @count = (select count(*) from STUDENT as s 
		join GROUPS as g on s.IDGROUP=g.IDGROUP
		join FACULTY as f on g.FACULTY=f.FACULTY
		where f.FACULTY = @faculty)
	return @count;
end;


go
alter function COUNT_STUDENTS2 (@faculty varchar(20) = null, @proffesion varchar(20) = null) returns int
as begin 
	declare @count int = 0;
	set @count = (select count(*) from STUDENT as s 
		join GROUPS as g on s.IDGROUP=g.IDGROUP
		join FACULTY as f on g.FACULTY=f.FACULTY
		where g.FACULTY = @faculty and g.PROFESSION = @proffesion)
	return @count;
end;


go
declare @f int = dbo.COUNT_STUDENTS2 ('ТОВ', '1-48 01 02');
print 'кол-во студентов ' + cast(@f as varchar(5));


--TASK 2
go
create function FSUBJECTS (@pulpit varchar(20)) returns varchar(300) 
as begin
	declare @sub varchar(60);
	declare @result varchar(300) = '';
	declare SubCurs CURSOR LOCAL
		for select s.SUBJECT 
		from SUBJECT as s
		where s.PULPIT = @pulpit;
	open SubCurs;
	fetch SubCurs into @sub;
	while @@FETCH_STATUS = 0
	begin
		set @result += rtrim(@sub) + ',';
		fetch SubCurs into @sub;
	end;
	return @result;
	end;


go
select p.PULPIT as кафедра, dbo.FSUBJECTS (p.PULPIT) as дисциплины
	from PULPIT as p


--TASK 3
go
create function FFACPUL (@f varchar(50), @p varchar(50)) returns table
as return
	select f.FACULTY, p.PULPIT
		from FACULTY as f left outer join PULPIT as p
		on f.FACULTY=p.FACULTY
		where f.FACULTY = isnull(@f, f.FACULTY) and p.PULPIT = isnull(@p, p.PULPIT);


go
select * from dbo.FFACPUL(NULL,NULL);
select * from dbo.FFACPUL('ТТЛП',NULL);
select * from dbo.FFACPUL(NULL,'ИСиТ');
select * from dbo.FFACPUL('ЛХФ','ЛВ');
select * from dbo.FFACPUL('ЛХ','ПИ');


--TASK4
go
create function FCTEACHER (@pulpit as varchar(20)) returns int
as begin
	declare @count_t int = 0;
	set @count_t = (select count(*) from TEACHER as t
			inner join PULPIT as p on t.PULPIT=p.PULPIT
			where p.PULPIT = isnull(@pulpit, p.PULPIT))
	return @count_t
end;


go
select P.PULPIT, dbo.FCTEACHER(p.PULPIT) as [кол-во преподователей] from PULPIT as p
select dbo.FCTEACHER(null) as [всего преподователей]


--TASK 6
go
create function COUNT_PULPITS (@FACULTY varchar(20)) returns int
as begin
	declare @COUNT int = (select count(PULPIT) from PULPIT where FACULTY = isnull(@FACULTY, FACULTY))
	return @COUNT
end


go
create function COUNT_GROUPS (@FACULTY varchar(20)) returns int
as begin
	declare @COUNT int = (select count(IDGROUP) from GROUPS where FACULTY = isnull(@FACULTY, FACULTY))
	return @COUNT
end


go
create function COUNT_PROFESSIONS (@FACULTY varchar(20)) returns int
as begin
	declare @COUNT int =  (select count(PROFESSION) from PROFESSION where FACULTY = isnull(@FACULTY, FACULTY))
	return @COUNT
end

----------------
go
create function FACULTY_REPORT(@c int) returns @fr table
	([Факультет] varchar(50), [Кол-во кафедр] int, [Кол-во групп] int, [Кол-во студентов] int, [Кол-во специальностей] int)
as begin 
	declare @f varchar(30);
	declare cc CURSOR static for 
		select FACULTY from FACULTY 
			where  dbo.COUNT_STUDENTS (FACULTY) > @c; 
	open cc;  
		fetch cc into @f;
	    while @@fetch_status = 0
			begin
	            insert @fr values(
				@f,  
				dbo.COUNT_PULPITS(@f),
	            dbo.COUNT_GROUPS(@f),   
				dbo.COUNT_STUDENTS(@f),
	            dbo.COUNT_PROFESSIONS(@f)); 
	            fetch cc into @f;  
	        end;   
	return; 
end;


go
select * from dbo.FACULTY_REPORT(0)