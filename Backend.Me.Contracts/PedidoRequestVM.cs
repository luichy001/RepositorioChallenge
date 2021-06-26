using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Contracts
{
    public class PedidoRequestVM
    {
        public string pedido { get; set; }
        public List<ItemVM> itens { get; set; }
    }
    
}
