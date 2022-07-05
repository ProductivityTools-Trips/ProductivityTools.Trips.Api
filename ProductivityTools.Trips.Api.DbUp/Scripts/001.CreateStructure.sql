CREATE SCHEMA t;
GO;


CREATE TABLE [t].[Trip](
	[TripId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[DayCount] [int] NULL,
	[Description] [VARCHAR](MAX) NULL,
	[Nights] [int] NULL,
	[DateStart] [date] NULL,
	[DateEnd] [date] NULL,
	[Learnings] [varchar](1000) NULL,
	Constraint PK_TripId PRIMARY KEY (TripId)
	)


	CREATE TABLE [t].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	Constraint PK_CategoryId PRIMARY KEY (CategoryId)
	)


	CREATE TABLE [t].[Currency](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	Constraint PK_CurrencyId PRIMARY KEY (CurrencyId)
	)

	CREATE TABLE [t].[TripCurrency](
	[TripCurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[TripId] [int] NOT NULL,
	[Value] [decimal](5, 3) NOT NULL,
	CONSTRAINT PK_TripCurrencyId PRIMARY KEY (TripCurrencyId),
	CONSTRAINT FK_TripCurrency_Trip FOREIGN KEY (TripId) REFERENCES [t].[Trip],
	CONSTRAINT FK_TripCurrency_Currency FOREIGN KEY (CurrencyId) REFERENCES [t].[Currency]
	)

	CREATE TABLE [t].[Expense](
	[ExpenseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NULL,
	[CategoryId] [int] NULL,
	TripId [int] NULL,
	[Date] [datetime] NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[CurrencyId] [int] NULL,
	[Value] [decimal](6, 2) NULL,
	[Free] [bit] NOT NULL,
	[Discount] [decimal](7, 2) NOT NULL,
	[ValueAfterDiscount]  AS ([Value]-[Discount]),
	CONSTRAINT PK_ExpenseId PRIMARY KEY ([ExpenseId]),
	CONSTRAINT FK_Expense_Trip FOREIGN KEY (TripId) REFERENCES [t].Trip(TripId),
	CONSTRAINT FK_Expense_Category FOREIGN KEY (CategoryId) REFERENCES [t].Category(CategoryId),
	CONSTRAINT FK_Expense_Currency FOREIGN KEY (CurrencyId) REFERENCES [t].Currency(CurrencyId),

)

ALTER TABLE t.[Expense] ADD  CONSTRAINT [def_false]  DEFAULT ((0)) FOR [Free]
ALTER TABLE t.[Expense] ADD  DEFAULT ((0)) FOR [Discount]






