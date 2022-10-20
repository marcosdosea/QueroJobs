using Services;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests;

[TestClass()]
public class CourseServiceTests
{
    private QueroJobsContext _queroJobsContext;
    private CourseService _courseService;

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
        var courses = new List<Course>
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

        _queroJobsContext.AddRange(courses);
        _queroJobsContext.SaveChanges();

        _courseService = new CourseService(_queroJobsContext);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        _courseService.Create(new Course()
        {
            Id = 4,
            CourseName = "Análise de dados"
        }).Wait();

        // Assert
        Assert.AreEqual(4, _courseService.GetAll().Result.Count());
        Course course = _courseService.Get(4).Result;
        Assert.IsNotNull(course);
        Assert.AreEqual(course.CourseName, "Análise de dados");
    }

    [TestMethod()]
    public void EditTest()
    {
        // Act
        Course course = _courseService.Get(3).Result;
        course.CourseName = "SQL";
        _courseService.Edit(course).Wait();

        // Assert
        course = _courseService.Get(3).Result;
        Assert.IsNotNull(course);
        Assert.AreEqual(course.CourseName, "SQL");
    }

    [TestMethod()]
    public void DeleteTest()
    {
        // Act
        _courseService.Delete(2).Wait();
        // Assert
        Assert.AreEqual(2, _courseService.GetAll().Result.Count());
        var autor = _courseService.Get(2).Result;
        Assert.AreEqual(null, autor);
    }

    [TestMethod()]
    public void GetTest()
    {
        // Act
        Course course = _courseService.Get(1).Result;

        // Assert
        Assert.IsNotNull(course);
        Assert.AreEqual("Matemática", course.CourseName);
    }

    [TestMethod()]
    public void GetAllTest()
    {
        // Act
        IEnumerable<Course> courseList = _courseService.GetAll().Result;

        // Assert
        Assert.IsInstanceOfType(courseList, typeof(IEnumerable<Course>));
        Assert.IsNotNull(courseList);
        Assert.AreEqual(3, courseList.Count());
        Assert.AreEqual(1, courseList.First().Id);
        Assert.AreEqual("Matemática", courseList.First().CourseName);
    }
}