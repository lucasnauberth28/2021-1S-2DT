USE  Medical;
GO

INSERT INTO tipoUsuario (tituloTipoUsuario)
VALUES

	('Administrador')
	,('M�dico')
	,('Paciente');
GO

INSERT INTO Usuario (IdTipoUsuario)
VALUES 
	(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123')
	,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle456')
	,(2, 'helena.souza@spmedicalgroup.com.br', 'helena789')
	,(3, 'ligia@gmail.com', 'ligia123')
	,(3, 'alexandre@gmail.com', 'alexandre456')
	,(3, 'fernando@gmail.com', 'fernando789')
	,(3, 'henrique@gmail.com', 'henrique987')
	,(3, 'joao@gmail.com', 'joao654')
	,(3, 'bruno@gmail.com', 'bruno123')
	,(3, 'mariana@outlook.com', 'mariana987')
	,(1, 'adm@adm.com', 'adm123');
GO

INSERT INTO Especialidade (nomeEspecialidade)
VALUES
	 ('Acupuntura')
	,('Anestesiologia')
	,('Angiologia')
	,('Cardiologia')
	,('Cirurgia Cardiovascular')
	,('Cirurgia de M�o')
	,('Cirurgia do Aparelho Digestivo')
	,('Cirurgia Geral')
	,('Cirurgia Pedi�trica')
	,('Cirurgia Pl�stica')
	,('Cirurgia Tor�cica')
	,('Cirurgia Vascular')
	,('Dermatologia')
	,('Radioterapia')
	,('Urologia')
	,('Pediatria')
	,('Psiquiatria');
GO

INSERT INTO Clinica (CNPJ, endereco, nomeFantasia, razaoSocial)
VALUES				('86400902000130', 'Av. Bar�o Limeira, 532', 'Clinica Possarle', 'SP M�dical Group');
GO

INSERT INTO Medico (idUsuario, idEspecialidade, idClinica, nomeMedico,CRM)
VALUES		   (1, 2, 1,'Ricardo Lemos','54356-SP')
				  ,(2, 17, 1, 'Roberto Possarle' ,'53452-SP')
				  ,(3, 16, 1, 'Helena Strada' ,'65463-SP');
GO

INSERT INTO Paciente (idUsuario, dataNascimento, nomePaciente, RG, CPF, telefone, endereco)
VALUES				 (4, '10/03/1983', 'Ligia','435225435', '94839859000', '1134567654', 'Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000')
					,(5, '07/03/2001', 'Alexandre','326543457', '73556944057', '11987656543', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200')
					,(6, '10/10/1978', 'Fernando','546365253', '16839338002', '11972084453', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200')
					,(7, '13/10/1985', 'Henrique','543663625', '14332654765', '1134566543', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
					,(8, '27/08/1975', 'Jo�o','325444441', '91305348010', '1176566377', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380')
					,(9, '21/03/1972', 'Bruno','545662667', '79799299004', '11954368769', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001')
					,(10, '05/03/2018','Mariana','545662668', '13771913039', null, 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO Situacao(Situacao)
VALUES				 ('Realizada')
					,('Cancelada')
					,('Agendada');
GO

INSERT INTO Consulta (idMedico, idPaciente, idSituacao, dataConsulta, descricao)
VALUES				 (3, 7, 1, '14/04/2021', 'Crian�a com catarro na garganta')
					,(2, 2, 2, '28/03/2021', 'Paciente com falta de confian�a em si mesmo')
					,(2, 3, 1, '29/03/2021', 'Paciente com depress�o severa')
					,(2, 2, 1, '08/04/2021', 'Paciente com boderline')
					,(1, 4, 2, '21/05/2021', 'Paciente verificando se tem alergia a anestesia utilizada na cirurgia')
					,(3, 7, 3, '30/03/2021', 'Crian�a com dor de bronquilote')
					,(1, 4, 3, '06/04/2021', 'Paciente com parestesia');
GO