using Microsoft.EntityFrameworkCore.Migrations;

namespace SecProbRec19.Migrations
{
    public partial class AddingipAdreessagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Receive",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Receive");
        }
    }
}
