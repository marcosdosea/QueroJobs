using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests;

[TestClass()]
public class VacancyServiceTests
{
    private QueroJobsContext _context;
    private IVacancyService _vacancyService;

    [TestInitialize]
    public void Initialize()
    {
        //Arrange
        var builder = new DbContextOptionsBuilder<QueroJobsContext>();
        builder.UseInMemoryDatabase("QueroJobs");
        var options = builder.Options;
        _context = new QueroJobsContext(options);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        var vacancies = new List<Vacancy>
        {
             new Vacancy
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
                },
                new Vacancy
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
                },
                new Vacancy
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
                },
        };

        _context.AddRange(vacancies);
        _context.SaveChanges();

        _vacancyService = new VacancyService(_context);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _vacancyService.Create(new Vacancy()
        {
            Id = 4,
            VacancyName = "Análista de dados",
            IdCompany = 3,
            IdRole = 1,
            Salary = 2500,
            OpenDate = DateTime.UtcNow,
            CloseDate = DateTime.UtcNow.AddDays(1),
            Description = "Lorem ipsum",
            Location = "UFS",
            Modality = "REMOTE",
            Situation = "OPEN",
            Workload = 2,
            Quantity = 20
        }).Wait();

        // Assert
        Assert.AreEqual(4, _vacancyService.GetAll().Result.Count());
        Vacancy vacancy = _vacancyService.Get(4).Result;
        Assert.IsNotNull(vacancy);
        Assert.AreEqual(vacancy.VacancyName, "Análista de dados");
    }

    [TestMethod()]
    public void EditTest()
    {
        // Act
        Vacancy vacancy = _vacancyService.Get(3).Result;
        vacancy.VacancyName = "Marceneiro";
        _vacancyService.Edit(vacancy).Wait();

        // Assert
        vacancy = _vacancyService.Get(3).Result;
        Assert.IsNotNull(vacancy);
        Assert.AreEqual(vacancy.VacancyName, "Marceneiro");
    }

    [TestMethod()]
    public void DeleteTest()
    {
        // Act
        _vacancyService.Delete(2).Wait();
        // Assert
        Assert.AreEqual(2, _vacancyService.GetAll().Result.Count());
        var autor = _vacancyService.Get(2).Result;
        Assert.AreEqual(null, autor);
    }

    [TestMethod()]
    public void GetTest()
    {
        // Act
        Vacancy vacancy = _vacancyService.Get(1).Result;

        // Assert
        Assert.IsNotNull(vacancy);
        Assert.AreEqual("DevWeb Trainne", vacancy.VacancyName);
    }

    [TestMethod()]
    public void GetAllTest()
    {
        // Act
        IEnumerable<Vacancy> vacancyList = _vacancyService.GetAll().Result;

        // Assert
        Assert.IsInstanceOfType(vacancyList, typeof(IEnumerable<Vacancy>));
        Assert.IsNotNull(vacancyList);
        Assert.AreEqual(3, vacancyList.Count());
        Assert.AreEqual(1, vacancyList.First().Id);
        Assert.AreEqual("DevWeb Trainne", vacancyList.First().VacancyName);
    }
}
