USE HROADS;

--Selecionar todos os personagens;
SELECT * FROM Personagem;

--Selecionar todas as Classes
SELECT * FROM Classe;

--Selecionar somente o nome das classes;
SELECT Nome FROM Classe

--Selecionar todas as habilidades;
SELECT * FROM Habilidade;

--Realizar a contagem de quantas habilidade estão cadastradas;
SELECT COUNT (Habilidade.idHabilidade) AS [Quantidade de Habilidades]
FROM Habilidade

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT idHabilidade FROM Habilidade ORDER BY idHabilidade

--Selecionar todos os tipos de habilidades;
SELECT Tipo FROM TipoHabilidade

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT Habilidade.Habilidade, TipoHabilidade.Tipo FROM Habilidade
INNER JOIN TipoHabilidade
ON Habilidade.idTipo = TipoHabilidade.idTipo

--Selecionar todos os personagens e suas respectivas classes;
SELECT Personagem.Nome, Classe.Nome AS Classe FROM Personagem
INNER JOIN Classe
ON Personagem.idClasse = Classe.idClasse

--Selecionar todos os personagens e todas as classes;
SELECT Personagem.Nome, Classe.Nome AS Classes FROM Classe
LEFT JOIN Personagem
ON Personagem.idClasse = Classe.idClasse

--Selecionar todas as classes e suas respectivas habilidades;
SELECT Classe.Nome, Habilidade.Habilidade FROM ClasseHabilidade
INNER JOIN Classe
ON ClasseHabilidade.idClasse = Classe.idClasse
INNER JOIN Habilidade
ON ClasseHabilidade.idHabilidade = Habilidade.idHabilidade

--Selecionar todas as habilidades e suas classes(somente as que possuem correspondência);
SELECT Habilidade.Habilidade, Classe.Nome FROM Habilidade
INNER JOIN ClasseHabilidade
ON Habilidade.idHabilidade = ClasseHabilidade.idHabilidade
INNER JOIN Classe
ON Classe.idClasse = ClasseHabilidade.idClasse

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT Habilidade.Habilidade, Classe.Nome FROM Habilidade
FULL OUTER JOIN ClasseHabilidade
ON Habilidade.idHabilidade = ClasseHabilidade.idHabilidade
FULL OUTER JOIN Classe
ON Classe.idClasse = ClasseHabilidade.idClasse
--
SELECT * FROM TipoHabilidade;
SELECT * FROM ClasseHabilidade;
--
SELECT * FROM Personagem;
SELECT idPersonagem, idClasse, YEAR(DataAtualizacao) FROM Personagem
--
SELECT * FROM Habilidade
SELECT * FROM TipoHabilidade
--