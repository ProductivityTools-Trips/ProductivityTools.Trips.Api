CREATE VIEW t.TripCurrencyFullView
AS
SELECT  [TripCurrencyId]
	  ,TripId
      ,c.[CurrencyId]
	  ,c.Name as CurrencyName
      ,[Value]
  FROM [PTTrips].[t].[TripCurrency] TC
  inner join [t].Currency c on TC.CurrencyId=c.CurrencyId