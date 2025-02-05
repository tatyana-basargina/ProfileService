using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProfileService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddTypesSportEquipmentProfilesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesSportEquipmentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeSportEquipmentId = table.Column<int>(type: "integer", nullable: true),
                    LevelTrainingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesSportEquipmentProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypesSportEquipmentProfiles_LevelsTraining_LevelTrainingId",
                        column: x => x.LevelTrainingId,
                        principalTable: "LevelsTraining",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TypesSportEquipmentProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypesSportEquipmentProfiles_TypesSportEquipment_TypeSportEq~",
                        column: x => x.TypeSportEquipmentId,
                        principalTable: "TypesSportEquipment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypesSportEquipmentProfiles_LevelTrainingId",
                table: "TypesSportEquipmentProfiles",
                column: "LevelTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesSportEquipmentProfiles_ProfileId",
                table: "TypesSportEquipmentProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesSportEquipmentProfiles_TypeSportEquipmentId",
                table: "TypesSportEquipmentProfiles",
                column: "TypeSportEquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesSportEquipmentProfiles");
        }
    }
}
