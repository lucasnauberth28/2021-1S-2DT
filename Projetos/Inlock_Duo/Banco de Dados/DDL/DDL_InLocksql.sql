USE inlock_games_tarde

CREATE TABLE estudios
(
	idEstudio		INT PRIMARY KEY IDENTITY
	,nomeEstudio	VARCHAR(250) NOT NULL
);
GO

CREATE TABLE jogos
(
	idJogo				INT PRIMARY KEY IDENTITY
	,nomeJogo			VARCHAR(250)
	,descricao			VARCHAR(250)
	,dataLancamento		        DATETIME 
	,valor				DECIMAL
	,idEstudio			INT FOREIGN KEY REFERENCES estudios(idEstudio)
);
GO

CREATE TABLE tiposUsuarios
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,titulo			VARCHAR(250)
);
GO

CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,email				VARCHAR(255) UNIQUE NOT NULL
	,senha				VARCHAR(255) NOT NULL
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
);
GO

ALTER TABLE jogos ALTER COLUMN valor DECIMAL (18,2)