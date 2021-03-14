USE Medical;
GO

SELECT*FROM tipoUsuario;
SELECT*FROM Usuario;
SELECT*FROM Especialidade;
SELECT*FROM Clinica;
SELECT*FROM Medico;
SELECT*FROM Paciente;
SELECT*FROM Situacao;
SELECT*FROM consulta;

SELECT IdUsuario, tituloTipoUsuario, email from Usuario
INNER JOIN tipoUsuario
ON Usuario.IdTipoUsuario = tipoUsuario.IdTipoUsuario;

SELECT nomeMedico, nomeFantasia from consulta
INNER JOIN Medico
ON consulta.IdMedico = Medico.idMedico
INNER JOIN Clinica
ON Medico.idClinica = Clinica.IdClinica;

SELECT nomePaciente, nomeMedico, dataConsulta, nomeEspecialidade AS Especialidade, Situacao from consulta
INNER JOIN Medico
ON consulta.IdMedico = Medico.idMedico
INNER JOIN Paciente
ON consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN Especialidade
ON Medico.idEspecialidade = Especialidade.idEspecialidade
INNER JOIN Situacao
ON consulta.idSituacao = situacao.IdSituacao;

SELECT tituloTipoUsuario[Permissao], email from Usuario
INNER JOIN tipoUsuario
ON Usuario.IdTipoUsuario = tipoUsuario.IdTipoUsuario
WHERE email = 'adm@adm.com' and senha = 'adm123';