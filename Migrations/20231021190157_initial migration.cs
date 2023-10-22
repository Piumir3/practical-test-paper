using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNefc.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NumSeats = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsSingleColor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RegNo);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VehicleRegNo = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                    table.ForeignKey(
                        name: "FK_Colors_Vehicles_VehicleRegNo",
                        column: x => x.VehicleRegNo,
                        principalTable: "Vehicles",
                        principalColumn: "RegNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_VehicleRegNo",
                table: "Colors",
                column: "VehicleRegNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
