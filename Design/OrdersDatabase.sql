-- Bernabest Inventory System – Orders module schema
-- Run against: BernabestInventorySystem on DESKTOP-3ASQD5D\SQLEXPRESS01

USE BernabestInventorySystem;
GO

IF OBJECT_ID('OrderAddOns', 'U') IS NOT NULL DROP TABLE OrderAddOns;
IF OBJECT_ID('CalendarEvents', 'U') IS NOT NULL DROP TABLE CalendarEvents;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('AddOns', 'U') IS NOT NULL DROP TABLE AddOns;
IF OBJECT_ID('FrostingTypes', 'U') IS NOT NULL DROP TABLE FrostingTypes;
IF OBJECT_ID('CakeSizes', 'U') IS NOT NULL DROP TABLE CakeSizes;
IF OBJECT_ID('CakeFlavors', 'U') IS NOT NULL DROP TABLE CakeFlavors;
GO

CREATE TABLE CakeFlavors (
    FlavorID   VARCHAR(10)  PRIMARY KEY,
    FlavorName NVARCHAR(80) NOT NULL,
    BasePrice  DECIMAL(18,2) NOT NULL
);

CREATE TABLE CakeSizes (
    SizeID     VARCHAR(10)  PRIMARY KEY,
    SizeLabel  NVARCHAR(50) NOT NULL,
    InchSize   INT          NOT NULL,
    PriceAdder DECIMAL(18,2) NOT NULL DEFAULT 0
);

CREATE TABLE FrostingTypes (
    FrostingID   VARCHAR(10)  PRIMARY KEY,
    FrostingName NVARCHAR(50) NOT NULL,
    PriceAdder   DECIMAL(18,2) NOT NULL DEFAULT 0
);

CREATE TABLE AddOns (
    AddOnID    VARCHAR(10)  PRIMARY KEY,
    AddOnName  NVARCHAR(80) NOT NULL,
    UnitPrice  DECIMAL(18,2) NOT NULL,
    IsQtyBased BIT NOT NULL DEFAULT 0
);

CREATE TABLE Orders (
    OrderID          VARCHAR(10)   PRIMARY KEY,
    OrderType        VARCHAR(20)   NOT NULL,   -- Standard | CustomCake
    OrderStatus      VARCHAR(20)   NOT NULL,
    CustomerName     NVARCHAR(100) NOT NULL,
    ContactNo        VARCHAR(20)   NOT NULL,
    CreatedByUserID  VARCHAR(10)   NULL,
    OrderDate        DATETIME      NOT NULL DEFAULT GETDATE(),
    PickupDate       DATE          NULL,
    ProductID        VARCHAR(10)   NULL,
    Quantity         INT           NULL,
    FlavorID         VARCHAR(10)   NULL,
    SizeID           VARCHAR(10)   NULL,
    FrostingID       VARCHAR(10)   NULL,
    SpecialMessage   NVARCHAR(200) NULL,
    Notes            NVARCHAR(500) NULL,
    ProductSubTotal  DECIMAL(18,2) NULL,
    CakeSubTotal     DECIMAL(18,2) NULL,
    AddOnsTotal      DECIMAL(18,2) NOT NULL DEFAULT 0,
    TotalAmount      DECIMAL(18,2) NOT NULL
);

CREATE TABLE OrderAddOns (
    OrderAddOnID VARCHAR(10) PRIMARY KEY,
    OrderID      VARCHAR(10) NOT NULL REFERENCES Orders(OrderID) ON DELETE CASCADE,
    AddOnID      VARCHAR(10) NOT NULL REFERENCES AddOns(AddOnID),
    Quantity     INT         NOT NULL DEFAULT 1,
    UnitPrice    DECIMAL(18,2) NOT NULL
);

CREATE TABLE CalendarEvents (
    EventID     VARCHAR(10)  PRIMARY KEY,
    EventDate   DATE         NOT NULL,
    EventTitle  NVARCHAR(200) NOT NULL,
    EventType   VARCHAR(30)  NOT NULL,
    ReferenceID VARCHAR(10)  NULL,
    CreatedBy   VARCHAR(10)  NULL
);
GO

-- Sample cake options
INSERT INTO CakeFlavors (FlavorID, FlavorName, BasePrice) VALUES
('F0001', 'Chocolate Cake', 450.00),
('F0002', 'Vanilla Cake', 400.00),
('F0003', 'Red Velvet', 480.00);

INSERT INTO CakeSizes (SizeID, SizeLabel, InchSize, PriceAdder) VALUES
('S0001', '6in - Layers', 6, 0),
('S0002', '8in - Layers', 8, 150),
('S0003', '10in - Layers', 10, 300);

INSERT INTO FrostingTypes (FrostingID, FrostingName, PriceAdder) VALUES
('FR001', 'Buttercream', 0),
('FR002', 'Fondant', 80),
('FR003', 'Cream Cheese', 50);

INSERT INTO AddOns (AddOnID, AddOnName, UnitPrice, IsQtyBased) VALUES
('A0001', 'Candles (Set of 12)', 50, 1),
('A0002', 'Number Candles', 80, 1),
('A0003', 'Cake Toppers (Basic)', 120, 0),
('A0004', 'Cake Topper (Custom)', 250, 0),
('A0005', 'Rush Order Fee', 300, 0);
GO
