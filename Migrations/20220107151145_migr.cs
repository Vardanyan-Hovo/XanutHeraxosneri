using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XanutHeraxosneri.Migrations
{
    public partial class migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DescCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeoplesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masnaget = table.Column<bool>(type: "bit", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    session = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeoplesDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApranqnerDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longdesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFavorit = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false),
                    Apranctime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: true),
                    categoryAId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApranqnerDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApranqnerDb_CategoryDb_categoryAId",
                        column: x => x.categoryAId,
                        principalTable: "CategoryDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApranqName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdApranq = table.Column<int>(type: "int", nullable: false),
                    ApranqId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    sessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardsessionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartsDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartsDb_ApranqnerDb_ApranqId",
                        column: x => x.ApranqId,
                        principalTable: "ApranqnerDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartsDb_PeoplesDb_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "PeoplesDb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ordersDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idcart = table.Column<int>(type: "int", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    Idpeople = table.Column<int>(type: "int", nullable: false),
                    PeopleorderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordersDb_cartsDb_cartId",
                        column: x => x.cartId,
                        principalTable: "cartsDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersDb_PeoplesDb_PeopleorderId",
                        column: x => x.PeopleorderId,
                        principalTable: "PeoplesDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApranqnerDb_categoryAId",
                table: "ApranqnerDb",
                column: "categoryAId");

            migrationBuilder.CreateIndex(
                name: "IX_cartsDb_ApranqId",
                table: "cartsDb",
                column: "ApranqId");

            migrationBuilder.CreateIndex(
                name: "IX_cartsDb_PeopleId",
                table: "cartsDb",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersDb_cartId",
                table: "ordersDb",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersDb_PeopleorderId",
                table: "ordersDb",
                column: "PeopleorderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordersDb");

            migrationBuilder.DropTable(
                name: "cartsDb");

            migrationBuilder.DropTable(
                name: "ApranqnerDb");

            migrationBuilder.DropTable(
                name: "PeoplesDb");

            migrationBuilder.DropTable(
                name: "CategoryDb");
        }
    }
}
