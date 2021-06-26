using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Contracts
{
    public class StatusRequestVM
    {
        public string status { get; set; }
        public int itensAprovados { get; set; }
        public int valorAprovado { get; set; }
        public string pedido { get; set; }
    }
}
