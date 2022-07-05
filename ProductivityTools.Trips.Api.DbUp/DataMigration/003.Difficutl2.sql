with x as (

SELECT [ExpenseID]
      ,e.[Name]
      ,[Date]
      ,[TimeStamp]
      ,[Value]
      ,[Free]
      ,[Discount]
      ,[ValueAfterDiscount]
	  ,cat.Name as CategoryName
	  ,cur.Name as CurrencyName
	  ,b.Name as BagName
	  ,tripsCategory.CategoryId as tripsCategoryId
	  ,tripsCurrency.CurrencyId as tripsCurrencyId
	  ,trip.TripId as tripId
  FROM [Powershell].[mw].[Expense] e
  inner join mw.Category cat ON e.CategoryID=cat.CategoryID
  inner join mw.Currency cur ON e.CurrencyID=cur.CurrencyID
  inner join mw.Bag b ON e.BagID=b.BagID
  inner join PTTrips.t.Category tripsCategory ON tripsCategory.Name=cat.Name COLLATE Polish_CI_AS
  inner join PTTrips.t.Currency tripsCurrency ON tripsCurrency.Name=cur.Name COLLATE Polish_CI_AS
  inner join PTTrips.t.Trip trip ON trip.Name=b.Name COLLATE Polish_CI_AS
  )
  insert into PTTrips.t.Expense (Name,Date,Value,Free,Discount,CategoryId,CurrencyId,TripId) 
  select x.Name,x.Date,x.Value,x.Free,x.Discount,x.tripsCategoryId,x.tripsCurrencyId,x.TripId from x