using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.ContentModel;
using NuGet.Protocol.Core.Types;
using QueroJobsWEB.Controllers;
using QueroJobsWEB.Mappers;
using QueroJobsWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroJobsWEB.Controllers.Tests;

[TestClass()]
public class AdminControllerTests
{
    private static AdminController adminController;

    [TestInitialize]
    public void Initialize()
    {
        Assert.Fail();
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
        adminController = new AdminController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void AdminControllerTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void IndexTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyDetailsTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyCreateTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyCreateTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyEditTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyEditTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyDeleteTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompanyDeleteTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CandidateDetailsTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CandidateEditTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CandidateEditTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CandidateDeleteTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CandidateDeleteTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompetenceCreateTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompetenceCreateTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompetenceEditTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompetenceEditTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompetenceDeleteTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CompetenceDeleteTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CourseCreateTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CourseCreateTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CourseEditTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CourseEditTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CourseDeleteTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CourseDeleteTest1()
    {
        Assert.Fail();
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
        Assert.Fail();
        
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
        Assert.Fail();
        
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
        Assert.Fail();
        
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
        Assert.Fail();
        
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
        Assert.Fail();
        
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
    public void RoleCreateTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void RoleCreateTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void RoleEditTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void RoleEditTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void RoleDeleteTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void RoleDeleteTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CreateTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void CreateTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void EditTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void EditTest1()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void DeleteTest()
    {
        Assert.Fail();
    }

    [TestMethod()]
    public void DeleteTest1()
    {
        Assert.Fail();
    }

    private InstitutionModel GetNewInstitution()
    {
        return new InstitutionModel
        {
            Id = 1,
            InstitutionName = "Oxford"
        };
    }

    private async Task<Institution> GetTargetInstitution()
    {
        return new Institution
        {
            Id = 1,
            InstitutionName = "Oxford"
        };
    }

    private InstitutionModel GetTargetInstitutionModel()
    {
        return new InstitutionModel
        {
            Id = 1,
            InstitutionName = "Oxford"
        };
    }

    private async Task<IEnumerable<Institution>> GetTestInstitutions()
    {
        return new List<Institution>
        {
            new Institution
            {
                Id = 1,
                InstitutionName = "Oxford"
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