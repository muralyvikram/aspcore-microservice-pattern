using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cms.Entities
{
    public partial class MasterDBContext : DbContext
    {
        public MasterDBContext() { }

        public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options) { }

        public virtual DbSet<McsClusters> McsClusters { get; set; }
        public virtual DbSet<McsCompanies> McsCompanies { get; set; }
        public virtual DbSet<McsContactDetails> McsContactDetails { get; set; }
        public virtual DbSet<McsDepartments> McsDepartments { get; set; }
        public virtual DbSet<McsPlants> McsPlants { get; set; }
        public virtual DbSet<McsReasonGroups> McsReasonGroups { get; set; }
        public virtual DbSet<McsRoles> McsRoles { get; set; }
        public virtual DbSet<McsSections> McsSections { get; set; }
        public virtual DbSet<MsUsers> MsUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=MasterDB2;Integrated Security=true;Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<McsClusters>(entity =>
            {
                entity.HasKey(e => e.ClusterId);

                entity.ToTable("mcs_clusters");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fki_fk_cluster_company_details");

                entity.HasIndex(e => e.ContactId)
                    .HasName("fki_fk_cluster_contact")
                    .IsUnique();

                entity.Property(e => e.ClusterId)
                    .HasColumnName("cluster_id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.ClusterCode)
                    .HasColumnName("cluster_code")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.ClusterName)
                    .HasColumnName("cluster_name")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.McsClusters)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_cluster_company_details");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.McsClusters)
                    .HasForeignKey<McsClusters>(d => d.ContactId)
                    .HasConstraintName("fk_cluster_contact");
            });

            modelBuilder.Entity<McsCompanies>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("mcs_companies");

                entity.HasIndex(e => e.ContactId)
                    .HasName("fki_fk_company_contact")
                    .IsUnique();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("company_code")
                    .HasColumnType("character varying(10)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.McsCompanies)
                    .HasForeignKey<McsCompanies>(d => d.ContactId)
                    .HasConstraintName("fk_company_to_contact");
            });

            modelBuilder.Entity<McsContactDetails>(entity =>
            {
                entity.HasKey(e => e.ContactUid);

                entity.ToTable("mcs_contact_details");

                entity.Property(e => e.ContactUid)
                    .HasColumnName("contact_uid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line1")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line2")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.DoorNo)
                    .HasColumnName("door_no")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.LandLineNo)
                    .HasColumnName("land_line_no")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.LandMark)
                    .HasColumnName("land_mark")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.MobileNo1)
                    .HasColumnName("mobile_no1")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.MobileNo2)
                    .HasColumnName("mobile_no2")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasColumnType("character varying(200)");
            });

            modelBuilder.Entity<McsDepartments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("mcs_departments");

                entity.HasIndex(e => e.ContactId)
                    .HasName("fki_fk_department_contact");

                entity.HasIndex(e => e.PlantId)
                    .HasName("fki_fk_department_plant");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasColumnName("department_code")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("department_name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.McsDepartments)
                    .HasForeignKey<McsDepartments>(d => d.ContactId)
                    .HasConstraintName("fk_department_contact");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.McsDepartments)
                    .HasForeignKey(d => d.PlantId)
                    .HasConstraintName("fk_department_plant");
            });

            modelBuilder.Entity<McsPlants>(entity =>
            {
                entity.HasKey(e => e.PlantId);

                entity.ToTable("mcs_plants");

                entity.HasIndex(e => e.ClusterId)
                    .HasName("fki_fk_plant_cluster");

                entity.HasIndex(e => e.ContactId)
                    .HasName("fki_fk_plant_contact");

                entity.Property(e => e.PlantId)
                    .HasColumnName("plant_id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.ClusterId).HasColumnName("cluster_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.PlantCode)
                    .IsRequired()
                    .HasColumnName("plant_code")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.PlantName)
                    .IsRequired()
                    .HasColumnName("plant_name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cluster)
                    .WithMany(p => p.McsPlants)
                    .HasForeignKey(d => d.ClusterId)
                    .HasConstraintName("fk_plant_cluster");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.McsPlants)
                    .HasForeignKey<McsPlants>(d => d.ContactId)
                    .HasConstraintName("fk_plant_contact");
            });

            modelBuilder.Entity<McsReasonGroups>(entity =>
            {
                entity.HasKey(e => e.ReasonGroupId);
                entity.ToTable("mcs_reason_groups");

                entity.Property(e => e.ReasonGroupId)
                    .HasColumnName("reason_group_id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.ReasonGroupName)
                    .HasColumnName("reason_group_name")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<McsRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("mcs_roles");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<McsSections>(entity =>
            {
                entity.HasKey(e => e.SectionId);

                entity.ToTable("mcs_sections");

                entity.HasIndex(e => e.ContactId)
                    .HasName("fki_fk_section_contact");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fki_fk_section_department");

                entity.Property(e => e.SectionId)
                    .HasColumnName("section_id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.SectionCode)
                    .IsRequired()
                    .HasColumnName("section_code")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasColumnName("section_name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.McsSections)
                    .HasForeignKey<McsSections>(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_section_contact");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.McsSections)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_section_department");
            });

            modelBuilder.Entity<MsUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("ms_users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivatedDate)
                    .HasColumnName("activated_date")
                    .HasColumnType("date");

                entity.Property(e => e.DeactivatedDate)
                    .HasColumnName("deactivated_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("character varying(200)");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });
        }
    }
}
