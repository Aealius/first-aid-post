using System;
using System.IO;
using Appp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Appp
{
    public partial class UniversityFirstAidPostContext : DbContext
    {
        public UniversityFirstAidPostContext()
        {
        }

        public UniversityFirstAidPostContext(DbContextOptions<UniversityFirstAidPostContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloodType> BloodTypes { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<ExcerptRecord> ExcerptRecords { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<HealthGroup> HealthGroups { get; set; }
        public virtual DbSet<Infection> Infections { get; set; }
        public virtual DbSet<MedicalCard> MedicalCards { get; set; }
        public virtual DbSet<MedicalCardRecord> MedicalCardRecords { get; set; }
        public virtual DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public virtual DbSet<RefferalRecord> RefferalRecords { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VaccinationCardRecord> VaccinationCardRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DevConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BloodType>(entity =>
            {
                entity.ToTable("blood_type");

                entity.Property(e => e.BloodTypeId).HasColumnName("blood_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("certificate");

                entity.Property(e => e.CertificateId).HasColumnName("certificate_id");

                entity.Property(e => e.Dianosis)
                    .HasMaxLength(128)
                    .HasColumnName("dianosis");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.Note)
                    .HasMaxLength(256)
                    .HasColumnName("note");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_certificate_user");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_certificate_student");
            });

            modelBuilder.Entity<ExcerptRecord>(entity =>
            {
                entity.ToTable("excerpt_record");

                entity.Property(e => e.ExcerptRecordId).HasColumnName("excerpt_record_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("text");

                entity.HasOne(d => d.MedicalCard)
                    .WithMany(p => p.ExcerptRecords)
                    .HasForeignKey(d => d.MedicalCardId)
                    .HasConstraintName("FK_excerpt_record_medical_card");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("faculty");

                entity.Property(e => e.FacultyId).HasColumnName("faculty_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.CreationYear)
                    .HasColumnType("date")
                    .HasColumnName("creation_year");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.SpecialityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group__specialit__74794A92");
            });

            modelBuilder.Entity<HealthGroup>(entity =>
            {
                entity.ToTable("health_group");

                entity.Property(e => e.HealthGroupId).HasColumnName("health_group_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Infection>(entity =>
            {
                entity.ToTable("infection");

                entity.Property(e => e.InfectionId).HasColumnName("infection_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MedicalCard>(entity =>
            {
                entity.ToTable("medical_card");

                entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

                entity.Property(e => e.BloodTypeId).HasColumnName("blood_type_id");

                entity.Property(e => e.HealthGroupId).HasColumnName("health_group_id");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.BloodType)
                    .WithMany(p => p.MedicalCards)
                    .HasForeignKey(d => d.BloodTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_medical_card_blood_type");

                entity.HasOne(d => d.HealthGroup)
                    .WithMany(p => p.MedicalCards)
                    .HasForeignKey(d => d.HealthGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_medical_card_health_group");
            });

            modelBuilder.Entity<MedicalCardRecord>(entity =>
            {
                entity.HasKey(e => e.MedcardRecordId)
                    .HasName("PK__medical___34F79C06BBCFC06D");

                entity.ToTable("medical_card_record");

                entity.Property(e => e.MedcardRecordId).HasColumnName("medcard_record_id");

                entity.Property(e => e.Complaints)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("complaints");

                entity.Property(e => e.Diagnosis)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("diagnosis");

                entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

                entity.Property(e => e.VisitDate)
                    .HasColumnType("date")
                    .HasColumnName("visit_date");

                entity.HasOne(d => d.MedicalCard)
                    .WithMany(p => p.MedicalCardRecords)
                    .HasForeignKey(d => d.MedicalCardId)
                    .HasConstraintName("FK_medcard_record_medical_card");
            });

            modelBuilder.Entity<MedicalExamination>(entity =>
            {
                entity.HasKey(e => e.MedExamId)
                    .HasName("PK__medical___2BBC246838D638D5");

                entity.ToTable("medical_examination");

                entity.Property(e => e.MedExamId).HasColumnName("med_exam_id");

                entity.Property(e => e.AcademicYear)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("academic_year");

                entity.Property(e => e.CompletanceStatus).HasColumnName("completance_status");

                entity.Property(e => e.Reason)
                    .HasMaxLength(512)
                    .HasColumnName("reason");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.MedicalExaminations)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_med_exam_student");
            });

            modelBuilder.Entity<RefferalRecord>(entity =>
            {
                entity.ToTable("refferal_record");

                entity.Property(e => e.RefferalRecordId).HasColumnName("refferal_record_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("text");

                entity.HasOne(d => d.MedicalCard)
                    .WithMany(p => p.RefferalRecords)
                    .HasForeignKey(d => d.MedicalCardId)
                    .HasConstraintName("FK_refferal_record_medical_card");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("speciality");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.FacultyId).HasColumnName("faculty_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("name");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Specialities)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__specialit__facul__73852659");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.EnrollDate)
                    .HasColumnType("date")
                    .HasColumnName("enroll_date");

                entity.Property(e => e.ExpulsionDate)
                    .HasColumnType("date")
                    .HasColumnName("expulsion_date");

                entity.Property(e => e.FacultyId).HasColumnName("faculty_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("lastname");

                entity.Property(e => e.MedicalcardId).HasColumnName("medicalcard_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("sex");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_student_faculty");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_student_group");

                entity.HasOne(d => d.Medicalcard)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MedicalcardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_student_medical_card");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_student_speciality");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.DoctorInitials)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("doctor_initials");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("pwd");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_user_role");
            });

            modelBuilder.Entity<VaccinationCardRecord>(entity =>
            {
                entity.HasKey(e => e.VaccardRecordId)
                    .HasName("PK__vaccinat__D2BA40DC41DB9C3C");

                entity.ToTable("vaccination_card_record");

                entity.Property(e => e.VaccardRecordId).HasColumnName("vaccard_record_id");

                entity.Property(e => e.Dose).HasColumnName("dose");

                entity.Property(e => e.ImmuneDate)
                    .HasColumnType("date")
                    .HasColumnName("immune_date");

                entity.Property(e => e.ImmuneWay)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("immune_way");

                entity.Property(e => e.InfectionId).HasColumnName("infection_id");

                entity.Property(e => e.Inoculation)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("inoculation");

                entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

                entity.Property(e => e.Reactions)
                    .HasMaxLength(256)
                    .HasColumnName("reactions");

                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("series");

                entity.Property(e => e.Vaccine)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("vaccine");

                entity.HasOne(d => d.Infection)
                    .WithMany(p => p.VaccinationCardRecords)
                    .HasForeignKey(d => d.InfectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vaccard_infection");

                entity.HasOne(d => d.MedicalCard)
                    .WithMany(p => p.VaccinationCardRecords)
                    .HasForeignKey(d => d.MedicalCardId)
                    .HasConstraintName("FK_vaccard_record_medical_card");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
