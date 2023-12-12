
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

using SocialMedia.WebUI.Models;

namespace SocialMedia.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreatePostModel model)
        {


            if (ModelState.IsValid)
            {
                var serialNumberClaim = HttpContext.User.FindFirst(ClaimTypes.SerialNumber);

                if (serialNumberClaim == null)
                {
                    // userId yok hata döndürürüz.
                    return NotFound();
                }

                var UserId = serialNumberClaim.Value;
                

            }
            else
            {
                Console.WriteLine("Error creating post");
            }
            return Ok();
        }



    }
}