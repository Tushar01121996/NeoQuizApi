using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickQuestionBank.Domain.Migrations
{
    public partial class AddQuizQuestionMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_QuestionAnswerMapping_QuizQuestions_QuestionId",
            //    table: "QuestionAnswerMapping");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_QuestionTypes_AspNetUsers_UserId",
            //    table: "QuestionTypes");

            //migrationBuilder.DropIndex(
            //    name: "IX_QuestionTypes_UserId",
            //    table: "QuestionTypes");

            //migrationBuilder.DropIndex(
            //    name: "IX_QuestionAnswerMapping_QuestionId",
            //    table: "QuestionAnswerMapping");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "QuestionTypes");

            //migrationBuilder.AlterColumn<int>(
            //    name: "SortOrder",
            //    table: "QuestionAnswerMapping",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            migrationBuilder.CreateTable(
                name: "QuizQuestionMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionMapping", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizQuestionMapping");

        //    migrationBuilder.AddColumn<string>(
        //        name: "UserId",
        //        table: "QuestionTypes",
        //        type: "nvarchar(450)",
        //        nullable: true);

        //    migrationBuilder.AlterColumn<string>(
        //        name: "SortOrder",
        //        table: "QuestionAnswerMapping",
        //        type: "nvarchar(max)",
        //        nullable: true,
        //        oldClrType: typeof(int),
        //        oldType: "int");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionTypes_UserId",
        //        table: "QuestionTypes",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionAnswerMapping_QuestionId",
        //        table: "QuestionAnswerMapping",
        //        column: "QuestionId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_QuestionAnswerMapping_QuizQuestions_QuestionId",
        //        table: "QuestionAnswerMapping",
        //        column: "QuestionId",
        //        principalTable: "QuizQuestions",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_QuestionTypes_AspNetUsers_UserId",
        //        table: "QuestionTypes",
        //        column: "UserId",
        //        principalTable: "AspNetUsers",
        //        principalColumn: "Id");
        }
    }
}
