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

    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private IAuthService _authService;
        private IUserService _userService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService, IUserService userService)
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


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FirstName + " " + model.LastName,
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password
                };
                Console.WriteLine("Registere post geldi user oluşturma başarılı");
                TempData["SuccessMessage"] = "Başarıyla kayıt oldunuz. Şimdi giriş yapabilirsiniz.";
                return RedirectToAction("Register");
                var result = await _userService.Create(user);

                if (result)
                {
                    // Başarılı bir şekilde kayıt olundu, giriş yap sayfasına yönlendir
                    return RedirectToAction("Login");
                }
                else
                {
                    // Kayıt işlemi başarısız, hata mesajını göster
                    ModelState.AddModelError("", "Kayıt olma işlemi başarısız oldu.");
                }
            }
            else
            {
                var missingFields = ModelState.Where(x => x.Value.Errors.Any())
                              .Select(x => new
                              {
                                  FieldName = x.Key,
                                  ErrorMessage = x.Value.Errors.First().ErrorMessage
                              })
                              .ToList();    

                if (missingFields.Any())
                {
                    foreach (var missingField in missingFields)
                    {
                        Console.WriteLine($"{missingField.FieldName} alanı eksik. Hata: {missingField.ErrorMessage}");
                        TempData["ErrorMessage"] = missingField.ErrorMessage;
                        break;
                    }

                    return RedirectToAction("Register");

                }
            }

            return View(model);
        }

    }
}