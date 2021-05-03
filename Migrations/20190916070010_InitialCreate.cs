using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cms.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''");

            migrationBuilder.CreateTable(
                name: "mcs_contact_details",
                columns: table => new
                {
                    door_no = table.Column<string>(type: "character varying(200)", nullable: true),
                    address_line1 = table.Column<string>(type: "character varying(200)", nullable: true),
                    address_line2 = table.Column<string>(type: "character varying(200)", nullable: true),
                    land_mark = table.Column<string>(type: "character varying(200)", nullable: true),
                    country = table.Column<string>(type: "character varying(200)", nullable: true),
                    state = table.Column<string>(type: "character varying(200)", nullable: true),
                    zipcode = table.Column<string>(type: "character varying(200)", nullable: true),
                    land_line_no = table.Column<string>(type: "character varying(20)", nullable: true),
                    mobile_no1 = table.Column<string>(type: "character varying(20)", nullable: true),
                    mobile_no2 = table.Column<string>(type: "character varying(20)", nullable: true),
                    latitude = table.Column<string>(type: "character varying(20)", nullable: true),
                    longitude = table.Column<string>(type: "character varying(20)", nullable: true),
                    contact_uid = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_contact_details", x => x.contact_uid);
                });

            migrationBuilder.CreateTable(
                name: "mcs_roles",
                columns: table => new
                {
                    role_id = table.Column<Guid>(nullable: false),
                    role_name = table.Column<string>(type: "character varying", nullable: false),
                    is_active = table.Column<bool>(nullable: true),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "ms_users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(type: "character varying(200)", nullable: false),
                    last_name = table.Column<string>(type: "character varying(200)", nullable: false),
                    gender = table.Column<string>(type: "character varying(20)", nullable: false),
                    role_id = table.Column<Guid>(nullable: true),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: true),
                    is_active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "mcs_companies",
                columns: table => new
                {
                    company_name = table.Column<string>(type: "character varying(200)", nullable: false),
                    activated_date = table.Column<DateTime>(type: "date", nullable: true),
                    deactivated_date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<bool>(nullable: true),
                    company_id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    company_code = table.Column<string>(type: "character varying(10)", nullable: true),
                    contact_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mcs_companies", x => x.company_id);
                    table.ForeignKey(
                        name: "fk_company_to_contact",
                        column: x => x.contact_id,
                        principalTable: "mcs_contact_details",
                        principalColumn: "contact_uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fki_fk_company_contact",
                table: "mcs_companies",
                column: "contact_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mcs_companies");

            migrationBuilder.DropTable(
                name: "mcs_roles");

            migrationBuilder.DropTable(
                name: "ms_users");

            migrationBuilder.DropTable(
                name: "mcs_contact_details");
        }
    }
}
