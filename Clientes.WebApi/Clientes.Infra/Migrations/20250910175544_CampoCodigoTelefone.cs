using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clientes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CampoCodigoTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CodigoTelefone",
                table: "Telefones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("0e481610-8420-410f-b02b-3ea66b39d854"),
                column: "DataInsercao",
                value: new DateTime(2025, 9, 10, 17, 55, 43, 859, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("1aaae748-3a5a-496e-8626-9692d277e1da"),
                column: "DataInsercao",
                value: new DateTime(2025, 9, 10, 17, 55, 43, 859, DateTimeKind.Utc).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("858dd8c5-921a-4a0b-aaeb-3293e4afcf05"),
                column: "DataInsercao",
                value: new DateTime(2025, 9, 10, 17, 55, 43, 859, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("fbe917e7-5d43-44cb-b375-e3cbe44e3d42"),
                columns: new[] { "DataInsercao", "DescricaoTipoTelefone" },
                values: new object[] { new DateTime(2025, 9, 10, 17, 55, 43, 859, DateTimeKind.Utc).AddTicks(3995), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoTelefone",
                table: "Telefones");

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("0e481610-8420-410f-b02b-3ea66b39d854"),
                column: "DataInsercao",
                value: new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("1aaae748-3a5a-496e-8626-9692d277e1da"),
                column: "DataInsercao",
                value: new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("858dd8c5-921a-4a0b-aaeb-3293e4afcf05"),
                column: "DataInsercao",
                value: new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "TiposTelefone",
                keyColumn: "CodigoTipoTelefone",
                keyValue: new Guid("fbe917e7-5d43-44cb-b375-e3cbe44e3d42"),
                columns: new[] { "DataInsercao", "DescricaoTipoTelefone" },
                values: new object[] { new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7498), "WHATSAPP" });
        }
    }
}
