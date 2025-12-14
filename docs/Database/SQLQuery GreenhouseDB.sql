-- 1. Създаване на базата (ако не съществува)
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'GreenhouseDB')
BEGIN
    CREATE DATABASE GreenhouseDB;
END
GO

USE GreenhouseDB;
GO

-- =========================================================
-- 0. ПОЧИСТВАНЕ (Изтриване на стари таблици в правилен ред)
-- =========================================================
IF OBJECT_ID('dbo.SensorLog', 'U') IS NOT NULL DROP TABLE dbo.SensorLog;
IF OBJECT_ID('dbo.Sensors', 'U') IS NOT NULL DROP TABLE dbo.Sensors;
IF OBJECT_ID('dbo.Devices', 'U') IS NOT NULL DROP TABLE dbo.Devices;
IF OBJECT_ID('dbo.Schedules', 'U') IS NOT NULL DROP TABLE dbo.Schedules;
IF OBJECT_ID('dbo.OperationsLog', 'U') IS NOT NULL DROP TABLE dbo.OperationsLog;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
GO

-- =============================================
-- 1. Таблица: ПОТРЕБИТЕЛИ (Users)
-- =============================================
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL, 
    Role NVARCHAR(20) DEFAULT 'User' 
);

INSERT INTO Users (Username, Password, Role) VALUES 
('admin', 'admin123', 'Admin'),    
('worker', 'worker123', 'Worker'); 

-- =============================================
-- 2. Таблица: УПРАВЛЯЕМИ УСТРОЙСТВА (Devices)
-- Използваме IsActive като състояние (0=Изкл, 1=Вкл)
-- =============================================
CREATE TABLE Devices (
    DeviceId INT PRIMARY KEY IDENTITY(1,1),
    DeviceName NVARCHAR(100) NOT NULL, 
    IsActive BIT DEFAULT 0, -- 0 = Off/Closed, 1 = On/Open
    LastUpdated DATETIME DEFAULT GETDATE()
);

-- Вмъкване на имената на английски
INSERT INTO Devices (DeviceName, IsActive) VALUES 
('Roof Motor', 0),
('Water Pump', 0),
('Windows', 0),
('Pesticide Sprayers', 0),
('Valve Sector A', 0),
('Valve Sector B', 0),
('Valve Sector C', 0),
('Valve Sector D', 0);

-- =============================================
-- 3. Таблица: СЕНЗОРИ (Sensors)
-- =============================================
CREATE TABLE Sensors (
    SensorId INT PRIMARY KEY IDENTITY(1,1),
    SensorName NVARCHAR(100) NOT NULL,
    Unit NVARCHAR(20) -- Мерна единица
);

-- Вмъкване на имената на английски
INSERT INTO Sensors (SensorName, Unit) VALUES 
('Temperature Sensor', '°C'),
('Light Sensor', 'lux'),
('Humidity Sensor A', '%'),
('Humidity Sensor B', '%'),
('Humidity Sensor C', '%'),
('Humidity Sensor D', '%');

-- =============================================
-- 4. Таблица: ИСТОРИЯ НА СЕНЗОРИТЕ (SensorLog)
-- =============================================
CREATE TABLE SensorLog (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    SensorId INT NOT NULL, 
    Value DECIMAL(10, 2) NOT NULL,
    ReadingTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SensorId) REFERENCES Sensors(SensorId)
);

-- =============================================
-- 5. Таблица: ИСТОРИЯ НА ОПЕРАЦИИ (OperationsLog)
-- =============================================
CREATE TABLE OperationsLog (
    OpId INT PRIMARY KEY IDENTITY(1,1),
    OperationName NVARCHAR(100), 
    Details NVARCHAR(MAX),       
    Initiator NVARCHAR(50),      
    OpTime DATETIME DEFAULT GETDATE()
);

-- =============================================
-- 6. Таблица: ГРАФИК (Schedules)
-- =============================================
CREATE TABLE Schedules (
    ScheduleId INT PRIMARY KEY IDENTITY(1,1),
    ActionName NVARCHAR(100),      
    Sector NVARCHAR(50),           
    ScheduledDate DATETIME,        
    DurationMinutes INT DEFAULT 15,
    Status NVARCHAR(50) DEFAULT 'Pending' 
);
GO