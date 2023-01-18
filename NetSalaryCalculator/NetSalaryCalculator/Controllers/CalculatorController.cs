using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetSalaryCalculator.Services.Calculators;

namespace NetSalaryCalculator.Controllers
{
    [Authorize]
	public class CalculatorController : Controller
	{
		private readonly ICalculatorService calculator;
		public CalculatorController(ICalculatorService calculator)
		{
			this.calculator = calculator;
		}

		public IActionResult Year() 
		{
			return View(calculator.GetYears());
		}

		public IActionResult Calculator(int annualBasisId, string userId)
		{
			return View(calculator.GetCalculatorInfo(annualBasisId, userId));
		}

		public IActionResult Calculate(decimal grossSalary, int annualBasisId, string userId, int salaryId)
		{
			if (grossSalary < 0)
			{
				this.ModelState.AddModelError(nameof(grossSalary), "The gross salary cannot be less than 0!"); 
			}

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Calculator", new { annualBasisId, userId });
            }

            calculator.CalculateNetSalary(grossSalary, annualBasisId, salaryId);

			return RedirectToAction("Calculator", new { annualBasisId, userId });
		}

		
	}
}
