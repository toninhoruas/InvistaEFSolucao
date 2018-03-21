using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InvistaEFSolucao.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePessoa = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoID);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(nullable: true),
                    NomeEquipamento = table.Column<string>(nullable: true),
                    NomeFabricante = table.Column<string>(nullable: true),
                    Serie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoID);
                });

            migrationBuilder.CreateTable(
                name: "IndicadoresBiologicos",
                columns: table => new
                {
                    IndicadorBiologicoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorOriginal = table.Column<string>(nullable: true),
                    CorPosterior = table.Column<string>(nullable: true),
                    Microorganismo = table.Column<string>(nullable: true),
                    Produto = table.Column<string>(nullable: true),
                    ValorD = table.Column<string>(nullable: true),
                    ValorN = table.Column<string>(nullable: true),
                    ValorZ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadoresBiologicos", x => x.IndicadorBiologicoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    SenhaUsuario = table.Column<string>(nullable: true),
                    emailUsuario = table.Column<string>(nullable: true),
                    loginUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    ContatoComercialContatoID = table.Column<int>(nullable: true),
                    ContatoTecnicoContatoID = table.Column<int>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    InscricaoEstadual = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Contatos_ContatoComercialContatoID",
                        column: x => x.ContatoComercialContatoID,
                        principalTable: "Contatos",
                        principalColumn: "ContatoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Contatos_ContatoTecnicoContatoID",
                        column: x => x.ContatoTecnicoContatoID,
                        principalTable: "Contatos",
                        principalColumn: "ContatoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    CaminhoLogoEmpresa = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    ContatoComercialContatoID = table.Column<int>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    InscricaoEstadual = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresas_Contatos_ContatoComercialContatoID",
                        column: x => x.ContatoComercialContatoID,
                        principalTable: "Contatos",
                        principalColumn: "ContatoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContatoComercialContatoID",
                table: "Clientes",
                column: "ContatoComercialContatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContatoTecnicoContatoID",
                table: "Clientes",
                column: "ContatoTecnicoContatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ContatoComercialContatoID",
                table: "Empresas",
                column: "ContatoComercialContatoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "IndicadoresBiologicos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Contatos");
        }
    }
}
