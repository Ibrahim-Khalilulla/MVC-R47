create table department
(
deptid varchar(10) primary key,
deptname varchar(100),
)
create table items
(
itemcode varchar(10) primary key,
itemname varchar(100),
deptid varchar(10) foreign key references department(deptid)
)
create table purchasedetails
(
vrno varchar(20),
slno int,
itemcode varchar(10) foreign key references items(itemcode),
qty int,
unitprice money,
totalprice as qty*unitprice, 
date datetime, 
primary key(vrno,slno)
)
create table party
(
PID varchar(10) primary key,
Name varchar(100),
address varchar(200)
)
create table purchasemaster
(
vrno varchar(20) primary key,
total money,
discount money,
net as total-discount,
paid money,
due as total-discount-paid,
PID varchar(10) foreign key references party(PID),
date datetime
)
create table salesdetails
(
vrno varchar(20),
slno int,
itemcode varchar(10) foreign key references items(itemcode),
qty int,
unitprice money,
totalprice as qty*unitprice, 
date datetime, 
primary key(vrno,slno)
)
create table salesmaster
(
vrno varchar(20) primary key,
total money,
discount money,
net as total-discount,
paid money,
due as total-discount-paid,
PID varchar(10) foreign key references party(PID),
date datetime
)
insert department values('D-01','Crockery')
,('D-02','Crockery'),('D-03','Crockery')
insert 
