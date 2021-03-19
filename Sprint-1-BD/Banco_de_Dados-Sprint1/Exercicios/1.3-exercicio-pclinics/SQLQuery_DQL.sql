USE PCCLINICS;

SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM Dono;
SELECT * FROM TipoPet;
SELECT * FROM Raca;
SELECT * FROM Pet;
SELECT * FROM Atendimento;
 
SELECT nomeVeterinario, crmVeterinario, Clinica.nomeClinica  FROM Veterinario 
INNER JOIN Clinica 
ON Clinica.idClinica = Veterinario.idClinica
WHERE nomeClinica like 'Loving this pet S2';

SELECT tipoPet FROM TipoPet WHERE tipoPet LIKE '%_o';
SELECT nomeRaca FROM Raca WHERE nomeRaca LIKE 'S_%';

SELECT Pet.nomePet,Dono.nomeDono 
FROM Pet
INNER JOIN Dono
ON Pet.idDono = Dono.idDono;

SELECT Atendimento.idVeterinario, Veterinario.nomeVeterinario, Raca.nomeRaca, Pet.nomePet, Dono.nomeDono, Clinica.nomeClinica FROM Atendimento
INNER JOIN Veterinario 
ON Atendimento.idVeterinario = Veterinario.idVeterinario
INNER JOIN Pet
ON Atendimento.idPet = Pet.idPet
INNER JOIN Raca 
ON Raca.idRaca = Pet.idRaca
INNER JOIN Dono
ON Dono.idDono = Pet.idDono
INNER JOIN Clinica
ON Clinica.idClinica = Veterinario.idClinica;