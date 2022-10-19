using Services;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests;

[TestClass()]
public class CompetenceServiceTests
{
    private QueroJobsContext _queroJobsContext;
    private CompetenceService _competenceService;

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
        var companies = new List<Competence>
        {
             new Competence
                {
                    Id = 1,
                    CompetenceName = "Especialização em Power BI"
                },
                new Competence
                {
                    Id = 2,
                    CompetenceName = "Doutorado Sitemas"
                },
                new Competence
                {
                    Id = 3,
                    CompetenceName = "Analista de dados e DBA"
                },
        };

        _queroJobsContext.AddRange(companies);
        _queroJobsContext.SaveChanges();

        _competenceService = new CompetenceService(_queroJobsContext);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _competenceService.Create(new Competence()
        {
            Id = 4,
            CompetenceName = "Soft skills"
        }).Wait();

        // Assert
        Assert.AreEqual(4, _competenceService.GetAll().Result.Count());
        Competence competence = _competenceService.Get(4).Result;
        Assert.IsNotNull(competence);
        Assert.AreEqual(competence.CompetenceName, "Soft skills");
    }

    [TestMethod()]
    public void EditTest()
    {
        // Act
        Competence competence = _competenceService.Get(3).Result;
        competence.CompetenceName = "Analista de dados e DBA";
        _competenceService.Edit(competence).Wait();

        // Assert
        competence = _competenceService.Get(3).Result;
        Assert.IsNotNull(competence);
        Assert.AreEqual(competence.CompetenceName, "Analista de dados e DBA");
    }

    [TestMethod()]
    public void DeleteTest()
    {
        // Act
        _competenceService.Delete(2).Wait();
        // Assert
        Assert.AreEqual(2, _competenceService.GetAll().Result.Count());
        var autor = _competenceService.Get(2).Result;
        Assert.AreEqual(null, autor);
    }

    [TestMethod()]
    public void GetTest()
    {
        // Act
        Competence competence = _competenceService.Get(1).Result;

        // Assert
        Assert.IsNotNull(competence);
        Assert.AreEqual("Especialização em Power BI", competence.CompetenceName);
    }

    [TestMethod()]
    public void GetAllTest()
    {
        // Act
        IEnumerable<Competence> competenceList = _competenceService.GetAll().Result;

        // Assert
        Assert.IsInstanceOfType(competenceList, typeof(IEnumerable<Competence>));
        Assert.IsNotNull(competenceList);
        Assert.AreEqual(3, competenceList.Count());
        Assert.AreEqual(1, competenceList.First().Id);
        Assert.AreEqual("Especialização em Power BI", competenceList.First().CompetenceName);
    }
}