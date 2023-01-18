using NetSalaryCalculator.Data.Models;

using static NetSalaryCalculator.Test.Data.Users;

namespace NetSalaryCalculator.Test.Data
{
    public static class Salaries
    {
        public static Salary Salary
            => new Salary()
            {
                GrossSalary = 3100,
            };
    }
}
