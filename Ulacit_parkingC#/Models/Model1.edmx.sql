
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2024 20:13:38
-- Generated from EDMX file: C:\Users\Dell\Downloads\Mariapuala\MVP2\Ulacit_parkingC# (2)\Ulacit_parkingC#\Ulacit_parkingC#\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ParkingDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Assignment_ParkingLotId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParkingAssignments] DROP CONSTRAINT [FK_Assignment_ParkingLotId];
GO
IF OBJECT_ID(N'[dbo].[FK_Assignment_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParkingAssignments] DROP CONSTRAINT [FK_Assignment_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_MovementLog_VehicleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovementLog] DROP CONSTRAINT [FK_MovementLog_VehicleId];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehicles_OwnerId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_Vehicles_OwnerId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MovementLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovementLog];
GO
IF OBJECT_ID(N'[dbo].[ParkingAssignments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParkingAssignments];
GO
IF OBJECT_ID(N'[dbo].[ParkingLots]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParkingLots];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Vehicles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MovementLog'
CREATE TABLE [dbo].[MovementLog] (
    [id] int IDENTITY(1,1) NOT NULL,
    [vehicle_id] int  NULL,
    [action] nvarchar(20)  NOT NULL,
    [timestamp] datetime  NULL,
    [reason] nvarchar(255)  NULL
);
GO

-- Creating table 'ParkingAssignments'
CREATE TABLE [dbo].[ParkingAssignments] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [parking_lot_id] int  NOT NULL,
    [assignment_date] datetime  NOT NULL
);
GO

-- Creating table 'ParkingLots'
CREATE TABLE [dbo].[ParkingLots] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [regular_capacity] int  NOT NULL,
    [motorcycle_capacity] int  NOT NULL,
    [special_capacity] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [role_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [email] nvarchar(120)  NOT NULL,
    [date_of_birth] datetime  NOT NULL,
    [identification] nvarchar(50)  NOT NULL,
    [role_id] int  NOT NULL,
    [password] nvarchar(100)  NOT NULL,
    [first_login] char(1)  NULL,
    [password_changed] char(1)  NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [brand] nvarchar(50)  NOT NULL,
    [color] nvarchar(30)  NOT NULL,
    [license_plate] nvarchar(10)  NOT NULL,
    [vehicle_type] nvarchar(20)  NOT NULL,
    [owner_id] int  NOT NULL,
    [uses_special_space] char(1)  NULL,
    [is_active] char(1)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'MovementLog'
ALTER TABLE [dbo].[MovementLog]
ADD CONSTRAINT [PK_MovementLog]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ParkingAssignments'
ALTER TABLE [dbo].[ParkingAssignments]
ADD CONSTRAINT [PK_ParkingAssignments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ParkingLots'
ALTER TABLE [dbo].[ParkingLots]
ADD CONSTRAINT [PK_ParkingLots]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [vehicle_id] in table 'MovementLog'
ALTER TABLE [dbo].[MovementLog]
ADD CONSTRAINT [FK_MovementLog_VehicleId]
    FOREIGN KEY ([vehicle_id])
    REFERENCES [dbo].[Vehicles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovementLog_VehicleId'
CREATE INDEX [IX_FK_MovementLog_VehicleId]
ON [dbo].[MovementLog]
    ([vehicle_id]);
GO

-- Creating foreign key on [parking_lot_id] in table 'ParkingAssignments'
ALTER TABLE [dbo].[ParkingAssignments]
ADD CONSTRAINT [FK_Assignment_ParkingLotId]
    FOREIGN KEY ([parking_lot_id])
    REFERENCES [dbo].[ParkingLots]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Assignment_ParkingLotId'
CREATE INDEX [IX_FK_Assignment_ParkingLotId]
ON [dbo].[ParkingAssignments]
    ([parking_lot_id]);
GO

-- Creating foreign key on [user_id] in table 'ParkingAssignments'
ALTER TABLE [dbo].[ParkingAssignments]
ADD CONSTRAINT [FK_Assignment_UserId]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Assignment_UserId'
CREATE INDEX [IX_FK_Assignment_UserId]
ON [dbo].[ParkingAssignments]
    ([user_id]);
GO

-- Creating foreign key on [role_id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserRole]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole'
CREATE INDEX [IX_FK_UserRole]
ON [dbo].[Users]
    ([role_id]);
GO

-- Creating foreign key on [owner_id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_Vehicles_OwnerId]
    FOREIGN KEY ([owner_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehicles_OwnerId'
CREATE INDEX [IX_FK_Vehicles_OwnerId]
ON [dbo].[Vehicles]
    ([owner_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------