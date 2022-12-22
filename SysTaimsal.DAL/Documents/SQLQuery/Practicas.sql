Use DBSysTaimsal
GO

CREATE SCHEMA [Taimsal]
GO

CREATE TABLE [Taimsal].[User] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [IdRol] int,
  [IdClient] int,
  [IdProduct] int,
  [IdProvider] int,
  [IdAttendance] int,
  [IdEmployee] int,
  [NIE] int,
  [NameUser] varchar(30),
  [LastNameUser] varchar(30),
  [login] varchar(25),
  [Password] varchar(32),
  [Status_User] char,
  [RegistrationUser] datetime
)
GO

CREATE TABLE [Taimsal].[Rol] (
  [IdRol] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [NameRol] varchar(30)
)
GO

CREATE TABLE [Taimsal].[Client] (
  [IdClient] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [NameClient] varchar(30),
  [PhoneNumber] int
)
GO

CREATE TABLE [Taimsal].[Product] (
  [IdProduct] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [NameProduct] varchar(40),
  [ImageProduct] nvarchar(255),
  [DescriptionProduct] varchar(200),
  [price] decimal
)
GO

CREATE TABLE [Taimsal].[Providers] (
  [IdProvider] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [IdMachine] int,
  [NameProvider] varchar(60)
)
GO

CREATE TABLE [Taimsal].[Machine] (
  [IdMachine] int PRIMARY KEY IDENTITY(1, 1),
  [NameMachine] varchar(40),
  [ImageMachine] nvarchar(255)
)
GO

CREATE TABLE [Taimsal].[Attendance] (
  [IdAttendance] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [IdEmployee] int NOT NULL,
  [DayAttendence] date,
  [CheckInTime] time
)
GO

CREATE TABLE [Taimsal].[Employee] (
  [IdEmployee] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [IdMachine] int,
  [NameEmployee] varchar(30),
  [LastNameEmployee] varchar(30),
  [Rol] varchar(20)
)
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla roL 1-1',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'User',
@level2type = N'Column', @level2name = 'IdRol';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla Client 1<N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'User',
@level2type = N'Column', @level2name = 'IdClient';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla Product 1<N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'User',
@level2type = N'Column', @level2name = 'IdProduct';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla Provides 1<N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'User',
@level2type = N'Column', @level2name = 'IdProvider';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla IdAttendance 1<N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'User',
@level2type = N'Column', @level2name = 'IdAttendance';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla Employee 1<N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'User',
@level2type = N'Column', @level2name = 'IdEmployee';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Posible modificacion de tamaño',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'Product',
@level2type = N'Column', @level2name = 'NameProduct';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla Machine 1<N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'Providers',
@level2type = N'Column', @level2name = 'IdMachine';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Posible modificacion de tamaño',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'Machine',
@level2type = N'Column', @level2name = 'ImageMachine';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'tabla Employee 1>N',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'Attendance',
@level2type = N'Column', @level2name = 'IdEmployee';
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'Tabla Machine 1-1 ',
@level0type = N'Schema', @level0name = 'Taimsal',
@level1type = N'Table',  @level1name = 'Employee',
@level2type = N'Column', @level2name = 'IdMachine';
GO

ALTER TABLE [Taimsal].[User] ADD FOREIGN KEY ([IdRol]) REFERENCES [Taimsal].[Rol] ([IdRol])
GO

ALTER TABLE [Taimsal].[User] ADD FOREIGN KEY ([IdClient]) REFERENCES [Taimsal].[Client] ([IdClient])
GO

ALTER TABLE [Taimsal].[User] ADD FOREIGN KEY ([IdProduct]) REFERENCES [Taimsal].[Product] ([IdProduct])
GO

ALTER TABLE [Taimsal].[User] ADD FOREIGN KEY ([IdProvider]) REFERENCES [Taimsal].[Providers] ([IdProvider])
GO

ALTER TABLE [Taimsal].[User] ADD FOREIGN KEY ([IdAttendance]) REFERENCES [Taimsal].[Attendance] ([IdAttendance])
GO

ALTER TABLE [Taimsal].[User] ADD FOREIGN KEY ([IdEmployee]) REFERENCES [Taimsal].[Employee] ([IdEmployee])
GO

ALTER TABLE [Taimsal].[Providers] ADD FOREIGN KEY ([IdMachine]) REFERENCES [Taimsal].[Machine] ([IdMachine])
GO

ALTER TABLE [Taimsal].[Attendance] ADD FOREIGN KEY ([IdEmployee]) REFERENCES [Taimsal].[Employee] ([IdEmployee])
GO

ALTER TABLE [Taimsal].[Machine] ADD FOREIGN KEY ([IdMachine]) REFERENCES [Taimsal].[Employee] ([IdMachine])
GO
