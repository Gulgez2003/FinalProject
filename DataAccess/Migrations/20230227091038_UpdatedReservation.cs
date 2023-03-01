using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdatedReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "Reservations",
                newName: "NumberOfInfants");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Reservations",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAdults",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "NumberOfAdults",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "NumberOfInfants",
                table: "Reservations",
                newName: "NumberOfPeople");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Reservations",
                newName: "Name");
        }
    }
}
