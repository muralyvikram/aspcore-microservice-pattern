using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cms.Migrations
{
    public partial class ClusterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mcs_clusters",
                columns: table => new
                {
                    cluster_name = table.Column<string>(type: "character varying(200)", nullable: true),
                    cluster_code = table.Column<string>(type: "character varying(50)", nullable: true),
                    cluster_id = table.Column<Guid>(nullable: false),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<bool>(nullable: false),
                    company_id = table.Column<Guid>(nullable: false),
                    contact_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_clusters", x => x.cluster_id);
                    table.ForeignKey(
                        name: "fk_cluster_contact",
                        column: x => x.contact_id,
                        principalTable: "mcs_contact_details",
                        principalColumn: "contact_uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fki_fk_cluster_contact",
                table: "mcs_clusters",
                column: "contact_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mcs_clusters");
        }
    }
}
