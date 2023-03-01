namespace DataAccess.Migrations
{
    public partial class UpdatedReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureDateTime",
                table: "Reservations",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalDateTime",
                table: "Reservations",
                newName: "DepartureDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Reservations",
                newName: "DepartureDateTime");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "Reservations",
                newName: "ArrivalDateTime");
        }
    }
}
