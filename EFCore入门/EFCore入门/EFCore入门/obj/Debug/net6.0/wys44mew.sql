BEGIN TRANSACTION;
GO

CREATE UNIQUE INDEX [IX_T_Dog_Name] ON [T_Dog] ([Name]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516082850_ModifyDog', N'7.0.5');
GO

COMMIT;
GO

