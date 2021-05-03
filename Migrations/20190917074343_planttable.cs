using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cms.Migrations
{
    public partial class planttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cluster_company_details",
                table: "mcs_companies");

            migrationBuilder.CreateTable(
                name: "mcs_plants",
                columns: table => new
                {
                    plant_name = table.Column<string>(type: "character varying(100)", nullable: false),
                    plant_code = table.Column<string>(type: "character varying(50)", nullable: false),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<bool>(nullable: true),
                    cluster_id = table.Column<Guid>(nullable: true),
                    plant_id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    contact_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_plants", x => x.plant_id);
                    table.ForeignKey(
                        name: "fk_plant_contact",
                        column: x => x.contact_id,
                        principalTable: "mcs_contact_details",
                        principalColumn: "contact_uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fki_fk_plant_cluster",
                table: "mcs_plants",
                column: "cluster_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fki_fk_plant_contact",
                table: "mcs_plants",
                column: "contact_id");

            migrationBuilder.AddForeignKey(
                name: "fk_plant_cluster",
                table: "mcs_clusters",
                column: "cluster_id",
                principalTable: "mcs_plants",
                principalColumn: "plant_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_cluster_company_details",
                table: "mcs_clusters",
                column: "company_id",
                principalTable: "mcs_companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_plant_cluster",
                table: "mcs_clusters");

            migrationBuilder.DropForeignKey(
                name: "fk_cluster_company_details",
                table: "mcs_clusters");

            migrationBuilder.DropTable(
                name: "mcs_plants");

            migrationBuilder.AddForeignKey(
                name: "fk_cluster_company_details",
                table: "mcs_companies",
                column: "company_id",
                principalTable: "mcs_clusters",
                principalColumn: "cluster_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
