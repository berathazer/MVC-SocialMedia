using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess;

namespace SocialMedia.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var db = new AppDbContext())
            {
                var _posts = db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .ToList();
                ViewBag.posts = _posts;

                Console.WriteLine("---------" + _posts.Count() + "-----------");
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
