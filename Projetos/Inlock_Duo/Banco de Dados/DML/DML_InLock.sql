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
VALUES			  ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '15/05/2012', 99, 1)
				 ,('Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western', '26/10/2018', 120, 2)