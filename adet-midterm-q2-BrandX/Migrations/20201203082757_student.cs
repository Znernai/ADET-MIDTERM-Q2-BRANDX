using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrandX.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quiz1 = table.Column<int>(nullable: false),
                    Quiz2 = table.Column<int>(nullable: false),
                    Quiz3 = table.Column<int>(nullable: false),
                    Assignment1 = table.Column<int>(nullable: false),
                    Assignment2 = table.Column<int>(nullable: false),
                    Assignment3 = table.Column<int>(nullable: false),
                    Exam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Midterm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quiz1 = table.Column<int>(nullable: false),
                    Quiz2 = table.Column<int>(nullable: false),
                    Quiz3 = table.Column<int>(nullable: false),
                    Assignment1 = table.Column<int>(nullable: false),
                    Assignment2 = table.Column<int>(nullable: false),
                    Assignment3 = table.Column<int>(nullable: false),
                    Exam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midterm", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prefinal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quiz1 = table.Column<int>(nullable: false),
                    Quiz2 = table.Column<int>(nullable: false),
                    Quiz3 = table.Column<int>(nullable: false),
                    Assignment1 = table.Column<int>(nullable: false),
                    Assignment2 = table.Column<int>(nullable: false),
                    Assignment3 = table.Column<int>(nullable: false),
                    Exam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefinal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prelim",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quiz1 = table.Column<int>(nullable: false),
                    Quiz2 = table.Column<int>(nullable: false),
                    Quiz3 = table.Column<int>(nullable: false),
                    Assignment1 = table.Column<int>(nullable: false),
                    Assignment2 = table.Column<int>(nullable: false),
                    Assignment3 = table.Column<int>(nullable: false),
                    Exam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prelim", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finals");

            migrationBuilder.DropTable(
                name: "Midterm");

            migrationBuilder.DropTable(
                name: "Prefinal");

            migrationBuilder.DropTable(
                name: "Prelim");

            migrationBuilder.DropTable(
                name: "StudentInfo");
        }
    }
}
