using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeBooks.Services.Migrations
{
    public partial class update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NAV = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funds", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UnitHolders",
                columns: table => new
                {
                    UnitHolderId = table.Column<string>(fixedLength: true, maxLength: 12, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false),
                    LastLoginDateUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitHolders", x => x.UnitHolderId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateUtc = table.Column<DateTime>(nullable: false),
                    FundCode = table.Column<string>(nullable: false),
                    OwnerUnitHolderId = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AllocNAV = table.Column<decimal>(nullable: true),
                    AllocUnits = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Funds_FundCode",
                        column: x => x.FundCode,
                        principalTable: "Funds",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_UnitHolders_OwnerUnitHolderId",
                        column: x => x.OwnerUnitHolderId,
                        principalTable: "UnitHolders",
                        principalColumn: "UnitHolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_FundCode",
                table: "Subscriptions",
                column: "FundCode");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_OwnerUnitHolderId",
                table: "Subscriptions",
                column: "OwnerUnitHolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Funds");

            migrationBuilder.DropTable(
                name: "UnitHolders");
        }
    }
}
