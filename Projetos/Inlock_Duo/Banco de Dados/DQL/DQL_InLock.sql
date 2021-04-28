USE inlock_games_tarde

--Listar todos os usuários;
SELECT * FROM usuarios

--Listar todos os estúdios;
SELECT * FROM estudios

--Listar todos os jogos;
SELECT * FROM jogos

--Listar todos os jogos e seus respectivos estúdios;
SELECT nomeJogo AS 'Jogo', valor AS 'Preço em R$', nomeEstudio AS 'Estúdio' FROM jogos
INNER JOIN estudios
ON jogos.idJogo = estudios.idEstudio

--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT jogos.nomeJogo, estudios.nomeEstudio FROM estudios
LEFT JOIN jogos
ON jogos.idEstudio = estudios.idEstudio

--Buscar um usuário por e-mail e senha (login);
SELECT email, senha FROM usuarios
WHERE email = 'admin@admin.com' AND senha = 'admin'

--Buscar um jogo por idJogo;
SELECT nomeJogo AS 'Jogo' FROM jogos
WHERE idJogo = 2

--Buscar um estúdio por idEstúdio;
SELECT nomeEstudio AS 'Estúdio' FROM estudios
WHERE idEstudio = 1

SELECT * FROM jogos