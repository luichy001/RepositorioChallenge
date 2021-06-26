CREATE TABLE [dbo].[Pedido]
(
	[IdPedido]  INT           IDENTITY (1, 1) NOT NULL, 
    [Pedido] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([IdPedido] ASC),
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Pedido_01]
    ON [dbo].[Pedido]([Pedido] ASC);

