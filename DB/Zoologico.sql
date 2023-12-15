User
Use master
go
if exists (select* from sysdatabases where name='Zoologico')
        drop database Zoologico
go
 
 Set DATEFORMAT dmy
 Go	
 Create database Zoologico
 go
 Use Zoologico
 go
 create table Alimentos(
	CodAlimento int IDENTITY (1, 1) NOT NULL,
	Alimento Varchar(20),
	Descricao varchar(40),
	Constraint pk_Die primary key (CodAlimento)
)
go
Create Table Animais(
	CodAnimal int IDENTITY (1, 1) NOT NULL,
	Animal varchar(20),
	Nome Varchar(20),
	PaisOrigem varchar(20),
	AnoNasc int,
	Genero Varchar(20),
	codalimento int,
	QuantGramas int,
	Constraint pk_CodAnimal primary key (CodAnimal),
	Constraint fk_CD foreign key (codalimento) references alimentos (codalimento)
)
go



Insert into Alimentos Values
('FrutasA','Maça, Melão e Abacaxi'),
('CarneA','Carne Bovina'),
('CarneB','Carne de pequenos animais'),
('Gramíneas','Grama e capim'),
('Legumes','Brocolis, Cenoura e Abobora'),
('Vegetais','Repolho, Chuchu, Batata e Batata doce'),
('FrutasB', 'Pessego, Laranja e Carambola'),
('Aves','Ração e Alpiste'),
('Frutos do mar','Peixes');

Insert into Animais Values
('Coral','Coralina','Brasil',2013,'Femêa',3,100),
('Macaco','Caco','Brasil',2010,'Macho',7,200),
('Gazela','Zela','Canada',2005,'Femêa',4,600),
('Tigre','Roger','Australia',2016,'Macho',2,400),
('Jabuti','Buti','Brasil',1930,'Macho',5,100),
('Jacaré','Caré','Brasil',2000,'Macho',2,300),
('Leopardo','Pardo','USA',2013,'Femêa',2,350),
('Lontra','Ontra','França',2014,'Femêa',9,200),
('Elefante','Fante','Finlandia',2016,'Macho',6,1500),
('Leão','King','Africa',2013,'Macho',2,500),
('Harpia','Pia','Canada',2017,'Femêa',8,100),
('Leão-Dourado','Golden','Brasil',2018,'Macho',7,200),
('Raposa','Dora','Australia',2017,'Femêa',3,300),
('Alpaca','Parkas','Australia',2015,'Macho',4,450),
('Zebra','Listrinha','Canada',2017,'Femêa',4,1200),
('Girafa','Rafa','USA',2016,'Macho',4,1300),
('Falcão','Hawnking','USA',2017,'Macho',8,180),
('Arara','Hanna','Brasil',2012,'Femêa',8,220),
('Hipopotamo','Glória','Africa',2014,'Femêa',1,2200);


select * from Alimentos
Select * from Animais
Select * from Animais as ani INNER JOIN Alimentos as Ali On ani.codalimento = Ali.codalimento 
