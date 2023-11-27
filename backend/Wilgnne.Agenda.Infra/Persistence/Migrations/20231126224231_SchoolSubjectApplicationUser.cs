using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wilgnne.Agenda.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchoolSubjectApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SchoolSubjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjects_UserId",
                table: "SchoolSubjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolSubjects_Users_UserId",
                table: "SchoolSubjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolSubjects_Users_UserId",
                table: "SchoolSubjects");

            migrationBuilder.DropIndex(
                name: "IX_SchoolSubjects_UserId",
                table: "SchoolSubjects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SchoolSubjects");
        }
    }
}
