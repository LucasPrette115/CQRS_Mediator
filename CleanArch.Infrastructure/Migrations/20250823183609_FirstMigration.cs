using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "Gender", "IsActive", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6d59e76a-eb4d-4957-8734-4111b375fc52"), new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(6231), null, "leonhard.euler@example", "Leonhard", "Male", true, "Euler", new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(6233) },
                    { new Guid("7924816e-af12-4f3e-abdf-ab1e2e613a18"), new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(4290), null, "carl.gauss@example", "Carl", "Male", true, "Gauss", new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(4298) },
                    { new Guid("c89afcb4-e59d-4eff-8324-b70de9fdc53a"), new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(6237), null, "marie.curie@example", "Marie", "Female", true, "Curie", new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(6238) },
                    { new Guid("dfaca3cd-b7c1-4d86-9ede-f7ec905178d3"), new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(6235), null, "ada.lovelace@example", "Ada", "Female", true, "Lovelace", new DateTime(2025, 8, 23, 15, 36, 8, 778, DateTimeKind.Local).AddTicks(6236) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
