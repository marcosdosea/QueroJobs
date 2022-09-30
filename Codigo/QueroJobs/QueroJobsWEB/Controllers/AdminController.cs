using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ICompanyService _companyService;
        private readonly ICompetenceService _competenceService;
        private readonly ICourseService _courseService;
        private readonly IRoleService _roleService;
        //private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public AdminController(
            ICandidateService candidateService,
            ICompanyService companyService,
            ICompetenceService competenceService,
            ICourseService courseService,
            IRoleService roleService,
            //IVacancyService vacancyService,
            IMapper mapper
            )
        {
            _candidateService = candidateService;
            _companyService = companyService;
            _competenceService = competenceService;
            _courseService = courseService;
            _roleService = roleService;
            //_vacancyService = vacancyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var candidates = await _candidateService.GetAll();
            var companys = await _companyService.GetAll();
            var competences = await _competenceService.GetAll();
            var courses = await _courseService.GetAll();
            var roles = await _roleService.GetAll();
            //var vacancys = await _vacancyService.GetAll();

            AdminModel adminModel = new AdminModel { 
                candidate = candidates, 
                company = companys, 
                competence = competences, 
                course = courses, 
                role = roles,
                //vacancy = vacancys
            };

            return View(adminModel);
        }

        [HttpGet]
        public ActionResult CompanyDetails(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CandidateDetails(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CompetenceDetails(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CourseDetails(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult RoleDetails(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
}
