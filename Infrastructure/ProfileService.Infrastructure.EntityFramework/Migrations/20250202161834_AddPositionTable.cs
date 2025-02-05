using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfileInfo_Profiles_Id",
                table: "ClientProfileInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientProfileInfo",
                table: "ClientProfileInfo");

            migrationBuilder.RenameTable(
                name: "ClientProfileInfo",
                newName: "ClientProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientProfiles",
                table: "ClientProfiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientProfiles",
                table: "ClientProfiles");

            migrationBuilder.RenameTable(
                name: "ClientProfiles",
                newName: "ClientProfileInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientProfileInfo",
                table: "ClientProfileInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfileInfo_Profiles_Id",
                table: "ClientProfileInfo",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
