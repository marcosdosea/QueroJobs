using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueroJobsWEB.Models;
using static QueroJobsWEB.Models.FormModel;

namespace QueroJobsWEB.Controllers;

public class CandidateController : Controller
{
    private readonly ICandidateService _candidateService;
    private readonly IMapper _mapper;
    public CandidateController(ICandidateService candidateService, IMapper mapper)
    {
        _candidateService = candidateService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Return all candidate in a ViewModel
    /// </summary>
    /// <returns>View(companies)</returns>
    public async Task<ActionResult> Index()
    {
        var canditates = await _candidateService.GetAll();

        if (canditates == null) return BadRequest();

        var candidatesModel = _mapper.Map<List<CandidateModel>>(canditates);

        return View(candidatesModel);
    }

    // GET: CompanyController/Details/{id}
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var candidate = await _candidateService.Get(id);

        if (candidate == null) return BadRequest();

        /*CandidateDTO candidateDTO = new CandidateDTO
        {
            Id = id,
            ActualRole = candidate.ActualRole,
            BirthDate = candidate.BirthDate,
            CellphoneNumber = candidate.CellphoneNumber,
            Cep = candidate.Cep,
            City = candidate.City,
            Country = candidate.Country,
            Complement = candidate.Complement,
            Deficiency = candidate.Deficiency,
            Description = candidate.Description,
            District = candidate.District,
            Email = candidate.Email,
            EmploymentStatus = candidate.EmploymentStatus,
            Gender = candidate.Gender,
            HouseNumber = candidate.HouseNumber,
            Name = candidate.Name,
            SalaryExpectation = candidate.SalaryExpectation,
            State = candidate.State,
            Street = candidate.Street,
            TelephoneNumber = candidate.TelephoneNumber,
        };*/

        var candidateModel = _mapper.Map<CandidateModel>(candidate);

        return View(candidateModel);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CandidateModel candidateModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var candidate = _mapper.Map<Candidate>(candidateModel);
                await _candidateService.Create(candidate);
            }
            catch
            {
                return View(candidateModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(candidateModel);

    }

    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var candidate = await _candidateService.Get(id);

        var candidateModel = _mapper.Map<CandidateModel>(candidate);

        return View(candidateModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CandidateModel candidateModel)
    {
        if (id != candidateModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var candidate = _mapper.Map<Candidate>(candidateModel);
                await _candidateService.Edit(candidate);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(candidateModel);

    }

    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var candidate = await _candidateService.Get((int)id);

        if (candidate == null) return NotFound();

        var candidateModel = _mapper.Map<CandidateModel>(candidate);

        return View(candidateModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _candidateService.Delete(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("forms")]
    public async Task<ActionResult> Forms(int idCandidate)
    {
        var candidate = await _candidateService.Get(idCandidate);

        if (candidate == null) return NotFound();



        FormModel form = new FormModel
        {
            CandidateId = candidate.Id,
            EmploymentStatus = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem {
                        Text = "Integral",
                        Value = "NONE"
                    },
                    new SelectListItem {
                        Text = "Integral",
                        Value = "FULL-TIME"
                    },
                    new SelectListItem {
                        Text = "Meio Período",
                        Value = "PART-TIME"
                    },
                    new SelectListItem {
                        Text = "Autônomo",
                        Value = "SELF-EMPLOYED"
                    },
                    new SelectListItem {
                        Text = "Freelance",
                        Value = "FREELANCE"
                    },
                    new SelectListItem {
                        Text = "Contrato",
                        Value = "CONTRACT"
                    },
                    new SelectListItem {
                        Text = "Contrato Indireto",
                        Value = "INDIRECT-CONTRACT"
                    },
                    new SelectListItem {
                        Text = "Estágio",
                        Value = "INTERNSHIP"
                    },
                    new SelectListItem {
                        Text = "Aprendiz",
                        Value = "APPRENTICESHIP"
                    },
                    new SelectListItem {
                        Text = "Líder",
                        Value = "LEADERSHIP-PROGRAM"
                    }
                }
            ),
            OccupationAreaNames = candidate.Candidateoccupationareas.Select(c => c.IdOccupationAreaNavigation.OccupationAreaName),
            Description = candidate.Description,
            Formations = new FormationModel
            {
                Course = new SelectList(
                    new List<SelectListItem>{
                        candidate.Formations.Select(c => new SelectListItem{
                            Text = c.IdCourseNavigation.CourseName,
                            Value = c.IdCourseNavigation.CourseName
                            }
                        ).ToList()
                    }
                    ),

            }

        };

        return View(form);
    }

}
