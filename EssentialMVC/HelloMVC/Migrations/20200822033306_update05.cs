using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloMVC.Migrations
{
    public partial class update05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE sell.tb_product SET Comment = 'update05' ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
