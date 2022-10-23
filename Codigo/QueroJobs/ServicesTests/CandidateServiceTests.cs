using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace ServicesTests;

[TestClass()]
public class CandidateServiceTests
{
    private QueroJobsContext _queroJobsContext;
    private CandidateService _candidateService;

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
        var candidaties = new List<Candidate>
        {
            new Candidate
            {
                Id = 1,
                Name = "Milena",
                Email = "milena@gmail.com",
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
            },
            new Candidate
            {
                Id = 2,
                Name = "Eri",
                Email = "eri@gmail.com",
                Cep = "4955-000",
                Country = "USA",
                State = "SE",
                City = "Itabaiana",
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
            }
        };

        _queroJobsContext.AddRange(candidaties);
        _queroJobsContext.SaveChanges();

        _candidateService = new CandidateService(_queroJobsContext);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _candidateService.Create(new Candidate()
        {
            Id = 3,
            Name = "Maira",
            Email = "maira@gmail.com",
            Cep = "49550-000",
            Country = "USA",
            State = "SE",
            City = "Aracaju",
            District = "Centro",
            Street = "Rua",
            HouseNumber = "233",
            Complement = "Casa",
            CellphoneNumber = "79981554289",
            TelephoneNumber = "",
            BirthDate = DateTime.UtcNow,
            Gender = "F",
            Cpf = "1234569",
            Deficiency = "Não se aplica",
            SalaryExpectation = 5000,
            EmploymentStatus = "FREELANCE",
            ActualRole = "Serviço social",
            Description = "Algo sobre mim"
        }).Wait();

        // Assert
        Assert.AreEqual(3, _candidateService.GetAll().Result.Count());
        Candidate candidate = _candidateService.Get(3).Result;
        Assert.IsNotNull(candidate);
        Assert.AreEqual(candidate.Name, "Maira");
        Assert.AreEqual(candidate.Email, "maira@gmail.com");
    }

    [TestMethod()]
    public void EditTest()
    {
        // Act
        Candidate candidate = _candidateService.Get(2).Result;
        candidate.Name = "Davy";
        candidate.Email = "davy@gmail.com";
        _candidateService.Edit(candidate).Wait();

        // Assert
        candidate = _candidateService.Get(2).Result;
        Assert.IsNotNull(candidate);
        Assert.AreEqual(candidate.Name, "Davy");
        Assert.AreEqual(candidate.Email, "davy@gmail.com");
    }

    [TestMethod()]
    public void DeleteTest()
    {
        // Act
        _candidateService.Delete(1).Wait();
        // Assert
        Assert.AreEqual(1, _candidateService.GetAll().Result.Count());
        var autor = _candidateService.Get(1).Result;
        Assert.AreEqual(null, autor);
    }

    [TestMethod()]
    public void GetTest()
    {
        // Act
        Candidate candidate = _candidateService.Get(1).Result;

        // Assert
        Assert.IsNotNull(candidate);
        Assert.AreEqual("Milena", candidate.Name);
        Assert.AreEqual("milena@gmail.com", candidate.Email);
    }

    [TestMethod()]
    public void GetAllTest()
    {
        // Act
        IEnumerable<Candidate> candidateList = _candidateService.GetAll().Result;

        // Assert
        Assert.IsInstanceOfType(candidateList, typeof(IEnumerable<Candidate>));
        Assert.IsNotNull(candidateList);
        Assert.AreEqual(2, candidateList.Count());
        Assert.AreEqual(1, candidateList.First().Id);
        Assert.AreEqual("Milena", candidateList.First().Name);
    }
}
