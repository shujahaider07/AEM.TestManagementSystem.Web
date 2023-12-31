﻿using AEM.TestManagementSystem.Repository.Entities;
using AEM.TestManagementSystem.Repository.Models;
using AEM.TestManagementSystem.Repository.Models.DTO;

namespace AEM.TestManagementSystem.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<Status> LoginAsync(string username, string password);
        Task<List<Students>> GetAllStudents();
        Task<Students> GetStudentById(int id);
    }
}
 