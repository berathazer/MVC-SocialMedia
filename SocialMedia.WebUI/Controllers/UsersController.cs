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
    }
}
