CREATE DATABASE ManageAuthorBooks
GO
USE ManageAuthorBooks
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Authors] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [DateOfBirthday] datetime2 NOT NULL,
    [Document] varchar(14) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [ISBN] varchar(20) NOT NULL,
    [Category] varchar(40) NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201227204052_InitialCreate', N'5.0.1');
GO

COMMIT;
GO

