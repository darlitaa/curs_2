USE [Univer]
GO
/****** Object:  StoredProcedure [dbo].[PSUBJECT]    Script Date: 09.05.2025 12:46:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PSUBJECT] @p varchar(20), @c int output
AS
BEGIN
	declare @count int = (select COUNT(*) from SUBJECT);
	select * from SUBJECT where SUBJECT.PULPIT = @p;
	set @c = @@rowcount
	print 'параметры: @p = ' + @p + ' @c = ' + cast(@c as varchar(5));
	return @count;
END