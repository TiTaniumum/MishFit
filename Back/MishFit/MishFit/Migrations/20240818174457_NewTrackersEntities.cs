﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MishFit.Migrations
{
    /// <inheritdoc />
    public partial class NewTrackersEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trackers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackerType = table.Column<int>(type: "integer", nullable: false),
                    MealId = table.Column<Guid>(type: "uuid", nullable: true),
                    MealGrams = table.Column<int>(type: "integer", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActivityId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ActivityType = table.Column<int>(type: "integer", nullable: true),
                    ActivityTimespan = table.Column<int>(type: "integer", nullable: true),
                    ActivitySets = table.Column<int>(type: "integer", nullable: true),
                    ActivityRepetitions = table.Column<int>(type: "integer", nullable: true),
                    SleepBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SleepEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SleepQuality = table.Column<int>(type: "integer", nullable: true),
                    TrackerDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trackers_Activities_ActivityId1",
                        column: x => x.ActivityId1,
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trackers_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trackers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trackers_ActivityId1",
                table: "Trackers",
                column: "ActivityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trackers_MealId",
                table: "Trackers",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Trackers_UserId",
                table: "Trackers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trackers");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}