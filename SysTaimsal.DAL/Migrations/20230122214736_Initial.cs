using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysTaimsal.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameClient = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__Taimsal_001", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    IdMachine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMachine = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Machine__Taimsal__001", x => x.IdMachine);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduct = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ImageProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionProduct = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__Taimsal_001", x => x.IdProduct);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__TaimsalDev_001", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    IdProvider = table.Column<int>(type: "int", nullable: false),
                    NameProvider = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provider__Taimsal__001", x => x.IdProvider);
                    table.ForeignKey(
                        name: "PK__Provider__Machine",
                        column: x => x.IdProvider,
                        principalTable: "Machine",
                        principalColumn: "IdMachine");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastNameUser = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nchar(32)", fixedLength: true, maxLength: 32, nullable: false),
                    Status_User = table.Column<byte>(type: "tinyint", nullable: false),
                    RegistrationUser = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__Taimsal__001", x => x.Id);
                    table.ForeignKey(
                        name: "FK1__Rol__User__001",
                        column: x => x.Id,
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    IdReport = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: true),
                    IdProvider = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Report__001", x => x.IdReport);
                    table.ForeignKey(
                        name: "FK1__User__Report",
                        column: x => x.IdReport,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK2__Clients__Report",
                        column: x => x.IdReport,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FK3__Provider__Report__001",
                        column: x => x.IdReport,
                        principalTable: "Providers",
                        principalColumn: "IdProvider");
                    table.ForeignKey(
                        name: "FK4__Products__Report",
                        column: x => x.IdReport,
                        principalTable: "Product",
                        principalColumn: "IdProduct");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
