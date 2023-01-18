namespace NetSalaryCalculator.Services.Calculators.Models
{
    public class CalculatorServiceModel
	{
        public string UserId { get; set; }

        public int AnnualBasisId { get; set; }

        public int SalaryId { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal TotalIncomeTax { get; set; }

        public decimal HealthInsuranceTax { get; set; }

        public decimal NetSalary { get; set; }

        public int Year { get; set; }

        public decimal MinimumThreshold { get; set; }

        public double TotalIncomePercentage { get; set; }

        public double HealthInsurancePercentage { get; set; }

        public decimal MaximumThreshold { get; set; }
    }
}
