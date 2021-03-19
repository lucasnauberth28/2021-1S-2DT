USE Locadora;

SELECT * FROM Empresas;
SELECT * FROM Marcas;
SELECT * FROM Modelos;
SELECT * FROM Veiculos;
SELECT * FROM Cliente;

SELECT * FROM Aluguel;

SELECT Aluguel.dataPegado, Aluguel.dataDevolucao, Cliente.nomeCliente, Modelos.nomeModelo FROM Aluguel
INNER JOIN Cliente
ON Cliente.idCliente = Aluguel.idCliente
INNER JOIN Veiculos
ON Aluguel.idVeiculo = Veiculos.idVeiculo
INNER JOIN Modelos
ON Modelos.idModelo = Veiculos.idModelo;

SELECT Aluguel.dataPegado, Aluguel.dataDevolucao, Cliente.nomeCliente, Modelos.nomeModelo FROM Aluguel
INNER JOIN Cliente
ON Cliente.idCliente = Aluguel.idCliente
INNER JOIN Veiculos
ON Aluguel.idVeiculo = Veiculos.idVeiculo
INNER JOIN Modelos
ON Modelos.idModelo = Veiculos.idModelo
WHERE Cliente.nomeCliente LIKE 'Lucas';