using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wilgnne.Agenda.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchoolSubjectWeekSettingsSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolSubjectWeekSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SchoolSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjectWeekSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSubjectWeekSetting_SchoolSubjects_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSubjectSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    WeekSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjectSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSubjectSchedule_SchoolSubjectWeekSetting_WeekSettingId",
                        column: x => x.WeekSettingId,
                        principalTable: "SchoolSubjectWeekSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjectSchedule_WeekSettingId",
                table: "SchoolSubjectSchedule",
                column: "WeekSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjectWeekSetting_SchoolSubjectId",
                table: "SchoolSubjectWeekSetting",
                column: "SchoolSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolSubjectSchedule");

            migrationBuilder.DropTable(
                name: "SchoolSubjectWeekSetting");
        }
    }
}
