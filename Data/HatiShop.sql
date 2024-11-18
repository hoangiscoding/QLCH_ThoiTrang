--CREATE DATABASE HatiShop;
--GO

USE HatiShop;
GO

CREATE TABLE Customer (
    Id varchar(50) PRIMARY KEY,
    Username varchar(50) NOT NULL,
    [Password] varchar(100) NOT NULL,
    FullName nvarchar(50) NOT NULL,
    Gender nvarchar(4),
    BirthDate datetime,
    PhoneNumber varchar(10),
    Email varchar(100),
    Address nvarchar(200),
    AvatarPath nvarchar(MAX),
    Revenue int DEFAULT 0,
    Rank nvarchar(50) DEFAULT N'ĐỒNG'
);

CREATE TABLE Staff (
    Id varchar(50) PRIMARY KEY,
    Username varchar(50) NOT NULL,
    [Password] varchar(100) NOT NULL,
    FullName nvarchar(50) NOT NULL,
    Gender nvarchar(4),
    BirthDate datetime,
    PhoneNumber varchar(10),
    Email varchar(100),
    Address nvarchar(200),
    AvatarPath nvarchar(MAX),
    [Role] nvarchar(50)
);

CREATE TABLE Product (
    Id varchar(50) PRIMARY KEY,
    Name nvarchar(100) NOT NULL,
    Price int NOT NULL,
    [Type] nvarchar(50),
    Quantity int DEFAULT 0,
    Size nvarchar(10),
    Info nvarchar(MAX),
    AvatarPath nvarchar(MAX)
);

CREATE TABLE ImportGood (
    Id varchar(50) PRIMARY KEY,
    StaffId varchar(50) NOT NULL,
    ProductId varchar(50) NOT NULL,
    ImportTime datetime NOT NULL,
    Quantity int NOT NULL,
    FOREIGN KEY (StaffId) REFERENCES Staff(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

CREATE TABLE Bill (
    Id varchar(50) PRIMARY KEY,
    CustomerId varchar(50) NOT NULL,
    StaffId varchar(50) NOT NULL,
    CreationTime datetime NOT NULL,
    DiscountAmount float DEFAULT 0,
    OriginalPrice float NOT NULL,
    DiscountedTotal float NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
    FOREIGN KEY (StaffId) REFERENCES Staff(Id)
);

CREATE TABLE BillDetail (
    Id varchar(50),
    ProductId varchar(50) NOT NULL,
    Quantity int NOT NULL,
    Total float NOT NULL,
    PRIMARY KEY (Id, ProductId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

CREATE TABLE UserRoles (
    UserId varchar(50) NOT NULL,
    [Role] nvarchar(50) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Staff(Id)
);

delete from Staff
where Id = 'NV2'
insert into staff (Id, Username, Password, FullName, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role)
values('NV2', 'minh', '123456', N'Dương Quang Minh', 'Nam', '2004-03-22 13:45:06.000', '0912160889',
'duongminhtp223@gmail.com', N'Hải Phòng','D:\DH\Kì 5\LTTQ\BTL\QLCH_ThoiTrang\images\Avatars\man.png', N'QUẢN LÝ')
