USE master
GO

-- Verifica se o banco de dados já existe antes de criar
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Login')
BEGIN
    DROP DATABASE Login
END
GO

-- Cria o banco de dados Login
CREATE DATABASE Login
USE Login
GO

-- Criação da tabela Usuario
CREATE TABLE Usuario (
    CodUser INT IDENTITY (1, 1) NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    Senha VARCHAR(40) NOT NULL,
    CONSTRAINT pk_Usuario PRIMARY KEY (CodUser)
)
GO

-- Inserção de dados na tabela Usuario
INSERT INTO Usuario (Nome, Senha) VALUES
('John Doe', 'password123'),
('Jane Smith', 'securepass'),
('Bob Johnson', 'letmein'),
('senha', 'senha');
