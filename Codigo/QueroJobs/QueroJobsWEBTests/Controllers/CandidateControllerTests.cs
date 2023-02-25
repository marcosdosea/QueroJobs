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
public class CandidateControllerTests
{
    private static CandidateController candidateController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        var mockService = new Mock<ICandidateService>();

        IMapper mapper = new MapperConfiguration(config => config.AddProfile(new CandidateProfile())).CreateMapper();

        mockService.Setup(service => service.GetAll())
                .Returns(GetTestCandidaties());
        mockService.Setup(service => service.Get(1))
            .Returns(GetTargetCandidate());
        mockService.Setup(service => service.Edit(It.IsAny<Candidate>()))
            .Verifiable();
        mockService.Setup(service => service.Create(It.IsAny<Candidate>()))
            .Verifiable();

        candidateController = new CandidateController(mockService.Object, mapper);
    }

    [TestMethod()]
    public void IndexTest()
    {
        var result = candidateController.Index().Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CandidateModel>));

        List<CandidateModel> list = (List<CandidateModel>)viewResult.ViewData.Model;
        Assert.AreEqual(2, list.Count);
    }

    [TestMethod()]
    public void DetailsTest()
    {
        // Act
        var result = candidateController.Details(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CandidateModel));
        CandidateModel candidateModel = (CandidateModel)viewResult.ViewData.Model;

        Assert.AreEqual("Maria Milena de Oliveira Souza", candidateModel.Name);
        Assert.AreEqual("milena@gmail.com", candidateModel.Email);
    }

    [TestMethod()]
    public void CreateTest()
    {
        // Act
        var result = candidateController.Create();
        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod()]
    public void CreateTest_Valid()
    {
        // Act
        var result = candidateController.Create(GetNewCandidate()).Result;

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
        candidateController.ModelState.AddModelError("Name", "Campo requerido");

        // Act
        var result = candidateController.Create(GetNewCandidate()).Result;

        // Assert
        Assert.AreEqual(1, candidateController.ModelState.ErrorCount);
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;
        Assert.IsNotNull(viewResult);
    }

    [TestMethod()]
    public void EditTest_Get()
    {
        // Act
        var result = candidateController.Edit(1).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        ViewResult viewResult = (ViewResult)result;

        Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CandidateModel));
        CandidateModel candidateModel = (CandidateModel)viewResult.ViewData.Model;

        Assert.AreEqual("Maria Milena de Oliveira Souza", candidateModel.Name);
        Assert.AreEqual("milena@gmail.com", candidateModel.Email);
    }

    [TestMethod()]
    public void EditTest_Post()
    {
        // Act
        var result = candidateController.Edit(GetTargetCandidateModel().Id, GetTargetCandidateModel()).Result;

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
        var result = candidateController.Delete(1).Result;

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
        var result = candidateController.Delete(GetTargetCandidateModel().Id).Result;

        // Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
        Assert.IsNull(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    private CandidateModel GetTargetCandidateModel()
    {
        return new CandidateModel
        {
            Id = 1,
            Name = "Maria Milena de Oliveira Souza",
            Email = "milena@gmail.com",
            Cep = "49550-000",
            Country = "Brasil",
            State = "SE",
            City = "Carira",
            District = "Centro",
            Street = "Rua Silvino Braz da Silva",
            HouseNumber = "233",
            Complement = "Casa",
            CellphoneNumber = "79981341962",
            TelephoneNumber = "79981341962",
            BirthDate = new DateTime(1998, 9, 6),
            Gender = "F",
            Cpf = "96677758010",
            Deficiency = "Não se aplica",
            SalaryExpectation = 1000,
            EmploymentStatus = "FREELANCE",
            ActualRole = "Desenvolvedor de Softwares",
            Description = "Algo sobre mim"
        };
    }

    private CandidateModel GetNewCandidate()
    {
        return new CandidateModel
        {
            Id = 1,
            Name = "Maria Milena de Oliveira Souza",
            Email = "milena@gmail.com",
            Cep = "49550-000",
            Country = "Brasil",
            State = "SE",
            City = "Carira",
            District = "Centro",
            Street = "Rua Silvino Braz da Silva",
            HouseNumber = "233",
            Complement = "Casa",
            CellphoneNumber = "79981341962",
            TelephoneNumber = "79981341962",
            BirthDate = new DateTime(1998, 9, 6),
            Gender = "F",
            Cpf = "96677758010",
            Deficiency = "Não se aplica",
            SalaryExpectation = 1000,
            EmploymentStatus = "FREELANCE",
            ActualRole = "Desenvolvedor de Softwares",
            Description = "Algo sobre mim"
        };
    }

    private async Task<Candidate> GetTargetCandidate()
    {
        return new Candidate
        {
            Id = 1,
            Name = "Maria Milena de Oliveira Souza",
            Email = "milena@gmail.com",
            Cep = "49550-000",
            Country = "Brasil",
            State = "SE",
            City = "Carira",
            District = "Centro",
            Street = "Rua Silvino Braz da Silva",
            HouseNumber = "233",
            Complement = "Casa",
            CellphoneNumber = "79981341962",
            TelephoneNumber = "79981341962",
            BirthDate = new DateTime(1998, 9, 6),
            Gender = "F",
            Cpf = "96677758010",
            Deficiency = "Não se aplica",
            SalaryExpectation = 1000,
            EmploymentStatus = "FREELANCE",
            ActualRole = "Desenvolvedor de Softwares",
            Description = "Algo sobre mim"
        };
    }

    private async Task<IEnumerable<Candidate>> GetTestCandidaties()
    {
        return new List<Candidate>
        {
            new Candidate
            {
                Id = 1,
                Name = "Maria Milena de Oliveira Souza",
                Email = "milena@gmail.com",
                Cep = "49550-000",
                Country = "Brasil",
                State = "SE",
                City = "Carira",
                District = "Centro",
                Street = "Rua Silvino Braz da Silva",
                HouseNumber = "233",
                Complement = "Casa",
                CellphoneNumber = "79981341962",
                TelephoneNumber = "79981341962",
                BirthDate = new DateTime(1998, 9, 6),
                Gender = "F",
                Cpf = "96677758010",
                Deficiency = "Não se aplica",
                SalaryExpectation = 1000,
                EmploymentStatus = "FREELANCE",
                ActualRole = "Desenvolvedor de Softwares",
                Description = "Algo sobre mim"
            },
            new Candidate
            {
                Id = 2,
                Name = "Ericles Dos Santos",
                Email = "RatoDeAcademia@gmail.com",
                Cep = "49550-000",
                Country = "USA",
                State = "SE",
                City = "Itabaiana",
                District = "Centro",
                Street = "Rua Montero",
                HouseNumber = "233",
                Complement = "Casa",
                CellphoneNumber = "79912345678",
                TelephoneNumber = "79912345678",
                BirthDate = new DateTime(1998, 12, 25),
                Gender = "M",
                Cpf = "66755209031",
                Deficiency = "Não se aplica",
                SalaryExpectation = 4000,
                EmploymentStatus = "FREELANCE",
                ActualRole = "DBA",
                Description = "Algo sobre mim"
            }
        };
    }
}
