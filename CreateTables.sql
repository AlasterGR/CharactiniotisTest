-- Table for Clients
CREATE TABLE IF NOT EXISTS Clients (
    ClientID SERIAL PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Address VARCHAR(100) NOT NULL,
    PostalCode NUMERIC(5,0) NOT NULL, -- I use NUMERIC data type to store exactly 5 digits
    PhoneNumber NUMERIC(10, 0) NOT NULL UNIQUE, -- I will not provide for the country code
    Email VARCHAR(320) UNIQUE,
    CONSTRAINT PostalCode_length_check CHECK (LENGTH(PostalCode::TEXT) = 5), -- Costraint PostalCode to exactly 5 digits,
    CONSTRAINT PhoneNumber_length_check CHECK (LENGTH(PhoneNumber::TEXT) = 10) -- Costraint PhoneNumber to exactly 10 digits
);

-- Table for Books
CREATE TABLE IF NOT EXISTS Books (
    ISBN NUMERIC(13,0) PRIMARY KEY,  -- I use the maximum number of digits supported for ISBN...
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(50) NOT NULL,
    Summary TEXT,
	CONSTRAINT ISBN_length_check CHECK (LENGTH(ISBN::TEXT) = 10 OR LENGTH(ISBN::TEXT) = 13) -- ... and I allow the ISBN value to be either 10 or 13 digits, as dictated by the standard.
);

-- Table for Order Header
CREATE TABLE IF NOT EXISTS OrderHeader (
    OrderID SERIAL PRIMARY KEY,
    ClientID INT NOT NULL,
    OrderDate DATE NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES Clients(ClientID)
);

-- Table for Order Details
CREATE TABLE IF NOT EXISTS OrderDetails (
    --OrderDetailID SERIAL PRIMARY KEY,
    OrderID INT NOT NULL UNIQUE,
    ISBN NUMERIC(13,0) NOT NULL UNIQUE, -- UNIQUE because we have already presumed to have 1` of any book
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES OrderHeader(OrderID),
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN)
);