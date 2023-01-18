using NetSalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static NetSalaryCalculator.Test.Data.Salaries;

namespace NetSalaryCalculator.Test.Data
{
    public static class Users
    {
        public static User GetUser
            => CreateUser();

        private static User CreateUser()
        {
            var user = new User
            {
                Id = "0",
                FirstName = "Emo",
                LastName = "Yordanov",
                Email = "test@mail.bg",
                UserName = "Emo"
            };

            var salary = new Salary
            {
                Id = 1,
                GrossSalary = 1000,
                User = user,
                UserId = user.Id
            };

            user.Salary = salary;
            user.SalaryId = salary.Id;

            return user;
        }
    }
}
