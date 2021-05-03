using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cms.Migrations
{
    public partial class ClusterAddedunq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cluster_contact",
                table: "mcs_clusters");

            migrationBuilder.AlterColumn<Guid>(
                name: "contact_id",
                table: "mcs_clusters",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "cluster_id",
                table: "mcs_clusters",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "fk_cluster_contact",
                table: "mcs_clusters",
                column: "contact_id",
                principalTable: "mcs_contact_details",
                principalColumn: "contact_uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cluster_contact",
                table: "mcs_clusters");

            migrationBuilder.AlterColumn<Guid>(
                name: "contact_id",
                table: "mcs_clusters",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "cluster_id",
                table: "mcs_clusters",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddForeignKey(
                name: "fk_cluster_contact",
                table: "mcs_clusters",
                column: "contact_id",
                principalTable: "mcs_contact_details",
                principalColumn: "contact_uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
