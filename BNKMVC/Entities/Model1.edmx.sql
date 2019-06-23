
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/18/2019 20:12:38
-- Generated from EDMX file: D:\ProJects\CryptoHaz\BNKMVC\Entities\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CryptoBank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetUsers_Countries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Countries];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_ForwardTransfer_tblAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForwardTransfer] DROP CONSTRAINT [FK_ForwardTransfer_tblAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccount_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccount] DROP CONSTRAINT [FK_tblAccount_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRegister_tblAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRegister] DROP CONSTRAINT [FK_tblRegister_tblAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionCode_tblAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionCode] DROP CONSTRAINT [FK_TransactionCode_tblAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[ForwardTransfer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForwardTransfer];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccount];
GO
IF OBJECT_ID(N'[dbo].[tblAdminLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAdminLogin];
GO
IF OBJECT_ID(N'[dbo].[tblfeedbacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblfeedbacks];
GO
IF OBJECT_ID(N'[dbo].[tblLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLogins];
GO
IF OBJECT_ID(N'[dbo].[tblRegister]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRegister];
GO
IF OBJECT_ID(N'[dbo].[tblTransfer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTransfer];
GO
IF OBJECT_ID(N'[dbo].[TransactionCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionCode];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [DateStamp] datetime  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [CountryId] varchar(50)  NULL,
    [ImageUrl] nvarchar(max)  NULL,
    [Sex] nvarchar(max)  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Alph3Code] varchar(50)  NOT NULL,
    [Name] varchar(max)  NULL
);
GO

-- Creating table 'ForwardTransfers'
CREATE TABLE [dbo].[ForwardTransfers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AccountID] varchar(50)  NULL,
    [BeneficaryBank] varchar(50)  NULL,
    [BeneficaryName] varchar(50)  NULL,
    [DestinationAccountNo] varchar(50)  NULL,
    [BeneficarySwiftCode] int  NULL,
    [BeneficaryAddress] varchar(1000)  NULL,
    [IBAN] varchar(50)  NULL,
    [Amount] decimal(18,2)  NULL,
    [Purpose] varchar(500)  NULL,
    [Status] varchar(50)  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tblAccounts'
CREATE TABLE [dbo].[tblAccounts] (
    [acctNo] varchar(50)  NOT NULL,
    [ActiveAmount] decimal(18,2)  NULL,
    [currency] varchar(50)  NULL,
    [userId] nvarchar(128)  NULL
);
GO

-- Creating table 'tblAdminLogins'
CREATE TABLE [dbo].[tblAdminLogins] (
    [id] int IDENTITY(1,1) NOT NULL,
    [AdminUsername] varchar(50)  NULL,
    [AdminPassword] varchar(50)  NULL,
    [role] varchar(50)  NULL
);
GO

-- Creating table 'tblfeedbacks'
CREATE TABLE [dbo].[tblfeedbacks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Clientname] varchar(50)  NULL,
    [email] varchar(50)  NULL,
    [Message] varchar(max)  NULL,
    [datesent] varchar(50)  NULL
);
GO

-- Creating table 'tblLogins'
CREATE TABLE [dbo].[tblLogins] (
    [loginId] int IDENTITY(1,1) NOT NULL,
    [LoginUsername] varchar(max)  NULL,
    [LoginPassword] varchar(50)  NULL,
    [status] varchar(50)  NULL
);
GO

-- Creating table 'tblRegisters'
CREATE TABLE [dbo].[tblRegisters] (
    [tblRegID] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Othername] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [phone] varchar(50)  NULL,
    [address] varchar(400)  NULL,
    [AccountType] varchar(50)  NULL,
    [DOB] varchar(50)  NULL,
    [AccountNo] varchar(50)  NOT NULL,
    [password] varchar(50)  NOT NULL,
    [currencyType] varchar(50)  NULL
);
GO

-- Creating table 'tblTransfers'
CREATE TABLE [dbo].[tblTransfers] (
    [transferID] int IDENTITY(1,1) NOT NULL,
    [AcctNo] varchar(50)  NULL,
    [RecipientAcctNo] varchar(50)  NULL,
    [IBAN] varchar(50)  NULL,
    [BIC] varchar(50)  NULL,
    [RoutingNumber] varchar(50)  NULL,
    [Amount] varchar(50)  NULL,
    [Status] varchar(50)  NULL,
    [DateSent] varchar(50)  NULL
);
GO

-- Creating table 'TransactionCodes'
CREATE TABLE [dbo].[TransactionCodes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountNo] varchar(50)  NULL,
    [COT] varchar(50)  NULL,
    [TAX] varchar(50)  NULL,
    [IMF] varchar(50)  NULL,
    [DateGenerated] datetime  NULL,
    [Status] varchar(50)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Alph3Code] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Alph3Code] ASC);
GO

-- Creating primary key on [ID] in table 'ForwardTransfers'
ALTER TABLE [dbo].[ForwardTransfers]
ADD CONSTRAINT [PK_ForwardTransfers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [acctNo] in table 'tblAccounts'
ALTER TABLE [dbo].[tblAccounts]
ADD CONSTRAINT [PK_tblAccounts]
    PRIMARY KEY CLUSTERED ([acctNo] ASC);
GO

-- Creating primary key on [id] in table 'tblAdminLogins'
ALTER TABLE [dbo].[tblAdminLogins]
ADD CONSTRAINT [PK_tblAdminLogins]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tblfeedbacks'
ALTER TABLE [dbo].[tblfeedbacks]
ADD CONSTRAINT [PK_tblfeedbacks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [loginId] in table 'tblLogins'
ALTER TABLE [dbo].[tblLogins]
ADD CONSTRAINT [PK_tblLogins]
    PRIMARY KEY CLUSTERED ([loginId] ASC);
GO

-- Creating primary key on [tblRegID] in table 'tblRegisters'
ALTER TABLE [dbo].[tblRegisters]
ADD CONSTRAINT [PK_tblRegisters]
    PRIMARY KEY CLUSTERED ([tblRegID] ASC);
GO

-- Creating primary key on [transferID] in table 'tblTransfers'
ALTER TABLE [dbo].[tblTransfers]
ADD CONSTRAINT [PK_tblTransfers]
    PRIMARY KEY CLUSTERED ([transferID] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionCodes'
ALTER TABLE [dbo].[TransactionCodes]
ADD CONSTRAINT [PK_TransactionCodes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [CountryId] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [FK_AspNetUsers_Countries]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([Alph3Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUsers_Countries'
CREATE INDEX [IX_FK_AspNetUsers_Countries]
ON [dbo].[AspNetUsers]
    ([CountryId]);
GO

-- Creating foreign key on [userId] in table 'tblAccounts'
ALTER TABLE [dbo].[tblAccounts]
ADD CONSTRAINT [FK_tblAccount_AspNetUsers]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccount_AspNetUsers'
CREATE INDEX [IX_FK_tblAccount_AspNetUsers]
ON [dbo].[tblAccounts]
    ([userId]);
GO

-- Creating foreign key on [AccountID] in table 'ForwardTransfers'
ALTER TABLE [dbo].[ForwardTransfers]
ADD CONSTRAINT [FK_ForwardTransfer_tblAccount]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[tblAccounts]
        ([acctNo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ForwardTransfer_tblAccount'
CREATE INDEX [IX_FK_ForwardTransfer_tblAccount]
ON [dbo].[ForwardTransfers]
    ([AccountID]);
GO

-- Creating foreign key on [AccountNo] in table 'tblRegisters'
ALTER TABLE [dbo].[tblRegisters]
ADD CONSTRAINT [FK_tblRegister_tblAccount]
    FOREIGN KEY ([AccountNo])
    REFERENCES [dbo].[tblAccounts]
        ([acctNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRegister_tblAccount'
CREATE INDEX [IX_FK_tblRegister_tblAccount]
ON [dbo].[tblRegisters]
    ([AccountNo]);
GO

-- Creating foreign key on [AccountNo] in table 'TransactionCodes'
ALTER TABLE [dbo].[TransactionCodes]
ADD CONSTRAINT [FK_TransactionCode_tblAccount]
    FOREIGN KEY ([AccountNo])
    REFERENCES [dbo].[tblAccounts]
        ([acctNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionCode_tblAccount'
CREATE INDEX [IX_FK_TransactionCode_tblAccount]
ON [dbo].[TransactionCodes]
    ([AccountNo]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------