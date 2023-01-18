using NetSalaryCalculator.Data.Models;
using System.Collections.Generic;

namespace NetSalaryCalculator.Services.AnnualBases
{
    public interface IAnnualBasisService
    {
        void CreateAnnualBasis(int year,
            decimal minimumThreshold,
            double totalIncomePercentage,
            double healthInsurancePercentage,
            decimal maximumThreshold);

        public List<AnnualBasis> GetAnnualBases();

        void DeleteAnnualBasis(int id);

        AnnualBasis GetAnnualBasis(int id);

        void EditAnnualBasis(AnnualBasis annualBasis, int id);
    }
}
