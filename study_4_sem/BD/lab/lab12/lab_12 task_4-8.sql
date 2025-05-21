--TASK 4
--работа неподтвержденное, неповторяющееся и фантомное чтение
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('ТПвИ','Технологии программирования в интернет','ИСиТ');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '30' WHERE AUDITORIUM_NAME='301-1';	
INSERT INTO AUDITORIUM VALUES('444-1', 'ЛБ-К', 60, '444-1');
-------------------------- t1 ------------------
-------------------------- t2 ------------------
rollback;



--TASK 5
--неподтвержденное чтения
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('ТПвИ','Технологии программирования в интернет','ИСиТ');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '15' WHERE AUDITORIUM_NAME='301-1';	
INSERT INTO AUDITORIUM VALUES('444-1', 'ЛБ-К', 60, '444-1');
-------------------------- t1 ------------------
-------------------------- t2 ------------------
commit;

DELETE SUBJECT WHERE SUBJECT = 'ТПвИ';
DELETE AUDITORIUM WHERE AUDITORIUM_NAME='444-1';

--работа фантомного и неповторяющегося чтения
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '70' WHERE AUDITORIUM_NAME='325-1';	
INSERT INTO AUDITORIUM VALUES('444-1', 'ЛБ-К', 60, '444-1');
-------------------------- t1 ------------------
-------------------------- t2 ------------------
commit;


--TASK 6

DELETE SUBJECT WHERE SUBJECT = 'ТПвИ';
--не работа неподтвежденного и неповторяющегося чтения
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('ТПвИ','Технологии программирования в интернет','ИСиТ');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '15' WHERE AUDITORIUM_NAME='301-1';	
rollback;


DELETE AUDITORIUM WHERE AUDITORIUM_NAME='444-1';
--работа фантомного чтения
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO AUDITORIUM VALUES('444-1', 'ЛБ-К', 60, '444-1');
commit;



--TASK 7

DELETE SUBJECT WHERE SUBJECT = 'ТПвИ';
--не работа неподтвежденного, неповторяющегося и фантомного чтения
BEGIN TRANSACTION 
SELECT @@SPID 'SID';
INSERT INTO SUBJECT VALUES('ТПвИ','Технологии программирования в интернет','ИСиТ');   
UPDATE AUDITORIUM SET AUDITORIUM_CAPACITY = '35' WHERE AUDITORIUM_NAME='301-1';	
rollback;
