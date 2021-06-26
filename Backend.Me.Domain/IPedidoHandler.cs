using Backend.Me.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Me.Domain
{
    public interface IPedidoHandler
    {
        PedidoModel HandleObter(PedidoCommand request);

        int HandleInserir(PedidoCommand request);

        int HandleDeletar(PedidoCommand request);

        int HandleAtualizar(PedidoCommand request);
    }
}
