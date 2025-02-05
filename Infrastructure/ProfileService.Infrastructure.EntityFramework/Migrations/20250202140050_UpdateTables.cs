using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientProfileInfoId",
                table: "ClientProfileInfo",
                newName: "OwnerProfileInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerProfileInfoId",
                table: "ClientProfileInfo",
                newName: "ClientProfileInfoId");
        }
    }
}
