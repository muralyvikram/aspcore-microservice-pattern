// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cms.Entities;

namespace cms.Migrations
{
    [DbContext(typeof(MasterDBContext))]
    partial class MasterDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("cms.Entities.McsClusters", b =>
                {
                    b.Property<Guid>("ClusterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cluster_id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<string>("ClusterCode")
                        .HasColumnName("cluster_code")
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ClusterName")
                        .HasColumnName("cluster_name")
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnName("company_id");

                    b.Property<Guid?>("ContactId")
                        .HasColumnName("contact_id");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.HasKey("ClusterId");

                    b.HasIndex("CompanyId")
                        .HasName("fki_fk_cluster_company_details");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasName("fki_fk_cluster_contact");

                    b.ToTable("mcs_clusters");
                });

            modelBuilder.Entity("cms.Entities.McsCompanies", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("company_id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<string>("CompanyCode")
                        .HasColumnName("company_code")
                        .HasColumnType("character varying(10)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("company_name")
                        .HasColumnType("character varying(200)");

                    b.Property<Guid?>("ContactId")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<bool?>("Status")
                        .HasColumnName("status");

                    b.HasKey("CompanyId");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasName("fki_fk_company_contact");

                    b.ToTable("mcs_companies");
                });

            modelBuilder.Entity("cms.Entities.McsContactDetails", b =>
                {
                    b.Property<Guid>("ContactUid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("contact_uid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("AddressLine1")
                        .HasColumnName("address_line1")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("AddressLine2")
                        .HasColumnName("address_line2")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("DoorNo")
                        .HasColumnName("door_no")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("LandLineNo")
                        .HasColumnName("land_line_no")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LandMark")
                        .HasColumnName("land_mark")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Latitude")
                        .HasColumnName("latitude")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Longitude")
                        .HasColumnName("longitude")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("MobileNo1")
                        .HasColumnName("mobile_no1")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("MobileNo2")
                        .HasColumnName("mobile_no2")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Zipcode")
                        .HasColumnName("zipcode")
                        .HasColumnType("character varying(200)");

                    b.HasKey("ContactUid");

                    b.ToTable("mcs_contact_details");
                });

            modelBuilder.Entity("cms.Entities.McsDepartments", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("department_id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<Guid>("ContactId")
                        .HasColumnName("contact_id");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnName("department_code")
                        .HasColumnType("character varying(50)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnName("department_name")
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("PlantId")
                        .HasColumnName("plant_id");

                    b.Property<bool?>("Status")
                        .HasColumnName("status");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasName("fki_fk_department_contact");

                    b.HasIndex("PlantId")
                        .HasName("fki_fk_department_plant");

                    b.ToTable("mcs_departments");
                });

            modelBuilder.Entity("cms.Entities.McsPlants", b =>
                {
                    b.Property<Guid>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("plant_id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<Guid?>("ClusterId")
                        .HasColumnName("cluster_id");

                    b.Property<Guid?>("ContactId")
                        .HasColumnName("contact_id");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<string>("PlantCode")
                        .IsRequired()
                        .HasColumnName("plant_code")
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PlantName")
                        .IsRequired()
                        .HasColumnName("plant_name")
                        .HasColumnType("character varying(100)");

                    b.Property<bool?>("Status")
                        .HasColumnName("status");

                    b.HasKey("PlantId");

                    b.HasIndex("ClusterId")
                        .HasName("fki_fk_plant_cluster");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasName("fki_fk_plant_contact");

                    b.ToTable("mcs_plants");
                });

            modelBuilder.Entity("cms.Entities.McsReasonGroups", b =>
                {
                    b.Property<Guid>("ReasonGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("reason_group_id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<string>("ReasonGroupName")
                        .HasColumnName("reason_group_name")
                        .HasColumnType("character varying(200)");

                    b.Property<bool?>("Status")
                        .HasColumnName("status");

                    b.HasKey("ReasonGroupId");

                    b.ToTable("mcs_reason_groups");
                });

            modelBuilder.Entity("cms.Entities.McsRoles", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("is_active");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnName("role_name")
                        .HasColumnType("character varying");

                    b.HasKey("RoleId");

                    b.ToTable("mcs_roles");
                });

            modelBuilder.Entity("cms.Entities.McsSections", b =>
                {
                    b.Property<Guid>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("section_id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<Guid?>("ContactId")
                        .HasColumnName("contact_id");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnName("department_id");

                    b.Property<string>("SectionCode")
                        .IsRequired()
                        .HasColumnName("section_code")
                        .HasColumnType("character varying(50)");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnName("section_name")
                        .HasColumnType("character varying(100)");

                    b.Property<bool?>("Status")
                        .HasColumnName("status");

                    b.HasKey("SectionId");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasName("fki_fk_section_contact");

                    b.HasIndex("DepartmentId")
                        .HasName("fki_fk_section_department");

                    b.ToTable("mcs_sections");
                });

            modelBuilder.Entity("cms.Entities.MsUsers", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<DateTime?>("ActivatedDate")
                        .HasColumnName("activated_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnName("deactivated_date")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("gender")
                        .HasColumnType("character varying(20)");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("is_active");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(200)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId");

                    b.ToTable("ms_users");
                });

            modelBuilder.Entity("cms.Entities.McsClusters", b =>
                {
                    b.HasOne("cms.Entities.McsCompanies", "Company")
                        .WithMany("McsClusters")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("fk_cluster_company_details")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cms.Entities.McsContactDetails", "Contact")
                        .WithOne("McsClusters")
                        .HasForeignKey("cms.Entities.McsClusters", "ContactId")
                        .HasConstraintName("fk_cluster_contact");
                });

            modelBuilder.Entity("cms.Entities.McsCompanies", b =>
                {
                    b.HasOne("cms.Entities.McsContactDetails", "Contact")
                        .WithOne("McsCompanies")
                        .HasForeignKey("cms.Entities.McsCompanies", "ContactId")
                        .HasConstraintName("fk_company_to_contact");
                });

            modelBuilder.Entity("cms.Entities.McsDepartments", b =>
                {
                    b.HasOne("cms.Entities.McsContactDetails", "Contact")
                        .WithOne("McsDepartments")
                        .HasForeignKey("cms.Entities.McsDepartments", "ContactId")
                        .HasConstraintName("fk_department_contact")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cms.Entities.McsPlants", "Plant")
                        .WithMany("McsDepartments")
                        .HasForeignKey("PlantId")
                        .HasConstraintName("fk_department_plant")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cms.Entities.McsPlants", b =>
                {
                    b.HasOne("cms.Entities.McsClusters", "Cluster")
                        .WithMany("McsPlants")
                        .HasForeignKey("ClusterId")
                        .HasConstraintName("fk_plant_cluster");

                    b.HasOne("cms.Entities.McsContactDetails", "Contact")
                        .WithOne("McsPlants")
                        .HasForeignKey("cms.Entities.McsPlants", "ContactId")
                        .HasConstraintName("fk_plant_contact");
                });

            modelBuilder.Entity("cms.Entities.McsSections", b =>
                {
                    b.HasOne("cms.Entities.McsContactDetails", "Contact")
                        .WithOne("McsSections")
                        .HasForeignKey("cms.Entities.McsSections", "ContactId")
                        .HasConstraintName("fk_section_contact")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cms.Entities.McsDepartments", "Department")
                        .WithMany("McsSections")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_section_department")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
