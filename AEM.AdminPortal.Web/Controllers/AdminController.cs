using AEM.TestManagementSystem.Repository.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AEM.AdminPortal.Web.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IStudentService studentService;
        private readonly DatabaseContext database;

        public AdminController(DatabaseContext database)
        {
            this.database = database;
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

    }
}
