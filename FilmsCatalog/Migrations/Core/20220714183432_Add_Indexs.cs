using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations.Core
{
    public partial class Add_Indexs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AspNetFilms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 14, 21, 34, 32, 298, DateTimeKind.Local).AddTicks(1589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 13, 15, 23, 51, 988, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetFilms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 14, 21, 34, 32, 294, DateTimeKind.Local).AddTicks(9509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 13, 15, 23, 51, 985, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetFilms_CreatedDate",
                table: "AspNetFilms",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetFilms_Producer",
                table: "AspNetFilms",
                column: "Producer");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetFilms_Year",
                table: "AspNetFilms",
                column: "Year");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_AspNetFilms_CreatedDate",
                table: "AspNetFilms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetFilms_Producer",
                table: "AspNetFilms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetFilms_Year",
                table: "AspNetFilms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AspNetFilms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 13, 15, 23, 51, 988, DateTimeKind.Local).AddTicks(6217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 14, 21, 34, 32, 298, DateTimeKind.Local).AddTicks(1589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetFilms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 13, 15, 23, 51, 985, DateTimeKind.Local).AddTicks(1284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 14, 21, 34, 32, 294, DateTimeKind.Local).AddTicks(9509));
        }
    }
}
