using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;
using SocialMedia.WebUI.Models;

namespace SocialMedia.WebUI.Controllers
{

    public class UsersController : Controller
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            var users = _userService.GetAll();

            var userViewModel = new UsersViewModel { users = users };

            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        /*   [HttpPost]
          public async Task<IActionResult> Register(UserRegistrationModel model)
          {
              if (ModelState.IsValid)
              {
                  var user = new User
                  {
                      FullName = model.FullName,
                      Email = model.Email,
                      Username = model.Username,
                      Password = model.Password // Gerekirse şifre hashleme işlemi yapılabilir
                  };

                  var result = await _userService.CreateUser(user);

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

              return View(model);
          }
        */


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /* [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Authenticate(model.Email, model.Password);

                if (user != null)
                {
                    // Başarılı bir şekilde giriş yapıldı, ana sayfaya yönlendir
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Giriş işlemi başarısız, hata mesajını göster
                    ModelState.AddModelError("", "Giriş işlemi başarısız oldu.");
                }
            }

            return View(model);
        }
 */

    }
}
