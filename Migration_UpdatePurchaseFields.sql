BEGIN TRANSACTION;
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Purchase]') AND [c].[name] = N'Payment');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Purchase] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Purchase] DROP COLUMN [Payment];

ALTER TABLE [Purchase] ADD [CCV] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Purchase] ADD [CardNumber] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Purchase] ADD [CustomerPhoneNumber] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Purchase] ADD [Expiry] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251207212341_UpdatePurchaseFields', N'9.0.0');

COMMIT;
GO

