using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;


namespace QueroJobsWEB.Controllers;

public class RoleController : Controller
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;
    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Return all roles in a ViewModel
    /// </summary>
    /// <returns>View(roles)</returns>
    public async Task<ActionResult> Index()
    {
        var roles = await _roleService.GetAll();

        if (roles == null) return BadRequest();

        var rolesModel = _mapper.Map<List<RoleModel>>(roles);

        return View(rolesModel);
    }

    // GET: RoleController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var role = await _roleService.Get(id);

        if (role == null) return BadRequest();

        var roleModel = _mapper.Map<RoleModel>(role);

        return View(roleModel);
    }

    // GET: RoleController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: RoleController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(RoleModel roleModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var role = _mapper.Map<Role>(roleModel);
                await _roleService.Create(role);
            }
            catch
            {
                return View(roleModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(roleModel);

    }

    // GET: RoleController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var role = await _roleService.Get(id);

        var roleModel = _mapper.Map<RoleModel>(role);

        return View(roleModel);
    }

    // POST: RoleController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, RoleModel roleModel)
    {
        if (id != roleModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var role = _mapper.Map<Role>(roleModel);
                await _roleService.Edit(role);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(roleModel);

    }

    // GET: RoleController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var role = await _roleService.Get((int)id);

        if (role == null) return NotFound();

        var roleModel = _mapper.Map<RoleModel>(role);

        return View(roleModel);
    }

    // POST: RoleController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _roleService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
