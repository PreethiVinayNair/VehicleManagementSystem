using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Domain.Migrations
{
    public partial class coretex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(nullable: true),
                    speed = table.Column<int>(nullable: false),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    temperature = table.Column<float>(nullable: false),
                    pressure = table.Column<float>(nullable: false),
                    Utc = table.Column<DateTime>(nullable: false),
                    drivermessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles");
        }
    }
}
