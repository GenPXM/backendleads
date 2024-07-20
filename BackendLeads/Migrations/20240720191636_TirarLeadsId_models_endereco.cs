using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLeads.Migrations
{
    /// <inheritdoc />
    public partial class TirarLeadsId_models_endereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadsId",
                table: "Enderecos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadsId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
