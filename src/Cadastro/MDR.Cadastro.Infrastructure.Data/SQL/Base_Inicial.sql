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
CREATE TABLE [Departamentos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] Varchar(60) NOT NULL,
    CONSTRAINT [PK_Departamentos] PRIMARY KEY ([Id])
);

CREATE TABLE [Pessoas] (
    [Id] uniqueidentifier NOT NULL,
    [DepartamentoId] uniqueidentifier NOT NULL,
    [Nome] Varchar(60) NOT NULL,
    [SobreNome] Varchar(60) NOT NULL,
    [Idade] Integer NOT NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoas_Departamentos_DepartamentoId] FOREIGN KEY ([DepartamentoId]) REFERENCES [Departamentos] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Pessoas_DepartamentoId] ON [Pessoas] ([DepartamentoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250324114248_Inicializando_DataBase', N'9.0.3');

COMMIT;
GO

