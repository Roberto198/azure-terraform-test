using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vans",
                columns: table => new
                {
                    VanId = table.Column<Guid>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    MotExpriryDate = table.Column<DateTime>(nullable: true),
                    EnteredSystemDate = table.Column<DateTime>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    DriverClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vans", x => x.VanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vans");
        }
    }
}
