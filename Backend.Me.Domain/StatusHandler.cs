using Backend.Me.Contracts;
using Backend.Me.Domain.Contracts.Model;
using Backend.Me.Domain.Contracts.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Me.Domain
{
    public class StatusHandler : IStatusHandler
    {
        private readonly IPedidoRepository _repository;
        public StatusHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public StatusRetornoModel Handle(StatusCommand request)
        {
            PedidoModel pedido = new PedidoModel();
            StatusRetornoModel retorno = new StatusRetornoModel();
            List<string> listaStatus = new List<string>();
            request.pedido = new PedidoModel();
           
            // INICIO - DADOS RECUPERADOS NO BANCO DE DADOS DO PEDIDO 
            var model = _repository.GetById(request.status.pedido);

            if (model == null)
            {
                listaStatus.Add("CODIGO_PEDIDO_INVALIDO");
                retorno.status = listaStatus.ToArray();
                return retorno;
            }


            decimal total = 0.0M;
            foreach (var item in model.itens)
            {
                total += (item.precoUnitario * item.qtd);
            }

            int totalqtde = model.itens.AsEnumerable().Sum(o => o.qtd);
            // FIM - DADOS RECUPERADOS NO BANCO DE DADOS DO PEDIDO 

            if (request.status.pedido == model.pedido)
            {
                if (request.status.status.Equals("REPROVADO"))
                {
                    listaStatus.Add("REPROVADO");
                    retorno.status = listaStatus.ToArray();
                    return retorno;
                }

                if (request.status.itensAprovados == totalqtde)
                {
                    if (request.status.valorAprovado == total)
                    {
                        listaStatus.Add("APROVADO");
                    }
                }
                if (request.status.valorAprovado > total)
                {
                    listaStatus.Add("APROVADO_VALOR_A_MAIOR");
                }
                if (request.status.valorAprovado < total)
                {
                    listaStatus.Add("APROVADO_VALOR_A_MENOR");
                }
                if (request.status.itensAprovados > totalqtde)
                {
                    listaStatus.Add("APROVADO_QTD_A_MAIOR");
                }
                if (request.status.itensAprovados < totalqtde)
                {
                    listaStatus.Add("APROVADO_QTD_A_MENOR");
                }
            }
            retorno.pedido = request.status.pedido;
            retorno.status = listaStatus.ToArray();

            return retorno;
        }
    }

    public class StatusCommand : IRequest<StatusModel>
    {
        public PedidoModel pedido { get; set; }
        public StatusModel status { get; set; }

    }
}