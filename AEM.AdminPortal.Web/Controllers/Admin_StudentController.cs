using AEM.TestManagementSystem.Repository.Models.Domain;
using AEM.TestManagementSystem.Services.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AEM.AdminPortal.Web.Controllers
{
    public class Admin_StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly DatabaseContext ctx;
        private readonly INotyfService _notyf;
        public Admin_StudentController(DatabaseContext database, IStudentService studentService, INotyfService _notyf)
        {
            this.ctx = database;
            this.studentService = studentService;
            this._notyf = _notyf;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("~/Views/Login/LoginView.cshtml");
            }

            try
            {
                var data = await studentService.GetAllStudents();
                return View(data);
                
            }
            catch (Exception ex)
            {
                
            }

            // You can return a default view or redirect to another page if no exception occurs.
            return View("GetAllStudents"); // Redirect to the "Index" action of the "Home" controller.
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
