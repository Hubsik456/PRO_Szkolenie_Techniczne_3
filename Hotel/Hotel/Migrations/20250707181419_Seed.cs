using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        private void InsertData(MigrationBuilder migrationBuilder, string FirstName, string LastName, DateOnly DateOfBirth, string Email, string PhoneNumber)
        {
            migrationBuilder.InsertData("Clients", schema: "w67259_PRO_ST3", columns: new[] { "FirstName", "LastName", "DateOfBirth", "Email", "PhoneNumber" },
                values: new object[] { FirstName, LastName, DateOfBirth, Email, PhoneNumber });
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            InsertData(migrationBuilder, "Imię #1", "Nazwisko #1", new DateOnly(2025, 1, 20), "Email_1@wip.com", "501-234-567");
            InsertData(migrationBuilder, "Imię #2", "Nazwisko #2", new DateOnly(2025, 1, 21), "Email_2@wip.com", "660-555-444");
            InsertData(migrationBuilder, "Imię #3", "Nazwisko #3", new DateOnly(2025, 1, 22), "Email_3@wip.com", "600-987-654");
            InsertData(migrationBuilder, "Imię #4", "Nazwisko #4", new DateOnly(2025, 1, 23), "Email_4@wip.com", "801-402-503");
            InsertData(migrationBuilder, "Imię #5", "Nazwisko #5", new DateOnly(2025, 1, 24), "Email_5@wip.com", "691-300-600");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
