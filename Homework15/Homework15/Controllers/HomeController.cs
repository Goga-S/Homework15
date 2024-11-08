using Homework15.Abstractions;
using Homework15.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("/Reservation", Name = "Reservation")]
        public ActionResult Reservation()
        {
            
            return View();
        }

        [HttpPost]
        [Route("/Reservation", Name = "Reservation")]
        public ActionResult Reservation(Patient patient)
        {
           
                IFileOperations operations = new JsonFile();

                
            if ( patient.VisitTime.Hour < 10 || patient.VisitTime.Hour > 19)
            {
                return View("customErr");
            } else
            {
                operations.saveJson(patient);
                return View();
            }

            
        }

        [HttpGet]
        [Route("/Records", Name = "Records")]
        public ActionResult Records() 
        {
            IFileOperations records = new JsonFile();
            var recs = records.showJson();
            return Json(recs); 
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
