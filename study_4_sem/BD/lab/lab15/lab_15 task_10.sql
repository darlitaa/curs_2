GO
CREATE TABLE TR_EST
(
    ID INT IDENTITY,
    STMT VARCHAR(20) CHECK (STMT IN ('INS', 'DEL', 'UPD')),
    TRNAME VARCHAR(20),
    CC VARCHAR(300)
);
GO

-- Триггер для вставки
GO
CREATE TRIGGER TR_EST_INS ON FinancialMetrics AFTER INSERT
AS
BEGIN
    DECLARE @date DATE, @enterpriseID INT, @indicatorID INT, @value DECIMAL(18, 2);
    DECLARE @in VARCHAR(300);
    
    PRINT 'Операция вставки';
    
    SELECT @date = Date, @enterpriseID = EnterpriseID, @indicatorID = IndicatorID, @value = Value FROM inserted;
    
    SET @in = CAST(@date AS VARCHAR(10)) + ' ' + CAST(@enterpriseID AS VARCHAR) + ' ' + CAST(@indicatorID AS VARCHAR) + ' ' + CAST(@value AS VARCHAR);
    
    INSERT INTO TR_EST(STMT, TRNAME, CC)
    VALUES ('INS', 'TR_EST_INS', @in);
END;

-- Триггер для удаления
GO
CREATE TRIGGER TR_EST_DEL ON FinancialMetrics AFTER DELETE
AS
BEGIN
    DECLARE @date DATE, @enterpriseID INT, @indicatorID INT, @value DECIMAL(18, 2);
    DECLARE @in VARCHAR(300);
    
    PRINT 'Операция удаления';
    
    SELECT @date = Date, @enterpriseID = EnterpriseID, @indicatorID = IndicatorID, @value = Value FROM deleted;
    
    SET @in = CAST(@date AS VARCHAR(10)) + ' ' + CAST(@enterpriseID AS VARCHAR) + ' ' + CAST(@indicatorID AS VARCHAR) + ' ' + CAST(@value AS VARCHAR);
    
    INSERT INTO TR_EST(STMT, TRNAME, CC)
    VALUES ('DEL', 'TR_EST_DEL', @in);
END;

-- Триггер для обновления
GO
CREATE TRIGGER TR_EST_UPD ON FinancialMetrics AFTER UPDATE
AS
BEGIN
    DECLARE @newDate DATE, @newEnterpriseID INT, @newIndicatorID INT, @newValue DECIMAL(18, 2);
    DECLARE @oldDate DATE, @oldEnterpriseID INT, @oldIndicatorID INT, @oldValue DECIMAL(18, 2);
    DECLARE @in VARCHAR(300);
    
    PRINT 'Операция изменения';
    
    SELECT @newDate = Date, @newEnterpriseID = EnterpriseID, @newIndicatorID = IndicatorID, @newValue = Value FROM inserted;
    SELECT @oldDate = Date, @oldEnterpriseID = EnterpriseID, @oldIndicatorID = IndicatorID, @oldValue = Value FROM deleted;

    SET @in = CAST(@oldDate AS VARCHAR(10)) + ' ' + CAST(@oldEnterpriseID AS VARCHAR) + ' ' + CAST(@oldIndicatorID AS VARCHAR) + ' ' + CAST(@oldValue AS VARCHAR) + ' / ' +
               CAST(@newDate AS VARCHAR(10)) + ' ' + CAST(@newEnterpriseID AS VARCHAR) + ' ' + CAST(@newIndicatorID AS VARCHAR) + ' ' + CAST(@newValue AS VARCHAR);
    
    INSERT INTO TR_EST(STMT, TRNAME, CC)
    VALUES ('UPD', 'TR_EST_UPD', @in);
END;

-- Примеры операций
GO
-- Вставка
INSERT INTO FinancialMetrics (EnterpriseID, IndicatorID, Date, Value) VALUES (1, 1, '2024-05-23', 100000.00);
SELECT * FROM FinancialMetrics;
SELECT * FROM TR_EST;

-- Удаление
DELETE FROM FinancialMetrics WHERE MetricID = 1;  -- Укажите ID метрики для удаления
SELECT * FROM FinancialMetrics;
SELECT * FROM TR_EST;

-- Обновление
UPDATE FinancialMetrics SET Value = 150000.00 WHERE MetricID = 1;  -- Укажите ID метрики для обновления
SELECT * FROM FinancialMetrics;
SELECT * FROM TR_EST;