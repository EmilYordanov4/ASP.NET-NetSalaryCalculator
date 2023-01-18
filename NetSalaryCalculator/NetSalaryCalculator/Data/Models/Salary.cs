using System.ComponentModel.DataAnnotations;

namespace NetSalaryCalculator.Data.Models
{
    public class Salary
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		public decimal GrossSalary { get; set; }

		[Required]
		public decimal TotalIncomeTax { get; set; }

		[Required]
		public decimal HealthInsuranceTax { get; set; }

		[Required]
		public decimal NetSalary { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }
	}
}
