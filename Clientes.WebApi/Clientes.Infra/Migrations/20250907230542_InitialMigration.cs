using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clientes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "TiposTelefone",
                columns: table => new
                {
                    CodigoTipoTelefone = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescricaoTipoTelefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTelefone", x => x.CodigoTipoTelefone);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    CodigoCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CodigoTipoTelefone = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operadora = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => new { x.CodigoCliente, x.NumeroTelefone });
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefones_TiposTelefone_CodigoTipoTelefone",
                        column: x => x.CodigoTipoTelefone,
                        principalTable: "TiposTelefone",
                        principalColumn: "CodigoTipoTelefone",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TiposTelefone",
                columns: new[] { "CodigoTipoTelefone", "DataInsercao", "DescricaoTipoTelefone", "UsuarioInsercao" },
                values: new object[,]
                {
                    { new Guid("0e481610-8420-410f-b02b-3ea66b39d854"), new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7476), "RESIDENCIAL", "sistema" },
                    { new Guid("1aaae748-3a5a-496e-8626-9692d277e1da"), new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7500), "CELULAR", "sistema" },
                    { new Guid("858dd8c5-921a-4a0b-aaeb-3293e4afcf05"), new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7495), "COMERCIAL", "sistema" },
                    { new Guid("fbe917e7-5d43-44cb-b375-e3cbe44e3d42"), new DateTime(2025, 9, 7, 23, 5, 41, 177, DateTimeKind.Utc).AddTicks(7498), "WHATSAPP", "sistema" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_CodigoTipoTelefone",
                table: "Telefones",
                column: "CodigoTipoTelefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposTelefone");
        }
    }
}
