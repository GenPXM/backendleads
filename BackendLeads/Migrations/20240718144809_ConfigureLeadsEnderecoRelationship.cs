using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLeads.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureLeadsEnderecoRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRealizacao",
                table: "Leads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeadsId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Leads_LeadsId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_LeadsId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataRealizacao",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "LeadsId",
                table: "Enderecos");
        }
    }
}
