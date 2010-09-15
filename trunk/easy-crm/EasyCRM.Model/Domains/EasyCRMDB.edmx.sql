
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2010 10:37:02
-- Generated from EDMX file: G:\Documents\VisualStudio\EasyCRM\EasyCRM.Model\Domains\EasyCRMModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EasyCRMDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactSet] DROP CONSTRAINT [FK_UserContact];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSet] DROP CONSTRAINT [FK_UserAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOpportunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OpportunitySet] DROP CONSTRAINT [FK_UserOpportunity];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_UserTask];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountIndustrialSector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSet] DROP CONSTRAINT [FK_AccountIndustrialSector];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountOpportunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OpportunitySet] DROP CONSTRAINT [FK_AccountOpportunity];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_TaskAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_TaskContact];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactSet] DROP CONSTRAINT [FK_AccountContact];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[AccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSet];
GO
IF OBJECT_ID(N'[dbo].[ContactSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactSet];
GO
IF OBJECT_ID(N'[dbo].[TaskSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskSet];
GO
IF OBJECT_ID(N'[dbo].[OpportunitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OpportunitySet];
GO
IF OBJECT_ID(N'[dbo].[IndustrialSectorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IndustrialSectorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [IsAdmin] bit  NOT NULL
);
GO

-- Creating table 'AccountSet'
CREATE TABLE [dbo].[AccountSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Owner_Id] int  NOT NULL,
    [IndustrialSector_Id] int  NOT NULL
);
GO

-- Creating table 'ContactSet'
CREATE TABLE [dbo].[ContactSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [ResponsibleUser_Id] int  NOT NULL,
    [Account_Id] int  NOT NULL
);
GO

-- Creating table 'TaskSet'
CREATE TABLE [dbo].[TaskSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [LimitDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Priority] nvarchar(max)  NOT NULL,
    [ResponsibleUser_Id] int  NOT NULL,
    [Account_Id] int  NULL,
    [Contact_Id] int  NULL
);
GO

-- Creating table 'OpportunitySet'
CREATE TABLE [dbo].[OpportunitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ResponsibleUser_Id] int  NOT NULL,
    [Account_Id] int  NOT NULL
);
GO

-- Creating table 'IndustrialSectorSet'
CREATE TABLE [dbo].[IndustrialSectorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sector] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccountSet'
ALTER TABLE [dbo].[AccountSet]
ADD CONSTRAINT [PK_AccountSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactSet'
ALTER TABLE [dbo].[ContactSet]
ADD CONSTRAINT [PK_ContactSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [PK_TaskSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OpportunitySet'
ALTER TABLE [dbo].[OpportunitySet]
ADD CONSTRAINT [PK_OpportunitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndustrialSectorSet'
ALTER TABLE [dbo].[IndustrialSectorSet]
ADD CONSTRAINT [PK_IndustrialSectorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ResponsibleUser_Id] in table 'ContactSet'
ALTER TABLE [dbo].[ContactSet]
ADD CONSTRAINT [FK_UserContact]
    FOREIGN KEY ([ResponsibleUser_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserContact'
CREATE INDEX [IX_FK_UserContact]
ON [dbo].[ContactSet]
    ([ResponsibleUser_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'AccountSet'
ALTER TABLE [dbo].[AccountSet]
ADD CONSTRAINT [FK_UserAccount]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAccount'
CREATE INDEX [IX_FK_UserAccount]
ON [dbo].[AccountSet]
    ([Owner_Id]);
GO

-- Creating foreign key on [ResponsibleUser_Id] in table 'OpportunitySet'
ALTER TABLE [dbo].[OpportunitySet]
ADD CONSTRAINT [FK_UserOpportunity]
    FOREIGN KEY ([ResponsibleUser_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOpportunity'
CREATE INDEX [IX_FK_UserOpportunity]
ON [dbo].[OpportunitySet]
    ([ResponsibleUser_Id]);
GO

-- Creating foreign key on [ResponsibleUser_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_UserTask]
    FOREIGN KEY ([ResponsibleUser_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTask'
CREATE INDEX [IX_FK_UserTask]
ON [dbo].[TaskSet]
    ([ResponsibleUser_Id]);
GO

-- Creating foreign key on [IndustrialSector_Id] in table 'AccountSet'
ALTER TABLE [dbo].[AccountSet]
ADD CONSTRAINT [FK_AccountIndustrialSector]
    FOREIGN KEY ([IndustrialSector_Id])
    REFERENCES [dbo].[IndustrialSectorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountIndustrialSector'
CREATE INDEX [IX_FK_AccountIndustrialSector]
ON [dbo].[AccountSet]
    ([IndustrialSector_Id]);
GO

-- Creating foreign key on [Account_Id] in table 'OpportunitySet'
ALTER TABLE [dbo].[OpportunitySet]
ADD CONSTRAINT [FK_AccountOpportunity]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[AccountSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountOpportunity'
CREATE INDEX [IX_FK_AccountOpportunity]
ON [dbo].[OpportunitySet]
    ([Account_Id]);
GO

-- Creating foreign key on [Account_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_TaskAccount]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[AccountSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskAccount'
CREATE INDEX [IX_FK_TaskAccount]
ON [dbo].[TaskSet]
    ([Account_Id]);
GO

-- Creating foreign key on [Contact_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_TaskContact]
    FOREIGN KEY ([Contact_Id])
    REFERENCES [dbo].[ContactSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskContact'
CREATE INDEX [IX_FK_TaskContact]
ON [dbo].[TaskSet]
    ([Contact_Id]);
GO

-- Creating foreign key on [Account_Id] in table 'ContactSet'
ALTER TABLE [dbo].[ContactSet]
ADD CONSTRAINT [FK_AccountContact]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[AccountSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountContact'
CREATE INDEX [IX_FK_AccountContact]
ON [dbo].[ContactSet]
    ([Account_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------