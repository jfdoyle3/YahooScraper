CREATE TABLE [dbo].[ScrapedStocks] (
    [ID]         INT         IDENTITY (1, 1) NOT NULL,
    [DateStamp]  DATETIME2 (7)  NULL,
    [Symbol]     NVARCHAR (50) NULL,
	[Change]     NVARCHAR (50) NULL,
	[MarketTime] NVARCHAR (50) NULL,
	[ChgPct]      NVARCHAR (50) NULL,
    [LastPrice]  NVARCHAR (50) NULL,
    [Volume]     NVARCHAR (50) NULL,
    [AvgVol3m]   NVARCHAR (50) NULL,
    [MarketCap]  NVARCHAR (50) NULL,
	[Price]     NVARCHAR (50) NULL,
    [Closing]   NVARCHAR (50) NULL,
	[Method]     NVARCHAR (50) NULL,

    CONSTRAINT [PK_ScrapedStocks] PRIMARY KEY CLUSTERED ([ID] ASC)
);