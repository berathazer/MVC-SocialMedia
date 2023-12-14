
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Business.Abstract;
using SocialMedia.Entities;
using SocialMedia.WebUI.Models;

namespace SocialMedia.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private IPostService _postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var serialNumberClaim = HttpContext.User.FindFirst(ClaimTypes.SerialNumber);

                    if (serialNumberClaim == null)
                    {
                        // userId yok hata döndürürüz.
                        return NotFound();
                    }

                    var userId = serialNumberClaim.Value;

                    var mediaExtension = Path.GetExtension(model.Media.FileName);

                    var mediaName = $"{Guid.NewGuid()}{mediaExtension}";

                    var mediaFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/posts");

                    // Oluşturulacak dosyanın tam yolu
                    var mediaPath = Path.Combine(mediaFolderPath, mediaName);

                    // Eğer 'wwwroot/posts' klasörü yoksa oluştur
                    if (!Directory.Exists(mediaFolderPath))
                    {
                        Directory.CreateDirectory(mediaFolderPath);
                    }

                    // Save the media file
                    using (var stream = new FileStream(mediaPath, FileMode.Create))
                    {
                        model.Media.CopyTo(stream);
                    }

                    Post newPost = new Post()
                    {
                        UserID = Guid.Parse(userId),
                        PostContent = model.Content,
                        MediaType = mediaExtension,
                        MediaURL = mediaName
                    };

                    string jsonString = JsonConvert.SerializeObject(newPost, Formatting.Indented);
                    Console.WriteLine(jsonString);

                    var isCreated = await _postService.Create(newPost);
                    Console.WriteLine($"Created?:{isCreated}");
                    return Ok();
                }
                else
                {
                    Console.WriteLine("Error creating post - Invalid model");
                    return BadRequest("Invalid post data");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating post: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}