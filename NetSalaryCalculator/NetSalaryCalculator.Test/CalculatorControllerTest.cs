using Xunit;
using MyTested.AspNetCore.Mvc;
using NetSalaryCalculator.Controllers;
using System.Linq;

using static NetSalaryCalculator.Test.Data.AnnualBases;
using static NetSalaryCalculator.Test.Data.Salaries;
using static NetSalaryCalculator.Test.Data.Users;
using System.Collections.Generic;
using NetSalaryCalculator.Services.Calculators.Models;
using NetSalaryCalculator.Test.Data;

namespace NetSalaryCalculator.Test
{
    public class CalculatorControllerTest
    {
        [Fact]
        public void CalculatorShouldThrowError()
            => MyController<CalculatorController>
                .Instance()
                .Calling(c => c
                    .Calculator(1, "0"))
                .ShouldThrow()
                .Exception();

        [Fact]
        public void CalculatorShouldReturnCalculatorView()
            => MyController<CalculatorController>
                .Instance(i => i
                    .WithData(GetUser)
                    .WithUser("Emo")
                    .WithData(AnnualBasis))
                .Calling(c => c
                    .Calculator(1, "0"))
                .ShouldReturn()
                .View();

        [Fact]
        public void YearShouldReturnCorrectModel() 
            => MyController<CalculatorController>
                .Instance(i => i
                    .WithData(AnnualBasis))
                .Calling(c => c
                    .Year())
                .ShouldReturn()
                .View(v => v.WithModel<List<YearServiceModel>>(ListYear));

        [Fact]
        public void YearShouldReturnYearViewWithTheRightModelType() 
            => MyController<CalculatorController>
                .Instance()
                .Calling(c => c
                    .Year())
                .ShouldReturn()
                .View(v => v.WithModelOfType<List<YearServiceModel>>());

        [Fact]
        public void CalculateShouldReturnCalculatorView()
        {
            MyController<CalculatorController>
                .Instance(i => i
                    .WithData(Salary)
                    .WithData(AnnualBasis))
                .Calling(c => c
                    .Calculate(Salary.GrossSalary, 1, "0", 1))
                .ShouldReturn()
                .RedirectToAction("Calculator");
        }
        
        [Fact]
        public void CalculateShouldReturnCalculatorViewWithInvalidModel()
        {
            MyController<CalculatorController>
                .Instance(i => i
                    .WithData(Salary)
                    .WithData(AnnualBasis))
                .Calling(c => c
                    .Calculate(-1, 1, "0", 1))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Calculator");
        }
    }
}
