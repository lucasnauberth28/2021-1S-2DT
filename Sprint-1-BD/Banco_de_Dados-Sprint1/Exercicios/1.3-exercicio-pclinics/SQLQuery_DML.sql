USE PCCLINICS;

INSERT INTO Clinica (enderecoClinica, nomeClinica, telefoneClinica)
VALUES ('R.Arroz Doce, 48', 'Amor ao Pet', '(11) 94567-8988'),
	   ('R.Goiabada, 87', 'Clinica do amor', '(11) 94567-7626');

INSERT INTO Veterinario (nomeVeterinario, crmVeterinario, idadeVeterinario, idClinica)
VALUES ('Lais', 'A054008', '38', 1),
	   ('Tonia', 'A054007', '25', 2);

INSERT INTO Dono (nomeDono, idadeDono, telefoneDono)
VALUES ('Luiza', '57', '(11) 98765-4738'),
	   ('Mauricio', '23', '(11) 94729-8382');

INSERT INTO TipoPet (tipoPet)
VALUES ('Cachorro'), 
	   ('Gato'),
	   ('Hamster');

INSERT INTO Raca (nomeRaca, idTipoPet)
VALUES ('Pinscher', 1),
	   ('Hamster', 3),
	   ('Shitzu', 1);

INSERT INTO Pet (nomePet, dataNascimento, idDono, idRaca)
VALUES ('Lilica', '01/06/2013', 1, 1),
	   ('Meg', '07/07/2019', 2, 2);

INSERT INTO Atendimento (horaAtendimento, fichaCadastroPet, dataAtendimento, idPet, idVeterinario)
VALUES ('7:30', 'Infecção de ouvido', '24/02/2021', 1, 2),
	   ('16:43', 'Infecção urinária', '23/09/2020', 2, 1);