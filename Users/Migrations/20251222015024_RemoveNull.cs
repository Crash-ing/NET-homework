using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_ITSupports_SupportID",
                table: "Assignements");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements");

            migrationBuilder.AlterColumn<int>(
                name: "TicketID",
                table: "Assignements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupportID",
                table: "Assignements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Assignements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_ITSupports_SupportID",
                table: "Assignements",
                column: "SupportID",
                principalTable: "ITSupports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_ITSupports_SupportID",
                table: "Assignements");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements");

            migrationBuilder.AlterColumn<int>(
                name: "TicketID",
                table: "Assignements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SupportID",
                table: "Assignements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Assignements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_ITSupports_SupportID",
                table: "Assignements",
                column: "SupportID",
                principalTable: "ITSupports",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID");
        }
    }
}
