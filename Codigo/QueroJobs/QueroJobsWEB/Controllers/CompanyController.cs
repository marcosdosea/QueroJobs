using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace QueroJobsWEB.Controllers;

public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    /// <summary>
    /// Return all companies in a ViewModel
    /// </summary>
    /// <returns>View(companies)</returns>
    public async Task<ActionResult> Index()
    {
        var companies = await _companyService.GetAll();

        if (companies == null) return BadRequest();

        return View(companies);
    }

    // GET: CompanyController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var company = await _companyService.Get(id);

        if (company == null) return BadRequest();

        return View(company);
    }

    // GET: CompanyController/Create
    public  ActionResult Create()
    {
        return View();
    }

    // POST: CompanyController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Company company)
    {

        if (ModelState.IsValid)
        {
            try
            {
                await _companyService.Create(company);
            }
            catch
            {
                return View(company);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(company);

    }

    // GET: CompanyController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var company = await _companyService.Get(id);
        return View(company);
    }

    // POST: CompanyController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, Company company )
    {
        if (id != company.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _companyService.Edit(company);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(company);

    }

    // GET: CompanyController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var company = await _companyService.Get((int)id);

        if (company == null) return NotFound();

        return View(company);
    }

    // POST: CompanyController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _companyService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
