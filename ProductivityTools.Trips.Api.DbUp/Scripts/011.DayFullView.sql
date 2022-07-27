
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
	  ,e.Cost
	  ,e.Expensed
  FROM [PTTrips].[t].[Trip] t
  LEFT JOIN expenses e ON t.TripId=e.TripId
GO

