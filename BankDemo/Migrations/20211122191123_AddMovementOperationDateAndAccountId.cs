using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankDemo.Migrations
{
    public partial class AddMovementOperationDateAndAccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Movements");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Movements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OperationDate",
                table: "Movements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Movements_AccountId",
                table: "Movements",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Accounts_AccountId",
                table: "Movements",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Accounts_AccountId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_AccountId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "OperationDate",
                table: "Movements");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
