CREATE DATABASE OPTUS;

USE OPTUS;

CREATE TABLE Artista
(
	idArtista INT PRIMARY KEY IDENTITY
	,nomeArtista VARCHAR (50) NOT NULL
);

CREATE TABLE Usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	,nomeUsuario VARCHAR (100) NOT NULL
	,email VARCHAR (100) NOT NULL
	,senha VARCHAR (50) NOT NULL
	,tipoPermissao VARCHAR(10) NOT NULL
);

CREATE TABLE Estilo
(
	idEstilo INT PRIMARY KEY IDENTITY
	,nomeEstilo VARCHAR (80) NOT NULL
);

CREATE TABLE Album
(
	idAlbum INT PRIMARY KEY IDENTITY
	,idEstilo INT FOREIGN KEY REFERENCES Estilo(idEstilo)
	,idArtista INT FOREIGN KEY REFERENCES Artista(idArtista)
	,tituloAlbum VARCHAR (50) not null
	,dataLancamentoAlbum DATE not null
	,localizacaoAlbum VARCHAR (150) not null
	,qtdMntAlbum VARCHAR(10) not null
	,albumAtivoOuNao VARCHAR (5) not null
);

CREATE TABLE AlbumEstilo
(
	idAlbumEstilo INT PRIMARY KEY IDENTITY
	,idAlbum INT FOREIGN KEY REFERENCES Album(idAlbum)
	,idEstilo INT FOREIGN KEY REFERENCES Estilo (idEstilo)
);