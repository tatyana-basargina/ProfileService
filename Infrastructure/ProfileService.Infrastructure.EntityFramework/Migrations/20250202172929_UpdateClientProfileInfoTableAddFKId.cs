using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientProfileInfoTableAddFKId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_Profiles_Id",
                table: "ClientProfiles",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_Profiles_Id",
                table: "ClientProfiles");
        }
    }
}
