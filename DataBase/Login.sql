Use master
go
if exists (select* from sysdatabases where name='Login')
        drop database Login
go
 
 Set DATEFORMAT dmy
 Go	
 Create database Login
 go
 Use Login
 go
 create table Usuario(
	CodUser int IDENTITY (1, 1) NOT NULL,
		Nome Varchar(50) NOT NULL,
	Senha Varchar(40) NOT NULL,
	Constraint pk_ primary key (CodUser)
)
go

Insert into Usuario (Nome, Senha) values
('John Doe', 'password123'),
('Jane Smith', 'securepass'),
('Bob Johnson', 'letmein'),
('Nicolas', '1004');

select * from Usuario

