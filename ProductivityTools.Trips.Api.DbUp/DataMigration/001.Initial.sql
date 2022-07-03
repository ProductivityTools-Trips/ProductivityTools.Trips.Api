INSERT INTO [PTTrips].[t].Category(Name)
SELECT [Name]
FROM [Powershell].[mw].[Category]

INSERT INTO [PTTrips].[t].Currency(Name)
SELECT [Name]
FROM [Powershell].[mw].[Currency]

INSERT INTO [PTTrips].[t].Trip(
[Name],[DayCount],[Description],[Nights],[DateStart],[DateEnd],[Learnings])
SELECT [Name],[DayCount],[Description],[Nights],[DateStart],[DateEnd],[Learnings]
FROM [Powershell].[mw].[Bag]