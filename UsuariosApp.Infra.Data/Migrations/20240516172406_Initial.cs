using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SOBRENOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SEXO = table.Column<int>(type: "int", nullable: false),
                    ENDERECO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FOTOPERFIL = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DATAHORACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAHORAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICOATIVIDADEUSUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICOATIVIDADEUSUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HISTORICOATIVIDADEUSUARIO_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOATIVIDADEUSUARIO_USUARIO_ID",
                table: "HISTORICOATIVIDADEUSUARIO",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Email",
                table: "USUARIO",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORICOATIVIDADEUSUARIO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
