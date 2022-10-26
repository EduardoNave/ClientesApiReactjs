CREATE DATABASE ProyectoClientes

USE ProyectoClientes

CREATE TABLE TemasInteres (
    IdTemaInteres INT IDENTITY(1,1) PRIMARY KEY,
    Tema NVARCHAR(100) NOT NULL,
    Activo TINYINT DEFAULT(1)
)

INSERT INTO TemasInteres (Tema) VALUES 
    ('Pintura'),
    ('Fontanería'),
    ('Jardín'),
    ('Decoración'),
    ('Herramientas')

CREATE TABLE TiposDocumento (
    IdTipoDocumento INT IDENTITY(1,1) PRIMARY KEY,
    TipoDocumento NVARCHAR(50),
    Activo TINYINT DEFAULT(1)
)

INSERT INTO TiposDocumento (TipoDocumento) VALUES 
    ('DUI'),
    ('Passaporte')

CREATE Table Generos (
    IdGenero INT IDENTITY(1,1) PRIMARY KEY,
    Genero NVARCHAR(10),
    Activo TINYINT DEFAULT(1)
)

INSERT INTO Generos (Genero) VALUES
    ('Femenino'),
    ('Masculino')

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres NVARCHAR(50) NOT NULL,
    Apellidos NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(8) NOT NULL,
    IdTipoDocumento INT,
    NumeroDocumento NVARCHAR(10),
    FechaNacimiento DATE,
    IdGenero INT,
    Creacion DATETIME DEFAULT(getDate()),
    Activo TINYINT DEFAULT(1)
)

INSERT INTO Clientes (Nombres, Apellidos, Telefono) VALUES ('Eduardo', 'Nave', '74757879')
Select * FROM Clientes

CREATE TABLE InteresesClientes (
    IdInteresCliente INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdTemaInteres INT NOT NULL,
    Activo TINYINT DEFAULT(1)
)

select * from Clientes