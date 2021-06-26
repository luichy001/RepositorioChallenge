using Backend.Me.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Appservice.Interface
{
    public interface IPedidoAppservice
    {
        PedidoRetornoVM Obter(string pedido);

        int Inserir(PedidoRequestVM request);

        int Atualizar(PedidoRequestVM request);

        int Deletar(string pedido);
    }
}
