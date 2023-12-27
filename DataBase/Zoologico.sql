-- Use master para evitar criar o banco de dados Zoologico se ele já existir
USE master
GO

-- Verifica se o banco de dados já existe antes de criar
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Zoologico')
BEGIN
    DROP DATABASE Zoologico
END
GO

-- Cria o banco de dados Zoologico
CREATE DATABASE Zoologico
USE Zoologico
GO

-- Criação da tabela Alimentos
CREATE TABLE Alimentos (
    CodAlimento INT IDENTITY (1, 1) NOT NULL,
    NomeAlimento VARCHAR(20),
    Descricao VARCHAR(40),
    CONSTRAINT pk_CodAlimento PRIMARY KEY (CodAlimento)
)
GO

-- Criação da tabela Animais
CREATE TABLE Animais (
    CodAnimal INT IDENTITY (1, 1) NOT NULL,
    TipoAnimal VARCHAR(20),
    NomeAnimal VARCHAR(20),
    PaisOrigem VARCHAR(20),
    AnoNascimento DATE,
    Genero VARCHAR(20),
    CodAlimento INT,
    QuantGramas INT,
    CONSTRAINT pk_CodAnimal PRIMARY KEY (CodAnimal),
    CONSTRAINT fk_CodAlimento FOREIGN KEY (CodAlimento) REFERENCES Alimentos (CodAlimento)
)
GO

-- Inserção de dados na tabela Alimentos
INSERT INTO Alimentos VALUES
('FrutasA', 'Maça, Melão e Abacaxi'),
-- ... outros valores ...

-- Inserção de dados na tabela Animais
INSERT INTO Animais VALUES
('Coral', 'Caco', 'Brasil', '2013-01-01', 'Fêmea', 3, 100),
-- ... outros valores ...

-- Consulta para verificar os dados
SELECT * FROM Alimentos
SELECT * FROM Animais
SELECT * FROM Animais AS ani INNER JOIN Alimentos AS ali ON ani.CodAlimento = ali.CodAlimento
