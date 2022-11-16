using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class Provider
    {
        public int IdProvider { get; set; }
        public int? IdMachine { get; set; }
        public string? NameProvider { get; set; }
    }
}
