USE inlock_games_tarde

--Listar todos os usu�rios;
SELECT * FROM usuarios

--Listar todos os est�dios;
SELECT * FROM estudios

--Listar todos os jogos;
SELECT * FROM jogos

--Listar todos os jogos e seus respectivos est�dios;
SELECT nomeJogo AS 'Jogo', valor AS 'Pre�o em R$', nomeEstudio AS 'Est�dio' FROM jogos
INNER JOIN estudios
ON jogos.idJogo = estudios.idEstudio

--Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia;
SELECT jogos.nomeJogo, estudios.nomeEstudio FROM estudios
LEFT JOIN jogos
ON jogos.idEstudio = estudios.idEstudio

--Buscar um usu�rio por e-mail e senha (login);
SELECT email, senha FROM usuarios
WHERE email = 'admin@admin.com' AND senha = 'admin'

--Buscar um jogo por idJogo;
SELECT nomeJogo AS 'Jogo' FROM jogos
WHERE idJogo = 2

--Buscar um est�dio por idEst�dio;
SELECT nomeEstudio AS 'Est�dio' FROM estudios
WHERE idEstudio = 1

SELECT * FROM jogos