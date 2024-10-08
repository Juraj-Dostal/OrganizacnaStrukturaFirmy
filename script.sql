CREATE TABLE Zamestnanec (
 Id INT PRIMARY KEY,
 Meno VARCHAR(30) NOT NULL,
 Priezvisko VARCHAR(30) NOT NULL,
 Titul VARCHAR(30),
 Telefon VARCHAR(15),
 Email VARCHAR(50) NOT NULL
 );
GO

CREATE TABLE Uzol (
 Kod INT PRIMARY KEY,
 Nazov VARCHAR(30) NOT NULL,
 VeduciId INT NOT NULL,
 Typ CHAR(1) NOT NULL CONSTRAINT constrTyp CHECK (Typ IN ('F', 'D', 'P', 'O')),
 RodicUzol INT,
 CONSTRAINT constrZames FOREIGN KEY (VeduciId) REFERENCES Zamestnanec(Id),      
 CONSTRAINT constrUzol FOREIGN KEY (RodicUzol) REFERENCES Uzol(Kod) 
);
GO
