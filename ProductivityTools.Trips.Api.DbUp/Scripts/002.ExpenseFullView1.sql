
CREATE VIEW t.ExpenseFullView as

select e.TripId, t.Name as TripName, e.ExpenseId, e.name as 'ExpenseName' ,e.Date, c.CategoryId, cc.Name as 'CategoryName', cc.CurrencyId, c.Name as 'CurrencyName', e.Value,e.Discount, e.ValueAfterDiscount,
 tc.value as 'Exchange', 
 e.Value*ISNULL(tc.Value,1) as 'PLN',
 e.ValueAfterDiscount*ISNULL(tc.Value,1) as 'PLNAfterDiscount',
 SUM(e.Value*ISNULL(tc.Value,1) ) over (partition by [Date]) as 'DayInPln' 
 from t.Expense e
inner join t.Category c ON e.CategoryId=c.CategoryId
inner join t.currency cc on e.CurrencyId=cc.CurrencyId
left JOIN t.TripCurrency tc ON tc.CurrencyId=e.CurrencyId and tc.TripId=e.tripId
inner join t.Trip t on t.TripId=e.TripId
