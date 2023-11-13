using AspNetBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetBlog.Data;
using AspNetBlog.ViewModels;

namespace AspNetBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve the top 3 posts based on likes
            var topPosts = _context.Post_User_Likes
                .GroupBy(p => p.Post)
                .OrderByDescending(group => group.Count())
                .Take(3)
                .Select(group => group.Key)
                .ToList();

            // Create a ViewModel with the necessary data
            var viewModel = new PostDetailsViewModel
            {
                PostUserLikes = _context.Post_User_Likes.ToList(), // Assuming you need this list
                Posts = topPosts,
                // Add other properties as needed
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}