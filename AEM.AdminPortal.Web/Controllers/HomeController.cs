using AEM.TestManagementSystem.Repository.Models.Domain;
using liteAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AEM.AdminPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext ctx;

        public HomeController(ILogger<HomeController> logger, DatabaseContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }
        
        [HttpGet]
        public IActionResult Dashboard()
        {
            var countStd = ctx.Students.Where(x => x.Role == "user").Count();
            var countadm = ctx.Students.Where(x => x.Role == "admin").Count();
            var CountCourses = ctx.Exam.Where(x => x.ExamID == x.ExamID).Count();
            ViewBag.AdminCount = countadm;
            ViewBag.ExamCount = CountCourses;
            ViewBag.StudentCount = countStd;

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Students objHis = HttpContext.Session.GetObjectFromJson<Students>("AuthenticatedUser");
            // IQueryable<Students> iqCandidate = await _stud.SearchCandidate(e => e.Sl_No.Equals(objHis.Sl_No));
            //Students objCandidate = iqCandidate.FirstOrDefault();
            //return View(objCandidate);
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}