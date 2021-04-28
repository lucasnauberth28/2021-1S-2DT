USE inlock_games_tarde

INSERT INTO tiposUsuarios (titulo)
VALUES					  ('Cliente') 
					     ,('Administrador')
GO

INSERT INTO usuarios (email, senha, idTipoUsuario)
VALUES				 ('admin@admin.com', 'admin', 2)
					,('cliente@cliente.com', 'cliente', 1)
GO

INSERT INTO estudios (nomeEstudio)
VALUES				 ('Blizzard')
					,('Rockstar Studios')
					,('Square Enix')
GO

INSERT INTO jogos (nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			  ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '15/05/2012', 99, 1)
				 ,('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western', '26/10/2018', 120, 2)