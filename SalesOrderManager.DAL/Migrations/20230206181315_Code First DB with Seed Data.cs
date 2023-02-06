using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrderManager.DAL.Migrations
{
    public partial class CodeFirstDBwithSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    WindowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantityOfWindows = table.Column<int>(type: "int", nullable: true),
                    TotalSubElements = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.WindowId);
                    table.ForeignKey(
                        name: "FK_Windows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "SubElements",
                columns: table => new
                {
                    SubElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindowId = table.Column<int>(type: "int", nullable: true),
                    ElementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Element = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElements", x => x.SubElementId);
                    table.ForeignKey(
                        name: "FK_SubElements_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "WindowId");
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Name" },
                values: new object[,]
                {
                    { 1, "AL" },
                    { 2, "AK" },
                    { 3, "AZ" },
                    { 4, "AR" },
                    { 5, "CA" },
                    { 6, "CO" },
                    { 7, "CT" },
                    { 8, "DE" },
                    { 9, "DC" },
                    { 10, "FL" },
                    { 11, "GA" },
                    { 12, "HI" },
                    { 13, "ID" },
                    { 14, "IL" },
                    { 15, "IN" },
                    { 16, "IA" },
                    { 17, "KS" },
                    { 18, "KY" },
                    { 19, "LA" },
                    { 20, "ME" },
                    { 21, "MD" },
                    { 22, "MA" },
                    { 23, "MI" },
                    { 24, "MN" },
                    { 25, "MS" },
                    { 26, "MO" },
                    { 27, "MT" },
                    { 28, "NY" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Name", "StateId" },
                values: new object[] { 1, "New York Building 1", 28 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Name", "StateId" },
                values: new object[] { 2, "California Hotel AJK", 5 });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "WindowId", "Name", "OrderId", "QuantityOfWindows", "TotalSubElements" },
                values: new object[,]
                {
                    { 1, "A51", 1, 4, 3 },
                    { 2, "C Zone 5", 1, 2, 1 },
                    { 3, "GLB", 2, 3, 2 },
                    { 4, "OHF", 2, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "SubElements",
                columns: new[] { "SubElementId", "Element", "ElementType", "Height", "Width", "WindowId" },
                values: new object[,]
                {
                    { 1, 1, "Doors", 1850, 1200, 1 },
                    { 2, 2, "Window", 1850, 800, 1 },
                    { 3, 3, "Window", 1850, 700, 1 },
                    { 4, 1, "Window", 2000, 1500, 2 },
                    { 5, 1, "Doors", 2200, 1400, 3 },
                    { 6, 2, "Window", 2200, 600, 3 },
                    { 7, 1, "Window", 2000, 1500, 4 },
                    { 8, 1, "Window", 2000, 1500, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StateId",
                table: "Orders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SubElements_WindowId",
                table: "SubElements",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId",
                table: "Windows",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubElements");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
