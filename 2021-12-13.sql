use cm_resto
select * from details where salesid='70'
select * from master where salesid='20'
sp_help

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
