using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string? NameProduct { get; set; }
        public string? ImageProduct { get; set; }
        public string? DescriptionProduct { get; set; }
        public decimal? Price { get; set; }
    }
}
