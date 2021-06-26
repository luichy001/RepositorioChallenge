using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Domain.Contracts.Model
{
    public class StatusRetornoModel
    {
        public string pedido { get; set; }

        public string[] status { get; set; }
    }
}
