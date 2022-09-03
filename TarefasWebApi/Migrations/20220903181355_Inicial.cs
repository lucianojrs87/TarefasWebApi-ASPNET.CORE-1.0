using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TarefasWebApi.Models.Enums;

namespace TarefasWebApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Codigo", "Descricao", "Status" },
                values: new object[] { 1, "Tomar café da manhã", 1 });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Codigo", "Descricao", "Status" },
                values: new object[] { 2, "Levar as crianças para a escola", 1 });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Codigo", "Descricao", "Status" },
                values: new object[] { 3, "Ir ao trabalho", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
