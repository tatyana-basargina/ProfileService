using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddClientProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Profiles",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerProfileId",
                table: "Profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OwnerProfileId",
                table: "Profiles",
                column: "OwnerProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_OwnerProfileId",
                table: "Profiles",
                column: "OwnerProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_OwnerProfileId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_OwnerProfileId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "OwnerProfileId",
                table: "Profiles");
        }
    }
}
