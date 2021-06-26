using AutoMapper;
using Backend.Me.Appservice.Interface;
using Backend.Me.Contracts;
using Backend.Me.Domain;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Backend.Me.Appservice
{
    public class PedidoAppservice : IPedidoAppservice
    {
        private readonly IPedidoHandler _handler;
        private readonly IMapper _mapper;
        public PedidoAppservice(IPedidoHandler handler, IMapper mapper) 
        {
            _handler = handler;
            _mapper = mapper;
        }

        public PedidoRetornoVM Obter(string pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }
            PedidoRetornoVM retorno = new PedidoRetornoVM();
            PedidoCommand command = new PedidoCommand();
            command.pedido = new PedidoModel();
            command.pedido.pedido = pedido;
            var model = _handler.HandleObter(command);
            retorno.pedido = model.pedido;
            List<ItemVM> itens = _mapper.Map< List<ItemModel>, List<ItemVM> >(model.itens);
            retorno.itens = itens;
            return retorno;
        }

        public int Inserir(PedidoRequestVM request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            PedidoCommand command = new PedidoCommand();
            command.pedido = new PedidoModel();
            command.pedido.pedido = request.pedido;
            List<ItemModel> itens = _mapper.Map<List<ItemVM>, List<ItemModel>>(request.itens);
            command.pedido.itens = itens;
            var model = _handler.HandleInserir(command);

            return model;
        }
        public int Atualizar(PedidoRequestVM request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            PedidoCommand command = new PedidoCommand();
            command.pedido = new PedidoModel();
            command.pedido.pedido = request.pedido;
            List<ItemModel> itens = _mapper.Map<List<ItemVM>, List<ItemModel>>(request.itens);
            command.pedido.itens = itens;
            var model = _handler.HandleAtualizar(command);

            return model;
        }

        public int Deletar(string pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }
            PedidoCommand command = new PedidoCommand();
            command.pedido = new PedidoModel();
            command.pedido.pedido = pedido;
            var model = _handler.HandleDeletar(command);

            return model;
        }


    }
}

