using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NetSalaryCalculator.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int SalaryId { get; set; }

        public Salary Salary { get; set; }
    }
}
