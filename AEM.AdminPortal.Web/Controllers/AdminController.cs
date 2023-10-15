using AEM.TestManagementSystem.Repository.Models.Domain;
using AEM.TestManagementSystem.Services.Interfaces;
using AEM.TestManagementSystem.Services.Models.DTO;
using AEM.TestManagementSystem.Web.Models.DTO;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AEM.AdminPortal.Web.Controllers
{
    public class AdminController : Controller
    {

        private readonly IStudentService studentService;
        private readonly DatabaseContext ctx;
        private readonly INotyfService _notyf;
        public AdminController(DatabaseContext database, IStudentService studentService, INotyfService _notyf)
        {
            this.ctx = database;
            this.studentService = studentService;
            this._notyf = _notyf;
        }


        public IActionResult SignUp()
        {
            return View("~/Views/Account/SignUp.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.Role = "user";
                var result = await this.studentService.RegisterAsync(model);
                TempData["msg"] = result.Message;

                return RedirectToAction(nameof(SignUp));
            }
            catch (Exception)
            {

                throw;
            }

        }


        public IActionResult Login()
        {
            return View("~/Views/Login/LoginView.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await studentService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetString("password", model.Password);
                _notyf.Success("Login Sucessfull");
                return RedirectToAction("Dashboard", "Home");

            }
            else
            {
                _notyf.Error("Login Failed");
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {

          

            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("password");
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }

    }
}
