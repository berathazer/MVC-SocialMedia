using Microsoft.AspNetCore.Mvc;
using SocialMedia.WebUI.Models;

namespace SocialMedia.WebUI.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {

            List<User> _users = new List<User>
            {
                new() { Ad = "Ahmet", Soyad = "Yılmaz", Yas = 25 },
                new() { Ad = "Ayşe", Soyad = "Kaya", Yas = 30 },
                new() { Ad = "Mustafa", Soyad = "Demir", Yas = 28 }
            };
            //ViewBag.users = _users;

            var userViewModel = new UsersViewModel { users = _users };

            return View(userViewModel);
        }
    }

    public class User
    {
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public int Yas { get; set; }
    }
}
