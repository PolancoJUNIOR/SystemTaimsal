using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SysTaimsal.EL.DBModels
{
    public partial class DBSysTaimsalContext : DbContext
    {
        public DBSysTaimsalContext()
        {
        }

        public DBSysTaimsalContext(DbContextOptions<DBSysTaimsalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Machine> Machines { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBSysTaimsal;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.IdAttendance)
                    .HasName("PK__Attendan__DEB0138C902FD521");

                entity.ToTable("Attendance", "Taimsal");

                entity.Property(e => e.DayAttendence).HasColumnType("date");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Client__C1961B3332F0D709");

                entity.ToTable("Client", "Taimsal");

                entity.Property(e => e.NameClient)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__Employee__51C8DD7A8CAE3551");

                entity.ToTable("Employee", "Taimsal");

                entity.Property(e => e.LastNameEmployee)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NameEmployee)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdMachine)
                    .HasConstraintName("FK__Employee__IdMach__48CFD27E");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => e.IdMachine)
                    .HasName("PK__Machine__7C237E9A4D8C27FE");

                entity.ToTable("Machine", "Taimsal");

                entity.Property(e => e.ImageMachine).HasMaxLength(255);

                entity.Property(e => e.NameMachine)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__2E8946D4D31747F4");

                entity.ToTable("Product", "Taimsal");

                entity.Property(e => e.DescriptionProduct)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageProduct).HasMaxLength(255);

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK__Provider__809B73B8AA7C8578");

                entity.ToTable("Providers", "Taimsal");

                entity.Property(e => e.NameProvider)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584CCF3BE5F4");

                entity.ToTable("Rol", "Taimsal");

                entity.Property(e => e.NameRol)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Taimsal");

                entity.Property(e => e.LastNameUser)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nie).HasColumnName("NIE");

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationUser).HasColumnType("datetime");

                entity.Property(e => e.StatusUser)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_User")
                    .IsFixedLength();

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__User__IdRol__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
