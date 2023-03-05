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
public class AdminControllerTests
{
    private static AdminController adminController; //TODO

    [TestInitialize]
    public void Initialize()
    {
        Assert.Inconclusive();
        return;
        // Arrange
        var mockService = new Mock<IInstitutionService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new InstitutionProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
            .Returns(GetTestInstitutions());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetInstitution());
        mockService.Setup(service => service.Edit(It.IsAny<Institution>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Institution>()))
            .Verifiable();






        //For All Use Cases Of Admin
        //adminController = new AdminController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void AdminControllerTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void IndexTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyDetailsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyCreateTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyCreateTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyEditTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyEditTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyDeleteTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompanyDeleteTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CandidateDetailsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CandidateEditTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CandidateEditTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CandidateDeleteTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CandidateDeleteTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompetenceCreateTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompetenceCreateTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompetenceEditTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompetenceEditTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompetenceDeleteTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CompetenceDeleteTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CourseCreateTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CourseCreateTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CourseEditTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CourseEditTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CourseDeleteTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CourseDeleteTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void InstitutionCreateTest()
    {
        // Act
        var result = adminController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void InstitutionCreateTest_Valid()
    {
        Assert.Inconclusive();

        /*
        // Act
        var result = adminController.Create(GetNewInstitution()).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index",redirectToActionResult.ActionName);*/
    }

    [TestMethod()]
    public void InstitutionEditTest_Get()
    {
        Assert.Inconclusive();

        /*
        // Act
        var result = adminController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(InstitutionModel));
        InstitutionModel institutionModel = (InstitutionModel)viewResult.ViewData.Model;

        Assert.AreEqual("TEXTOAQUI OXFORD", institutionModel.InstitutionName);*/
    }

    [TestMethod()]
    public void InstitutionEditTest_Post()
    {
        Assert.Inconclusive();

        /*
        // Act
        var result = adminController.Edit(GetTargetInstitutionModel().Id, GetTargetInstitutionModel()).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);*/
    }

    [TestMethod()]
    public void InstitutionDeleteTest_Post()
    {
        Assert.Inconclusive();

        /*
        // Act
        var result = adminController.Delete(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);*/
    }

    [TestMethod()]
    public void InstitutionDeleteTest_Get()
    {
        Assert.Inconclusive();

        /*
        // Act
        var result = adminController.Delete(GetTargetInstitutionModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);*/
    }

    [TestMethod()]
    public void RoleCreateTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void RoleCreateTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void RoleEditTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void RoleEditTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void RoleDeleteTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void RoleDeleteTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CreateTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void CreateTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void DeleteTest_Get()
    {
        Assert.Inconclusive();
    }

    [TestMethod()]
    public void DeleteTest_Post()
    {
        Assert.Inconclusive();
    }

    private InstitutionModel GetNewInstitution()
    {
        return new InstitutionModel
        {
            Id = 1,
            InstitutionName = "Massachusetts Institute of Technology - MIT"
        };
    }

    private async Task<Institution> GetTargetInstitution()
    {
        return new Institution
        {
            Id = 1,
            InstitutionName = "Massachusetts Institute of Technology - MIT"
        };
    }

    private InstitutionModel GetTargetInstitutionModel()
    {
        return new InstitutionModel
        {
            Id = 1,
            InstitutionName = "Massachusetts Institute of Technology - MIT"
        };
    }

    private async Task<IEnumerable<Institution>> GetTestInstitutions()
    {
        return new List<Institution>
        {
            new Institution
            {
                Id = 1,
                InstitutionName = "Massachusetts Institute of Technology - MIT"
            },
            new Institution
            {
                Id = 2,
                InstitutionName = "Harvard"
            },
            new Institution
            {
                Id = 3,
                InstitutionName = "Universidade Federal de Sergipe - UFS"
            }
        };
    }

}