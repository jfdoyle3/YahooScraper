CREATE TABLE [dbo].[RestSharpStocks] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [DateStamp]  DATETIME2 (7) NULL,
    [Symbol]     NVARCHAR (50) NULL,
    [Change]     NVARCHAR (50) NULL,
    [MarketTime] NVARCHAR (50) NULL,
    [ChgPct]     NVARCHAR (50) NULL,
    [Price]      NVARCHAR (50) NULL,
    [Closing]    NVARCHAR (50) NULL,
    [Method]     NVARCHAR (50) NULL,

    CONSTRAINT [PK_RestSharpStocks] PRIMARY KEY CLUSTERED ([ID] ASC)
);