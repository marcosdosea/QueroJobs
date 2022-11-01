using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers;

public class VacancyController : Controller
{
    private readonly IVacancyService _vacancyService;
    private readonly IMapper _mapper;

    public VacancyController(IVacancyService vacancyService, IMapper mapper)
    {
        _vacancyService = vacancyService;
        _mapper = mapper;
    }


    [HttpGet]

    public async Task<ActionResult> Index()
    {
        var vacancies = await _vacancyService.GetAll();

        if (vacancies == null) return BadRequest();

        var vacanciesModel = _mapper.Map<List<VacancyModel>>(vacancies);

        return View(vacanciesModel);
    }

    // GET: VacancyController/Details/{id}
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var vacancy = await _vacancyService.Get(id);

        if (vacancy == null) return BadRequest();

        var vacancyModel = _mapper.Map<VacancyModel>(vacancy);

        return View(vacancyModel);
    }


    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(VacancyModel vacancyModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var vacancy = _mapper.Map<Vacancy>(vacancyModel);
                await _vacancyService.Create(vacancy);
            }
            catch
            {
                return View(vacancyModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(vacancyModel);

    }


    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var vacancy = await _vacancyService.Get(id);

        var vacancyModel = _mapper.Map<VacancyModel>(vacancy);

        return View(vacancyModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, VacancyModel vacancyModel)
    {
        if (id != vacancyModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var vacancy = _mapper.Map<Vacancy>(vacancyModel);
                await _vacancyService.Edit(vacancy);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(vacancyModel);

    }

    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var vacancy = await _vacancyService.Get((int)id);

        if (vacancy == null) return NotFound();

        var vacancyModel = _mapper.Map<VacancyModel>(vacancy);

        return View(vacancyModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _vacancyService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
