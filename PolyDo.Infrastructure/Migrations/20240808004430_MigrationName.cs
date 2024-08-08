using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolyDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentTask_TaskList_ListId",
                table: "ParentTask");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTask_ParentTask_TaskId",
                table: "SubTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTask",
                table: "SubTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentTask",
                table: "ParentTask");

            migrationBuilder.RenameTable(
                name: "TaskList",
                newName: "TaskLists");

            migrationBuilder.RenameTable(
                name: "SubTask",
                newName: "SubTasks");

            migrationBuilder.RenameTable(
                name: "ParentTask",
                newName: "ParentTasks");

            migrationBuilder.RenameIndex(
                name: "IX_SubTask_TaskId",
                table: "SubTasks",
                newName: "IX_SubTasks_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentTask_ListId",
                table: "ParentTasks",
                newName: "IX_ParentTasks_ListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTasks",
                table: "SubTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentTasks",
                table: "ParentTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentTasks_TaskLists_ListId",
                table: "ParentTasks",
                column: "ListId",
                principalTable: "TaskLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTasks_ParentTasks_TaskId",
                table: "SubTasks",
                column: "TaskId",
                principalTable: "ParentTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentTasks_TaskLists_ListId",
                table: "ParentTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTasks_ParentTasks_TaskId",
                table: "SubTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTasks",
                table: "SubTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentTasks",
                table: "ParentTasks");

            migrationBuilder.RenameTable(
                name: "TaskLists",
                newName: "TaskList");

            migrationBuilder.RenameTable(
                name: "SubTasks",
                newName: "SubTask");

            migrationBuilder.RenameTable(
                name: "ParentTasks",
                newName: "ParentTask");

            migrationBuilder.RenameIndex(
                name: "IX_SubTasks_TaskId",
                table: "SubTask",
                newName: "IX_SubTask_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentTasks_ListId",
                table: "ParentTask",
                newName: "IX_ParentTask_ListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTask",
                table: "SubTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentTask",
                table: "ParentTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentTask_TaskList_ListId",
                table: "ParentTask",
                column: "ListId",
                principalTable: "TaskList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTask_ParentTask_TaskId",
                table: "SubTask",
                column: "TaskId",
                principalTable: "ParentTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
