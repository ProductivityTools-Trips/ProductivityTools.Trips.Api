-- Seed [t].[Category] with a fixed set of categories and stable CategoryId values.
-- Idempotent: safe to run on an empty test database as well as on production,
-- where some of these rows may already exist. Follows the same rules as
-- 023.CurrencySeed.sql.
DECLARE @Seed TABLE (CategoryId INT NOT NULL, Name VARCHAR(20) NOT NULL);
INSERT INTO @Seed (CategoryId, Name) VALUES
    (1, 'Food'),
    (2, 'Restaurant'),
    (3, 'Car-Fuel'),
    (4, 'Sleep'),
    (5, 'Fun'),
    (6, 'Other'),
    (7, 'Car-Other');

-- A category that exists under the wrong id and is not referenced anywhere
-- (fresh database) is removed so it can be re-inserted with the expected id.
DELETE c
FROM [t].[Category] c
JOIN @Seed s ON s.Name = c.Name AND s.CategoryId <> c.CategoryId
WHERE NOT EXISTS (SELECT 1 FROM [t].[Expense] e WHERE e.CategoryId = c.CategoryId);

SET IDENTITY_INSERT [t].[Category] ON;

-- Insert missing categories under their expected id when that id is free.
INSERT INTO [t].[Category] (CategoryId, Name)
SELECT s.CategoryId, s.Name
FROM @Seed s
WHERE NOT EXISTS (SELECT 1 FROM [t].[Category] c WHERE c.CategoryId = s.CategoryId)
  AND NOT EXISTS (SELECT 1 FROM [t].[Category] c WHERE c.Name = s.Name);

SET IDENTITY_INSERT [t].[Category] OFF;

-- Fallback: a category whose expected id is occupied by a different, referenced
-- category must still exist - insert it with an identity-assigned id.
INSERT INTO [t].[Category] (Name)
SELECT s.Name
FROM @Seed s
WHERE NOT EXISTS (SELECT 1 FROM [t].[Category] c WHERE c.Name = s.Name);
