using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Contracts
{
    public class PedidoRetornoVM
    {
        public string pedido { get; set; }
        public List<ItemVM> itens { get; set; }
    }
}
