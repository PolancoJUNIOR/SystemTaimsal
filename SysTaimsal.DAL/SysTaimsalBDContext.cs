using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTaimsal.EL;

namespace SysTaimsal.DAL
{
    public class SysTaimsalBDContext : DbContext
    {

        public DbSet<Rol> Rol { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;persist security info=False;initial catalog=DbSysTaimsalDev");
        }
    }
}
