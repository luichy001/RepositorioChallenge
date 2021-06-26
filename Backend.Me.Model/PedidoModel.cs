using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Contracts
{
    public class PedidoModel
    {
        public string pedido { get; set; }
        public List<ItemModel> itens { get; set; }

    }
}
