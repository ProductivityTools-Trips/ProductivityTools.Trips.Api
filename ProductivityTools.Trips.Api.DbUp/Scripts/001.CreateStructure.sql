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




