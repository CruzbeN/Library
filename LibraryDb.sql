-- Create the database
CREATE DATABASE LibraryDB;
GO

-- Use the database
USE LibraryDB;
GO

-- Create the Categories table with auto-incrementing Id
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50)
);

-- Create the Books table with auto-incrementing Id
CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100),
    Author VARCHAR(100),
    ReleaseYear INT,
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories (CategoryId)
);

-- Create the Customers table with auto-incrementing Id
CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Address VARCHAR(200)
);

-- Create the Rentals table with auto-incrementing Id
CREATE TABLE Rentals (
    RentalId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT,
    BookId INT,
    BorrowDate DATETIME,
    ReturnDate DATETIME,
    FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
    FOREIGN KEY (BookId) REFERENCES Books (BookId)
);


-- Insert data into Categories table
INSERT INTO Categories (Name)
VALUES
    ('Fantastyka'),
    ('Science Fiction'),
    ('Krymina³'),
    ('Romans'),
    ('Thriller'),
    ('Biografia'),
    ('Historia');

-- Insert data into Books table
INSERT INTO Books (Title, Author, ReleaseYear, CategoryId)
VALUES
    ('Harry Potter i Kamieñ Filozoficzny', 'J.K. Rowling', 1997, 1),
    ('W³adca Pierœcieni: Dru¿yna Pierœcienia', 'J.R.R. Tolkien', 1954, 1),
    ('1984', 'George Orwell', 1949, 2),
    ('Cz³owiek poszukiwany', 'John le Carré', 2019, 2),
    ('Zbrodnia i kara', 'Fiodor Dostojewski', 1866, 3),
    ('To', 'Stephen King', 1986, 3),
    ('Romeo i Julia', 'William Shakespeare', 1597, 4),
    ('Wuthering Heights', 'Emily Brontë', 1847, 4),
    ('Milczenie owiec', 'Thomas Harris', 1988, 5),
    ('Niezgodna', 'Veronica Roth', 2011, 5),
    ('Steve Jobs', 'Walter Isaacson', 2011, 6),
    ('Mê¿czyŸni którzy nienawidz¹ kobiet', 'Stieg Larsson', 2005, 6),
    ('Sapiens: Od zwierz¹t do bogów', 'Yuval Noah Harari', 2011, 7),
    ('Homo Deus: Krótka historia jutra', 'Yuval Noah Harari', 2015, 7),
    ('Pieœñ lodu i ognia: Gra o tron', 'George R.R. Martin', 1996, 1),
    ('Duma i uprzedzenie', 'Jane Austen', 1813, 4)
    -- Dodaj kolejne ksi¹¿ki...
	
-- Insert data into Customers table
INSERT INTO Customers (FirstName, LastName, Address)
VALUES
    ('Jan', 'Kowalski', 'ul. Kwiatowa 1'),
    ('Anna', 'Nowak', 'ul. Ogrodowa 10')
    -- Dodaj kolejnych klientów...

-- Insert data into Rentals table
INSERT INTO Rentals (CustomerId, BookId, BorrowDate, ReturnDate)
VALUES
    (1, 1, '2023-07-01', '2023-07-10'),
    (2, 2, '2023-07-02', '2023-07-11')
    -- Dodaj kolejne wypo¿yczenia...

