using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetSalaryCalculator.Models.YearlyBasis;
using NetSalaryCalculator.Services.AnnualBases;

namespace NetSalaryCalculator.Controllers
{
    [Authorize]
    public class AnnualBasisController : Controller
    {
        private readonly IAnnualBasisService annualBases;
        public AnnualBasisController(IAnnualBasisService annualBases)
        {
            this.annualBases = annualBases;
        }

        public IActionResult All()
        {
            return View(annualBases.GetAnnualBases());
        }


        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddAnnualBasisFormModel basisModel)
        {
            if (basisModel.MinimumThreshold > basisModel.MaximumThreshold)
            {
                this.ModelState.AddModelError(nameof(basisModel.Year), "The annual basis thresholds are not valid! The minimum cannot be greater than the maximum!");
            }
            if (!ModelState.IsValid)
            {
                return View(basisModel);
            }

            annualBases.CreateAnnualBasis(basisModel.Year,
                basisModel.MinimumThreshold,
                basisModel.TotalIncomePercentage,
                basisModel.HealthInsurancePercentage,
                basisModel.MaximumThreshold);

            return RedirectToAction(nameof(All));
        }
    }
}
