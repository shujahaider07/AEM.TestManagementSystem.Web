using AEM.TestManagementSystem.Repository.Models;
using AEM.TestManagementSystem.Repository.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AEM.AdminPortal.Web.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IStudentService studentService;
        private readonly DatabaseContext database;
        //private readonly IStudentService studentService;
        public AdminController(DatabaseContext database)
        {
            this.database = database;
            //this.studentService = studentService;
        }

        //public AdminController(IStudentService studentService)
        //{
        //    this.studentService = studentService;
        //}

        [HttpGet]

        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var data = await database.Students.ToListAsync();
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        //public IActionResult SignUp()
        //{
        //    return View("~/Views/Account/SignUp.cshtml");
        //}


        //[HttpPost]
        //public async Task<IActionResult> SignUp(RegistrationModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }
        //        model.Role = "admin";
        //        var result = await this.studentService.RegisterAsync(model);
        //        TempData["msg"] = result.Message;

        //        return RedirectToAction(nameof(SignUp));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //} 


        public IActionResult Login()
        {
            return View("~/Views/Login/LoginView.cshtml");
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(Students model)
        //{
        //    var chck = database.Students.Where(x=> x.FirstName == model.FirstName && x.Role == "admin");
            
        //    return View("~/Views/Home/Dashboard.cshtml");
        //}
    }
}
