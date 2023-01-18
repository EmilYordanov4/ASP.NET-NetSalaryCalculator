using MyTested.AspNetCore.Mvc;
using NetSalaryCalculator.Controllers;
using NetSalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using NetSalaryCalculator.Test.Data;
using NetSalaryCalculator.Models.YearlyBasis;

namespace NetSalaryCalculator.Test
{
    public class AnnualBasisControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
            => MyController<AnnualBasisController>
            .Calling(c => c
                .All())
            .ShouldReturn()
            .View();

        [Fact]
        public void AllShouldReturnViewWithCorrectModelType()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .All())
            .ShouldReturn()
            .View(v => v
                .WithModelOfType<List<AnnualBasis>>());

        [Fact]
        public void AllShouldReturnViewWithCorrectData()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .All())
            .ShouldReturn()
            .View(v => v
                .WithModel<List<AnnualBasis>>(AnnualBases.AnnualBasesList));

        [Fact]
        public void AddShouldReturnAddView()
            => MyController<AnnualBasisController>
            .Calling(c => c
                .Add())
            .ShouldReturn()
            .View();

        [Fact]
        public void AddPostWithValidModelShouldReturnRedirectToAllView()
            => MyController<AnnualBasisController>
            .Instance()
            .Calling(c => c
                .Add(AnnualBases.AnnualFormModel))
            .ShouldHave()
            .ValidModelState()
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("All");

        [Fact]
        public void AddPostWithBiggerMinimumThresoldThanMaximumThreshold()
            => MyController<AnnualBasisController>
            .Instance()
            .Calling(c => c
                .Add(AnnualBases.InvalidAnnualFormModel))
            .ShouldHave()
            .InvalidModelState();

        [Fact]
        public void AddPostWithNullModelShouldReturnException()
            => MyController<AnnualBasisController>
            .Instance()
            .Calling(c => c
                .Add(null))
            .ShouldThrow()
            .Exception();

        [Fact]
        public void AddPostWithInvalidModelShouldReturnAddView()
            => MyController<AnnualBasisController>
            .Instance()
            .Calling(c => c
                .Add(AnnualBases.InvalidAnnualFormModel))
            .ShouldHave()
            .InvalidModelState()
            .AndAlso()
            .ShouldReturn()
            .View();

    }
}
