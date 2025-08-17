using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Api_v2.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mCQ_Options",
                columns: table => new
                {
                    Option_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Correct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mCQ_Options", x => x.Option_ID);
                });

            migrationBuilder.CreateTable(
                name: "questionTypes",
                columns: table => new
                {
                    Question_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionType_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionTypes", x => x.Question_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_Num = table.Column<int>(type: "int", nullable: true),
                    Business_Entity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Status_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Business_Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Num = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password_Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_ID = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Account_ID);
                    table.ForeignKey(
                        name: "FK_accounts_roles_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_statuses_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "statuses",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    Exam_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.Exam_ID);
                    table.ForeignKey(
                        name: "FK_exams_accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    Login_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password_Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_ID = table.Column<int>(type: "int", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.Login_ID);
                    table.ForeignKey(
                        name: "FK_logins_accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logins_statuses_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "statuses",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "questionBanks",
                columns: table => new
                {
                    Question_Bank_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Correct_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    Question_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Option_ID = table.Column<int>(type: "int", nullable: false),
                    OptionsOption_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionBanks", x => x.Question_Bank_ID);
                    table.ForeignKey(
                        name: "FK_questionBanks_accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_questionBanks_mCQ_Options_Option_ID",
                        column: x => x.Option_ID,
                        principalTable: "mCQ_Options",
                        principalColumn: "Option_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_questionBanks_mCQ_Options_OptionsOption_ID",
                        column: x => x.OptionsOption_ID,
                        principalTable: "mCQ_Options",
                        principalColumn: "Option_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_questionBanks_questionTypes_Question_Type_ID",
                        column: x => x.Question_Type_ID,
                        principalTable: "questionTypes",
                        principalColumn: "Question_Type_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exam_QuestionBanks",
                columns: table => new
                {
                    Exam_QB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Exam_ID = table.Column<int>(type: "int", nullable: false),
                    Question_Bank_ID = table.Column<int>(type: "int", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam_QuestionBanks", x => x.Exam_QB_ID);
                    table.ForeignKey(
                        name: "FK_exam_QuestionBanks_accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exam_QuestionBanks_exams_Exam_ID",
                        column: x => x.Exam_ID,
                        principalTable: "exams",
                        principalColumn: "Exam_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exam_QuestionBanks_questionBanks_Question_Bank_ID",
                        column: x => x.Question_Bank_ID,
                        principalTable: "questionBanks",
                        principalColumn: "Question_Bank_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fill_In_Gaps",
                columns: table => new
                {
                    Gap_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gap_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correct_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question_Bank_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fill_In_Gaps", x => x.Gap_ID);
                    table.ForeignKey(
                        name: "FK_fill_In_Gaps_questionBanks_Question_Bank_ID",
                        column: x => x.Question_Bank_ID,
                        principalTable: "questionBanks",
                        principalColumn: "Question_Bank_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trueOrFalses",
                columns: table => new
                {
                    Question_Bank_ID = table.Column<int>(type: "int", nullable: false),
                    Correct_Ans = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trueOrFalses", x => x.Question_Bank_ID);
                    table.ForeignKey(
                        name: "FK_trueOrFalses_questionBanks_Question_Bank_ID",
                        column: x => x.Question_Bank_ID,
                        principalTable: "questionBanks",
                        principalColumn: "Question_Bank_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_ExamQBs",
                columns: table => new
                {
                    Student_QB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    Exam_QB_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_ExamQBs", x => x.Student_QB);
                    table.ForeignKey(
                        name: "FK_student_ExamQBs_accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_ExamQBs_exam_QuestionBanks_Exam_QB_ID",
                        column: x => x.Exam_QB_ID,
                        principalTable: "exam_QuestionBanks",
                        principalColumn: "Exam_QB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_Email",
                table: "accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_NationalId",
                table: "accounts",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_Role_ID",
                table: "accounts",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_Status_ID",
                table: "accounts",
                column: "Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_exam_QuestionBanks_Account_ID",
                table: "exam_QuestionBanks",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_exam_QuestionBanks_Exam_ID",
                table: "exam_QuestionBanks",
                column: "Exam_ID");

            migrationBuilder.CreateIndex(
                name: "IX_exam_QuestionBanks_Question_Bank_ID",
                table: "exam_QuestionBanks",
                column: "Question_Bank_ID");

            migrationBuilder.CreateIndex(
                name: "IX_exams_Account_ID",
                table: "exams",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_fill_In_Gaps_Question_Bank_ID",
                table: "fill_In_Gaps",
                column: "Question_Bank_ID");

            migrationBuilder.CreateIndex(
                name: "IX_logins_Account_ID",
                table: "logins",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_logins_Status_ID",
                table: "logins",
                column: "Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_questionBanks_Account_ID",
                table: "questionBanks",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_questionBanks_Option_ID",
                table: "questionBanks",
                column: "Option_ID");

            migrationBuilder.CreateIndex(
                name: "IX_questionBanks_OptionsOption_ID",
                table: "questionBanks",
                column: "OptionsOption_ID");

            migrationBuilder.CreateIndex(
                name: "IX_questionBanks_Question_Type_ID",
                table: "questionBanks",
                column: "Question_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_Role_Name",
                table: "roles",
                column: "Role_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_ExamQBs_Account_ID",
                table: "student_ExamQBs",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_student_ExamQBs_Exam_QB_ID",
                table: "student_ExamQBs",
                column: "Exam_QB_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fill_In_Gaps");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "student_ExamQBs");

            migrationBuilder.DropTable(
                name: "trueOrFalses");

            migrationBuilder.DropTable(
                name: "exam_QuestionBanks");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "questionBanks");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "mCQ_Options");

            migrationBuilder.DropTable(
                name: "questionTypes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "statuses");
        }
    }
}
