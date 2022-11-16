using System;
using System.Collections.Generic;

namespace SysTaimsal.EL.DBModels
{
    public partial class User
    {
        public int Id { get; set; }
        public int? IdRol { get; set; }
        public int? IdClient { get; set; }
        public int? IdProduct { get; set; }
        public int? IdProvider { get; set; }
        public int? IdAttendance { get; set; }
        public int? IdEmployee { get; set; }
        public int? Nie { get; set; }
        public string? NameUser { get; set; }
        public string? LastNameUser { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? StatusUser { get; set; }
        public DateTime? RegistrationUser { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
    }
}
