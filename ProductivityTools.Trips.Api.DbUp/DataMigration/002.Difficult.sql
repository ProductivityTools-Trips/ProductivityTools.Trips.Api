/****** Script for SelectTopNRows command from SSMS  ******/
with x as
(
SELECT  bc.[BagCurrencyID]
      ,bc.[CurrencyID]
      ,bc.[BagID]
      ,bc.[Value]
	  ,b.Name AS oldBagName
	  ,c.Name AS oldCurrencyName
	  ,nc.CurrencyId as newCurrencyId
	  ,t.TripId as newTripId
  FROM [Powershell].[mw].[BagCurrency] bc
  INNER JOIN [Powershell].[mw].Bag b ON BC.BagID=B.BagID
  INNER JOIN [Powershell].[mw].Currency c ON c.CurrencyID=bc.CurrencyID
  INNER JOIN [PTTrips].[t].Currency nc ON nc.Name=c.Name COLLATE Polish_CI_AS
  INNER JOIN [PTTrips].t.Trip	t ON t.Name=b.Name COLLATE Polish_CI_AS
  )
  INSERT INTO PTTrips.T.TripCurrency (CurrencyId,TripId,Value)
  SELECT newCurrencyId, newTripId,value FROM X