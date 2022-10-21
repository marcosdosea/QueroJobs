using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QueroJobsWEB.Mappers;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers.Tests;

[TestClass()]
public class CompetenceControllerTests
{
    private static CompetenceController competenceController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        var mockService = new Mock<ICompetenceService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new CompetenceProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
                .Returns(GetTestCompetences());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetCompetence());
        mockService.Setup(service => service.Edit(It.IsAny<Competence>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Competence>()))
            .Verifiable();

        competenceController = new CompetenceController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void IndexTest()
    {
        // Act
        var result = competenceController.Index().Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CompetenceModel>));

        List<CompetenceModel> list = (List<CompetenceModel>)viewResult.ViewData.Model;
        Assert.AreEqual(3, list.Count);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        var result = competenceController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void CreateTest_Valid()
    {
        // Act
        var result = competenceController.Create(GetNewCompetence()).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    [TestMethod()]
    public void CreateTest_InValid()
    {
        // Arrange
        competenceController.ModelState.AddModelError("CompetenceName", "Campo requerido");

        // Act
        var result = competenceController.Create(GetNewCompetence()).Result;

        // Assert
        Assert.AreEqual(1, competenceController.ModelState.ErrorCount);
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsNotNull(viewResult);
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        // Act
        var result = competenceController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CompetenceModel));
        CompetenceModel competenceModel = (CompetenceModel)viewResult.ViewData.Model;

        Assert.AreEqual("Especialização em Power BI", competenceModel.CompetenceName);
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        // Act
        var result = competenceController.Edit(GetTargetCompetenceModel().Id, GetTargetCompetenceModel()).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    [TestMethod()]
    public void DeleteTest_Post()
    {
        // Act
        var result = competenceController.Delete(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    [TestMethod()]
    public void DeleteTest_Get()
    {
        // Act
        var result = competenceController.Delete(GetTargetCompetenceModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    private CompetenceModel GetNewCompetence()
    {
        return new CompetenceModel
        {
            Id = 1,
            CompetenceName = "Especialização em Power BI"
        };
    }

    private async Task<Competence> GetTargetCompetence()
    {
        return new Competence
        {
            Id = 1,
            CompetenceName = "Especialização em Power BI"
        };
    }

    private CompetenceModel GetTargetCompetenceModel()
    {
        return new CompetenceModel
        {
            Id = 1,
            CompetenceName = "Especialização em Power BI"
        };
    }

    private async Task<IEnumerable<Competence>> GetTestCompetences()
    {
        return new List<Competence>
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
    }
}