using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;


namespace SysTaimsal.DAL
{
    public class SysTaimsalBDContext : DbContext
    {
        public SysTaimsalBDContext() { }

        public SysTaimsalBDContext(DbContextOptions<SysTaimsalBDContext> options) : base(options) { }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;persist security info=False;initial catalog=DbSysTaimsalDev ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__TaimsalDev_001");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(m => m.IdMachine)
                    .HasName("PK__Machine__Taimsal__001");

                //entity.HasOne(p => p.Provider)
                //    .WithMany(m => m.Machines)
                //    .HasForeignKey(p => p.IdMachine)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK1__Machine__Provider");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.IdClient)
                    .HasName("PK__Client__Taimsal_001");

                //entity.HasOne(d => d.Report)
                //    .WithMany(c => c.Clients)
                //    .HasForeignKey(c => c.IdClient)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK1__Client__Report");

            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(p => p.IdProvider)
                    .HasName("PK__Provider__Taimsal__001");

                entity.HasOne(p => p.Machine)
                    .WithMany(c => c.Providers)
                    .HasForeignKey(c => c.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK__Provider__Machine");

                //entity.HasOne(p => p.Report)
                //    .WithMany(r => r.Providers)
                //    .HasForeignKey("PK__Providers__Report")
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK1__Providers__Report");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id)
                    .HasName("PK__User__Taimsal__001");

                //entity.HasOne(r => r.Report)
                //    .WithMany(u => u.users)
                //    .HasForeignKey(u => u.IdReport)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK1__User__Report");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.IdProduct)
                    .HasName("PK__Product__Taimsal_001");

                //entity.HasOne(p => p.Report)
                //    .WithMany(r => r.Products)
                //    .HasForeignKey(r => r.IdProduct)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK1__Products__Report");
            });



            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(d => d.IdReport)
                    .HasName("PK__Report__001");

                entity.HasOne(c => c.user)
                    .WithMany(r => r.Reports)
                    .HasForeignKey(r => r.IdReport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1__Users__Report");

                entity.HasOne(e => e.Client)
                    .WithMany(r => r.Reports)
                    .HasForeignKey(r => r.IdReport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1__Clients__Report");

                entity.HasOne(e => e.Provider)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(p => p.IdReport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1__Providers__Report");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(p => p.IdReport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1__Products__Report");
            });



        }


    }
}
