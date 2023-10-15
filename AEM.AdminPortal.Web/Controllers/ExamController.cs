using AEM.TestManagementSystem.Repository.Entities;
using AEM.TestManagementSystem.Repository.Models.Domain;
using AEM.TestManagementSystem.Services.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AEM.AdminPortal.Web.Controllers
{
    public class ExamController : Controller
    {
        private readonly IStudentService studentService;
        private readonly DatabaseContext ctx;
        private readonly INotyfService _notyf;
        public ExamController(DatabaseContext database, IStudentService studentService, INotyfService _notyf)
        {
            this.ctx = database;
            this.studentService = studentService;
            this._notyf = _notyf;
        }
        [HttpGet]
        public IActionResult AddQuestionsForExam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestionsForExam(Exam ex)
        {
            ctx.Exam.Add(ex);
            ctx.SaveChanges();
            _notyf.Success("Question Added");

            return View(nameof(AddQuestionsForExam));
        }

    }
}
