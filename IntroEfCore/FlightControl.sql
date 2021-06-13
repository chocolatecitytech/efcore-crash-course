--STEP 1
--Create a Database called FlightControl

--STEP 2 
--Create all required tables
/*
[dbo].[Flights]
*/
CREATE TABLE [dbo].[Flights](
	[Id] [bigint] NOT NULL,
	[FlightName] [nvarchar](500) NULL,
	[FromLocation] [nvarchar](100) NOT NULL,
	[ToLocation] [nvarchar](100) NOT NULL,
	[Departure] [datetime] NOT NULL,
	[Arrival] [datetime] NOT NULL,
	[TotalSeat] [int] NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*
[dbo].[FlightDetails]
*/
CREATE TABLE [dbo].[FlightDetails](
	[Key] [uniqueidentifier] NOT NULL,
	[Price] [money] NOT NULL,
	[ChiefPilot] [nvarchar](100) NOT NULL,
	[SecondaryPilot] [nvarchar](100) NULL,
	[AvailableSeats] [int] NULL,
	[FlightId] [bigint] NOT NULL,
 CONSTRAINT [PK_FlightDetails] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FlightDetails]  WITH CHECK ADD  CONSTRAINT [FK_FlightDetails_Flights] FOREIGN KEY([FlightId])
REFERENCES [dbo].[Flights] ([Id])
GO

ALTER TABLE [dbo].[FlightDetails] CHECK CONSTRAINT [FK_FlightDetails_Flights]
GO

/*
[dbo].[Passengers]
*/
CREATE TABLE [dbo].[Passengers](
	[Key] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Passengers] ADD  CONSTRAINT [DF_Passenger_Key]  DEFAULT (newid()) FOR [Key]
GO

/*
[dbo].[DiscountTypes]
*/
CREATE TABLE [dbo].[DiscountTypes](
	[Key] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_DiscountType] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*
[dbo].[Discounts]
*/
CREATE TABLE [dbo].[Discounts](
	[Key] [uniqueidentifier] NOT NULL,
	[DiscountTypeId] [uniqueidentifier] NOT NULL,
	[DiscountAmount] [int] NULL,
 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD  CONSTRAINT [FK_Discounts_DiscountType] FOREIGN KEY([DiscountTypeId])
REFERENCES [dbo].[DiscountTypes] ([Key])
GO

ALTER TABLE [dbo].[Discounts] CHECK CONSTRAINT [FK_Discounts_DiscountType]
GO

/*
[dbo].[CreditCards]
*/
CREATE TABLE [dbo].[CreditCards](
	[Key] [uniqueidentifier] NOT NULL,
	[CardNumber] [varchar](50) NOT NULL,
	[CardType] [nvarchar](50) NOT NULL,
	[Expires] [date] NOT NULL,
	[PassengerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CreditCards] ADD  CONSTRAINT [DF_CreditCard_Key]  DEFAULT (newid()) FOR [Key]
GO

ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCard_Passenger] FOREIGN KEY([PassengerId])
REFERENCES [dbo].[Passengers] ([Key])
GO

ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCard_Passenger]
GO

/*
[dbo].[Tickets]
*/
CREATE TABLE [dbo].[Tickets](
	[Key] [uniqueidentifier] NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[FlightId] [bigint] NOT NULL,
	[PassengerId] [uniqueidentifier] NOT NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_FlightId] FOREIGN KEY([FlightId])
REFERENCES [dbo].[Flights] ([Id])
GO

ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_FlightId]
GO

ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Passengers] FOREIGN KEY([PassengerId])
REFERENCES [dbo].[Passengers] ([Key])
GO

ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Passengers]
GO




--STEP 3 
---SEED DATA


--discounttypes
INSERT INTO [dbo].[DiscountTypes]
           ([Key]
           ,[Name])
     VALUES
           ('69600258-fbf5-49c3-a32c-afd57ff76c6e','percent'),
		   ('3ffd1464-08e0-4aba-8da2-1b7d8db520b7','flat-rate')
GO


--flights
INSERT INTO [dbo].[Flights]
           ([Id]
           ,[FlightName]
           ,[FromLocation]
           ,[ToLocation]
           ,[Departure]
           ,[Arrival]
           ,[TotalSeat])
     VALUES
           (1,'To Ghana and Back','DC','Ghana','2021-06-07 08:00','2021-06-07 20:00',900),
		   (2,'Aloha','NYC','Hawaii','2021-07-17 10:00','2021-06-07 20:00',700),
		   (3,'Windy City','ATL','Chicago','2021-08-17 10:00','2021-06-07 15:00',600)
GO
--passengers
INSERT INTO [dbo].[Passengers]
           ([Key]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[Phone]
           ,[Email])
     VALUES
           ('17e13d53-193c-476f-ba41-b939ac0c5a46','Deeroc','Man','12 DC road','111-111-1111','deeroc@dc.com'),
		   ('9fb3311e-ebb0-4be0-ab2a-c000d64f9c97','Buyer1','Doe','56 Main road','111-111-1112','buyer1@dc.com'),
		   ('cf054a3d-9a97-43d6-8f50-0dba7b0f0dff','Passenger1','LastName','5 Passenger Road','111-111-1114','Passenger1@dc.com'),
		   ('5606eabf-5666-4691-8ac6-2a62cb65efd9','Passenger56','Snipes','56 Passenger Road','111-111-1115','Passenger56@dc.com')
GO
