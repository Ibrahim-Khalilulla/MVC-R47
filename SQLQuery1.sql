use cm_resto
drop table if exists details
create table details
(
salesid varchar(100) ,
slno int,
itemcode varchar(100),
itemname varchar(100), 
qty int,
unitprice money,
totalprice money,
primary key(salesid,slno)
)
drop table if exists master
create table master
(
salesid varchar(100),
date datetime,
party varchar(100),
total money,
discount money,
gross money,
paid money,
due money,
primary key(salesid)
)

select * from details

create table student5
(
ID int primary key,
Name varchar(100),
Class varchar(100)
)
create table Guradian5
(
GuardianID  int primary key,
FatherName varchar(100),
MotherName varchar(100),
StudentsId int foreign key references student5(ID)
)
select * from student5
select * from guradian5
delete from student5
delete from guradian5

create table dept2
(
deptid int primary key,
deptname varchar(100),
location varchar(100)
)
create table items2
(
itemcode int primary key,
itemname varchar(100),
deptid int foreign key references dept2(deptid),
cost money,
rate money
)
select * from dept2
select * from items2
delete from dept2
delete from items2
