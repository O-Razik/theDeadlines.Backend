using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theDeadlines.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deadline",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Deadline__3213E83F60841816", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubDeadline",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    deadline_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deadline_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubDeadl__3213E83F351D4B4C", x => x.id);
                    table.ForeignKey(
                        name: "FK__SubDeadli__deadl__398D8EEE",
                        column: x => x.deadline_id,
                        principalTable: "Deadline",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Checklist",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sub_deadline_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Checklis__3213E83F7436A59C", x => x.id);
                    table.ForeignKey(
                        name: "FK__Checklist__sub_d__3C69FB99",
                        column: x => x.sub_deadline_id,
                        principalTable: "SubDeadline",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ChecklistItem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    is_completed = table.Column<bool>(type: "bit", nullable: false),
                    checklist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Checklis__3213E83F2AFA52A5", x => x.id);
                    table.ForeignKey(
                        name: "FK__Checklist__check__403A8C7D",
                        column: x => x.checklist_id,
                        principalTable: "Checklist",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_sub_deadline_id",
                table: "Checklist",
                column: "sub_deadline_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItem_checklist_id",
                table: "ChecklistItem",
                column: "checklist_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubDeadline_deadline_id",
                table: "SubDeadline",
                column: "deadline_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistItem");

            migrationBuilder.DropTable(
                name: "Checklist");

            migrationBuilder.DropTable(
                name: "SubDeadline");

            migrationBuilder.DropTable(
                name: "Deadline");
        }
    }
}
