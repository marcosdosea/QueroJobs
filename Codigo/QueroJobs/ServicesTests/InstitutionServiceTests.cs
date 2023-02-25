using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests;

[TestClass()]
public class InstitutionServiceTests
{
    private QueroJobsContext _context;
    private IInstitutionService _institutionService;

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
        var institutions = new List<Institution>
        {
            new Institution {Id = 1, InstitutionName = "Universidade Federal de Sergipe - UFS"},
            new Institution {Id = 2, InstitutionName = "Massachusetts Institute of Technology - MIT"},
            new Institution {Id = 3, InstitutionName = "Universidade Tiradentes - UNIT"}
        };

        _context.AddRange(institutions);
        _context.SaveChanges();

        _institutionService = new InstitutionService(_context);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _institutionService.Create(new Institution()
        {
            Id = 4,
            InstitutionName = "Harvard University - HAVARD"
        }).Wait();

        // Assert
        Assert.AreEqual(4, _institutionService.GetAll().Result.Count());
        Institution institution = _institutionService.Get(4).Result;
        Assert.IsNotNull(institution);
        Assert.AreEqual(institution.InstitutionName, "Harvard University - HAVARD");

    }

    [TestMethod()]
    public void DeleteTest()
    {
        // Act
        _institutionService.Delete(3).Wait();

        // Assert
        Assert.AreEqual(2, _institutionService.GetAll().Result.Count());
        var institution = _institutionService.Get(3).Result;
        Assert.AreEqual(null, institution);
    }

    [TestMethod()]
    public void EditTest()
    {
        // Act
        Institution institution = _institutionService.Get(1).Result;
        institution.InstitutionName = "Universidade Federal de Sergipe Itabaiana - UFS";
        _institutionService.Edit(institution).Wait();

        // Assert
        institution = _institutionService.Get(1).Result;
        Assert.IsNotNull(institution);
        Assert.AreEqual(institution.InstitutionName, "Universidade Federal de Sergipe Itabaiana - UFS");
    }

    [TestMethod()]
    public void GetTest()
    {
        // Act
        Institution institution = _institutionService.Get(1).Result;

        // Assert
        Assert.IsNotNull(institution);
        Assert.AreEqual("Universidade Federal de Sergipe - UFS", institution.InstitutionName);
    }

    [TestMethod()]
    public void GetAllTest()
    {
        // Act
        IEnumerable<Institution> institutionsList = _institutionService.GetAll().Result;

        // Assert
        Assert.IsInstanceOfType(institutionsList, typeof(IEnumerable<Institution>));
        Assert.IsNotNull(institutionsList);
        Assert.AreEqual("Universidade Federal de Sergipe - UFS", institutionsList.First().InstitutionName);
    }
}