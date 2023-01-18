using NetSalaryCalculator.Data.Models;
using NetSalaryCalculator.Models.YearlyBasis;
using NetSalaryCalculator.Services.Calculators.Models;
using System.Collections.Generic;

namespace NetSalaryCalculator.Test.Data
{
    public static class AnnualBases
    {
        public static AddAnnualBasisFormModel InvalidAnnualFormModel
            => new AddAnnualBasisFormModel
            {
                Year = 2022,
                MinimumThreshold = 1000,
                HealthInsurancePercentage = 10,
                TotalIncomePercentage = 10,
                MaximumThreshold = 0
            };
        
        public static AnnualBasis InvalidAnnualBasis
            => new AnnualBasis
            {
                Year = 2022,
                MinimumThreshold = 1000,
                HealthInsurancePercentage = 10,
                TotalIncomePercentage = 10,
                MaximumThreshold = 0
            };

        public static AddAnnualBasisFormModel AnnualFormModel
             => new AddAnnualBasisFormModel
             {
                 Year = 2022,
                 MinimumThreshold = 1000,
                 HealthInsurancePercentage = 10,
                 TotalIncomePercentage = 10,
                 MaximumThreshold = 1100
             };
        public static List<AnnualBasis> AnnualBasesList
            => new List<AnnualBasis> 
            {
                AnnualBasis
            };

        public static AnnualBasis AnnualBasis
            => new AnnualBasis()
            {
                Id = 1,
                Year = 2022,
                MinimumThreshold = 1000,
                TotalIncomePercentage = 15,
                HealthInsurancePercentage = 10,
                MaximumThreshold = 3000
            };

        public static YearServiceModel YearServiceModel
            => new YearServiceModel()
            {
                Id = 1,
                Year = 2022,
            };

        public static List<YearServiceModel> ListYear
         => new List<YearServiceModel>()
         {
             YearServiceModel
         };
    }
}
