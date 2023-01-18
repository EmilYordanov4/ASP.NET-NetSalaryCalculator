using NetSalaryCalculator.Data;
using System.Collections.Generic;
using System.Linq;
using AnnualBasis = NetSalaryCalculator.Data.Models.AnnualBasis;

namespace NetSalaryCalculator.Services.AnnualBases
{


    public class AnnualBasisService : IAnnualBasisService
    {
        private readonly NetSalaryCalculatorDbContext data;

        public AnnualBasisService(NetSalaryCalculatorDbContext data)
        {
            this.data = data;
        }

        public void CreateAnnualBasis(int year,
            decimal minimumThreshold,
            double totalIncomePercentage,
            double healthInsurancePercentage,
            decimal maximumThreshold)
        {
            AnnualBasis annualBasis = new()
            {
                Year = year,
                MinimumThreshold = minimumThreshold,
                TotalIncomePercentage = totalIncomePercentage,
                HealthInsurancePercentage = healthInsurancePercentage,
                MaximumThreshold = maximumThreshold
            };

            data.AnnualBases.Add(annualBasis);

            data.SaveChanges();
        }

        public void DeleteAnnualBasis(int id)
        {
            var basis = GetAnnualBasis(id);

            data.AnnualBases.Remove(basis);

            data.SaveChanges();
        }

        public void EditAnnualBasis(AnnualBasis annualBasis, int id)
        {
            DeleteAnnualBasis(id);

            CreateAnnualBasis(annualBasis.Year,
                annualBasis.MinimumThreshold,
                annualBasis.TotalIncomePercentage,
                annualBasis.HealthInsurancePercentage,
                annualBasis.MaximumThreshold);

            data.SaveChanges();
        }

        public List<AnnualBasis> GetAnnualBases()
        {
            return data.AnnualBases.OrderByDescending(a => a.Year).ToList();
        }

        public AnnualBasis GetAnnualBasis(int id)
        {
            return data.AnnualBases.FirstOrDefault(a => a.Id == id);
        }
    }
}
