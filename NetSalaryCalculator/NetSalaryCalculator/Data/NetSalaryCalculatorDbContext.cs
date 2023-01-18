using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetSalaryCalculator.Data.Models;

namespace NetSalaryCalculator.Data
{
    public class NetSalaryCalculatorDbContext : IdentityDbContext<User>
    {
        public NetSalaryCalculatorDbContext(DbContextOptions<NetSalaryCalculatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<AnnualBasis> AnnualBases { get; init; }

        public DbSet<Salary> Salaries { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(a => a.Salary)
                .WithOne(b => b.User)
                .HasForeignKey<Salary>(b => b.UserId);
            
            builder.Entity<Salary>()
                .HasOne(a => a.User)
                .WithOne(b => b.Salary)
                .HasForeignKey<User>(b => b.SalaryId);

            base.OnModelCreating(builder);
        }
    }
}
