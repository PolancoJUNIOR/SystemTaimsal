﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SysTaimsal.DAL;

#nullable disable

namespace SysTaimsal.DAL.Migrations
{
    [DbContext(typeof(SysTaimsalBDContext))]
    partial class SysTaimsalBDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SysTaimsal.EL.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"), 1L, 1);

                    b.Property<string>("NameClient")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdClient")
                        .HasName("PK__Client__Taimsal_001");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SysTaimsal.EL.Machine", b =>
                {
                    b.Property<int>("IdMachine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMachine"), 1L, 1);

                    b.Property<string>("ImageMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMachine")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdMachine")
                        .HasName("PK__Machine__Taimsal__001");

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("SysTaimsal.EL.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"), 1L, 1);

                    b.Property<string>("DescriptionProduct")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProduct")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProduct")
                        .HasName("PK__Product__Taimsal_001");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SysTaimsal.EL.Provider", b =>
                {
                    b.Property<int>("IdProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProvider"), 1L, 1);

                    b.Property<string>("NameProvider")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("IdProvider")
                        .HasName("PK__Provider__Taimsal__001");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("SysTaimsal.EL.Report", b =>
                {
                    b.Property<int>("IdReport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int?>("IdMachine")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("IdProvider")
                        .HasColumnType("int");

                    b.HasKey("IdReport")
                        .HasName("PK__Report__001");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("SysTaimsal.EL.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<string>("NameRol")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdRol")
                        .HasName("PK__Rol__TaimsalDev_001");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("SysTaimsal.EL.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("LastNameUser")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nchar(32)")
                        .IsFixedLength();

                    b.Property<DateTime>("RegistrationUser")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status_User")
                        .HasColumnType("tinyint");

                    b.HasKey("Id")
                        .HasName("PK__User__Taimsal__001");

                    b.ToTable("UserDev");
                });

            modelBuilder.Entity("SysTaimsal.EL.Report", b =>
                {
                    b.HasOne("SysTaimsal.EL.User", "user")
                        .WithMany("Reports")
                        .HasForeignKey("IdReport")
                        .IsRequired()
                        .HasConstraintName("FK1__User__Report");

                    b.HasOne("SysTaimsal.EL.Client", "Client")
                        .WithMany("Reports")
                        .HasForeignKey("IdReport")
                        .IsRequired()
                        .HasConstraintName("FK2__Clients__Report");

                    b.HasOne("SysTaimsal.EL.Machine", "Machine")
                        .WithMany("Reports")
                        .HasForeignKey("IdReport")
                        .IsRequired()
                        .HasConstraintName("FK5_Machine__Report__001");

                    b.HasOne("SysTaimsal.EL.Product", "Product")
                        .WithMany("Reports")
                        .HasForeignKey("IdReport")
                        .IsRequired()
                        .HasConstraintName("FK4__Products__Report");

                    b.HasOne("SysTaimsal.EL.Provider", "Provider")
                        .WithMany("Reports")
                        .HasForeignKey("IdReport")
                        .IsRequired()
                        .HasConstraintName("FK3__Provider__Report__001");

                    b.Navigation("Client");

                    b.Navigation("Machine");

                    b.Navigation("Product");

                    b.Navigation("Provider");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SysTaimsal.EL.User", b =>
                {
                    b.HasOne("SysTaimsal.EL.Rol", "Rol")
                        .WithMany("users")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK1__Rol__User__001");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("SysTaimsal.EL.Client", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("SysTaimsal.EL.Machine", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("SysTaimsal.EL.Product", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("SysTaimsal.EL.Provider", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("SysTaimsal.EL.Rol", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("SysTaimsal.EL.User", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
