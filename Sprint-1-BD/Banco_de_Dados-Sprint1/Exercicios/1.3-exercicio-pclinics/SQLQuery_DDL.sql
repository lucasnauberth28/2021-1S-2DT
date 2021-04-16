CREATE DATABASE PCCLINICS;

USE PCCLINICS;

CREATE TABLE Clinica
(
	idClinica INT PRIMARY KEY IDENTITY
	,enderecoClinica VARCHAR (100) NOT NULL
	,nomeClinica VARCHAR (50) NOT NULL
	,telefoneClinica VARCHAR (15) NOT NULL
);

CREATE TABLE Dono
(
	idDono INT PRIMARY KEY IDENTITY
	,nomeDono VARCHAR (50) NOT NULL
	,idadeDono CHAR (2) NOT NULL
	,telefoneDono VARCHAR (15) NOT NULL
);

CREATE TABLE Veterinario
(
	idVeterinario INT PRIMARY KEY IDENTITY
	,idClinica INT FOREIGN KEY REFERENCES Clinica(idClinica)
	,nomeVeterinario VARCHAR (100) NOT NULL
	,crmVeterinario CHAR (7) NOT NULL
	,idadeVeterinario CHAR (2)
);

CREATE TABLE TipoPet
(
	idTipoPet INT PRIMARY KEY IDENTITY
	,tipoPet VARCHAR (100) NOT NULL
);

CREATE TABLE Raca 
(
	idRaca INT PRIMARY KEY IDENTITY
	,idTipoPet INT FOREIGN KEY REFERENCES TipoPet(idTipoPet)
	,nomeRaca VARCHAR(40) NOT NULL
);

CREATE TABLE Pet
(
	idPet INT PRIMARY KEY IDENTITY
	,idRaca INT FOREIGN KEY REFERENCES Raca(idRaca)
	,idDono INT FOREIGN KEY REFERENCES Dono (idDono)	
	,nomePet VARCHAR (20) NOT NULL
	,dataNascimento DATE NOT NULL
);

CREATE TABLE Atendimento
(
	idAtendimento INT PRIMARY KEY IDENTITY
	,idPet INT FOREIGN KEY REFERENCES Pet (idPet)
	,idVeterinario INT FOREIGN KEY REFERENCES Veterinario(idVeterinario)
	,horaAtendimento TIME NOT NULL
	,fichaCadastroPet VARCHAR (150) NOT NULL
	,dataAtendimento DATE NOT NULL
);
