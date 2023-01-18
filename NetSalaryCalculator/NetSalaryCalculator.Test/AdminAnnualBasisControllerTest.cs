using MyTested.AspNetCore.Mvc;
using NetSalaryCalculator.Areas.Admin.Controllers;
using NetSalaryCalculator.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetSalaryCalculator.Test
{
    public class AdminAnnualBasisControllerTest
    {
        [Fact]
        public void DeleteAnnualBasisShouldDeleteSuccessfully()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .Delete(1));
        
        [Fact]
        public void DeleteAnnualBasisShouldRedirectToAllView()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .Delete(1))
            .ShouldReturn()
            .Redirect("/AnnualBasis/All");

        [Fact]
        public void EditAnnualBasisShouldReturnEditPostSuccessfully()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .Edit(1))
            .ShouldReturn()
            .View(AnnualBases.AnnualBasis);

        [Fact]
        public void EditPostAnnualBasisShouldReturnEditSuccessfully()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .Edit(AnnualBases.AnnualBasis, 1))
            .ShouldReturn()
            .Redirect("/AnnualBasis/All");
        
        [Fact]
        public void EditPostAnnualBasisWithInvalidModelShouldReturnEditView()
            => MyController<AnnualBasisController>
            .Instance(i => i
                .WithData(AnnualBases.AnnualBasis))
            .Calling(c => c
                .Edit(AnnualBases.InvalidAnnualBasis, 1))
            .ShouldReturn()
            .View();

    }
}
