using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core
{
    public partial class QueroJobsContext : DbContext
    {
        public QueroJobsContext()
        {
        }

        public QueroJobsContext(DbContextOptions<QueroJobsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Competence> Competences { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Occupationarea> Occupationareas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scholarity> Scholarities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=admin;database=querojobs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("candidate");

                entity.HasComment("				");

                entity.HasIndex(e => e.Cpf, "Cpf_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ActualRole)
                    .HasMaxLength(45)
                    .HasColumnName("actualRole");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");

                entity.Property(e => e.CellphoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("cellphoneNumber");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("city");

                entity.Property(e => e.Complement)
                    .HasMaxLength(45)
                    .HasColumnName("complement");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("country");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Deficiency)
                    .HasMaxLength(100)
                    .HasColumnName("deficiency");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.EmploymentStatus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("employmentStatus");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("houseNumber");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.SalaryExpectation)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("salaryExpectation");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("street");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("telephoneNumber");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Cnpj, "Cnpj_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CellphoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("cellphoneNumber");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("city");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Complement)
                    .HasMaxLength(45)
                    .HasColumnName("complement");

                entity.Property(e => e.CorporateName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("corporateName");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("country");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.FantasyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fantasyName");

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("houseNumber");

                entity.Property(e => e.ResponsibleName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("responsibleName");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.StateRegistration)
                    .HasMaxLength(9)
                    .HasColumnName("stateRegistration");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("street");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("telephoneNumber");
            });

            modelBuilder.Entity<Competence>(entity =>
            {
                entity.ToTable("competence");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Competence1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("competence");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Course1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("course");
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.ToTable("formation");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("institution");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Institution1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<Occupationarea>(entity =>
            {
                entity.ToTable("occupationarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OccupationArea1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("occupationArea");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Scholarity>(entity =>
            {
                entity.ToTable("scholarity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Scholarity1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("scholarity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
