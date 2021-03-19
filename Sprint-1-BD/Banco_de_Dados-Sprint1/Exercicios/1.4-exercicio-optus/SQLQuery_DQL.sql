USE OPTUS;

SELECT * FROM Usuario;
SELECT * FROM Artista;
SELECT * FROM Estilo;
SELECT * FROM Album;
SELECT * FROM AlbumEstilo;

SELECT Usuario.nomeUsuario, Usuario.tipoPermissao FROM Usuario;
SELECT Album.dataLancamentoAlbum, Album.tituloAlbum FROM Album WHERE Album.dataLancamentoAlbum > '2015';
SELECT Usuario.nomeUsuario, Usuario.senha FROM Usuario;

SELECT Album.albumAtivoOuNao, Artista.nomeArtista, Estilo.nomeEstilo FROM Album
INNER JOIN Artista
ON Album.idArtista = Artista.idArtista
INNER JOIN Estilo
ON Album.idEstilo = Estilo.idEstilo;