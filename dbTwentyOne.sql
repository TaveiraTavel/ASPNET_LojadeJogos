CREATE DATABASE dbTwentyOne;

USE dbTwentyOne;

CREATE USER 'twentyone'@'localhost' IDENTIFIED WITH mysql_native_password BY '123456';
GRANT ALL PRIVILEGES ON dbTwentyOne.* TO 'twentyone'@'localhost' WITH GRANT OPTION;

CREATE TABLE tbCliente(
	Nome varchar(100) not null,
    Cpf varchar(14) primary key,
    Nasc datetime not null,
    Email varchar(70) not null,
    Celular varchar(11) not null,
    Endereco varchar(150) not null
);

CREATE TABLE tbFuncionario(
	CodFunc mediumint primary key auto_increment,
	Nome varchar(100) not null,
    Cpf varchar(14) primary key,
    Rg varchar(14) primary key,
    Nasc datetime not null,
    Endereco varchar(150) not null,
    Celular varchar(11) not null,
    Email varchar(70) not null,
    Cargo varchar(30) not null
);
