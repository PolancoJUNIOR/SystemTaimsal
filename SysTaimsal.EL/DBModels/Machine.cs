using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class Machine
    {
        public Machine()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdMachine { get; set; }
        public string? NameMachine { get; set; }
        public string? ImageMachine { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
