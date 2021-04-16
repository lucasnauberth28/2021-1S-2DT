USE OPTUS;

INSERT INTO Usuario (nomeUsuario, email, senha, tipoPermissao)
VALUES ('Luana', 'luana@gmail.com', '123456', 'admin'),
	   ('Jos�', 'josegato@yahoo.com', '654321', 'comum');

INSERT INTO Artista (nomeArtista)
VALUES ('Katy Perry'), ('Anitta'),
	   ('Slipknot');

INSERT INTO Estilo (nomeEstilo)
VALUES ('Pop'), 
	   ('Funk'),
	   ('Rock');

INSERT INTO Album (tituloAlbum, dataLancamentoAlbum, localizacaoAlbum, qtdMntAlbum, albumAtivoOuNao, idEstilo, idArtista)
VALUES ('Smile', '28/08/2020', 'EUA', '36:00', 'Ativo', 1, 1),
	   ('Bang', '13/10/2015', 'Brasil', '42:00', 'Ativo', 2, 2),
	   ('Slipknot', '29/06/1999', 'California', '60:28', 'Ativo', 3, 3);

INSERT INTO AlbumEstilo 
VALUES (2, 2),
	   (2, 1);