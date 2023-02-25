namespace Core;

public class SeedingService
{
    private readonly QueroJobsContext _queroJobsContext;

    public SeedingService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }

    public void Seed()
    {
        if (_queroJobsContext.Companies.Any() ||
            _queroJobsContext.Vacancies.Any() ||
            _queroJobsContext.Roles.Any() ||
            _queroJobsContext.Candidates.Any() ||
            _queroJobsContext.Courses.Any() ||
            _queroJobsContext.Competences.Any() ||
            _queroJobsContext.Institutions.Any())
            return;

        Company c1 = new Company
        {
            Id = 1,
            FantasyName = "ItatechJr",
            Email = "itatechjr@gmail.com",
            Cep = "49504060",
            Country = "Brasil",
            State = "SE",
            City = "Itabaiana",
            District = "Marianga",
            Street = "Rua Juca Monteiro",
            HouseNumber = "1579",
            Complement = "Ao lado do bar do Jegue",
            CellphoneNumber = "79 999999999",
            TelephoneNumber = null,
            Cnpj = "10409486000170",
            StateRegistration = null,
            CorporateName = "SOFTWARES ITABAIANA JR. EMPRESA JUNIOR DO DEPARTAMENTO DE SISTEMAS DE INFORMACAO DA UFS",
            ResponsibleName = "Ericles dos Santos"
        };
        Company c2 = new Company
        {
            Id = 2,
            FantasyName = "Titan",
            Email = "Titan@gmail.com",
            Cep = "49500001",
            Country = "Brasil",
            State = "SE",
            City = "Aracaju",
            District = "Bananeira",
            Street = "Belivaldo Chagas",
            HouseNumber = "6458",
            Complement = null,
            CellphoneNumber = "78 888888888",
            TelephoneNumber = null,
            Cnpj = "39409486000504",
            StateRegistration = null,
            CorporateName = "TITAN SOFTWARES ARACAJU",
            ResponsibleName = "Sinho senho"
        };
        Company c3 = new Company
        {
            Id = 3,
            FantasyName = "Fabrica de Softwares",
            Email = "fabricadesoftwares@gmail.com",
            Cep = "24050363",
            Country = "Brasil",
            State = "SP",
            City = "São Paulo",
            District = "Centro",
            Street = "Bloco A",
            HouseNumber = "01",
            Complement = null,
            CellphoneNumber = "79 999999999",
            TelephoneNumber = null,
            Cnpj = "11456548978914",
            StateRegistration = null,
            CorporateName = "FABRICA DE SOFTWARES",
            ResponsibleName = "Dosea"
        };

        Role r1 = new Role { Id = 1, RoleName = "Desenvolvedor de Softwares" };
        Role r2 = new Role { Id = 2, RoleName = "Engenheiro de Software" };
        Role r3 = new Role { Id = 3, RoleName = "Designer UX/UI" };
        Role r4 = new Role { Id = 4, RoleName = "DBA" };
        Role r5 = new Role { Id = 5, RoleName = "Gerente de redes" };
        Role r6 = new Role { Id = 6, RoleName = "Gerente de segurança" };
        Role r7 = new Role { Id = 7, RoleName = "Gerente de infraestrutura" };

        Vacancy v1 = new Vacancy
        {
            Id = 1,
            IdCompany = 1,
            IdRole = 1,
            VacancyName = "DevWeb Trainne",
            Salary = 0,
            OpenDate = DateTime.UtcNow,
            CloseDate = DateTime.UtcNow.AddDays(1),
            Description = "Lorem ipsum",
            Location = "UFS",
            Modality = "REMOTE",
            Situation = "OPEN",
            Workload = 2,
            Quantity = 20
        };

        Vacancy v2 = new Vacancy
        {
            Id = 2,
            IdCompany = 3,
            IdRole = 2,
            VacancyName = "Engenheiro De Software III",
            Salary = 8000,
            OpenDate = DateTime.UtcNow,
            CloseDate = DateTime.UtcNow.AddDays(10),
            Description = "Lorem ipsum",
            Location = "Casa de Dósea",
            Modality = "PRESENTIAL",
            Situation = "OPEN",
            Workload = 8,
            Quantity = 1
        };

        Vacancy v3 = new Vacancy
        {
            Id = 3,
            IdCompany = 2,
            IdRole = 3,
            VacancyName = "Designer UX/UI",
            Salary = 0,
            OpenDate = DateTime.UtcNow,
            CloseDate = DateTime.UtcNow.AddDays(5),
            Description = "Lorem ipsum",
            Location = "Centro de itabaiana",
            Modality = "HYBRID",
            Situation = "OPEN",
            Workload = 4,
            Quantity = 2
        };

        Candidate cand1 = new Candidate
        {
            Id = 1,
            Name = "Milena",
            Email = "@gmail.com",
            Cep = "4955-000",
            Country = "Brasil",
            State = "SE",
            City = "Carira",
            District = "Centro",
            Street = "Rua",
            HouseNumber = "233",
            Complement = "Casa",
            CellphoneNumber = "79981341962",
            TelephoneNumber = "",
            BirthDate = DateTime.UtcNow,
            Gender = "F",
            Cpf = "123456789",
            Deficiency = "Não se aplica",
            SalaryExpectation = 1000,
            EmploymentStatus = "FREELANCE",
            ActualRole = "Desenvolvedor de Softwares",
            Description = "Algo sobre mim"
        };

        Candidate cand2 = new Candidate
        {
            Id = 2,
            Name = "Eri",
            Email = "@gmail.com",
            Cep = "4955-000",
            Country = "USA",
            State = "MI",
            City = "Mass",
            District = "Centro",
            Street = "Rua",
            HouseNumber = "233",
            Complement = "Casa",
            CellphoneNumber = "7912345678",
            TelephoneNumber = "",
            BirthDate = DateTime.UtcNow,
            Gender = "M",
            Cpf = "1234569",
            Deficiency = "Não se aplica",
            SalaryExpectation = 1000,
            EmploymentStatus = "FREELANCE",
            ActualRole = "DBA",
            Description = "Algo sobre mim"
        };

        Competence competence1 = new Competence
        {
            Id = 1,
            CompetenceName = "Boa comunicação"
        };

        Competence competence2 = new Competence
        {
            Id = 2,
            CompetenceName = "Dominio do inglês"
        };
        Competence competence3 = new Competence
        {
            Id = 3,
            CompetenceName = "Saber liderar"
        };

        Competence competence4 = new Competence
        {
            Id = 4,
            CompetenceName = "Facilidade no aprendizado"
        };


        //Formation for1 = new Formation { }


        Course course1 = new Course { Id = 1, CourseName = "Sistemas de Informação" };
        Course course2 = new Course { Id = 2, CourseName = "Engenharia de Software" };
        Course course3 = new Course { Id = 3, CourseName = "Marketing e Publicidade" };
        Course course4 = new Course { Id = 4, CourseName = "Contabilidade" };
        Course course5 = new Course { Id = 5, CourseName = "Medicina" };
        Course course6 = new Course { Id = 6, CourseName = "Direito" };


        Institution institution1 = new Institution { Id = 1, InstitutionName = "Universidade Federal de Sergipe - UFS" };
        Institution institution2 = new Institution { Id = 2, InstitutionName = "Universideade Tiradentes - UNIT" };
        Institution institution3 = new Institution { Id = 3, InstitutionName = "Unissal" };
        Institution institution4 = new Institution { Id = 4, InstitutionName = "Estácio" };

        _queroJobsContext.AddRange(c1, c2, c3);
        _queroJobsContext.AddRange(r1, r2, r3, r4, r5, r6, r7);
        _queroJobsContext.AddRange(v1, v2, v3);
        _queroJobsContext.AddRange(cand1, cand2);
        _queroJobsContext.AddRange(course1, course2, course3, course4, course5, course6);
        _queroJobsContext.AddRange(competence1, competence2, competence3, competence4);
        _queroJobsContext.AddRange(institution1, institution2, institution3, institution4);

        _queroJobsContext.SaveChanges();
    }
}