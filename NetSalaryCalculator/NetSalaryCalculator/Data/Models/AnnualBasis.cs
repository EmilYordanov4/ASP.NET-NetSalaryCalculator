using System.ComponentModel.DataAnnotations;

namespace NetSalaryCalculator.Data.Models
{
    public class AnnualBasis
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal MinimumThreshold { get; set; }

        [Required]
        public double TotalIncomePercentage { get; set; }

        [Required]
        public double HealthInsurancePercentage { get; set; }

        [Required]
        public decimal MaximumThreshold { get; set; }

    }
}
