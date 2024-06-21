using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Migrations
{
    /// <inheritdoc />
    public partial class restoretheconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "d658e832-e199-437e-ab21-de4cd84c861a");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "09cd19fb-76b7-4be7-9ca1-f9ce36291a2a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "d658e832-e199-437e-ab21-de4cd84c861a",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "09cd19fb-76b7-4be7-9ca1-f9ce36291a2a",
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
