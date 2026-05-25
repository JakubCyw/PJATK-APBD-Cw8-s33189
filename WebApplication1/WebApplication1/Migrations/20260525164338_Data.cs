using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BedTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Łóżko standardowe", "Standard" },
                    { 2, "Łóżko OIOM", "Intensywna terapia" },
                    { 3, "Łóżko rehabilitacyjne", "Rehabilitacyjne" },
                    { 4, "Łóżko pediatryczne", "Dziecięce" },
                    { 5, "Łóżko sterowane elektrycznie", "Elektryczne" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Pesel", "Age", "FirstName", "LastName", "Sex" },
                values: new object[,]
                {
                    { "04122098765", 20, "Zuzanna", "Kaczmarek", true },
                    { "68111122233", 57, "Marek", "Lewandowski", false },
                    { "72031245678", 53, "Piotr", "Wiśniewski", false },
                    { "85050567890", 40, "Anna", "Nowak", true },
                    { "90010112345", 35, "Jan", "Kowalski", false }
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Oddział chorób serca i układu krążenia", "Kardiologia" },
                    { 2, "Oddział chirurgii ogólnej", "Chirurgia" },
                    { 3, "Oddział leczenia urazów i schorzeń kości", "Ortopedia" },
                    { 4, "Oddział dziecięcy", "Pediatria" },
                    { 5, "Oddział chorób układu nerwowego", "Neurologia" }
                });

            migrationBuilder.InsertData(
                table: "Admissions",
                columns: new[] { "Id", "AdmissionDate", "DischargeDate", "PatientPesel", "WardId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "90010112345", 1 },
                    { 2, new DateTime(2026, 5, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), null, "85050567890", 2 },
                    { 3, new DateTime(2026, 5, 6, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "72031245678", 3 },
                    { 4, new DateTime(2026, 5, 8, 8, 45, 0, 0, DateTimeKind.Unspecified), null, "04122098765", 4 },
                    { 5, new DateTime(2026, 5, 9, 16, 20, 0, 0, DateTimeKind.Unspecified), null, "68111122233", 5 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HasTv", "WardId" },
                values: new object[,]
                {
                    { "A101", true, 1 },
                    { "B201", true, 2 },
                    { "C301", false, 3 },
                    { "D401", true, 4 },
                    { "E501", false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "Id", "BedTypeId", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, "A101" },
                    { 2, 2, "B201" },
                    { 3, 3, "C301" },
                    { 4, 4, "D401" },
                    { 5, 5, "E501" }
                });

            migrationBuilder.InsertData(
                table: "BadAssignments",
                columns: new[] { "Id", "BedId", "From", "PatientPesel", "To" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "90010112345", new DateTime(2026, 5, 5, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2026, 5, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), "85050567890", null },
                    { 3, 3, new DateTime(2026, 5, 6, 12, 30, 0, 0, DateTimeKind.Unspecified), "72031245678", new DateTime(2026, 5, 10, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2026, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "04122098765", null },
                    { 5, 5, new DateTime(2026, 5, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), "68111122233", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BadAssignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BadAssignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BadAssignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BadAssignments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BadAssignments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Pesel",
                keyValue: "04122098765");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Pesel",
                keyValue: "68111122233");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Pesel",
                keyValue: "72031245678");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Pesel",
                keyValue: "85050567890");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Pesel",
                keyValue: "90010112345");

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "A101");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "B201");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "C301");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "D401");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "E501");

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
