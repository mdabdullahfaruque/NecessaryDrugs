using Microsoft.EntityFrameworkCore.Migrations;

namespace NecessaryDrugs.Web.Migrations
{
    public partial class GenericNameOfMedicineAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenericName",
                table: "Medicines",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenericName",
                table: "Medicines");
        }
    }
}
