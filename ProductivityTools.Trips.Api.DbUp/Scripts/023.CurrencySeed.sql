-- Seed [t].[Currency] with a fixed set of currencies and stable CurrencyId values.
-- Idempotent: safe to run on an empty test database as well as on production,
-- where some of these rows already exist (e.g. USD inserted by 022.Dollars.sql).
DECLARE @Seed TABLE (CurrencyId INT NOT NULL, Name VARCHAR(20) NOT NULL);
INSERT INTO @Seed (CurrencyId, Name) VALUES
    (1, 'HRK'),
    (2, 'EUR'),
    (3, 'PLN'),
    (4, 'DKK'),
    (5, 'NOK'),
    (6, 'SEK'),
    (7, 'CZK'),
    (8, 'USD');

-- A currency that exists under the wrong id and is not referenced anywhere
-- (fresh database) is removed so it can be re-inserted with the expected id.
DELETE c
FROM [t].[Currency] c
JOIN @Seed s ON s.Name = c.Name AND s.CurrencyId <> c.CurrencyId
WHERE NOT EXISTS (SELECT 1 FROM [t].[Expense] e WHERE e.CurrencyId = c.CurrencyId)
  AND NOT EXISTS (SELECT 1 FROM [t].[TripCurrency] tc WHERE tc.CurrencyId = c.CurrencyId);

SET IDENTITY_INSERT [t].[Currency] ON;

-- Insert missing currencies under their expected id when that id is free.
INSERT INTO [t].[Currency] (CurrencyId, Name)
SELECT s.CurrencyId, s.Name
FROM @Seed s
WHERE NOT EXISTS (SELECT 1 FROM [t].[Currency] c WHERE c.CurrencyId = s.CurrencyId)
  AND NOT EXISTS (SELECT 1 FROM [t].[Currency] c WHERE c.Name = s.Name);

SET IDENTITY_INSERT [t].[Currency] OFF;

-- Fallback: a currency whose expected id is occupied by a different, referenced
-- currency must still exist - insert it with an identity-assigned id.
INSERT INTO [t].[Currency] (Name)
SELECT s.Name
FROM @Seed s
WHERE NOT EXISTS (SELECT 1 FROM [t].[Currency] c WHERE c.Name = s.Name);
