using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PhotoWebApp.Data;
using System.Linq;

namespace PhotoWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("user", username);
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index");
        }
    }
}
