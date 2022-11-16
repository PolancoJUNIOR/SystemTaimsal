using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class Client
    {
        public int IdClient { get; set; }
        public string? NameClient { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
