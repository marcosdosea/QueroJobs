using AutoMapper;
using Core;
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
        private readonly IInstitutionService _institutionService;
        private readonly IRoleService _roleService;
        //private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public AdminController(
            ICandidateService candidateService,
            ICompanyService companyService,
            ICompetenceService competenceService,
            ICourseService courseService,
            IInstitutionService institutionService,
            IRoleService roleService,
            //IVacancyService vacancyService,
            IMapper mapper
            )
        {
            _candidateService = candidateService;
            _companyService = companyService;
            _competenceService = competenceService;
            _courseService = courseService;
            _institutionService = institutionService;
            _roleService = roleService;
            //_vacancyService = vacancyService;
            _mapper = mapper;
        }

        /*
        public AdminController(
            IInstitutionService institutionService,
            IMapper mapper
        )
        {
            _institutionService = institutionService;
            _mapper = mapper;
        }*/


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var candidates = await _candidateService.GetAll();
            var companys = await _companyService.GetAll();
            var competences = await _competenceService.GetAll();
            var courses = await _courseService.GetAll();
            var institutions = await _institutionService.GetAll();
            var roles = await _roleService.GetAll();
            //var vacancys = await _vacancyService.GetAll();

            AdminModel adminModel = new AdminModel
            {
                candidate = candidates,
                company = companys,
                competence = competences,
                course = courses,
                institution = institutions,
                role = roles,
                //vacancy = vacancys
            };

            return View(adminModel);
        }

        public async Task<ActionResult> CompanyDetails(int id)
        {
            var company = await _companyService.Get(id);

            if (company == null) return BadRequest();

            var companyModel = _mapper.Map<CompanyModel>(company);

            return View(companyModel);
        }

        // GET: CompanyController/Create
        public ActionResult CompanyCreate()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompanyCreate(CompanyModel companyModel)
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
        public async Task<ActionResult> CompanyEdit(int id)
        {
            var company = await _companyService.Get(id);

            var companyModel = _mapper.Map<CompanyModel>(company);

            return View(companyModel);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompanyEdit(int id, CompanyModel companyModel)
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
        public async Task<ActionResult> CompanyDelete(int? id)
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
        public async Task<ActionResult> CompanyDelete(int id)
        {
            await _companyService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> CandidateDetails(int id)
        {
            var candidate = await _candidateService.Get(id);

            if (candidate == null) return BadRequest();

            var candidateModel = _mapper.Map<CandidateModel>(candidate);

            return View(candidateModel);
        }

        [HttpGet]
        public async Task<ActionResult> CandidateEdit(int id)
        {
            var candidate = await _candidateService.Get(id);

            var candidateModel = _mapper.Map<CandidateModel>(candidate);

            return View(candidateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CandidateEdit(int id, CandidateModel candidateModel)
        {
            if (id != candidateModel.Id) return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    var candidate = _mapper.Map<Candidate>(candidateModel);
                    await _candidateService.Edit(candidate);
                }
                catch
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(candidateModel);

        }

        [HttpGet]
        public async Task<ActionResult> CandidateDelete(int? id)
        {
            if (id == null) return BadRequest();

            var candidate = await _candidateService.Get((int)id);

            if (candidate == null) return NotFound();

            var candidateModel = _mapper.Map<CandidateModel>(candidate);

            return View(candidateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CandidateDelete(int id)
        {
            await _candidateService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult CompetenceCreate()
        {
            return View();
        }

        // POST: CompetenceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompetenceCreate(CompetenceModel competenceModel)
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
        public async Task<ActionResult> CompetenceEdit(int id)
        {
            var competence = await _competenceService.Get(id);

            var competenceModel = _mapper.Map<CompetenceModel>(competence);

            return View(competenceModel);
        }

        // POST: CompetenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompetenceEdit(int id, CompetenceModel competenceModel)
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
        public async Task<ActionResult> CompetenceDelete(int? id)
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
        public async Task<ActionResult> CompetenceDelete(int id)
        {
            await _competenceService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult CourseCreate()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CourseCreate(CourseModel courseModel)
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
        public async Task<ActionResult> CourseEdit(int id)
        {
            var course = await _courseService.Get(id);

            var courseModel = _mapper.Map<CourseModel>(course);

            return View(courseModel);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CourseEdit(int id, CourseModel courseModel)
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
        public async Task<ActionResult> CourseDelete(int? id)
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
        public async Task<ActionResult> CourseDelete(int id)
        {
            await _courseService.Delete(id);

            return RedirectToAction(nameof(Index));
        }



        // GET: InstitutionController/Create
        public ActionResult InstitutionCreate()
        {
            return View();
        }

        // POST: InstitutionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InstitutionCreate(InstitutionModel institutionModel)
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
        public async Task<ActionResult> InstitutionEdit(int id)
        {
            var institution = await _institutionService.Get(id);

            var institutionModel = _mapper.Map<InstitutionModel>(institution);

            return View(institutionModel);
        }

        // POST: InstitutionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InstitutionEdit(int id, InstitutionModel institutionModel)
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
        public async Task<ActionResult> InstitutionDelete(int? id)
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
        public async Task<ActionResult> InstitutionDelete(int id)
        {
            await _institutionService.Delete(id);

            return RedirectToAction(nameof(Index));
        }






        public ActionResult RoleCreate()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RoleCreate(RoleModel roleModel)
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
        public async Task<ActionResult> RoleEdit(int id)
        {
            var role = await _roleService.Get(id);

            var roleModel = _mapper.Map<RoleModel>(role);

            return View(roleModel);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RoleEdit(int id, RoleModel roleModel)
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
        public async Task<ActionResult> RoleDelete(int? id)
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
        public async Task<ActionResult> RoleDelete(int id)
        {
            await _roleService.Delete(id);

            return RedirectToAction(nameof(Index));
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
