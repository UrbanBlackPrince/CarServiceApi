using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Car Brand"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Car Color"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Car Registration Number")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
