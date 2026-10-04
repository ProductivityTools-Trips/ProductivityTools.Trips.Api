-- Optional trip category (Ski, CityBreak, Vacations, Festival, Spain).
-- Nullable: existing and new trips have no category until one is picked.
ALTER TABLE [t].[Trip]
    ADD TripCategory VARCHAR(20) NULL;
GO

ALTER TABLE [t].[Trip] WITH CHECK
    ADD CONSTRAINT CK_Trip_TripCategory
        CHECK (TripCategory IS NULL OR TripCategory IN ('Ski', 'CityBreak', 'Vacations', 'Festival', 'Spain'));
GO

ALTER VIEW [t].[TripFullView]
AS
    with expenses as
    (
    SELECT e.tripid, sum(e.ValuePln) as Cost
          ,sum(e.ExpensedInPln) as Expensed
          FROM  t.ExpenseFullView e
          GROUP BY e.TripId
    )

SELECT t.[TripId]
      ,t.[Name]
      ,[DayCount]
      ,[Description]
      ,[Nights]
      ,[DateStart]
      ,[DateEnd]
      ,[Learnings]
      ,t.[TripType]
      ,t.[TripCategory]
      ,e.Cost
      ,e.Expensed
  FROM [t].[Trip] t
  LEFT JOIN expenses e ON t.TripId=e.TripId
GO
