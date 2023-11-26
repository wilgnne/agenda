using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wilgnne.Agenda.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchoolSubjectEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolSubjectEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndEventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartEventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjectEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSubjectEvents_SchoolSubjects_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjectEvents_SchoolSubjectId",
                table: "SchoolSubjectEvents",
                column: "SchoolSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolSubjectEvents");
        }
    }
}
