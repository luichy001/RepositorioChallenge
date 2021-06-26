using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Contracts
{
    public class StatusRetornoVM
    {
        public string pedido { get; set; }

        public string[] status { get; set; }
    }
}
