using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JointTrips.Migrations
{
    /// <inheritdoc />
    public partial class RenameTripParticipantsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripParticipants_AspNetUsers_ParticipantsId",
                table: "TripParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TripParticipants_Trips_TripsJoinedId",
                table: "TripParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripParticipants",
                table: "TripParticipants");

            migrationBuilder.DropIndex(
                name: "IX_TripParticipants_TripsJoinedId",
                table: "TripParticipants");

            migrationBuilder.RenameColumn(
                name: "TripsJoinedId",
                table: "TripParticipants",
                newName: "TripId");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "TripParticipants",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripParticipants",
                table: "TripParticipants",
                columns: new[] { "TripId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_TripParticipants_UserId",
                table: "TripParticipants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripParticipants_Trips_TripId",
                table: "TripParticipants",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripParticipants_Users_UserId",
                table: "TripParticipants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripParticipants_Trips_TripId",
                table: "TripParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TripParticipants_Users_UserId",
                table: "TripParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripParticipants",
                table: "TripParticipants");

            migrationBuilder.DropIndex(
                name: "IX_TripParticipants_UserId",
                table: "TripParticipants");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TripParticipants",
                newName: "ParticipantsId");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "TripParticipants",
                newName: "TripsJoinedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripParticipants",
                table: "TripParticipants",
                columns: new[] { "ParticipantsId", "TripsJoinedId" });

            migrationBuilder.CreateIndex(
                name: "IX_TripParticipants_TripsJoinedId",
                table: "TripParticipants",
                column: "TripsJoinedId");

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
        }
    }
}
