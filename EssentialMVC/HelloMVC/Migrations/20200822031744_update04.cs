using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloMVC.Migrations
{
    public partial class update04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // anything want to da
            migrationBuilder.Sql("UPDATE sell.tb_product SET Comment = Comment + ' update04' ");

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(nullable: false),
                    ProductNo = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slot_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_tb_product_ProductNo",
                        column: x => x.ProductNo,
                        principalSchema: "sell",
                        principalTable: "tb_product",
                        principalColumn: "Id",
                        //onDelete: ReferentialAction.Restrict); // gen by ef
                        onDelete: ReferentialAction.SetNull); // manual change
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slot_MachineId",
                table: "Slot",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_ProductNo",
                table: "Slot",
                column: "ProductNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE sell.tb_product SET Comment = Comment + ' update04' ");

            migrationBuilder.DropTable(
                name: "Slot");
        }
    }
}
