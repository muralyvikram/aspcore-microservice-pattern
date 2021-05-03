using Microsoft.EntityFrameworkCore.Migrations;

namespace cms.Migrations
{
    public partial class companykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "fki_fk_cluster_company_details",
                table: "mcs_clusters",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cluster_company_details",
                table: "mcs_companies",
                column: "company_id",
                principalTable: "mcs_clusters",
                principalColumn: "cluster_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cluster_company_details",
                table: "mcs_companies");

            migrationBuilder.DropIndex(
                name: "fki_fk_cluster_company_details",
                table: "mcs_clusters");
        }
    }
}
