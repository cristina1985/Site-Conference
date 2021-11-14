using Microsoft.EntityFrameworkCore.Migrations;

namespace Conference.Domain.Migrations
{
    public partial class Workshops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PlacesAvailable = table.Column<int>(nullable: true),
                    RegistrationLink = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    RegistrationOpened = table.Column<bool>(nullable: false),
                    Prerequisites = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    WorkshopID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Speakers_Workshops_WorkshopID",
                        column: x => x.WorkshopID,
                        principalTable: "Workshops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    FeedbackEnabled = table.Column<bool>(nullable: false),
                    SpeakerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Talks_Speakers_SpeakerID",
                        column: x => x.SpeakerID,
                        principalTable: "Speakers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_WorkshopID",
                table: "Speakers",
                column: "WorkshopID");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_SpeakerID",
                table: "Talks",
                column: "SpeakerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talks");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
