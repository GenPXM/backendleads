using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLeads.Migrations
{
    /// <inheritdoc />
    public partial class RefatoracaoModelsGestor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLogin",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Gestores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdLogin",
                table: "Gestores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Gestores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
