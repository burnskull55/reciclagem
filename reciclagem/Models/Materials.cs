using System;
using System.Collections.Generic;

namespace reciclagem.Models
{
    public partial class Materials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? BuyPrice { get; set; }
        public double? SellPrice { get; set; }
    }
}
