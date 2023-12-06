using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;


namespace SocialMedia.WebUI.Controllers
{

    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private IAuthService _authService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        //Auth page, sadece giriş yapanlar görebilir
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // -/auth/login sayfası
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser()
        {

            //formdan gelen credential ve password bilgisini alıcak
            //form validation yapılacak

            //bilgileri AuthManager ile LoginUser fonksiyona gönderilecek
            var user = await _authService.LoginUser("credential", "hashed password");
            //geriye user dönmezse hata mesajı yazdırılacak
            if (user == null)
            {
                return NotFound();
            }


            //login başarılı cookie oluştur
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role,"User"),
                new Claim(ClaimTypes.SerialNumber,user.UserID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            //cookie oluşturuldu, kullanıcıyı yönlendir.
            return RedirectToAction("Index", "Auth");
        }



    }
}