CREATE DATABASE L_MyBASE;
GO

USE L_MyBASE;

CREATE TABLE Enterprises (
    EnterpriseID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    BankDetails VARCHAR(150),
    Phone VARCHAR(15),
    ContactPerson VARCHAR(100)
);

CREATE TABLE Indicators (
    IndicatorID INT PRIMARY KEY IDENTITY(1,1),
    IndicatorName VARCHAR(100) NOT NULL,
    ImportanceLevel INT NOT NULL 
);

CREATE TABLE FinancialMetrics (
    MetricID INT PRIMARY KEY IDENTITY(1,1),
    EnterpriseID INT,
    IndicatorID INT,
    Date DATE NOT NULL,
    Value DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (EnterpriseID) REFERENCES Enterprises(EnterpriseID),
    FOREIGN KEY (IndicatorID) REFERENCES Indicators(IndicatorID)
);


USE L_MyBASE;

INSERT INTO Enterprises (Name, BankDetails, Phone, ContactPerson) VALUES
('����������� �', '��������� 1', '111-222-333', '������ �.�.'),
('����������� �', '��������� 2', '444-555-666', '������ �.�.'),
('����������� �', '��������� 3', '777-888-999', '������� �.�.');

INSERT INTO Indicators (IndicatorName, ImportanceLevel) VALUES
('�������', 5),
('�������������', 4),
('�������', 5),
('��������������', 3);

INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES
(1, 1, '2023-01-01', 100000.00),
(1, 2, '2023-01-01', 75000.00),
(2, 1, '2023-01-01', 150000.00),
(2, 3, '2023-01-01', 200000.00),
(3, 4, '2023-01-01', 0.20);