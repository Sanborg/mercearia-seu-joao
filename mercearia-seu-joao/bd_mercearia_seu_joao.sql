CREATE DATABASE bd_mercearia_seu_joao
DEFAULT CHARACTER SET utf8
DEFAULT COLLATE utf8_general_ci;

USE bd_mercearia_seu_joao;

CREATE TABLE Usuario(
id int AUTO_INCREMENT,
nome varchar(100),
email varchar(100),
senha varchar(100),
tipoUsuario varchar(100),
dataHoraInclusao datetime,
dataHoraAlteracao datetime,
dataHoraExclusao datetime,
PRIMARY KEY(id)
)DEFAULT CHARSET = utf8;

CREATE TABLE Produto(
id int AUTO_INCREMENT,
nome varchar(100),
quantidade int,
precoUnitario float,
fornecedor varchar(100),
dataHoraInclusao datetime,
dataHoraAlteracao datetime,
dataHoraExclusao datetime,
PRIMARY KEY(id)
)DEFAULT CHARSET = utf8;

CREATE TABLE Vende(
id int AUTO_INCREMENT,
idUsuario int,
idProduto int,
qtdProduto int,
precoTotal float,
dataHoraVenda datetime,
PRIMARY KEY(id),
FOREIGN KEY(idUsuario) references Usuario(id),
FOREIGN KEY(idProduto) references Produto(id)
)DEFAULT CHARSET = utf8;

INSERT INTO Usuario (nome, email, senha, tipoUsuario, dataHoraInclusao) VALUES
('Gerente','gerente@gmail.com','G3rente@','gerente','2022-11-07 15:00:00'),
('Caixa','caixa@gmail.com','C@1xa123','caixa','2022-11-07 15:00:00');

INSERT INTO Produto (nome, quantidade, precoUnitario, fornecedor, dataHoraInclusao) VALUES
('Leite', 100, 7.99,'Ninho','2022-11-02 09:30:00'),
('Água mineral', 100, 2,'Passa Quatro','2022-11-02 09:30:00'),
('Nuggets', 10000, 25.90,'Seara','2022-11-02 09:30:00'),
('Iogurte', 500, 12.50,'Nestle','2022-11-02 09:30:00'),
('Cigarro', 5000, 11.50,'Malboro','2022-11-02 09:30:00');

