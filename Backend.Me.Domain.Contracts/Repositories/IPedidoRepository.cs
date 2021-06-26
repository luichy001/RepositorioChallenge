using Backend.Me.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Domain.Contracts.Repositories
{
    public interface IPedidoRepository
    {
        int Add(PedidoModel entity);
        PedidoModel GetById(string pedido);
        int Remove(PedidoModel entity);
        int Update(PedidoModel entity);
    }
}
