using AspNetBlog.Data;
using AspNetBlog.Models;
using AspNetBlog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetBlog.Controllers;

public class UserProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: UserProfile/Details/5
    public async Task<IActionResult> Details()
    {
        var userId = HttpContext.Request.RouteValues["id"]?.ToString();
        // Fetch the user by userId
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            // Handle the case where the user is not found
            return NotFound();
        }
        var userPosts = _context.Post.Where(p => p.CreatedBy.Id == userId).ToList();

        var UserDetailsViewModel = new UserDetailsViewModel
        {
            Posts = userPosts,
            User = user
        };
        
        return View(UserDetailsViewModel);
    }
}