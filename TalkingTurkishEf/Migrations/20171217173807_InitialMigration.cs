using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TalkingTurkishEf.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Voices",
                columns: table => new
                {
                    VoiceId = table.Column<Guid>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    LanguangeLanguageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voices", x => x.VoiceId);
                    table.ForeignKey(
                        name: "FK_Voices_Languages_LanguangeLanguageId",
                        column: x => x.LanguangeLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    ThingId = table.Column<Guid>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    PictureName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    VoiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.ThingId);
                    table.ForeignKey(
                        name: "FK_Things_Voices_VoiceId",
                        column: x => x.VoiceId,
                        principalTable: "Voices",
                        principalColumn: "VoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Things_VoiceId",
                table: "Things",
                column: "VoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Voices_LanguangeLanguageId",
                table: "Voices",
                column: "LanguangeLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Things");

            migrationBuilder.DropTable(
                name: "Voices");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
