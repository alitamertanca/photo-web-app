using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using PhotoWebApp.Models;
using PhotoWebApp.Data;

namespace PhotoWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
                return RedirectToAction("Index", "Login");

            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Add(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                // Benzersiz kullanıcı adı kontrolü
                if (!_context.Users.Any(u => u.Username == username))
                {
                    var newUser = new User { Username = username, Password = "1234" };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
