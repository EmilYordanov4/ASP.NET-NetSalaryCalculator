using Microsoft.AspNetCore.Mvc;
using NetSalaryCalculator.Data.Models;
using NetSalaryCalculator.Services.AnnualBases;

namespace NetSalaryCalculator.Areas.Admin.Controllers
{
    public class AnnualBasisController : AdminController
    {
        private readonly IAnnualBasisService basis;

        public AnnualBasisController(IAnnualBasisService basis)
        {
            this.basis = basis;
        }

        public IActionResult Delete(int basisId) 
        {
            basis.DeleteAnnualBasis(basisId);

            return Redirect("/AnnualBasis/All");
        }

        public IActionResult Edit(int basisId)
        {
            var annualBasis = basis.GetAnnualBasis(basisId);

            return View(annualBasis);
        }

        [HttpPost]
        public IActionResult Edit(AnnualBasis basisModel, int basisId)
        {
            if (basisModel.MinimumThreshold > basisModel.MaximumThreshold)
            {
                this.ModelState.AddModelError(nameof(basisModel.Year), "The annual basis thresholds are not valid! The minimum cannot be greater than the maximum!");
            }
            if (!ModelState.IsValid)
            {
                return View(basisModel);
            }

            basis.EditAnnualBasis(basisModel, basisId);

            return Redirect("/AnnualBasis/All");
        }
    }
}
