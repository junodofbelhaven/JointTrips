using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JointTrips.Migrations
{
    /// <inheritdoc />
    public partial class updateTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripParticipants");

            migrationBuilder.CreateTable(
                name: "ApplicationUserTrip",
                columns: table => new
                {
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripsJoinedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTrip", x => new { x.ParticipantsId, x.TripsJoinedId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTrip_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTrip_Trips_TripsJoinedId",
                        column: x => x.TripsJoinedId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTrip_TripsJoinedId",
                table: "ApplicationUserTrip",
                column: "TripsJoinedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTrip");

            migrationBuilder.CreateTable(
                name: "TripParticipants",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripParticipants", x => new { x.TripId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TripParticipants_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripParticipants_UserId",
                table: "TripParticipants",
                column: "UserId");
        }
    }
}
