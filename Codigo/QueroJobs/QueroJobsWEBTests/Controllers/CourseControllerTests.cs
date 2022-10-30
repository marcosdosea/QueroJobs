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
public class CourseControllerTests
{
    private static CourseController courseController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        var mockService = new Mock<ICourseService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new CourseProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
                .Returns(GetTestCourses());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetCourse());
        mockService.Setup(service => service.Edit(It.IsAny<Course>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Course>()))
            .Verifiable();

        courseController = new CourseController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void IndexTest()
    {
        // Act
        var result = courseController.Index().Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CourseModel>));

        List<CourseModel> list = (List<CourseModel>)viewResult.ViewData.Model;
        Assert.AreEqual(3, list.Count);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        var result = courseController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void CreateTest_Valid()
    {
        // Act
        var result = courseController.Create(GetNewCourse()).Result;

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
        courseController.ModelState.AddModelError("CourseName", "Campo requerido");

        // Act
        var result = courseController.Create(GetNewCourse()).Result;

        // Assert
        Assert.AreEqual(1, courseController.ModelState.ErrorCount);
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsNotNull(viewResult);
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        // Act
        var result = courseController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CourseModel));
        CourseModel courseModel = (CourseModel)viewResult.ViewData.Model;

        Assert.AreEqual("Matemática", courseModel.CourseName);
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        // Act
        var result = courseController.Edit(GetTargetCourseModel().Id, GetTargetCourseModel()).Result;

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
        var result = courseController.Delete(1).Result;

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
        var result = courseController.Delete(GetTargetCourseModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    private CourseModel GetNewCourse()
    {
        return new CourseModel
        {
            Id = 1,
            CourseName = "Matemática"
        };
    }

    private async Task<Course> GetTargetCourse()
    {
        return new Course
        {
            Id = 1,
            CourseName = "Matemática"
        };
    }

    private CourseModel GetTargetCourseModel()
    {
        return new CourseModel
        {
            Id = 1,
            CourseName = "Matemática"
        };
    }

    private async Task<IEnumerable<Course>> GetTestCourses()
    {
        return new List<Course>
            {

                new Course
                {
                    Id = 1,
                    CourseName = "Matemática"
                },
                new Course
                {
                    Id = 2,
                    CourseName = "Contabilidade"
                },
                new Course
                {
                    Id = 3,
                    CourseName = "SQL"
                },
            };
    }
}