using NetSalaryCalculator.Data;
using NetSalaryCalculator.Services.Calculators.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetSalaryCalculator.Services.Calculators
{
    public class CalculatorService : ICalculatorService
    {
        private readonly NetSalaryCalculatorDbContext data;

        public CalculatorService(NetSalaryCalculatorDbContext data)
        {
            this.data = data;
        }

        public void CalculateNetSalary(decimal grossSalary, int annualBasisId, int salaryId)
        {
            var annualBasis = data.AnnualBases.FirstOrDefault(x => x.Id == annualBasisId);

            var salary = data.Salaries.FirstOrDefault(x => x.Id == salaryId);

            salary.GrossSalary = grossSalary;
            if (grossSalary > annualBasis.MinimumThreshold)
            {
                grossSalary -= annualBasis.MinimumThreshold;
                salary.TotalIncomeTax = CalculateTotalIncomeTax(grossSalary, annualBasis.TotalIncomePercentage);
                if (salary.GrossSalary > annualBasis.MaximumThreshold)
                {
                    salary.HealthInsuranceTax = CalculateHealthInsuranceTax(annualBasis.MaximumThreshold - annualBasis.MinimumThreshold, annualBasis.HealthInsurancePercentage);
                }
                else
                {
                    salary.HealthInsuranceTax = CalculateHealthInsuranceTax(grossSalary, annualBasis.HealthInsurancePercentage);
                }
                salary.NetSalary = salary.GrossSalary - (salary.TotalIncomeTax + salary.HealthInsuranceTax);
            }
            else
            {
                salary.NetSalary = grossSalary;
                salary.TotalIncomeTax = 0;
                salary.HealthInsuranceTax = 0;
            }

            data.SaveChanges();
        }

        private static decimal CalculateTotalIncomeTax(decimal grossSalary, double totalIncomePercentage)
        {
            return grossSalary * (decimal)(totalIncomePercentage / 100);
        }

        private static decimal CalculateHealthInsuranceTax(decimal grossSalary, double healthInsurancePercentage)
        {
            return grossSalary * (decimal)(healthInsurancePercentage / 100);
        }

        public CalculatorServiceModel GetCalculatorInfo(int annualBasisId, string userId)
        {
            var annualBasis = data.AnnualBases.FirstOrDefault(x => x.Id == annualBasisId);

            var salary = data.Salaries.FirstOrDefault(x => x.UserId == userId);

            return new CalculatorServiceModel
            {
                UserId = userId,
                AnnualBasisId = annualBasis.Id,
                SalaryId = salary.Id,
                GrossSalary = salary.GrossSalary,
                NetSalary = salary.NetSalary,
                HealthInsuranceTax = salary.HealthInsuranceTax,
                TotalIncomeTax = salary.TotalIncomeTax,
                HealthInsurancePercentage = annualBasis.HealthInsurancePercentage,
                TotalIncomePercentage = annualBasis.TotalIncomePercentage,
                MaximumThreshold = annualBasis.MaximumThreshold,
                MinimumThreshold = annualBasis.MinimumThreshold,
                Year = annualBasis.Year,
            };
        }

        public List<YearServiceModel> GetYears()
        {
            return data
                .AnnualBases
                .Select(a => new YearServiceModel
                {
                    Id = a.Id,
                    Year = a.Year,
                })
                .OrderByDescending(a => a.Year)
                .ToList();
        }
    }
}
