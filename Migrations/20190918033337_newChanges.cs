using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cms.Migrations
{
    public partial class newChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_plant_cluster",
                table: "mcs_clusters");

            migrationBuilder.DropIndex(
                name: "fki_fk_plant_cluster",
                table: "mcs_plants");

            migrationBuilder.DropIndex(
                name: "fki_fk_plant_contact",
                table: "mcs_plants");

            migrationBuilder.CreateTable(
                name: "mcs_departments",
                columns: table => new
                {
                    department_id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    department_name = table.Column<string>(type: "character varying(100)", nullable: false),
                    department_code = table.Column<string>(type: "character varying(50)", nullable: false),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<bool>(nullable: true),
                    plant_id = table.Column<Guid>(nullable: false),
                    contact_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_departments", x => x.department_id);
                    table.ForeignKey(
                        name: "fk_department_contact",
                        column: x => x.contact_id,
                        principalTable: "mcs_contact_details",
                        principalColumn: "contact_uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_plant",
                        column: x => x.plant_id,
                        principalTable: "mcs_plants",
                        principalColumn: "plant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mcs_reason_groups",
                columns: table => new
                {
                    reason_group_id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    reason_group_name = table.Column<string>(type: "character varying(200)", nullable: true),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_reason_groups", x => x.reason_group_id);
                });

            migrationBuilder.CreateTable(
                name: "mcs_sections",
                columns: table => new
                {
                    section_name = table.Column<string>(type: "character varying(100)", nullable: false),
                    section_code = table.Column<string>(type: "character varying(50)", nullable: false),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<bool>(nullable: true),
                    department_id = table.Column<Guid>(nullable: true),
                    contact_id = table.Column<Guid>(nullable: true),
                    section_id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_sections", x => x.section_id);
                    table.ForeignKey(
                        name: "fk_section_contact",
                        column: x => x.contact_id,
                        principalTable: "mcs_contact_details",
                        principalColumn: "contact_uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_section_department",
                        column: x => x.department_id,
                        principalTable: "mcs_departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fki_fk_plant_cluster",
                table: "mcs_plants",
                column: "cluster_id");

            migrationBuilder.CreateIndex(
                name: "fki_fk_plant_contact",
                table: "mcs_plants",
                column: "contact_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fki_fk_department_contact",
                table: "mcs_departments",
                column: "contact_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fki_fk_department_plant",
                table: "mcs_departments",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "fki_fk_section_contact",
                table: "mcs_sections",
                column: "contact_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fki_fk_section_department",
                table: "mcs_sections",
                column: "department_id");

            migrationBuilder.AddForeignKey(
                name: "fk_plant_cluster",
                table: "mcs_plants",
                column: "cluster_id",
                principalTable: "mcs_clusters",
                principalColumn: "cluster_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_plant_cluster",
                table: "mcs_plants");

            migrationBuilder.DropTable(
                name: "mcs_reason_groups");

            migrationBuilder.DropTable(
                name: "mcs_sections");

            migrationBuilder.DropTable(
                name: "mcs_departments");

            migrationBuilder.DropIndex(
                name: "fki_fk_plant_cluster",
                table: "mcs_plants");

            migrationBuilder.DropIndex(
                name: "fki_fk_plant_contact",
                table: "mcs_plants");

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
        }
    }
}
