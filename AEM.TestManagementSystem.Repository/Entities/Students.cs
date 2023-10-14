using Quiz_Application.Services.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEM.TestManagementSystem.Repository.Entities
{
    public class Students : BaseEntity
    {

        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Candidate_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
