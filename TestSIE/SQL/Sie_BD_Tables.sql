CREATE DATABASE TestSIE;
GO
USE TestSIE;
GO

--Tabla Persona
CREATE TABLE Persona (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Persona UNIQUE (Nombre, Apellido) 
);

--Tabla Coche
CREATE TABLE Coche (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    VIN NVARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Coche_VIN UNIQUE (VIN)
);

--Tabla Propietario_Coche
CREATE TABLE Propietario_Coche (
    id INT IDENTITY(1,1) PRIMARY KEY,
    persona_id INT NOT NULL,
    coche_id INT NOT NULL,
    CONSTRAINT FK_Persona FOREIGN KEY (persona_id) REFERENCES Persona(id),
    CONSTRAINT FK_Coche FOREIGN KEY (coche_id) REFERENCES Coche(id),
    CONSTRAINT UQ_Coche_Propietario UNIQUE (coche_id)
);
