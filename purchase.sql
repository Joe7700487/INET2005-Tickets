BEGIN TRANSACTION;
CREATE TABLE [Purchase] (
    [PurchaseId] int NOT NULL IDENTITY,
    [PurchaseDate] datetime2 NOT NULL,
    [ListingId] int NULL,
    CONSTRAINT [PK_Purchase] PRIMARY KEY ([PurchaseId]),
    CONSTRAINT [FK_Purchase_Listing_ListingId] FOREIGN KEY ([ListingId]) REFERENCES [Listing] ([ListingId])
);

CREATE INDEX [IX_Purchase_ListingId] ON [Purchase] ([ListingId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251117142452_Purchases', N'9.0.0');

ALTER TABLE [Purchase] DROP CONSTRAINT [FK_Purchase_Listing_ListingId];

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Purchase]') AND [c].[name] = N'PurchaseDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Purchase] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Purchase] DROP COLUMN [PurchaseDate];

DROP INDEX [IX_Purchase_ListingId] ON [Purchase];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Purchase]') AND [c].[name] = N'ListingId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Purchase] DROP CONSTRAINT [' + @var1 + '];');
UPDATE [Purchase] SET [ListingId] = 0 WHERE [ListingId] IS NULL;
ALTER TABLE [Purchase] ALTER COLUMN [ListingId] int NOT NULL;
ALTER TABLE [Purchase] ADD DEFAULT 0 FOR [ListingId];
CREATE INDEX [IX_Purchase_ListingId] ON [Purchase] ([ListingId]);

ALTER TABLE [Purchase] ADD [Customer] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Purchase] ADD [Payment] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Purchase] ADD [Tickets] int NOT NULL DEFAULT 0;

ALTER TABLE [Purchase] ADD CONSTRAINT [FK_Purchase_Listing_ListingId] FOREIGN KEY ([ListingId]) REFERENCES [Listing] ([ListingId]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251118173323_UpdatePurchase', N'9.0.0');

COMMIT;
GO

