using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers;

[Authorize(Roles = "Empresa")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;
    public CompanyController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
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

        var companiesModel = _mapper.Map<List<CompanyModel>>(companies);

        return View(companiesModel);
    }

    // GET: CompanyController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var company = await _companyService.Get(id);

        if (company == null) return BadRequest();

        var companyModel = _mapper.Map<CompanyModel>(company);

        return View(companyModel);
    }

    // GET: CompanyController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CompanyController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CompanyModel companyModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var company = _mapper.Map<Company>(companyModel);
                await _companyService.Create(company);
            }
            catch
            {
                return View(companyModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(companyModel);

    }

    // GET: CompanyController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var company = await _companyService.Get(id);

        var companyModel = _mapper.Map<CompanyModel>(company);

        return View(companyModel);
    }

    // POST: CompanyController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CompanyModel companyModel)
    {
        if (id != companyModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var company = _mapper.Map<Company>(companyModel);
                await _companyService.Edit(company);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(companyModel);

    }

    // GET: CompanyController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var company = await _companyService.Get((int)id);

        if (company == null) return NotFound();

        var companyModel = _mapper.Map<CompanyModel>(company);

        return View(companyModel);
    }

    // POST: CompanyController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _companyService.Delete(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginCompanyModel loginCompanyModel)
    {

        // vai ter autenticação aqui

        return View(loginCompanyModel);
    }
}
