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

    /*[HttpGet]*/
    /// <summary>
    /// Return all companies in a ViewModel
    /// </summary>
    /// <returns></returns>
    public async Task<ActionResult> Index()
    {
        var companies = await _companyService.GetAll();

        if (companies == null) return BadRequest();

        return View(companies);
    }

    // GET: CompanyController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var company = await _companyService.Get(id);

        if (company == null) return BadRequest();

        return View(company);
    }

    // GET: CompanyController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CompanyController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CompanyController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CompanyController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CompanyController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CompanyController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
