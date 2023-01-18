using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetSalaryCalculator.Data;
using System.Threading.Tasks;
using System;
using NetSalaryCalculator.Data.Models;
using System.Linq;

namespace NetSalaryCalculator.Infrastructure
{

    using static NetSalaryCalculator.WebConstants.AdminConstants;

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            var data = services.GetRequiredService<NetSalaryCalculatorDbContext>();

            data.Database.Migrate();

            SeedAdministrator(data, services);
            SeedAnnualBases(data);

            return app;
        }

        private static void SeedAnnualBases(NetSalaryCalculatorDbContext data)
        {
            if (data.AnnualBases.Any())
            {
                return;
            }

            var basisOne = new AnnualBasis
            {
                Year = 2022,
                MinimumThreshold = 1000,
                TotalIncomePercentage = 10,
                HealthInsurancePercentage = 15,
                MaximumThreshold = 3000,
            };

            var basisTwo = new AnnualBasis
            {
                Year = 2021,
                MinimumThreshold = 500,
                TotalIncomePercentage = 10,
                HealthInsurancePercentage = 20,
                MaximumThreshold = 2500
            };

            var basisThree = new AnnualBasis
            {
                Year = 2020,
                MinimumThreshold = 1000,
                TotalIncomePercentage = 15,
                HealthInsurancePercentage = 15,
                MaximumThreshold = 3500
            };

            data.AnnualBases.AddRange(basisOne, basisTwo, basisThree);

            data.SaveChanges();
        }

        private static void SeedAdministrator(NetSalaryCalculatorDbContext data, IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@dcs.bg";
                    const string adminPassword = "admin12";

                    var user = new User
                    {
                        UserName = adminEmail,
                        FirstName = "Admin",
                        LastName = "Yordanov",
                        Email = adminEmail,
                    };

                    var Salary = new Salary
                    {
                        GrossSalary = 0,
                        HealthInsuranceTax = 0,
                        TotalIncomeTax = 0,
                        NetSalary = 0,
                        UserId = user.Id,
                        User = user
                    };


                    user.Salary = Salary;
                    user.SalaryId = Salary.Id;

                    data.Salaries.Add(Salary);


                    await userManager.CreateAsync(user, adminPassword);
                    
                    await userManager.AddToRoleAsync(user, role.Name);
                    
                    await data.SaveChangesAsync();
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
