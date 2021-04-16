USE Locadora;

INSERT INTO Empresas(nomeEmpresa, 
CNPJ, funcionariosEmpresa, enderecoEmpresa)
VALUES ('Uber', '11.222.333/0001-XX', 'Thiago','R. Tchubiram, 36'),
	   ('99Taxi', '11.287.444/0001-XX', 'Melissa', 'R. Feijoada Boa, 98');

INSERT INTO Marcas (nomeMarca, sloganMarca)
VALUES ('Fiat', 'A PAIXÃO MOVE'), 
	   ('Volkswagen', 'Das Auto');

INSERT INTO Modelos (nomeModelo, tipoModelo, idMarca)
VALUES ('Gol', 'Gol Bolinha', 2), 
	   ('Uno', 'Uno Quadrado', 1);

INSERT INTO Veiculos (placaVeiculo, corVeiculo, idEmpresa, idModelo)
VALUES ('AAA-000', 'Verde', 1, 1),
	   ('BBB-111', 'Branco', 2, 2);

INSERT INTO Cliente (nomeCliente, cnhCliente, idadeCliente, telefoneCliente)
VALUES ('Fernanda', '00000000-0', '22', '(11) 93454-9843'),
	   ('Luana', '11111111-0', '19', '(11) 98763-9809');

INSERT INTO Aluguel (horaAluguel, dataPegado, dataDevolucao, precoAluguel,idCliente, idVeiculo)
VALUES ('15:30', '22/02/2021', '10/03/2021', '550.00', 1, 2),
	   ('17:55', '20/02/2021', '05/03/2021', '495.00', 2, 1 );