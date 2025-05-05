using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using PhotoWebApp;

namespace PhotoWebApp.Controllers
{
    [SessionAuthorize]
    public class DashboardController : Controller
    {
        public IActionResult Index() => View();
    }
}