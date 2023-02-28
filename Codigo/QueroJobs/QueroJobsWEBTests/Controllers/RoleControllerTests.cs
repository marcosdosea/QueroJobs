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
public class RoleControllerTests
{
    private static RoleController roleController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        var mockService = new Mock<IRoleService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new RoleProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
                .Returns(GetTestRoles());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetRole());
        mockService.Setup(service => service.Edit(It.IsAny<Role>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Role>()))
            .Verifiable();

        roleController = new RoleController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void IndexTest()
    {
        var result = roleController.Index().Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<RoleModel>));

        List<RoleModel> list = (List<RoleModel>)viewResult.ViewData.Model;
        Assert.AreEqual(3, list.Count);
    }

    [TestMethod()]
    public void DetailsTest()
    {
        // Act
        var result = roleController.Details(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(RoleModel));
        RoleModel roleModel = (RoleModel)viewResult.ViewData.Model;

        Assert.AreEqual("Desenvolvedor de Softwares", roleModel.RoleName);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        var result = roleController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void CreateTest_Valid()
    {
        // Act
        var result = roleController.Create(GetNewRole()).Result;

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
        roleController.ModelState.AddModelError("RoleName", "Campo requerido");

        // Act
        var result = roleController.Create(GetNewRole()).Result;

        // Assert
        Assert.AreEqual(1, roleController.ModelState.ErrorCount);
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsNotNull(viewResult);
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        // Act
        var result = roleController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(RoleModel));
        RoleModel roleModel = (RoleModel)viewResult.ViewData.Model;

        Assert.AreEqual("Desenvolvedor de Softwares", roleModel.RoleName);
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        // Act
        var result = roleController.Edit(GetTargetRoleModel().Id, GetTargetRoleModel()).Result;

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
        var result = roleController.Delete(1).Result;

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
        var result = roleController.Delete(GetTargetRoleModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    private RoleModel GetNewRole()
    {
        return new RoleModel
        {
            Id = 1,
            RoleName = "Desenvolvedor de Softwares"
        };
    }

    private async Task<Role> GetTargetRole()
    {
        return new Role
        {
            Id = 1,
            RoleName = "Desenvolvedor de Softwares"
        };
    }

    private RoleModel GetTargetRoleModel()
    {
        return new RoleModel
        {
            Id = 1,
            RoleName = "Desenvolvedor de Softwares"
        };
    }

    private async Task<IEnumerable<Role>> GetTestRoles()
    {
        return new List<Role>
            {

                new Role
                {
                    Id = 1,
                    RoleName = "Desenvolvedor de Softwares"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Engenheiro de Software"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "Designer UX/UI"
                },
            };
    }
}
