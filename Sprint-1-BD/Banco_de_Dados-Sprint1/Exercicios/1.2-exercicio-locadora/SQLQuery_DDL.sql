CREATE DATABASE Locadora;

USE Locadora;

CREATE TABLE Empresas
(
	idEmpresa INT PRIMARY KEY IDENTITY
	,nomeEmpresa VARCHAR (100) NOT NULL
	,CNPJ CHAR(18) NOT NULL
	,funcionariosEmpresa VARCHAR (100) NOT NULL
	,enderecoEmpresa VARCHAR (150) NOT NULL
);

CREATE TABLE Marcas
(
	idMarca INT PRIMARY KEY IDENTITY
	,nomeMarca VARCHAR (50) NOT NULL
	,sloganMarca VARCHAR (100)
);

CREATE TABLE Modelos
(
	idModelo INT PRIMARY KEY IDENTITY
	,nomeModelo VARCHAR (50) NOT NULL
	,tipoModelo VARCHAR (100) NOT NULL
	,idMarca INT FOREIGN KEY REFERENCES Marcas(idMarca)
);

CREATE TABLE Veiculos
(
	 idVeiculo INT PRIMARY KEY IDENTITY
	,idEmpresa INT FOREIGN KEY REFERENCES Empresas(idEmpresa)
	,idModelo INT FOREIGN KEY REFERENCES Modelos(idModelo)
	,placaVeiculo VARCHAR (7) NOT NULL
	,corVeiculo VARCHAR (20) NOT NULL
);

CREATE TABLE Cliente(
	idCliente INT PRIMARY KEY IDENTITY
	,nomeCliente VARCHAR (100) NOT NULL
	,cnhCliente VARCHAR (10) NOT NULL
	,idadeCliente CHAR (2) NOT NULL
	,telefoneCliente VARCHAR (15) NOT NULL
);

CREATE TABLE Aluguel
(
	idAluguel INT PRIMARY KEY IDENTITY
	,idCliente INT FOREIGN KEY REFERENCES Cliente(idCliente)
	,idVeiculo INT FOREIGN KEY REFERENCES Veiculos(idVeiculo)
	,horaAluguel TIME NOT NULL
	,dataPegado DATE NOT NULL
	,dataDevolucao DATE NOT NULL
	,precoAluguel MONEY NOT NULL
);

 