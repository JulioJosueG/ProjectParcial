
create database NewsProjectDB

use NewsProjectDB

create table State(
idState int primary key,
StateName varchar(20)
)

create table authors(
idAuthor int primary key,
Name varchar(20),
LastName varchar(20),
idCountry varchar(2) foreign key references Countries(code),
idState int foreign key references State(idState)
)

create table Countries(
code varchar(2) primary key,
countryName varchar(20),
idState int foreign key references State(idState)
)

create table Categories(
idCategory int primary key,
CategoryName varchar(20),
idState int foreign key references State(idState)
)

create table Sources(
idSource int primary key,
SourceName varchar(20),
idState int foreign key references State(idState)
)

create table Articles(
ArticleId int primary key,
idAuthor int foreign key references Authors(idAuthor),
Title varchar(20),
content varchar(max),
PublishedAt datetime,
imageAt varchar(max),
CountryCode varchar(2) foreign key references Countries(code),
CategoryId int foreign key references Categories(idCategory),
IdSource int foreign key references Sources(idSource),
idState int foreign key references State(idState)
)



insert into Countries
values('ae','UAE ', 1)
,('ar','Argentina', 1)
,('at','Austria', 1)
,('au','Australia', 1)
,('be','Belgica', 1)
,('bg','Bulgaria', 1)
,('br','Brazil', 1)
,('ca','Canada', 1)
,('ch','Suiza', 1)
,('cn','China', 1)
,('co','Colombia', 1)
,('cu','Cuba"', 1)
,('cz','Republica Checa', 1)
,('de','Alemania', 1)
,('eg','Egipto', 1)
,('fr','Francia', 1)
,('gb','Reino Unido', 1)
,('gr','Grecia', 1)
,('hk','Hong Kong', 1)
,('hu','Hungria', 1)
,('id','Indonecia', 1)
,('ie','Irlanda', 1)
,('il','Israel', 1)
,('in','India', 1)
,('it','Itali', 1)
,('jp','Japon', 1)
,('kr','Sur Korea', 1)
,('lt','Lituania', 1)
,('lv','Latvia', 1)
,('ma','Marruecos', 1)
,('mx','Mexico', 1)
,('my','Malasia', 1)
,('ng','Nigeria', 1)
,('nl','Holanda', 1)
,('no','Nueruega', 1)
,('nz','Nueva Zelanda', 1)
,('ph','Philipinas', 1)
,('pl','Polonia', 1)
,('pt','Portugal', 1)
,('ro','Rumania', 1)
,('rs','Serbia', 1)
,('ru','Rusia', 1)
,('sa','Arabia Saudita', 1)
,('se','Suecia', 1)
,('sg','Singapur', 1)
,('si','Slovenia', 1)
,('sk','Slovakia', 1)
,('th','Tailandia', 1)
,('tr','Turkia', 1)
,('tw','Taiwan', 1)
,('ua','Ukrania', 1)
,('us','Estados Unidos', 1)
,('ve','Venezuela', 1)
,('za','Sudafrica', 1)