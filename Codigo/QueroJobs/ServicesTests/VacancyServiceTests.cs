using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests;

[TestClass()]
public class VacancyServiceTests
{
    private QueroJobsContext _queroJobsContext;
    private VacancyService _vacancyService;

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
        var vacancies = new List<Vacancy>
        {
             new Vacancy
                {
                    Id = 1,
                    VacancyName = "Manicure"
                },
                new Vacancy
                {
                    Id = 2,
                    VacancyName = "Motorista"
                },
                new Vacancy
                {
                    Id = 3,
                    VacancyName = "Marceneiro"
                },
        };

        _queroJobsContext.AddRange(vacancies);
        _queroJobsContext.SaveChanges();

        _vacancyService = new VacancyService(_queroJobsContext);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _vacancyService.Create(new Vacancy()
        {
            Id = 4,
            VacancyName = "Análista de dados"
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
        Assert.AreEqual("Manicure", vacancy.VacancyName);
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
        Assert.AreEqual("Manicure", vacancyList.First().VacancyName);
    }
}
