using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Rezerwacja.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "w67259_PRO_ST3");

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "w67259_PRO_ST3",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                schema: "w67259_PRO_ST3",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Places_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalSchema: "w67259_PRO_ST3",
                        principalTable: "Reservations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_ReservationID",
                schema: "w67259_PRO_ST3",
                table: "Places",
                column: "ReservationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places",
                schema: "w67259_PRO_ST3");

            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "w67259_PRO_ST3");
        }
    }
}
