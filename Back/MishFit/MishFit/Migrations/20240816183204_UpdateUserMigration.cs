using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MishFit.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Email");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StepsGoal",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightGoal",
                table: "Users",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StepsGoal",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WeightGoal",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
