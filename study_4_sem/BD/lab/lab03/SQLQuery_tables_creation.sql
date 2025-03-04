use L_MyBASE

create table ����������
(��������_���������� nvarchar(20) primary key,
��������_���������� real not null
);

create table �����������
(�������� nvarchar(20) primary key,
����������_��������� nvarchar(50) not null,
������� nvarchar(15) not null,
����������_���� nvarchar(50) not null
);

create table ������
(�����_������ int primary key,
����_������ datetime not null,
����������� nvarchar(20) foreign key references ����������� (��������),
���������� nvarchar(20) foreign key references ���������� (��������_����������)
);

alter table ������ add SomeColumn date;

alter table ������ drop column SomeColumn;

insert into ���������� (��������_����������, ��������_����������)
values ('�������', 1),
	   ('�������������', 0.8);

insert into ����������� (��������, ����������_���������, �������, ����������_����)
values ('����������� 1', 'IBAN:234234049823049', '80294857385', '���������� ����1, HR'),
	   ('����������� 2', 'IBAN:324728940938523', '80295285792', '���������� ����2, HR');

insert into ������ (�����_������, ����_������, �����������, ����������)
values (1, '2024-02-21 10:30:00', '����������� 1', '�������'),
	   (2, '2024-02-21 21:30:00', '����������� 2', '�������������');


select * from ������;
select �����������, ���������� from ������;
select count(*) from ������;

update ������ set ����_������ = '2024-02-22 15:20:00' where �����_������=2;