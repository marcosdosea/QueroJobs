using Microsoft.AspNetCore.Mvc;
using QueroJobs.Models;
using System.Diagnostics;

namespace QueroJobs.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: HomeController
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("fun")]
        public ActionResult FuncionarioCrud() { 
            return View(); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
