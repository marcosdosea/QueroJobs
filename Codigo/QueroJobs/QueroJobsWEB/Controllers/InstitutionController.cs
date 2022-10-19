using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers;

public class InstitutionController : Controller
{
    private readonly IInstitutionService _institutionService;
    private readonly IMapper _mapper;

    public InstitutionController(IInstitutionService institutionService, IMapper mapper)
    {
        _institutionService = institutionService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Return all institutions in a ViewModel
    /// </summary>
    /// <returns>(institutions)</returns>
    public async Task<ActionResult> Index()
    {
        var institutions = await _institutionService.GetAll();

        if (institutions == null) return BadRequest();

        var institutionsModel = _mapper.Map<List<InstitutionModel>>(institutions);

        return View(institutionsModel);
    }


    // GET: InstitutionController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: InstitutionController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(InstitutionModel institutionModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var institution = _mapper.Map<Institution>(institutionModel);
                await _institutionService.Create(institution);
            }
            catch
            {
                return View(institutionModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(institutionModel);

    }


    // GET: InstitutionController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var institution = await _institutionService.Get(id);

        var institutionModel = _mapper.Map<InstitutionModel>(institution);

        return View(institutionModel);
    }

    // POST: InstitutionController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, InstitutionModel institutionModel)
    {
        if (id != institutionModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var institution = _mapper.Map<Institution>(institutionModel);
                await _institutionService.Edit(institution);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(institutionModel);

    }


    // GET: InstitutionController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var institution = await _institutionService.Get((int)id);

        if (institution == null) return NotFound();

        var institutionModel = _mapper.Map<InstitutionModel>(institution);

        return View(institutionModel);
    }

    // POST: InstitutionController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _institutionService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
