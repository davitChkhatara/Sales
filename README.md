# Sales

--initial data  with products

insert into ProductTypes(TypeCode,Name)
values('BAN','Banana'),
('MAN','Mandarin'),
('PIN','Pineapple'),
('MAN','Mango');

insert into Products(Name,QtyOnHand,ProductTypeId,Price)
VALUES('Asian Banana',100,1,2.3),
('6 Pack Mango',123,4,1.7);


CREATE  TABLE VALUED FUNCTION AND  STORE  PROCEDURE  BEFORE  TESTING

SQL  Files  are in Infrastructure->SQL Files  Folder
1)CreateTableValuedFunction - get commission.sql  -  execute this  script
2)CreateStoredProcedure - calculate commission.sql  - execute this script

