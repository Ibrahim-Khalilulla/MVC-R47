select * from details where salesid='88'
select * from master where salesid='88'



sp_help

select * from details where salesid='AC-0004'
select * from master where salesid='AC-0004'
select * from students


create table items
(
itemcode varchar(100) primary key,
itemname varchar(100),
gname varchar(100),
cost money,
sell money
)




use cm_resto
go
create table FoodMenuTB(
id int primary key,
Food varchar(100),
Items varchar(100),
Price money
)


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



create table student2
( 
id int primary key,
name varchar(100),
class varchar(100),
fee money
)

insert into student2 values(1,'karim','six',1000),(2,'rahim','six',1000)

create table sales
(
salesid varchar(100),
slno int,
itemcode varchar(100),
itemname varchar(100),
price money,
date datetime,
primary key(salesid,slno)
)