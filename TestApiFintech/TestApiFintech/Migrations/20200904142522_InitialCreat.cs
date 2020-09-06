using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiFintech.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    BankId = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Number = table.Column<long>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoutings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schema = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CustomersId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoutings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRoutings_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CustomersId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    Provider = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CustomersId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoutings_CustomersId",
                table: "AccountRoutings",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_CustomersId",
                table: "Balances",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CustomersId",
                table: "Owners",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRoutings");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
