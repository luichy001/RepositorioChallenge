using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Contracts
{
    public class ItemVM
    {
        public string descricao { get; set; }
        public decimal precoUnitario { get; set; }
        public int qtd { get; set; }
    }
}