using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RastreoFirplak.Infrastructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroGuia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correotransportador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FH_Recogido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FH_CentroOrigen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FH_Viajando = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FH_CentroDestino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FH_ZonaDistribucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FH_Entregado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FH_POD = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoPODs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPODs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoPODs_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosEntregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDespacho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosEntregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosEntregas_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPODs_GuiaId",
                table: "DocumentoPODs",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosEntregas_GuiaId",
                table: "DocumentosEntregas",
                column: "GuiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoPODs");

            migrationBuilder.DropTable(
                name: "DocumentosEntregas");

            migrationBuilder.DropTable(
                name: "Guias");
        }
    }
}
