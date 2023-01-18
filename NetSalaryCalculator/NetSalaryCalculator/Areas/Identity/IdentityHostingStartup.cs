using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(NetSalaryCalculator.Areas.Identity.IdentityHostingStartup))]
namespace NetSalaryCalculator.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}