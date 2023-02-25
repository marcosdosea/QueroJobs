using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Candidatecompetence> Candidatecompetences { get; set; }
        public virtual DbSet<Candidateoccupationarea> Candidateoccupationareas { get; set; }
        public virtual DbSet<Candidaterole> Candidateroles { get; set; }
        public virtual DbSet<Candidatevacancy> Candidatevacancies { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Competence> Competences { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=querojobs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserrole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

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
                    .HasMaxLength(100)
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
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Complement)
                    .HasMaxLength(100)
                    .HasColumnName("complement");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("country");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Deficiency)
                    .HasMaxLength(100)
                    .HasColumnName("deficiency");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.EmploymentStatus)
                    .HasColumnType("enum('FULL-TIME','PART-TIME','SELF-EMPLOYED','FREELANCE','CONTRACT','INTERNSHIP','APPRENTICESHIP','LEADERSHIP-PROGRAM','INDIRECT-CONTRACT','NONE')")
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
                    .HasMaxLength(100)
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
                    .HasMaxLength(100)
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

                entity.HasIndex(e => e.IdCompetence, "fk_CandidateCompetence_Competence1_idx");

                entity.HasIndex(e => e.IdCandidate, "fk_Candidate_has_Competence_Candidate1_idx");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdCompetence)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCompetence");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidatecompetences)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Candidate_has_Competence_Candidate1");

                entity.HasOne(d => d.IdCompetenceNavigation)
                    .WithMany(p => p.Candidatecompetences)
                    .HasForeignKey(d => d.IdCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CandidateCompetence_Competence1");
            });

            modelBuilder.Entity<Candidateoccupationarea>(entity =>
            {
                entity.HasKey(e => new { e.IdCandidate, e.IdOccupationArea })
                    .HasName("PRIMARY");

                entity.ToTable("candidateoccupationarea");

                entity.HasIndex(e => e.IdOccupationArea, "fk_CandidateOccupationArea_OccupationArea1_idx");

                entity.HasIndex(e => e.IdCandidate, "fk_OccupationArea_has_Candidate_Candidate1_idx");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdOccupationArea)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idOccupationArea");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidateoccupationareas)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OccupationArea_has_Candidate_Candidate1");

                entity.HasOne(d => d.IdOccupationAreaNavigation)
                    .WithMany(p => p.Candidateoccupationareas)
                    .HasForeignKey(d => d.IdOccupationArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CandidateOccupationArea_OccupationArea1");
            });

            modelBuilder.Entity<Candidaterole>(entity =>
            {
                entity.HasKey(e => new { e.IdCandidate, e.IdRole })
                    .HasName("PRIMARY");

                entity.ToTable("candidaterole");

                entity.HasIndex(e => e.IdRole, "fk_CandidateRole_Role1_idx");

                entity.HasIndex(e => e.IdCandidate, "fk_Candidate_has_Role_Candidate1_idx");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idRole");

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
                    .HasConstraintName("fk_CandidateRole_Role1");
            });

            modelBuilder.Entity<Candidatevacancy>(entity =>
            {
                entity.HasKey(e => new { e.IdCandidate, e.IdVacancy })
                    .HasName("PRIMARY");

                entity.ToTable("candidatevacancy");

                entity.HasIndex(e => e.IdVacancy, "fk_CandidateVacancy_Vacancy1_idx");

                entity.HasIndex(e => e.IdCandidate, "fk_Vacancy_has_Candidate_Candidate1_idx");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdVacancy)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idVacancy");

                entity.Property(e => e.Message)
                    .HasMaxLength(2000)
                    .HasColumnName("message");

                entity.Property(e => e.Situation)
                    .IsRequired()
                    .HasColumnType("enum('APPROVED','PROGRESS','REJECTED')")
                    .HasColumnName("situation");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.Candidatevacancies)
                    .HasForeignKey(d => d.IdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vacancy_has_Candidate_Candidate1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Candidatevacancies)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CandidateVacancy_Vacancy1");
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
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Complement)
                    .HasMaxLength(100)
                    .HasColumnName("complement");

                entity.Property(e => e.CorporateName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("corporateName");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("country");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
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
                    .HasMaxLength(100)
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
                    .HasMaxLength(100)
                    .HasColumnName("street");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("telephoneNumber");
            });

            modelBuilder.Entity<Competence>(entity =>
            {
                entity.ToTable("competence");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CompetenceName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("competenceName");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("courseName");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.ToTable("formation");

                entity.HasIndex(e => e.IdCandidate, "fk_Formation_Candidate1_idx");

                entity.HasIndex(e => e.IdCourse, "fk_Formation_Course1_idx");

                entity.HasIndex(e => e.IdInstitution, "fk_Formation_Institution1_idx");

                entity.HasIndex(e => e.IdScholarity, "fk_Formation_Scholarity1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.IdCandidate)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCandidate");

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCourse");

                entity.Property(e => e.IdInstitution)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idInstitution");

                entity.Property(e => e.IdScholarity)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idScholarity");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Status)
                    .IsRequired()
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

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCourse");

                entity.Property(e => e.IdScholarity)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idScholarity");

                entity.Property(e => e.IdVacancy)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idVacancy");

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

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("institutionName");
            });

            modelBuilder.Entity<Occupationarea>(entity =>
            {
                entity.ToTable("occupationarea");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.OccupationAreaName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("occupationAreaName");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<Scholarity>(entity =>
            {
                entity.ToTable("scholarity");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

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

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

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

                entity.Property(e => e.IdRole)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idRole");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
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
                    .HasMaxLength(100)
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

                entity.HasIndex(e => e.IdCompetence, "fk_VacancyCompetence_Competence1_idx");

                entity.HasIndex(e => e.IdVacancy, "fk_VacancyCompetence_Vacancy1_idx");

                entity.Property(e => e.IdVacancy)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idVacancy");

                entity.Property(e => e.IdCompetence)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCompetence");

                entity.HasOne(d => d.IdCompetenceNavigation)
                    .WithMany(p => p.Vacancycompetences)
                    .HasForeignKey(d => d.IdCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VacancyCompetence_Competence1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Vacancycompetences)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VacancyCompetence_Vacancy1");
            });

            modelBuilder.Entity<Vacancyoccupationarea>(entity =>
            {
                entity.HasKey(e => new { e.IdOccupationArea, e.IdVacancy })
                    .HasName("PRIMARY");

                entity.ToTable("vacancyoccupationarea");

                entity.HasIndex(e => e.IdOccupationArea, "fk_VacancyOccupationArea_OccupationArea1_idx");

                entity.HasIndex(e => e.IdVacancy, "fk_VacancyOccupationArea_Vacancy1_idx");

                entity.Property(e => e.IdOccupationArea)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idOccupationArea");

                entity.Property(e => e.IdVacancy)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idVacancy");

                entity.HasOne(d => d.IdOccupationAreaNavigation)
                    .WithMany(p => p.Vacancyoccupationareas)
                    .HasForeignKey(d => d.IdOccupationArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VacancyOccupationArea_OccupationArea1");

                entity.HasOne(d => d.IdVacancyNavigation)
                    .WithMany(p => p.Vacancyoccupationareas)
                    .HasForeignKey(d => d.IdVacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VacancyOccupationArea_Vacancy1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
