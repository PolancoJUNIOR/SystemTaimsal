using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public int? IdMachine { get; set; }
        public string? NameEmployee { get; set; }
        public string? LastNameEmployee { get; set; }
        public string? Rol { get; set; }

        public virtual Machine? IdMachineNavigation { get; set; }
    }
}
