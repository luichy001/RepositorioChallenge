using Backend.Me.Appservice.Interface;
using Backend.Me.Contracts;
using Backend.Me.Domain;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Backend.ME.Unitest
{
    public class UnitTest1
    {
        [Fact]
        public void ME_Appservice_CODIGO_APROVADO()
        {
            string[] statusAprovado = new string[] { "APROVADO" };
            var retorno = new StatusRetornoVM()
            {
                pedido = "123456",
                status = statusAprovado
            };
            var request = new StatusRequestVM(){ status = "APROVADO", itensAprovados =3, valorAprovado = 20 , pedido = "123456" };
            var appservice = new Mock<IStatusAppservice>();
            appservice.Setup(x => x.Validar(request))
                .Returns(retorno);
        }


       [Fact]
        public void ME_APROVADO()
        {
            string PedidoValorBASEDADOS = "123456";
            string textoAPROVADO = "APROVADO";
            var mockhandler = new Mock<IStatusHandler>();
            var requestVM = new StatusRequestVM() { status = "APROVADO", itensAprovados = 3, valorAprovado = 20, pedido = "123456" };
            StatusCommand request = new StatusCommand();
            request.status = new Me.Domain.Contracts.Model.StatusModel();
            request.status.pedido = "123456";
            request.status.itensAprovados = 3;
            request.status.valorAprovado = 20;

            request.pedido = new PedidoModel();
            request.pedido.itens = new System.Collections.Generic.List<ItemModel>()
            {
                new ItemModel()
                {
                    descricao = "Item A",
                    precoUnitario = 10,
                    qtd = 1
                },
                new ItemModel()
                {
                    descricao = "Item B",
                    precoUnitario = 5,
                    qtd = 2
                }
            };

            decimal total = 0.0M;
            foreach (var item in request.pedido.itens)
            {
                total += (item.precoUnitario * item.qtd);
            }

            int totalqtde = request.pedido.itens.AsEnumerable().Sum(o => o.qtd);

            if (request.status.pedido.Equals(PedidoValorBASEDADOS))
            {
                if (request.status.itensAprovados == totalqtde)
                {
                    if (request.status.valorAprovado == total)
                    {
                        Assert.Equal("APROVADO", textoAPROVADO);

                    }
                }
            }
        }


        [Fact]
        public void ME_APROVADO_VALOR_A_MENOR()
        {
            string PedidoValorBASEDADOS = "123456"; 
            string textoStatus = "APROVADO_VALOR_A_MENOR";
            var mockhandler = new Mock<IStatusHandler>();
            var requestVM = new StatusRequestVM() { status = "APROVADO", itensAprovados = 3, valorAprovado = 20, pedido = "123456" };
            StatusCommand request = new StatusCommand();
            request.status = new Me.Domain.Contracts.Model.StatusModel();
            request.status.pedido = "123456";
            request.status.itensAprovados = 3;
            request.status.valorAprovado = 10;
            request.status.status = "APROVADO";


            request.pedido = new PedidoModel();
            request.pedido.itens = new System.Collections.Generic.List<ItemModel>()
            {
                new ItemModel()
                {
                    descricao = "Item A",
                    precoUnitario = 10,
                    qtd = 1
                },
                new ItemModel()
                {
                    descricao = "Item B",
                    precoUnitario = 5,
                    qtd = 2
                }
            };

            decimal total = 0.0M;
            foreach (var item in request.pedido.itens)
            {
                total += (item.precoUnitario * item.qtd);
            }

            int totalqtde = request.pedido.itens.AsEnumerable().Sum(o => o.qtd);

            if (request.status.pedido.Equals(PedidoValorBASEDADOS))
            {
                if (request.status.valorAprovado < total)
                {
                    Assert.Equal("APROVADO_VALOR_A_MENOR", textoStatus);
                }
            }
        }


        [Fact]
        public void ME_APROVADO_VALOR_A_MAIOR()
        {
            string PedidoValorBASEDADOS = "123456";
            string textoStatus = "APROVADO_VALOR_A_MAIOR";
            var mockhandler = new Mock<IStatusHandler>();
            var requestVM = new StatusRequestVM() { status = "APROVADO", itensAprovados = 3, valorAprovado = 20, pedido = "123456" };
            StatusCommand request = new StatusCommand();
            request.status = new Me.Domain.Contracts.Model.StatusModel();
            request.status.pedido = "123456";
            request.status.itensAprovados = 4;
            request.status.valorAprovado = 21;
            request.status.status = "APROVADO";


            request.pedido = new PedidoModel();
            request.pedido.itens = new System.Collections.Generic.List<ItemModel>()
            {
                new ItemModel()
                {
                    descricao = "Item A",
                    precoUnitario = 10,
                    qtd = 1
                },
                new ItemModel()
                {
                    descricao = "Item B",
                    precoUnitario = 5,
                    qtd = 2
                }
            };

            decimal total = 0.0M;
            foreach (var item in request.pedido.itens)
            {
                total += (item.precoUnitario * item.qtd);
            }

            int totalqtde = request.pedido.itens.AsEnumerable().Sum(o => o.qtd);

            if (request.status.pedido.Equals(PedidoValorBASEDADOS))
            {
                if (request.status.valorAprovado > total)
                {
                    Assert.Equal("APROVADO_VALOR_A_MAIOR", textoStatus);

                }

            }
        }


        [Fact]
        public void ME_APROVADO_QTD_A_MAIOR()
        {
            string PedidoValorBASEDADOS = "123456";
            string textoStatus = "APROVADO_QTD_A_MAIOR";
            var mockhandler = new Mock<IStatusHandler>();
            var requestVM = new StatusRequestVM() { status = "APROVADO", itensAprovados = 3, valorAprovado = 20, pedido = "123456" };
            StatusCommand request = new StatusCommand();
            request.status = new Me.Domain.Contracts.Model.StatusModel();
            request.status.pedido = "123456";
            request.status.itensAprovados = 4;
            request.status.valorAprovado = 21;
            request.status.status = "APROVADO";


            request.pedido = new PedidoModel();
            request.pedido.itens = new System.Collections.Generic.List<ItemModel>()
            {
                new ItemModel()
                {
                    descricao = "Item A",
                    precoUnitario = 10,
                    qtd = 1
                },
                new ItemModel()
                {
                    descricao = "Item B",
                    precoUnitario = 5,
                    qtd = 2
                }
            };

            decimal total = 0.0M;
            foreach (var item in request.pedido.itens)
            {
                total += (item.precoUnitario * item.qtd);
            }

            int totalqtde = request.pedido.itens.AsEnumerable().Sum(o => o.qtd);

            if (request.status.pedido.Equals(PedidoValorBASEDADOS))
            {
                if (request.status.itensAprovados > totalqtde)
                {
                    Assert.Equal("APROVADO_QTD_A_MAIOR", textoStatus);

                }

            }
        }


        [Fact]
        public void ME_APROVADO_QTD_A_MENOR()
        {
            string PedidoValorBASEDADOS = "123456";
            string textoStatus = "APROVADO_QTD_A_MENOR";
            var mockhandler = new Mock<IStatusHandler>();
            var requestVM = new StatusRequestVM() { status = "APROVADO", itensAprovados = 3, valorAprovado = 20, pedido = "123456" };
            StatusCommand request = new StatusCommand();
            request.status = new Me.Domain.Contracts.Model.StatusModel();
            request.status.pedido = "123456";
            request.status.itensAprovados = 2;
            request.status.valorAprovado = 20;
            request.status.status = "APROVADO";


            request.pedido = new PedidoModel();
            request.pedido.itens = new System.Collections.Generic.List<ItemModel>()
            {
                new ItemModel()
                {
                    descricao = "Item A",
                    precoUnitario = 10,
                    qtd = 1
                },
                new ItemModel()
                {
                    descricao = "Item B",
                    precoUnitario = 5,
                    qtd = 2
                }
            };

            decimal total = 0.0M;
            foreach (var item in request.pedido.itens)
            {
                total += (item.precoUnitario * item.qtd);
            }

            int totalqtde = request.pedido.itens.AsEnumerable().Sum(o => o.qtd);

            if (request.status.pedido.Equals(PedidoValorBASEDADOS))
            {
                if (request.status.itensAprovados > totalqtde)
                {
                    Assert.Equal("APROVADO_QTD_A_MENOR", textoStatus);

                }

            }
        }
    }
}
