using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasketballApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Conference = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Arena = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Coach_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    HighSchool = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "College",
                columns: new[] { "ID", "Arena", "City", "Conference", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Assembly Hall", "Bloomington", "Big Ten", "Indiana University", "Indiana" },
                    { 2, "Mackey Arena", "West Lafayette", "Big Ten", "Purdue University", "Indiana" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Point Guard" },
                    { 2, "Shooting Guard" },
                    { 3, "Small Forward" },
                    { 4, "Power Forward" },
                    { 5, "Center" }
                });

            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "ID", "CollegeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Mike Woodson" },
                    { 2, 2, "Matt Painter" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "CollegeId", "Height", "HighSchool", "Name", "Number", "PositionId", "Weight" },
                values: new object[,]
                {
                    { 1, 2, 88, "IMG Academy", "Zach Edey", 15, 5, 305 },
                    { 2, 1, 80, "Roselle Catholic High School", "Mackenzie Mgbako", 21, 3, 215 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coach_CollegeId",
                table: "Coach",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CollegeId",
                table: "Players",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
