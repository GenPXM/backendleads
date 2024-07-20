using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLeads.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao_models_endereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Leads_LeadsId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_LeadsId",
                table: "Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_EnderecoId",
                table: "Leads",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Enderecos_EnderecoId",
                table: "Leads",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Enderecos_EnderecoId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_EnderecoId",
                table: "Leads");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_LeadsId",
                table: "Enderecos",
                column: "LeadsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Leads_LeadsId",
                table: "Enderecos",
                column: "LeadsId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
