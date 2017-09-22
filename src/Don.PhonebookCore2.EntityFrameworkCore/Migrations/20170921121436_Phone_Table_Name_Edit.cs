using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Don.PhonebookCore2.Migrations
{
    public partial class Phone_Table_Name_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbPhone_PbPersons_PersonId",
                table: "PbPhone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PbPhone",
                table: "PbPhone");

            migrationBuilder.RenameTable(
                name: "PbPhone",
                newName: "PbPhones");

            migrationBuilder.RenameIndex(
                name: "IX_PbPhone_PersonId",
                table: "PbPhones",
                newName: "IX_PbPhones_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PbPhones",
                table: "PbPhones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PbPhones_PbPersons_PersonId",
                table: "PbPhones",
                column: "PersonId",
                principalTable: "PbPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbPhones_PbPersons_PersonId",
                table: "PbPhones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PbPhones",
                table: "PbPhones");

            migrationBuilder.RenameTable(
                name: "PbPhones",
                newName: "PbPhone");

            migrationBuilder.RenameIndex(
                name: "IX_PbPhones_PersonId",
                table: "PbPhone",
                newName: "IX_PbPhone_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PbPhone",
                table: "PbPhone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PbPhone_PbPersons_PersonId",
                table: "PbPhone",
                column: "PersonId",
                principalTable: "PbPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
