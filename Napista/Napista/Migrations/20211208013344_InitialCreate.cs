using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Napista.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id_Compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qtde_comprada = table.Column<int>(type: "int", nullable: false),
                    CartaoNumero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id_Compra);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id_Pagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprasId_Compra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id_Pagamento);
                    table.ForeignKey(
                        name: "FK_Pagamento_Compras_ComprasId_Compra",
                        column: x => x.ComprasId_Compra,
                        principalTable: "Compras",
                        principalColumn: "Id_Compra",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor_unitario = table.Column<float>(type: "real", nullable: false),
                    Qtde_estoque = table.Column<int>(type: "int", nullable: false),
                    ComprasId_Compra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Compras_ComprasId_Compra",
                        column: x => x.ComprasId_Compra,
                        principalTable: "Compras",
                        principalColumn: "Id_Compra",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_expedicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    PagamentoId_Pagamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Cartao_Pagamento_PagamentoId_Pagamento",
                        column: x => x.PagamentoId_Pagamento,
                        principalTable: "Pagamento",
                        principalColumn: "Id_Pagamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_PagamentoId_Pagamento",
                table: "Cartao",
                column: "PagamentoId_Pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CartaoNumero",
                table: "Compras",
                column: "CartaoNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_ComprasId_Compra",
                table: "Pagamento",
                column: "ComprasId_Compra");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ComprasId_Compra",
                table: "Produtos",
                column: "ComprasId_Compra");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Cartao_CartaoNumero",
                table: "Compras",
                column: "CartaoNumero",
                principalTable: "Cartao",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_Pagamento_PagamentoId_Pagamento",
                table: "Cartao");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
