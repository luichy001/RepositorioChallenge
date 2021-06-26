CREATE TABLE [dbo].[Item]
(
	[IdItem] INT  IDENTITY (1, 1) NOT NULL,
    [descricao] VARCHAR(150) NULL, 
    [precoUnitario] DECIMAL NULL, 
    [qtd] INT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([IdItem] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Item_01]
    ON [dbo].[Item]([descricao] ASC);
