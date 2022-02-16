﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonWeb.Migrations
{
    public partial class ProgramareTip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialistID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Specialist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialistNume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipMasaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramareTip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramareID = table.Column<int>(type: "int", nullable: false),
                    TipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramareTip", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramareTip_Programare_ProgramareID",
                        column: x => x.ProgramareID,
                        principalTable: "Programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramareTip_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_SpecialistID",
                table: "Programare",
                column: "SpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareTip_ProgramareID",
                table: "ProgramareTip",
                column: "ProgramareID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareTip_TipID",
                table: "ProgramareTip",
                column: "TipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Specialist_SpecialistID",
                table: "Programare",
                column: "SpecialistID",
                principalTable: "Specialist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Specialist_SpecialistID",
                table: "Programare");

            migrationBuilder.DropTable(
                name: "ProgramareTip");

            migrationBuilder.DropTable(
                name: "Specialist");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropIndex(
                name: "IX_Programare_SpecialistID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "SpecialistID",
                table: "Programare");
        }
    }
}
