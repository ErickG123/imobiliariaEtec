using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImobiliariaEtec.Migrations
{
    public partial class Imobiliaria2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoEstabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstabelecimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Endereco = table.Column<string>(maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(maxLength: 60, nullable: true),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    NumQuartos = table.Column<int>(nullable: false),
                    NumBanheiros = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TipoEstabelecimentoId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimento_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estabelecimento_TipoEstabelecimento_TipoEstabelecimentoId",
                        column: x => x.TipoEstabelecimentoId,
                        principalTable: "TipoEstabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimento_CidadeId",
                table: "Estabelecimento",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimento_TipoEstabelecimentoId",
                table: "Estabelecimento",
                column: "TipoEstabelecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimento");

            migrationBuilder.DropTable(
                name: "TipoEstabelecimento");
        }
    }
}
