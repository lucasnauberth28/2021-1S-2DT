--DDL-

CREATE DATABASE Filmes;
go 

USE Filmes;
go

CREATE TABLE Generos
(
	idGenero int primary key identity
	,nomeGenero varchar (200) not null
);
go

CREATE TABLE Filmes 
(
	idFilme int primary key identity
	,idGenero int foreign key REFERENCES Generos(idGenero)
	,tituloFilme varchar (250) not null
);
go