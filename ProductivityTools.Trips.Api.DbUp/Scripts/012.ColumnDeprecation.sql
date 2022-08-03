ALTER TABLE [t].[Expense]
DROP COLUMN ValueAfterDiscount;
GO

EXEC sp_rename  '[t].[Expense].[Free]', 'Free_To_Delete', 'COLUMN';

EXEC sp_rename  '[t].[Expense].[Discount]', 'Discount_To_Delete', 'COLUMN';

