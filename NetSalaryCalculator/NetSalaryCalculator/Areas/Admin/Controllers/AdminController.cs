using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetSalaryCalculator.Areas.Admin.Controllers
{
    using static NetSalaryCalculator.WebConstants.AdminConstants;

    [Area(AreaName)]
    [Authorize(Roles = AdministratorRoleName)]
    public class AdminController : Controller
    {
    }
}
