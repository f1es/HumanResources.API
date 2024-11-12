using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypoInVacancyProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Professions_ProffesionId",
                table: "Vacancies");

            migrationBuilder.RenameColumn(
                name: "ProffesionId",
                table: "Vacancies",
                newName: "ProfessionId");

            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "Vacancies",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_ProffesionId",
                table: "Vacancies",
                newName: "IX_Vacancies_ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Professions_ProfessionId",
                table: "Vacancies",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Professions_ProfessionId",
                table: "Vacancies");

            migrationBuilder.RenameColumn(
                name: "ProfessionId",
                table: "Vacancies",
                newName: "ProffesionId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Vacancies",
                newName: "Desciption");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_ProfessionId",
                table: "Vacancies",
                newName: "IX_Vacancies_ProffesionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Professions_ProffesionId",
                table: "Vacancies",
                column: "ProffesionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
