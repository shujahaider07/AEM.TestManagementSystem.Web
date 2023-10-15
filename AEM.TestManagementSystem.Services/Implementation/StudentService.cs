using AEM.TestManagementSystem.Repository.Entities;
using AEM.TestManagementSystem.Repository.Interfaces;
using AEM.TestManagementSystem.Repository.Models;
using AEM.TestManagementSystem.Repository.Models.Domain;
using AEM.TestManagementSystem.Repository.Models.DTO;
using AEM.TestManagementSystem.Services.Interfaces;
using AEM.TestManagementSystem.Services.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace AEM.TestManagementSystem.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IStudentRepository studentRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DatabaseContext cotx;
        public StudentService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IStudentRepository studentRepository, DatabaseContext cotx)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.studentRepository = studentRepository;
            this.cotx = cotx;
            this.signInManager = signInManager;

        }
        public async Task<Status> RegisterAsync(RegistrationModelDTO model)
        {
            try
            {


                var status = new Status();
                var userExists = await userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                {
                    status.StatusCode = 0;
                    status.Message = "User already exist";
                    return status;
                }

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                Students s = new Students()
                {
                    Id = model.Id,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = model.Role,
                    Candidate_ID = model.Candidate_ID

                };

                cotx.Students.Add(s);


                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    status.StatusCode = 0;
                    status.Message = "User creation failed";
                    return status;
                }

                if (!await roleManager.RoleExistsAsync(model.Role))
                    await roleManager.CreateAsync(new IdentityRole(model.Role));


                if (await roleManager.RoleExistsAsync(model.Role))
                {
                    await userManager.AddToRoleAsync(user, model.Role);
                }

                status.StatusCode = 1;
                status.Message = "You have registered successfully";
                return status;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Status> LoginAsync(LoginModel model)
        {
            try
            {
                return await studentRepository.LoginAsync(model.Username, model.Password);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Students>> GetAllStudents()
        {
            try
            {
                var students = await studentRepository.GetAllStudents();

                // You can work with the 'students' list here if needed.

                return students; // Return the list
            }
            catch (Exception ex)
            {

                return new List<Students>(); // Or any other handling logic.
            }
        }

    }
}
