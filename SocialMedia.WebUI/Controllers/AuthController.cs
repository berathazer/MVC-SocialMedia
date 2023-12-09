using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;
using SocialMedia.Entities;
using SocialMedia.WebUI.Models.Auth;

namespace SocialMedia.WebUI.Controllers
{
    using BCrypt.Net;
    using Microsoft.AspNetCore.Antiforgery;
    using SocialMedia.Entities.enums;

    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private IAuthService _authService;
        private IUserService _userService;


        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService,
            IUserService userService
        )
        {
            _logger = logger;
            _authService = authService;
            _userService = userService;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginFormModel model)
        {

            //formdan gelen credential ve password bilgisini alıcak
            if (ModelState.IsValid)
            {
                //bilgileri AuthManager ile LoginUser fonksiyona gönderilecek
                var user = await _authService.LoginUser(model.Credential, model.Password);

                //geriye user dönmezse hata mesajı yazdırılacak
                if (user == null)
                {
                    TempData["ErrorMessage"] = "Kullanıcı bulunamadı tekrar deneyin.";
                    return View(model);

                }

                //login başarılı cookie oluştur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role,user.Role.ToString()),
                    new Claim(ClaimTypes.SerialNumber,user.UserID.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                //cookie oluşturuldu, kullanıcıyı yönlendir.
                return RedirectToAction("Index", "Auth");
            }

            return View(model);

        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            Console.WriteLine("Posta  girdi");
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FirstName + " " + model.LastName,
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password
                };

                var result = await _userService.Create(user);

                if (result)
                {
                    Console.WriteLine("Registere post geldi user oluşturma başarılı");

                    // Başarılı bir şekilde kayıt olundu, giriş yap sayfasına yönlendir
                    return RedirectToAction("Login");

                }
                else
                {
                    Console.WriteLine("Registere post geldi user oluşturma başarısız");
                    // Kayıt işlemi başarısız, hata mesajını göster
                    TempData["ErrorMessage"] = "Böyle bir kullanıcı zaten mevcut!";
                }
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Kullanıcıyı sistemden çıkış yap
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Console.WriteLine("Logged out");
            // Çıkış işlemi başarıyla gerçekleşti, anasayfaya yönlendir
            return RedirectToAction("Login", "Auth");
        }
    }
}