IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201228172506_Workshops')
BEGIN
    CREATE TABLE [Workshops] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [PlacesAvailable] int NULL,
        [RegistrationLink] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [RegistrationOpened] bit NOT NULL,
        [Prerequisites] nvarchar(max) NULL,
        [ShortDescription] nvarchar(max) NULL,
        CONSTRAINT [PK_Workshops] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201228172506_Workshops')
BEGIN
    CREATE TABLE [Speakers] (
        [ID] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Company] nvarchar(max) NULL,
        [WebSite] nvarchar(max) NULL,
        [JobTitle] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [WorkshopID] int NULL,
        CONSTRAINT [PK_Speakers] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Speakers_Workshops_WorkshopID] FOREIGN KEY ([WorkshopID]) REFERENCES [Workshops] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201228172506_Workshops')
BEGIN
    CREATE TABLE [Talks] (
        [ID] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Level] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [FeedbackEnabled] bit NOT NULL,
        [SpeakerID] int NOT NULL,
        CONSTRAINT [PK_Talks] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Talks_Speakers_SpeakerID] FOREIGN KEY ([SpeakerID]) REFERENCES [Speakers] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201228172506_Workshops')
BEGIN
    CREATE INDEX [IX_Speakers_WorkshopID] ON [Speakers] ([WorkshopID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201228172506_Workshops')
BEGIN
    CREATE INDEX [IX_Talks_SpeakerID] ON [Talks] ([SpeakerID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201228172506_Workshops')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201228172506_Workshops', N'3.1.10');
END;

GO

