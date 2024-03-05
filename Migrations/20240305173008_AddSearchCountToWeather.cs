using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperimentNetApi6.Migrations
{
    public partial class AddSearchCountToWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchCount",
                table: "Weather",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchCount",
                table: "Weather");
        }
    }
}
