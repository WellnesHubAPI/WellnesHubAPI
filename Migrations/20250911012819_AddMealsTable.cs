using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMealsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Protein = table.Column<double>(type: "float", nullable: true),
                    Carbs = table.Column<double>(type: "float", nullable: true),
                    Fat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
