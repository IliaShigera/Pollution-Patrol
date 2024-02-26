using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false, comment: "The user's name"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "The user's email address"),
                    PasswordHash = table.Column<string>(type: "text", nullable: false, comment: "The securely hashed password of the user"),
                    VerificationCode = table.Column<string>(type: "text", nullable: false, comment: "A unique code used for email verification purposes"),
                    RegisteredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "The date and time the user registered"),
                    ExpiresOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "The date and time the registration or verification code will expire"),
                    VerifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false, comment: "The current status of the registration (e.g., pending, verified, expired)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Entity_Id",
                        column: x => x.Id,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_VerificationCode",
                table: "Registrations",
                column: "VerificationCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
