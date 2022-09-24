using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizService.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name_SQ = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_NO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_SQ = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_NO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_SQ = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description_EN = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description_NO = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizID = table.Column<int>(type: "int", nullable: false),
                    QuestionTypeID = table.Column<int>(type: "int", nullable: false),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Name_SQ = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_NO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QuestionTypeID",
                        column: x => x.QuestionTypeID,
                        principalTable: "QuestionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    Name_SQ = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name_NO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Option_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Option_QuestionID",
                table: "Option",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeID",
                table: "Question",
                column: "QuestionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                column: "QuizID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
