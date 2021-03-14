

USE HROADES

CREATE TABLE Classes
(

     idClasse INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(200) NOT NULL

)

CREATE TABLE Personagens
(
	idPersonagem INT PRIMARY KEY IDENTITY
	,idClasse INT FOREIGN KEY REFERENCES Classe (idClasse)
	,Nome VARCHAR(200) NOT NULL
	,CapacidadeMaximaDeVida VARCHAR(200) NOT NULL
	,CapacidadeMaximaDeMana VARCHAR(200) NOT NULL
	,DataAtualização DATETIME
	,DataCriacao DATETIME

)

CREATE TABLE TipoHabilidade
(
	idTipo INT PRIMARY KEY IDENTITY
	,Tipo VARCHAR(200) NOT NULL

)

CREATE TABLE Habilidade
(
	idHabilidade INT PRIMARY KEY IDENTITY
	,idTipo INT FOREIGN KEY REFERENCES TipoHabilidade (idTipo)
	,Habilidade VARCHAR(200) NOT NULL

)

CREATE TABLE ClasseHabilidade
(
	idClasse INT FOREIGN KEY REFERENCES Classe (idClasse)
	,idHabilidade INT FOREIGN KEY REFERENCES Habilidade (idHabilidade)
)

ALTER TABLE Personagem
DROP COLUMN DataAtualizacao

ALTER TABLE Personagem
ADD DataAtualizacao DATE

ALTER TABLE Personagem
DROP COLUMN DataCriacao

ALTER TABLE Personagem
ADD DataCriacao DATE