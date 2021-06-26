using AutoMapper;
using Backend.Me.Appservice.Interface;
using Backend.Me.Contracts;
using Backend.Me.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Appservice
{
    public class StatusAppservice : IStatusAppservice
    {
        private readonly IStatusHandler _handler;
        private readonly IMapper _mapper;
        public StatusAppservice(IStatusHandler handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }

        public StatusRetornoVM Validar(StatusRequestVM request)
        {
            StatusRetornoVM retorno = new StatusRetornoVM();
            StatusCommand command = new StatusCommand();
            command.status = new Domain.Contracts.Model.StatusModel();
            command.status.pedido = request.pedido;
            command.status.status = request.status;
            command.status.valorAprovado = request.valorAprovado;
            command.status.itensAprovados = request.itensAprovados;
            var model = _handler.Handle(command);
            retorno.pedido = model.pedido;
            retorno.status = model.status;

            return retorno;
        }

        //public StatusRetornoVM Calcular(PedidoRequestVM request)
        //{
        //    PedidoCommand command = new PedidoCommand();
        //    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        //    CancellationToken cancellationToken = cancellationTokenSource.Token;

        //    command.pedido = request.pedido;

        //    List<ItemModel> itens = _mapper.Map<List<ItemVM>, List<ItemModel>>(request.itens);
        //    command.itens = itens;
        //    var model = _handler.Handle(command, cancellationToken);

        //    return null;
        //}
    }
}
