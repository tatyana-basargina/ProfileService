using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfileInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientProfiles");

            migrationBuilder.DropTable(
                name: "InstructorProfiles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDismissal",
                table: "Profiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceBeforeHiring",
                table: "Profiles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Profiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentVersion",
                table: "Profiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OriginalId",
                table: "Profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerProfileInfoId",
                table: "Profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Profiles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileType",
                table: "Profiles",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VersionNumber",
                table: "Profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OwnerProfileInfoId",
                table: "Profiles",
                column: "OwnerProfileInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PositionId",
                table: "Profiles",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Positions_PositionId",
                table: "Profiles",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_OwnerProfileInfoId",
                table: "Profiles",
                column: "OwnerProfileInfoId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Positions_PositionId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_OwnerProfileInfoId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_OwnerProfileInfoId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PositionId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "DateDismissal",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ExperienceBeforeHiring",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsCurrentVersion",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "OwnerProfileInfoId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileType",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "ClientProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerProfileInfoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProfiles_Profiles_Id",
                        column: x => x.Id,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientProfiles_Profiles_OwnerProfileInfoId",
                        column: x => x.OwnerProfileInfoId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstructorProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: true),
                    DateDismissal = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExperienceBeforeHiring = table.Column<int>(type: "integer", nullable: true),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorProfiles_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstructorProfiles_Profiles_Id",
                        column: x => x.Id,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfiles_OwnerProfileInfoId",
                table: "ClientProfiles",
                column: "OwnerProfileInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfiles_PositionId",
                table: "InstructorProfiles",
                column: "PositionId");
        }
    }
}
