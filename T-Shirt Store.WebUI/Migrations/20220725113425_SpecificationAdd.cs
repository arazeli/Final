using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T_Shirt_Store.WebUI.Migrations
{
    public partial class SpecificationAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByID",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Faqs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByID",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Faqs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByID",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByID",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateById = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedByID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "DeletedByID",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedByID",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedByID",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Brands");
        }
    }
}
