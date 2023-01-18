using System;
using System.ComponentModel.DataAnnotations;

namespace NetSalaryCalculator.Models.YearlyBasis
{
	using static Data.DataConstants.AnnualBasis;

	public class AddAnnualBasisFormModel
    {
        [Required]
        [Range(MinYear, MaxYear, ErrorMessage = "Invalid year ! It should be between {1} and {2} !")]
        public int Year { get; set; }

        [Required]
        [Range(MinValue, MaxThreshold, ErrorMessage = "Invalid threshold ! It should be between {1} and {2} !")]
        public decimal MinimumThreshold { get; set; }

        [Required]
        [Range(MinValue, MaxPercentage, ErrorMessage = "Invalid percentage ! It should be between {1} and {2} !")]
        public double TotalIncomePercentage { get; set; }

        [Required]
        [Range(MinValue, MaxPercentage, ErrorMessage = "Invalid percentage ! It should be between {1} and {2} !")]
        public double HealthInsurancePercentage { get; set; }

        [Required]
        [Range(MinValue, MaxThreshold, ErrorMessage = "Invalid threshold ! It should be between {1} and {2} !")]
        public decimal MaximumThreshold { get; set; }
    }
}
