using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
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
        [Authorize]
        public IActionResult Index()
        {
            using (var db = new AppDbContext())
            {

                var serialNumberClaim = HttpContext.User.FindFirst(ClaimTypes.SerialNumber);

                if (serialNumberClaim != null)
                {
                    var serialNumber = serialNumberClaim.Value;
                    ViewBag.UserId = serialNumber;
                }



                var _posts = db.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .OrderByDescending(p => p.PostDate)
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
