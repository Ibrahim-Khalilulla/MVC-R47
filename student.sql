
use cm_resto
go 
create table student
(
id int primary key,
name varchar(100),
class varchar(100),
fee money
)
insert into student values(1,'karim','six',200),(2,'rahim ','seven',100)