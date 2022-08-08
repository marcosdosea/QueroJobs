using Microsoft.AspNetCore.Mvc;

namespace QueroJobs.Controllers
{
    public class FuncionarioCrudController : Controller
    {
        [HttpGet]
        public ActionResult Formulario()
        {
            return View();
        }

    }
}
