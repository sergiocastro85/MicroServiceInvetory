USE NewInventory;
GO

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name varchar(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
	Stock int
);
GO

CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(100) NOT NULL,
	Description varchar (100)
);
GO