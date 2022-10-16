using Services;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests;

[TestClass()]
public class CompanyServiceTests
{
    private QueroJobsContext _queroJobsContext;
    private CompanyService _companyService;

    [TestInitialize]
    public void Initialize()
    {
        //Arrange
        var builder = new DbContextOptionsBuilder<QueroJobsContext>();
        builder.UseInMemoryDatabase("QueroJobs");
        var options = builder.Options;

        _queroJobsContext = new QueroJobsContext(options);
        _queroJobsContext.Database.EnsureDeleted();
        _queroJobsContext.Database.EnsureCreated();
        var companies = new List<Company>
        {
            new Company {
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
            },
            new Company  {
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
            },
            new Company {
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
            }
        };

        _queroJobsContext.AddRange(companies);
        _queroJobsContext.SaveChanges();

        _companyService = new CompanyService(_queroJobsContext);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _companyService.Create(new Company()
        {
            Id = 4,
            FantasyName = "Depressão",
            Email = "depressao@gmail.com",
            Cep = "00000000",
            Country = "Brasil",
            State = "SE",
            City = "SERGIPE",
            District = "Centro",
            Street = "Bloco",
            HouseNumber = "01",
            Complement = null,
            CellphoneNumber = "79 999999990",
            TelephoneNumber = null,
            Cnpj = "11456548978941",
            StateRegistration = null,
            CorporateName = "Depressão Corp",
            ResponsibleName = "Sem nome"
        }).Wait();

        // Assert
        Assert.AreEqual(4, _companyService.GetAll().Result.Count());
        Company company = _companyService.Get(4).Result;
        Assert.IsNotNull(company);
        Assert.AreEqual(company.FantasyName, "Depressão");
        Assert.AreEqual(company.Email, "depressao@gmail.com");
    }

    [TestMethod()]
    public void EditTest()
    {
        // Act
        Company company = _companyService.Get(3).Result;
        company.FantasyName = "No Hope";
        company.Email = "nohope@gmail.com";
        _companyService.Edit(company).Wait();
        
        // Assert
        company = _companyService.Get(3).Result;
        Assert.IsNotNull(company);
        Assert.AreEqual(company.FantasyName, "No Hope");
        Assert.AreEqual(company.Email, "nohope@gmail.com");
    }

    [TestMethod()]
    public void DeleteTest()
    {
        // Act
        _companyService.Delete(2).Wait();
        // Assert
        Assert.AreEqual(2, _companyService.GetAll().Result.Count());
        var autor = _companyService.Get(2).Result;
        Assert.AreEqual(null, autor);
    }

    [TestMethod()]
    public void GetTest()
    {
        // Act
        Company company = _companyService.Get(1).Result;

        // Assert
        Assert.IsNotNull(company);
        Assert.AreEqual("ItatechJr", company.FantasyName);
        Assert.AreEqual("itatechjr@gmail.com", company.Email);
    }

    [TestMethod()]
    public void GetAllTest()
    {
        // Act
        IEnumerable<Company> companyList = _companyService.GetAll().Result;

        // Assert
        Assert.IsInstanceOfType(companyList, typeof(IEnumerable<Company>));
        Assert.IsNotNull(companyList);
        Assert.AreEqual(3, companyList.Count());
        Assert.AreEqual(1, companyList.First().Id);
        Assert.AreEqual("ItatechJr", companyList.First().FantasyName);
    }
}