CREATE DATABASE InventarioTI;
GO

USE InventarioTI;
GO

CREATE TABLE Equipos (
    IdEquipo INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(50),
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Estado VARCHAR(30)
);


INSERT INTO Equipos (Tipo, Marca, Modelo, Estado) VALUES
('Laptop', 'Dell', 'Latitude 3420', 'Activo'),
('Laptop', 'Dell', 'Latitude 3440', 'Activo'),
('Laptop', 'Lenovo', 'ThinkPad L14', 'Activo'),
('Laptop', 'Lenovo', 'ThinkPad T14', 'Activo'),
('Laptop', 'Dell', 'Vostro 5415', 'Activo');

SELECT * FROM Equipos;