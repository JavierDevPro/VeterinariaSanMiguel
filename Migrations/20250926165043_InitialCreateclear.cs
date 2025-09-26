using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinariaSanMiguel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateclear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clientDb",
                table: "clientDb");

            migrationBuilder.RenameTable(
                name: "clientDb",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "clientDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientDb",
                table: "clientDb",
                column: "Id");
        }
    }
}
