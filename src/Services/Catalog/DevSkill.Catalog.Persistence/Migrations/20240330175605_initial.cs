using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSkill.Catalog.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3510), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3511), "Data Science" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3458), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3480), "Web Development" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3531), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3532), "Mobile Development" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3541), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3542), "Backend Development" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "Duration", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6ab7ba3c-330d-48a9-8c3f-21e72931f6d2"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3590), "Curso de HTML 5 COMPLETO e com Projetos Práticos para WEB", 46, "https://img-b.udemycdn.com/course/240x135/2231672_d36d_4.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3591), "Curso de HTML 5 COMPLETO e com Projetos Práticos para WEB", 350 },
                    { new Guid("7490207f-edff-4201-9e67-95ad48225358"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3606), "HTML e CSS Essencial -Front End Completo para Iniciantes", 46, "https://img-c.udemycdn.com/course/240x135/1755476_2755_5.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3607), "HTML e CSS Essencial -Front End Completo para Iniciantes", 110 },
                    { new Guid("812941fc-d06d-4158-80a9-e3c3b13a7c0b"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3563), "Description of Curso de C#", 10, "https://img-c.udemycdn.com/course/240x135/1581488_e3e1_2.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3564), "Curso de C#", 100 },
                    { new Guid("8816ca0b-73a1-4844-aa00-ad0234507d74"), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3646), "Flutter - Beginners Course", 43, "https://img-c.udemycdn.com/course/240x135/1586752_2d9e_2.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3647), "Flutter - Beginners Course", 120 },
                    { new Guid("a20964c4-e972-46e7-9cab-99e325cdae0e"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3619), "Web Design: Construa Sites com PHP, HTML, CSS e JavaScript", 120, "https://img-c.udemycdn.com/course/240x135/1586752_2d9e_2.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3620), "Web Design: Construa Sites com PHP, HTML, CSS e JavaScript", 70 },
                    { new Guid("b6aff6ab-a6a4-46ba-bd86-8031f21d7796"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3578), "Description of Curso de Python", 25, "https://img-c.udemycdn.com/course/240x135/567828_67d0.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3579), "Curso de Python", 200 },
                    { new Guid("ba24d51f-2946-4fa5-8006-a29af5b84b4d"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3635), "Python for Data Science and Machine Learning Bootcamp", 100, "https://img-c.udemycdn.com/course/240x135/1586752_2d9e_2.jpg", "System", new DateTime(2024, 3, 30, 14, 56, 5, 772, DateTimeKind.Local).AddTicks(3635), "Python for Data Science and Machine Learning Bootcamp", 87 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
