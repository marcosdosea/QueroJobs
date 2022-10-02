using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;


namespace QueroJobsWEB.Controllers;

public class CompetenceController : Controller
{
    private readonly ICompetenceService _competenceService;
    private readonly IMapper _mapper;
    public CompetenceController(ICompetenceService competenceService, IMapper mapper)
    {
        _competenceService = competenceService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Return all companies in a ViewModel
    /// </summary>
    /// <returns>View(companies)</returns>
    public async Task<ActionResult> Index()
    {
        var competences = await _competenceService.GetAll();

        if (competences == null) return BadRequest();

        var competencesModel = _mapper.Map<List<CompetenceModel>>(competences);

        return View(competencesModel);
    }

    // GET: CompetenceController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CompetenceController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CompetenceModel competenceModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var competence = _mapper.Map<Competence>(competenceModel);
                await _competenceService.Create(competence);
            }
            catch
            {
                return View(competenceModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(competenceModel);

    }

    // GET: CompetenceController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var competence = await _competenceService.Get(id);

        var competenceModel = _mapper.Map<CompetenceModel>(competence);

        return View(competenceModel);
    }

    // POST: CompetenceController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CompetenceModel competenceModel)
    {
        if (id != competenceModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var competence = _mapper.Map<Competence>(competenceModel);
                await _competenceService.Edit(competence);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(competenceModel);

    }

    // GET: CompetenceController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var competence = await _competenceService.Get((int)id);

        if (competence == null) return NotFound();

        var competenceModel = _mapper.Map<CompetenceModel>(competence);

        return View(competenceModel);
    }

    // POST: CompetenceController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _competenceService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
