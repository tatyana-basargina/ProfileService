using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientProfileInfoTableAddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_Profiles_Id",
                table: "ClientProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerProfileInfoId",
                table: "ClientProfiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfiles_OwnerProfileInfoId",
                table: "ClientProfiles",
                column: "OwnerProfileInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_Profiles_OwnerProfileInfoId",
                table: "ClientProfiles",
                column: "OwnerProfileInfoId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_Profiles_OwnerProfileInfoId",
                table: "ClientProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ClientProfiles_OwnerProfileInfoId",
                table: "ClientProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerProfileInfoId",
                table: "ClientProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_Profiles_Id",
                table: "ClientProfiles",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
