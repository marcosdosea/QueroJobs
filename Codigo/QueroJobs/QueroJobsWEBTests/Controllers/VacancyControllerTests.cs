using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers;

[TestClass()]
public class VacancyController : Controller
{
    
    private static VacancyController vacancyController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        var mockService = new Mock<IVacancyService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new VacancyProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
                .Returns(GetTestCompanies());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetVacancy());
        mockService.Setup(service => service.Edit(It.IsAny<Vacancy>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Vacancy>()))
            .Verifiable();

        vacancyController = new VacancyController(mockService.Object, mapper);
    }

   
    [TestMethod()]
    public void IndexTest()
    {
        var result = vacancyController.Index().Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<VacancyModel>));

        List<VacancyModel> list = (List<VacancyModel>)viewResult.ViewData.Model;
        Assert.AreEqual(3, list.Count);
    }

    [TestMethod()]
    public void DetailsTest()
    {
        // Act
        var result = vacancyController.Details(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VacancyModel));
        VacancyModel vacancyModel = (VacancyModel)viewResult.ViewData.Model;

        Assert.AreEqual("ItatechJr", vacancyModel.FantasyName);
        Assert.AreEqual("itatechjr@gmail.com", vacancyModel.Email);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        var result = vacancyController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void CreateTest_Valid()
    {
        // Act
        var result = vacancyController.Create(GetNewVacancy()).Result;

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
        vacancyController.ModelState.AddModelError("VacancyName", "Campo requerido");

        // Act
        var result = vacancyController.Create(GetNewVacancy()).Result;

        // Assert
        Assert.AreEqual(1, vacancyController.ModelState.ErrorCount);
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsNotNull(viewResult);
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        // Act
        var result = vacancyController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VacancyModel));
        VacancyModel vacancyModel = (VacancyModel)viewResult.ViewData.Model;

        Assert.AreEqual("ItatechJr", vacancyModel.FantasyName);
        Assert.AreEqual("itatechjr@gmail.com", vacancyModel.Email);
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        // Act
        var result = vacancyController.Edit(GetTargetVacancyModel().Id, GetTargetVacancyModel()).Result;

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
        var result = vacancyController.Delete(1).Result;

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
        var result = vacancyController.Delete(GetTargetVacancyModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    private VacancyModel GetNewVacancy()
    {
        return new VacancyModel
        {
            Id = 1,
            IdCompany = 1,
            VacancyName = "Engenheiro de Software III",
            Salary = 27000.00,
            OpenDate = 17102022,
            CloseDate = 17112022,
            Description = "Ajude a resolver desafios usando as mais novas tecnologias, e faça coisas extraordinárias. Impulsione soluções inovadoras para uma das organizações líderes mundiais. Faça parte!",
            Location = "Rua Juca Monteiro",
            Modality = "Remoto",
            Situation = "Aberta",
            Workload = 1,
            Quantity = 1,
            IdRole = 1
        };

    }
    private async Task<Vacancy> GetTargetVacancy()
    {
        return new Vacancy
        {
            Id = 1,
            IdCompany = 1,
            VacancyName = "Engenheiro de Software II",
            Salary = 10000.00,
            OpenDate = 17102022,
            CloseDate = 17112022,
            Description = "Ajude a resolver desafios usando as mais novas tecnologias, e faça coisas extraordinárias. Impulsione soluções inovadoras para uma das organizações líderes mundiais. Faça parte!",
            Location = "Rua Juca Monteiro",
            Modality = "Remoto",
            Situation = "Aberta",
            Workload = 1,
            Quantity = 1,
            IdRole = 1
        };
    }

    private VacancyModel GetTargetVacancyModel()
    {
        return new VacancyModel
        {
            Id = 1,
            IdCompany = 1,
            VacancyName = "Engenheiro de Software I",
            Salary = 4000.00,
            OpenDate = 17102022,
            CloseDate = 17112022,
            Description = "Ajude a resolver desafios usando as mais novas tecnologias, e faça coisas extraordinárias. Impulsione soluções inovadoras para uma das organizações líderes mundiais. Faça parte!",
            Location = "Rua Juca Monteiro",
            Modality = "Remoto",
            Situation = "Aberta",
            Workload = 1,
            Quantity = 1,
            IdRole = 1
        };
    }

    private async Task<IEnumerable<Vacancy>> GetTestCompanies()
    {
        return new List<Vacancy>
            {
                new Vacancy
                {
                    Id = 1,
                    FantasyName = "ItatechJr",
                    Email = "itatechjr@gmail.com",
                    Cep = "49504060",
                    Country = "Brasil",
                    State = "SE",
                    City = "Itabaiana",
                    District = "Marianga",
                    Street = "Rua Juca Monteiro",
                    HouseNumber = "1579",
                    Complement = "Ao lado do bar do Jegue",
                    CellphoneNumber = "79 999999999",
                    TelephoneNumber = null,
                    Cnpj = "10409486000170",
                    StateRegistration = null,
                    CorporateName = "SOFTWARES ITABAIANA JR. EMPRESA JUNIOR DO DEPARTAMENTO DE SISTEMAS DE INFORMACAO DA UFS",
                    ResponsibleName = "Ericles dos Santos"
                },
            new Vacancy
            {
                Id = 2,
                FantasyName = "Titan",
                Email = "Titan@gmail.com",
                Cep = "49500001",
                Country = "Brasil",
                State = "SE",
                City = "Aracaju",
                District = "Bananeira",
                Street = "Belivaldo Chagas",
                HouseNumber = "6458",
                Complement = null,
                CellphoneNumber = "78 888888888",
                TelephoneNumber = null,
                Cnpj = "39409486000504",
                StateRegistration = null,
                CorporateName = "TITAN SOFTWARES ARACAJU",
                ResponsibleName = "Sinho senho"
            },
                new Vacancy
                {
                    Id = 3,
                    FantasyName = "Fabrica de Softwares",
                    Email = "fabricadesoftwares@gmail.com",
                    Cep = "24050363",
                    Country = "Brasil",
                    State = "SP",
                    City = "São Paulo",
                    District = "Centro",
                    Street = "Bloco A",
                    HouseNumber = "01",
                    Complement = null,
                    CellphoneNumber = "79 999999999",
                    TelephoneNumber = null,
                    Cnpj = "11456548978914",
                    StateRegistration = null,
                    CorporateName = "FABRICA DE SOFTWARES",
                    ResponsibleName = "Dosea"
                },
            };
    }
}
