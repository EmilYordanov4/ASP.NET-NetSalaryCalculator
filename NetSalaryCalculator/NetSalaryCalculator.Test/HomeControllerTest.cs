using MyTested.AspNetCore.Mvc;
using NetSalaryCalculator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetSalaryCalculator.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void LoggedOutUserReturnDefaultView()
            => MyController<HomeController>
            .Calling(c => c
                .Index())
            .ShouldReturn()
            .View();

        [Fact]
        public void LoggedInUserShouldRedirectToIndexLoggedIn()
                    => MyController<HomeController>
                    .Instance(instance => instance
                        .WithUser())
                    .Calling(c => c
                        .Index())
                    .ShouldReturn()
                    .Redirect(r => r
                        .To<HomeController>(c => c
                            .IndexLoggedIn()));

        [Fact]
        public void ErrorShouldReturnView()
            => MyController<HomeController>
            .Calling(c => c
                .Error())
            .ShouldReturn()
            .View();

        [Fact]
        public void LoggedOutUserShouldntBeAbleToAccessIndexLoggedInPage()
            => MyController<HomeController>
            .Instance(i => i
                .WithoutUser())
            .Calling(c => c
                .IndexLoggedIn())
            .ShouldReturn()
            .View();
    }
}
