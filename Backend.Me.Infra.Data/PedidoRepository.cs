using Backend.Me.Contracts;
using Backend.Me.Domain.Contracts.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Backend.Me.Infra.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnection _contextManager;

        private readonly IConfiguration _configuration;
        public PedidoRepository(IDbConnection contextManager, IConfiguration configuration)
        {
            _contextManager = contextManager;
            _configuration = configuration;
        }

        public int Add(PedidoModel entity)
        {
            string dataConnectionString = _configuration["ConnectionStrings:SQLConnection"];
            int idPedido = 0;
            int idItem = 0;
            int id = 0;
            using (IDbConnection db = new SqlConnection(dataConnectionString))
            {
                idPedido = db.QuerySingle<int>($@"
                        INSERT INTO Pedido  VALUES  ( @entity ) ;
                        SELECT CAST(SCOPE_IDENTITY() as int)", new { entity = entity.pedido });

                foreach (var item in entity.itens)
                {
                    idItem = db.QuerySingle<int>($@"
                        INSERT INTO Item  VALUES  ( @descricao , @precoUnitario, @qtd ) ;
                        SELECT CAST(SCOPE_IDENTITY() as int)", new { descricao = item.descricao, precoUnitario = item.precoUnitario, qtd = item.qtd });

                    id = db.QuerySingle<int>($@"
                        INSERT INTO [PedidoItem]  VALUES  ( @idPedido , @idItem ) ;
                        SELECT CAST(SCOPE_IDENTITY() as int)", new { idPedido = idPedido, idItem = idItem });

                }
            }
            return id;
        }

            public PedidoModel GetById(string pedido)
        {
            string dataConnectionString = _configuration["ConnectionStrings:SQLConnection"];
            var data = new PedidoModel();
            using (IDbConnection db = new SqlConnection(dataConnectionString))
            {
                data = db.Query<PedidoModel>($@"
                        SELECT Pedido  
                        FROM [dbo].Pedido 
                        WHERE pedido = '{pedido}' ").FirstOrDefault();


                if (data != null)
                {
                    data.itens = db.Query<ItemModel>($@"
                        SELECT Pedido , descricao, precoUnitario, qtd  
                        FROM [dbo].Pedido Ped
                        INNER JOIN [dbo].[PedidoItem] PedIt
                        ON Ped.IdPedido = PedIt.IdPedido
                        INNER JOIN [dbo].Item it
                        ON it.IdItem = PedIt.IdItem
                        WHERE pedido = '{pedido}'").ToList();
                }
            }

            return data;
        }


        public int Remove(PedidoModel entity)
        {
            string dataConnectionString = _configuration["ConnectionStrings:SQLConnection"];
            var data = new PedidoModel();
            try
            {
                using (IDbConnection db = new SqlConnection(dataConnectionString))
                {
                    data = db.Query<PedidoModel>($@"
                        DELETE it FROM[dbo].Pedido Ped
                        INNER JOIN[dbo].[PedidoItem] PedIt
                        ON Ped.IdPedido = PedIt.IdPedido
                        INNER JOIN[dbo].Item it
                        ON it.IdItem = PedIt.IdItem WHERE pedido = '{entity.pedido}' ").FirstOrDefault();

                    data = db.Query<PedidoModel>($@"
                        DELETE PedIt FROM[dbo].Pedido Ped
                        INNER JOIN[dbo].[PedidoItem] PedIt
                        ON Ped.IdPedido = PedIt.IdPedido
                        WHERE pedido = '{entity.pedido}' ").FirstOrDefault();

                    data = db.Query<PedidoModel>($@"
                        DELETE  
                        FROM [dbo].Pedido 
                        WHERE pedido = '{entity.pedido}' ").FirstOrDefault();



                    

                    return 1;
                }
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Update(PedidoModel entity)
        {
            string dataConnectionString = _configuration["ConnectionStrings:SQLConnection"];

            try
            {
                using (IDbConnection db = new SqlConnection(dataConnectionString))
                {
                    foreach (var item in entity.itens)
                    {
                        db.Execute($@"
                        UPDATE Item  SET precoUnitario = @precoUnitario, qtd = @qtd WHERE descricao =  @descricao"
                           , new { precoUnitario = item.precoUnitario, qtd = item.qtd, descricao = item.descricao });


                    }
                }
                return 1;
            }

            catch (Exception)
            {
                return 0;
            }
        }
    }
}
