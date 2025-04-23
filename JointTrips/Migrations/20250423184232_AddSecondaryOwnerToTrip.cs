using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JointTrips.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondaryOwnerToTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserTrip_AspNetUsers_ParticipantsId",
                table: "ApplicationUserTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserTrip_Trips_TripsJoinedId",
                table: "ApplicationUserTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserTrip",
                table: "ApplicationUserTrip");

            migrationBuilder.RenameTable(
                name: "ApplicationUserTrip",
                newName: "TripParticipants");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserTrip_TripsJoinedId",
                table: "TripParticipants",
                newName: "IX_TripParticipants_TripsJoinedId");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryOwnerId",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripParticipants",
                table: "TripParticipants",
                columns: new[] { "ParticipantsId", "TripsJoinedId" });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_SecondaryOwnerId",
                table: "Trips",
                column: "SecondaryOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripParticipants_AspNetUsers_ParticipantsId",
                table: "TripParticipants",
                column: "ParticipantsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripParticipants_Trips_TripsJoinedId",
                table: "TripParticipants",
                column: "TripsJoinedId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_AspNetUsers_SecondaryOwnerId",
                table: "Trips",
                column: "SecondaryOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripParticipants_AspNetUsers_ParticipantsId",
                table: "TripParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TripParticipants_Trips_TripsJoinedId",
                table: "TripParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_SecondaryOwnerId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_SecondaryOwnerId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripParticipants",
                table: "TripParticipants");

            migrationBuilder.DropColumn(
                name: "SecondaryOwnerId",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "TripParticipants",
                newName: "ApplicationUserTrip");

            migrationBuilder.RenameIndex(
                name: "IX_TripParticipants_TripsJoinedId",
                table: "ApplicationUserTrip",
                newName: "IX_ApplicationUserTrip_TripsJoinedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserTrip",
                table: "ApplicationUserTrip",
                columns: new[] { "ParticipantsId", "TripsJoinedId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserTrip_AspNetUsers_ParticipantsId",
                table: "ApplicationUserTrip",
                column: "ParticipantsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserTrip_Trips_TripsJoinedId",
                table: "ApplicationUserTrip",
                column: "TripsJoinedId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
