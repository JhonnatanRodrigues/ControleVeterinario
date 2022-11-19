using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleVeterinario.Repositorio.Migrations
{
    public partial class UpdateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "CV_RFID",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "CV_RFID",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CV_TipoAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_TipoAnimal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CV_Raca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_Raca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CV_Raca_CV_TipoAnimal_IdTipoAnimal",
                        column: x => x.IdTipoAnimal,
                        principalTable: "CV_TipoAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CV_CadastroAnimais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRFID = table.Column<int>(type: "int", nullable: false),
                    IdTipoAnimal = table.Column<int>(type: "int", nullable: false),
                    IdRaca = table.Column<int>(type: "int", nullable: false),
                    DataNacimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    abat_morte = table.Column<bool>(type: "bit", nullable: true),
                    DataAbat_Morte = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Genero = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_CadastroAnimais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CV_CadastroAnimais_CV_Raca_IdRaca",
                        column: x => x.IdRaca,
                        principalTable: "CV_Raca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV_CadastroAnimais_CV_RFID_IdRFID",
                        column: x => x.IdRFID,
                        principalTable: "CV_RFID",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV_CadastroAnimais_CV_TipoAnimal_IdTipoAnimal",
                        column: x => x.IdTipoAnimal,
                        principalTable: "CV_TipoAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CV_Alimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    DataHora_FoiCome = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataHora_ParoCome = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ParoCome = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_Alimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CV_Alimentacao_CV_CadastroAnimais_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "CV_CadastroAnimais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CV_Alimentacao_IdAnimal",
                table: "CV_Alimentacao",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CadastroAnimais_IdRaca",
                table: "CV_CadastroAnimais",
                column: "IdRaca");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CadastroAnimais_IdRFID",
                table: "CV_CadastroAnimais",
                column: "IdRFID");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CadastroAnimais_IdTipoAnimal",
                table: "CV_CadastroAnimais",
                column: "IdTipoAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_CV_Raca_IdTipoAnimal",
                table: "CV_Raca",
                column: "IdTipoAnimal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CV_Alimentacao");

            migrationBuilder.DropTable(
                name: "CV_CadastroAnimais");

            migrationBuilder.DropTable(
                name: "CV_Raca");

            migrationBuilder.DropTable(
                name: "CV_TipoAnimal");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "CV_RFID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CV_RFID",
                newName: "Codigo");
        }
    }
}
