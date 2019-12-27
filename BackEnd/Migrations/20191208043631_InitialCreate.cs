using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BackEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premiacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Tipo = table.Column<string>(nullable: true),
                    QuantidadePremiados = table.Column<int>(nullable: false),
                    DesafioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premiacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desafio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NomeDesafio = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Etapas = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    PremiacaoId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desafio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desafio_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desafio_Premiacao_PremiacaoId",
                        column: x => x.PremiacaoId,
                        principalTable: "Premiacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ImgURL = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    DesafioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badge_Desafio_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Badge_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesafioUsuario",
                columns: table => new
                {
                    DesafioId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesafioUsuario", x => new { x.DesafioId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_DesafioUsuario_Desafio_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesafioUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ganhador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(nullable: true),
                    LinkedinUrl = table.Column<string>(nullable: true),
                    DesafioId = table.Column<int>(nullable: true),
                    PremiacaoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganhador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ganhador_Desafio_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ganhador_Premiacao_PremiacaoId",
                        column: x => x.PremiacaoId,
                        principalTable: "Premiacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ganhador_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_DesafioId",
                table: "Badge",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_Badge_UsuarioId",
                table: "Badge",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Desafio_EmpresaId",
                table: "Desafio",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Desafio_PremiacaoId",
                table: "Desafio",
                column: "PremiacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesafioUsuario_UsuarioId",
                table: "DesafioUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhador_DesafioId",
                table: "Ganhador",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhador_PremiacaoId",
                table: "Ganhador",
                column: "PremiacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhador_UsuarioId",
                table: "Ganhador",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "DesafioUsuario");

            migrationBuilder.DropTable(
                name: "Ganhador");

            migrationBuilder.DropTable(
                name: "Desafio");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Premiacao");
        }
    }
}
