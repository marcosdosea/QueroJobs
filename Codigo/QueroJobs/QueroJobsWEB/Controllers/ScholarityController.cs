using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers;

public class ScholarityController : Controller
{
    private readonly IScholarityService _scholarityService;
    private readonly IMapper _mapper;

    public ScholarityController(IScholarityService scholarityService, IMapper mapper)
    {
        _scholarityService = scholarityService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Return all companies in a ViewModel
    /// </summary>
    /// <returns>View(companies)</returns>
    public async Task<ActionResult> Index()
    {
        var scholarities = await _scholarityService.GetAll();

        if (scholarities == null) return BadRequest();

        var scholaritiesModel = _mapper.Map<List<ScholarityModel>>(scholarities);

        return View(scholaritiesModel);
    }

    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var scholarity = await _scholarityService.Get(id);

        if (scholarity == null) return BadRequest();

        var scholarityModel = _mapper.Map<ScholarityModel>(scholarity);

        return View(scholarityModel);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ScholarityModel scholarityModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var scholarity = _mapper.Map<Scholarity>(scholarityModel);
                await _scholarityService.Create(scholarity);
            }
            catch
            {
                return View(scholarityModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(scholarityModel);

    }

    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var scholarity = await _scholarityService.Get(id);

        var scholarityModel = _mapper.Map<ScholarityModel>(scholarity);

        return View(scholarityModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, ScholarityModel scholarityModel)
    {
        if (id != scholarityModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var scholarity = _mapper.Map<Scholarity>(scholarityModel);
                await _scholarityService.Edit(scholarity);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(scholarityModel);

    }

    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var scholarity = await _scholarityService.Get((int)id);

        if (scholarity == null) return NotFound();

        var scholarityModel = _mapper.Map<ScholarityModel>(scholarity);

        return View(scholarityModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _scholarityService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
