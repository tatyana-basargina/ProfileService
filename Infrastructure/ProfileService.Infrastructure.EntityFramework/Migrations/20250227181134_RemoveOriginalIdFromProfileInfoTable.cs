using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOriginalIdFromProfileInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_OriginalId_VersionNumber",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OriginalId",
                table: "Profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OriginalId_VersionNumber",
                table: "Profiles",
                columns: new[] { "OriginalId", "VersionNumber" },
                unique: true,
                filter: "\"OriginalId\" IS NOT NULL");
        }
    }
}
