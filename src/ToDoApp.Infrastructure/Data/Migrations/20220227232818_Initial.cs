using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoTaskGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTasks_TodoTaskGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "TodoTaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TodoTaskGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { 1, "My day" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_GroupId",
                table: "TodoTasks",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTasks");

            migrationBuilder.DropTable(
                name: "TodoTaskGroups");
        }
    }
}
