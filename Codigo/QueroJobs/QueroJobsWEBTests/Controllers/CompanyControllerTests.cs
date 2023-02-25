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
public class CompanyControllerTests
{
    private static CompanyController companyController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        var mockService = new Mock<ICompanyService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new CompanyProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
                .Returns(GetTestCompanies());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetCompany());
        mockService.Setup(service => service.Edit(It.IsAny<Company>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Company>()))
            .Verifiable();

        companyController = new CompanyController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void IndexTest()
    {
        var result = companyController.Index().Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CompanyModel>));

        List<CompanyModel> list = (List<CompanyModel>)viewResult.ViewData.Model;
        Assert.AreEqual(3, list.Count);
    }

    [TestMethod()]
    public void DetailsTest()
    {
        // Act
        var result = companyController.Details(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CompanyModel));
        CompanyModel companyModel = (CompanyModel)viewResult.ViewData.Model;

        Assert.AreEqual("ItatechJr", companyModel.FantasyName);
        Assert.AreEqual("itatechjr@gmail.com", companyModel.Email);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        var result = companyController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void CreateTest_Valid()
    {
        // Act
        var result = companyController.Create(GetNewCompany()).Result;

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
        companyController.ModelState.AddModelError("FantasyName", "Campo requerido");

        // Act
        var result = companyController.Create(GetNewCompany()).Result;

        // Assert
        Assert.AreEqual(1, companyController.ModelState.ErrorCount);
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsNotNull(viewResult);
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        // Act
        var result = companyController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CompanyModel));
        CompanyModel companyModel = (CompanyModel)viewResult.ViewData.Model;

        Assert.AreEqual("ItatechJr", companyModel.FantasyName);
        Assert.AreEqual("itatechjr@gmail.com", companyModel.Email);
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        // Act
        var result = companyController.Edit(GetTargetCompanyModel().Id, GetTargetCompanyModel()).Result;

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
        var result = companyController.Delete(1).Result;

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
        var result = companyController.Delete(GetTargetCompanyModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    private CompanyModel GetNewCompany()
    {
        return new CompanyModel
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
            CellphoneNumber = "88 99714-7271",
            TelephoneNumber = null,
            Cnpj = "10409486000170",
            StateRegistration = null,
            CorporateName = "SOFTWARES ITABAIANA JR. EMPRESA JUNIOR DO DEPARTAMENTO DE SISTEMAS DE INFORMACAO DA UFS",
            ResponsibleName = "Ericles dos Santos"
        };

    }
    private async Task<Company> GetTargetCompany()
    {
        return new Company
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
            CellphoneNumber = "88 99714-7271",
            TelephoneNumber = null,
            Cnpj = "10409486000170",
            StateRegistration = null,
            CorporateName = "SOFTWARES ITABAIANA JR. EMPRESA JUNIOR DO DEPARTAMENTO DE SISTEMAS DE INFORMACAO DA UFS",
            ResponsibleName = "Ericles dos Santos"
        };
    }

    private CompanyModel GetTargetCompanyModel()
    {
        return new CompanyModel
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
            CellphoneNumber = "88 99714-7271",
            TelephoneNumber = null,
            Cnpj = "10409486000170",
            StateRegistration = null,
            CorporateName = "SOFTWARES ITABAIANA JR. EMPRESA JUNIOR DO DEPARTAMENTO DE SISTEMAS DE INFORMACAO DA UFS",
            ResponsibleName = "Ericles dos Santos"
        };
    }

    private async Task<IEnumerable<Company>> GetTestCompanies()
    {
        return new List<Company>
            {
                new Company
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
                    CellphoneNumber = "88 99714-7271",
                    TelephoneNumber = null,
                    Cnpj = "10409486000170",
                    StateRegistration = null,
                    CorporateName = "SOFTWARES ITABAIANA JR. EMPRESA JUNIOR DO DEPARTAMENTO DE SISTEMAS DE INFORMACAO DA UFS",
                    ResponsibleName = "Ericles dos Santos"
                },
            new Company
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
                CellphoneNumber = "18 98814-1327",
                TelephoneNumber = null,
                Cnpj = "39409486000504",
                StateRegistration = null,
                CorporateName = "TITAN SOFTWARES ARACAJU",
                ResponsibleName = "Sinho senho"
            },
                new Company
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
                    CellphoneNumber = "85 98707-6154",
                    TelephoneNumber = null,
                    Cnpj = "11456548978914",
                    StateRegistration = null,
                    CorporateName = "FABRICA DE SOFTWARES",
                    ResponsibleName = "Dosea"
                },
            };
    }
}