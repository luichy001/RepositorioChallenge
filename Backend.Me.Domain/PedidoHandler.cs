using Backend.Me.Contracts;
using Backend.Me.Domain.Contracts.Repositories;
using MediatR;

namespace Backend.Me.Domain
{
    public class PedidoHandler : IPedidoHandler
    {
        private readonly IPedidoRepository _repository;
        public PedidoHandler(IPedidoRepository repository )
        {
            _repository = repository;
        }

        public int HandleAtualizar(PedidoCommand request)
        {
            PedidoModel model = new PedidoModel();

            if (request.pedido.pedido == string.Empty)
            {
                return 0;
            }
            model.pedido = request.pedido.pedido;
            model.itens = request.pedido.itens;
            return _repository.Update(model);
        }

        public int HandleDeletar(PedidoCommand request)
        {
            PedidoModel model = new PedidoModel();

            if (request.pedido.pedido == string.Empty)
            {
                return 0;
            }
            model.pedido = request.pedido.pedido;
            model.itens = request.pedido.itens;
            return _repository.Remove(model);
        }

        public int HandleInserir(PedidoCommand request)
        {
            PedidoModel model = new PedidoModel();

            if (request.pedido.pedido == string.Empty)
            {
                return 0;
            }
            model.pedido = request.pedido.pedido;
            model.itens = request.pedido.itens;
            return _repository.Add(model);
        }

        public PedidoModel HandleObter(PedidoCommand request)
        {
            PedidoModel model = new PedidoModel();

            if (request.pedido.pedido == string.Empty)
            {
                return null;
            }
            model.pedido = request.pedido.pedido;
            model.itens = request.pedido.itens;
            var retorno = _repository.GetById(model.pedido);

            return retorno;
        }
    }

    public class PedidoCommand : IRequest<PedidoModel>
    {
        public PedidoModel pedido { get; set; }

    }
}
