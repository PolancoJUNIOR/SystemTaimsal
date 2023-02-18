using Microsoft.EntityFrameworkCore;
using SysTaimsal.EL;


namespace SysTaimsal.DAL
{
    public class SysTaimsalBDContext : DbContext
    {
        public SysTaimsalBDContext() { }

        public SysTaimsalBDContext(DbContextOptions<SysTaimsalBDContext> options) : base(options) { }

        public DbSet<Rol> Rol { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<UserDev> UserDevs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NJIEQE0\SQLEXPRESS;Initial Catalog=DbSysTaimsalDev;TrustServerCertificate=True;persist security info=False;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;persist security info=False;initial catalog=DbSysTaimsalDev");
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
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.IdClient)
                    .HasName("PK__Client__Taimsal_001");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(p => p.IdProvider)
                    .HasName("PK__Provider__Taimsal__001");

            });

            modelBuilder.Entity<UserDev>(entity =>
            {
                entity.HasKey(u => u.IdUser)
                    .HasName("PK__User__Taimsal__001");

                entity.Property(e => e.Password).IsFixedLength();

                entity.HasOne(u => u.Rol)
                    .WithMany(r => r.users)
                    .HasForeignKey(r => r.IdRol)
                    .HasConstraintName("FK1__Rol__User__001")
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.IdProduct)
                    .HasName("PK__Product__Taimsal_001");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(d => d.IdReport)
                    .HasName("PK__Report__001");

                entity.HasOne(c => c.user)
                    .WithMany(r => r.Reports)
                    .HasForeignKey(r => r.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1__User__Report");

                entity.HasOne(e => e.Client)
                    .WithMany(r => r.Reports)
                    .HasForeignKey(r => r.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2__Clients__Report");

                entity.HasOne(e => e.Provider)
                    .WithMany(r => r.Reports)
                    .HasForeignKey(r => r.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK3__Provider__Report__001");
                    
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(p => p.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK4__Products__Report");

                entity.HasOne(p => p.Machine)
                    .WithMany(c => c.Reports)
                    .HasForeignKey(c => c.IdMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK5_Machine__Report__001");

            });
        }
    }
}
