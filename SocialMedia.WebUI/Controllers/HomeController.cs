using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess;
using SocialMedia.WebUI.Services;

namespace SocialMedia.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;
        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }
        [Authorize]
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

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
