-- Trip type: who the trip is with. Drives which expense amount fields are
-- editable in the web app (Family / Friends / Company).
ALTER TABLE [t].[Trip]
    ADD TripType VARCHAR(20) NOT NULL
        CONSTRAINT DF_Trip_TripType DEFAULT 'Family';
GO

ALTER TABLE [t].[Trip] WITH CHECK
    ADD CONSTRAINT CK_Trip_TripType CHECK (TripType IN ('Family', 'Friends', 'Company'));
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
      ,e.Cost
      ,e.Expensed
  FROM [t].[Trip] t
  LEFT JOIN expenses e ON t.TripId=e.TripId
GO
