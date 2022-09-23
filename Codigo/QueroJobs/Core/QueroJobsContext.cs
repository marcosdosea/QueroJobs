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
        public virtual DbSet<Candidatecompetence> Candidatecompetences { get; set; }
        public virtual DbSet<Candidateoccupationarea> Candidateoccupationareas { get; set; }
        public virtual DbSet<Candidaterole> Candidateroles { get; set; }
        public virtual DbSet<Candidatevacancy> Candidatevacancies { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Competence> Competences { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Formationvacancy> Formationvacancies { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Occupationarea> Occupationareas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scholarity> Scholarities { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<Vacancycompetence> Vacancycompetences { get; set; }
        public virtual DbSet<Vacancyoccupationarea> Vacancyoccupationareas { get; set; }

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

            modelBuilder.Entity<Candidatecompetence>(entity =>
            {
                entity.HasKey(e => new { e.IdCandidate, e.IdCompetence })
                    .HasName("PRIMARY");

                entity.ToTable("candidatecompetence");

                entity.HasIndex(e => e.IdCandidate, "fk_Candidate_has_Competence_Candidate1_idx");

                entity.HasIndex(e => e.IdCompetence, "fk_Candidate_has_Competence_Competence1_idx");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdCompetence).HasColumnName("idCompetence");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidatecompetences)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Candidate_has_Competence_Candidate1");

                entity.HasOne(d => d.IdCompetenceNavigation)
                    .WithMany(p => p.Candidatecompetences)
                    .HasForeignKey(d => d.IdCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Candidate_has_Competence_Competence1");
            });

            modelBuilder.Entity<Candidateoccupationarea>(entity =>
            {
                entity.HasKey(e => new { e.IdOccupationArea, e.IdCandidate })
                    .HasName("PRIMARY");

                entity.ToTable("candidateoccupationarea");

                entity.HasIndex(e => e.IdCandidate, "fk_OccupationArea_has_Candidate_Candidate1_idx");

                entity.HasIndex(e => e.IdOccupationArea, "fk_OccupationArea_has_Candidate_OccupationArea1_idx");

                entity.Property(e => e.IdOccupationArea).HasColumnName("idOccupationArea");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidateoccupationareas)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OccupationArea_has_Candidate_Candidate1");

                entity.HasOne(d => d.IdOccupationAreaNavigation)
                    .WithMany(p => p.Candidateoccupationareas)
                    .HasForeignKey(d => d.IdOccupationArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OccupationArea_has_Candidate_OccupationArea1");
            });

            modelBuilder.Entity<Candidaterole>(entity =>
            {
                entity.HasKey(e => new { e.IdCandidate, e.IdRole })
                    .HasName("PRIMARY");

                entity.ToTable("candidaterole");

                entity.HasIndex(e => e.IdCandidate, "fk_Candidate_has_Role_Candidate1_idx");

                entity.HasIndex(e => e.IdRole, "fk_Candidate_has_Role_Role1_idx");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.EndMonth).HasColumnName("endMonth");

                entity.Property(e => e.EndYear).HasColumnName("endYear");

                entity.Property(e => e.StartMonth).HasColumnName("startMonth");

                entity.Property(e => e.StartYear).HasColumnName("startYear");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidateroles)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Candidate_has_Role_Candidate1");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Candidateroles)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Candidate_has_Role_Role1");
            });

            modelBuilder.Entity<Candidatevacancy>(entity =>
            {
                entity.HasKey(e => new { e.IdVacancy, e.IdCandidate })
                    .HasName("PRIMARY");

                entity.ToTable("candidatevacancy");

                entity.HasIndex(e => e.IdCandidate, "fk_Vacancy_has_Candidate_Candidate1_idx");

                entity.HasIndex(e => e.IdVacancy, "fk_Vacancy_has_Candidate_Vacancy1_idx");

                entity.Property(e => e.IdVacancy).HasColumnName("idVacancy");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.Message)
                    .HasMaxLength(2000)
                    .HasColumnName("message");

                entity.Property(e => e.Situation)
                    .IsRequired()
                    .HasColumnType("enum('APPROVED','PROGRESS','REJECTED')")
                    .HasColumnName("situation");

                entity.Property(e => e.SubmitDate).HasColumnName("submitDate");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidatevacancies)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vacancy_has_Candidate_Candidate1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Candidatevacancies)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vacancy_has_Candidate_Vacancy1");
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

                entity.Property(e => e.CompetenceName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("competenceName");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("courseName");
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.ToTable("formation");

                entity.HasIndex(e => e.IdCandidate, "fk_Formation_Candidate1_idx");

                entity.HasIndex(e => e.IdCourse, "fk_Formation_Course1_idx");

                entity.HasIndex(e => e.IdInstitution, "fk_Formation_Institution1_idx");

                entity.HasIndex(e => e.IdScholarity, "fk_Formation_Scholarity1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataFim)
                    .HasColumnType("date")
                    .HasColumnName("dataFim");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdInstitution).HasColumnName("idInstitution");

                entity.Property(e => e.IdScholarity).HasColumnName("idScholarity");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('PROGRESS','FINISH')")
                    .HasColumnName("status");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Formation_Candidate1");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Formation_Course1");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Formation_Institution1");

                entity.HasOne(d => d.IdScholarityNavigation)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.IdScholarity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Formation_Scholarity1");
            });

            modelBuilder.Entity<Formationvacancy>(entity =>
            {
                entity.ToTable("formationvacancy");

                entity.HasIndex(e => e.IdCourse, "fk_FormationVacancy_Course1_idx");

                entity.HasIndex(e => e.IdScholarity, "fk_FormationVacancy_Scholarity1_idx");

                entity.HasIndex(e => e.IdVacancy, "fk_FormationVacancy_Vacancy1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdScholarity).HasColumnName("idScholarity");

                entity.Property(e => e.IdVacancy).HasColumnName("idVacancy");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('PROGRESS','FINISH')")
                    .HasColumnName("status");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Formationvacancies)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormationVacancy_Course1");

                entity.HasOne(d => d.IdScholarityNavigation)
                    .WithMany(p => p.Formationvacancies)
                    .HasForeignKey(d => d.IdScholarity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormationVacancy_Scholarity1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Formationvacancies)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormationVacancy_Vacancy1");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("institution");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("institutionName");
            });

            modelBuilder.Entity<Occupationarea>(entity =>
            {
                entity.ToTable("occupationarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OccupationAreaName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("occupationAreaName");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<Scholarity>(entity =>
            {
                entity.ToTable("scholarity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ScholarityName)
                    .IsRequired()
                    .HasColumnType("enum('SCHOOL','HIGH SCHOOL','GRADUATE')")
                    .HasColumnName("scholarityName");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("vacancy");

                entity.HasIndex(e => e.IdRole, "fk_Vacancy_Role1_idx");

                entity.HasIndex(e => e.IdCompany, "fk_Vaga_Empresa1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("date")
                    .HasColumnName("closeDate");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.IdCompany)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCompany");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("location");

                entity.Property(e => e.Modality)
                    .IsRequired()
                    .HasColumnType("enum('PRESENTIAL','REMOTE','HYBRID')")
                    .HasColumnName("modality");

                entity.Property(e => e.OpenDate)
                    .HasColumnType("date")
                    .HasColumnName("openDate");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int unsigned")
                    .HasColumnName("quantity");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("salary");

                entity.Property(e => e.Situation)
                    .IsRequired()
                    .HasColumnType("enum('OPEN','CLOSED','PROGRESS')")
                    .HasColumnName("situation");

                entity.Property(e => e.VacancyName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("vacancyName");

                entity.Property(e => e.Workload)
                    .HasColumnType("int unsigned")
                    .HasColumnName("workload");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vaga_Empresa1");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vacancy_Role1");
            });

            modelBuilder.Entity<Vacancycompetence>(entity =>
            {
                entity.HasKey(e => new { e.IdVacancy, e.IdCompetence })
                    .HasName("PRIMARY");

                entity.ToTable("vacancycompetence");

                entity.HasIndex(e => e.IdCompetence, "fk_Vacancy_has_Competence_Competence1_idx");

                entity.HasIndex(e => e.IdVacancy, "fk_Vacancy_has_Competence_Vacancy1_idx");

                entity.Property(e => e.IdVacancy).HasColumnName("idVacancy");

                entity.Property(e => e.IdCompetence).HasColumnName("idCompetence");

                entity.HasOne(d => d.IdCompetenceNavigation)
                    .WithMany(p => p.Vacancycompetences)
                    .HasForeignKey(d => d.IdCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vacancy_has_Competence_Competence1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Vacancycompetences)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vacancy_has_Competence_Vacancy1");
            });

            modelBuilder.Entity<Vacancyoccupationarea>(entity =>
            {
                entity.HasKey(e => new { e.IdOccupationArea, e.IdVacancy })
                    .HasName("PRIMARY");

                entity.ToTable("vacancyoccupationarea");

                entity.HasIndex(e => e.IdOccupationArea, "fk_OccupationArea_has_Vacancy_OccupationArea1_idx");

                entity.HasIndex(e => e.IdVacancy, "fk_OccupationArea_has_Vacancy_Vacancy1_idx");

                entity.Property(e => e.IdOccupationArea).HasColumnName("idOccupationArea");

                entity.Property(e => e.IdVacancy).HasColumnName("idVacancy");

                entity.HasOne(d => d.IdOccupationAreaNavigation)
                    .WithMany(p => p.Vacancyoccupationareas)
                    .HasForeignKey(d => d.IdOccupationArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OccupationArea_has_Vacancy_OccupationArea1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Vacancyoccupationareas)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OccupationArea_has_Vacancy_Vacancy1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
