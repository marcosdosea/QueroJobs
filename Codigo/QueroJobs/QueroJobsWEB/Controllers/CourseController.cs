using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;
using Services;

namespace QueroJobsWEB.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public CourseController(ICourseService courseService, IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Return all courses in a ViewModel
    /// </summary>
    /// <returns>(courses)</returns>
    public async Task<ActionResult> Index()
    {
        var courses = await _courseService.GetAll();

        if (courses == null) return BadRequest();

        var coursesModel = _mapper.Map<List<CourseModel>>(courses);

        return View(coursesModel);
    }


    // GET: CourseController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CourseController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CourseModel courseModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var course = _mapper.Map<Course>(courseModel);
                await _courseService.Create(course);
            }
            catch
            {
                return View(courseModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(courseModel);

    }


    // GET: CourseController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var course = await _courseService.Get(id);

        var courseModel = _mapper.Map<CourseModel>(course);

        return View(courseModel);
    }

    // POST: CourseController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CourseModel courseModel)
    {
        if (id != courseModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var course = _mapper.Map<Course>(courseModel);
                await _courseService.Edit(course);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(courseModel);

    }


    // GET: CourseController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var course = await _courseService.Get((int)id);

        if (course == null) return NotFound();

        var courseModel = _mapper.Map<CourseModel>(course);

        return View(courseModel);
    }

    // POST: CourseController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _courseService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}