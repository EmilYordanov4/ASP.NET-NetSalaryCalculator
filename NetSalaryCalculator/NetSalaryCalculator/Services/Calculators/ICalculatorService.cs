using NetSalaryCalculator.Services.Calculators.Models;
using System.Collections.Generic;

namespace NetSalaryCalculator.Services.Calculators
{
    public interface ICalculatorService
	{
		List<YearServiceModel> GetYears();

		CalculatorServiceModel GetCalculatorInfo(int yearId, string userId);

		void CalculateNetSalary(decimal grossSalary, int annualBasisId, int salaryId);
	}
}
