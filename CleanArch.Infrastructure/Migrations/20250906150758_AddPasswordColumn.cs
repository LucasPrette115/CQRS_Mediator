using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("6d59e76a-eb4d-4957-8734-4111b375fc52"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("7924816e-af12-4f3e-abdf-ab1e2e613a18"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("c89afcb4-e59d-4eff-8324-b70de9fdc53a"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("dfaca3cd-b7c1-4d86-9ede-f7ec905178d3"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Members",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "Gender", "IsActive", "LastName", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0aa1efde-c798-40dd-b85c-a4c58cfda446"), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "carl.gauss@example", "Carl", "Male", true, "Gauss", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e386b6b-1fbb-409f-94f1-5ef10887a3b5"), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "marie.curie@example", "Marie", "Female", true, "Curie", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60176952-afc2-4cf7-ab94-ad142d343c47"), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "leonhard.euler@example", "Leonhard", "Male", true, "Euler", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d084a8c1-8d83-473d-8ebd-ea204adb5bfc"), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ada.lovelace@example", "Ada", "Female", true, "Lovelace", "6F852F607905CE1E58918A6BE99F793F0DEC1A2938D4BE901519B9D526D0FC57A0062378B42994098AB3F6208E2E8B2021AAB15D40814711701BAF8DDE22EE56-A8CF68410CABDAD5B6DC7B222D523923", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("0aa1efde-c798-40dd-b85c-a4c58cfda446"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("4e386b6b-1fbb-409f-94f1-5ef10887a3b5"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("60176952-afc2-4cf7-ab94-ad142d343c47"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("d084a8c1-8d83-473d-8ebd-ea204adb5bfc"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Members");

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
    }
}
