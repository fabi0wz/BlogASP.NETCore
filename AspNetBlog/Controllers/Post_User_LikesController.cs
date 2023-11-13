using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetBlog.Data;
using AspNetBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Controllers
{
    public class Post_User_LikesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public Post_User_LikesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Post_User_Likes
        public async Task<IActionResult> Index()
        {
              return _context.Post_User_Likes != null ? 
                          View(await _context.Post_User_Likes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Post_User_Likes'  is null.");
        }

        // GET: Post_User_Likes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post_User_Likes == null)
            {
                return NotFound();
            }

            var post_User_Likes = await _context.Post_User_Likes
                .FirstOrDefaultAsync(m => m.Like_Id == id);
            if (post_User_Likes == null)
            {
                return NotFound();
            }

            return View(post_User_Likes);
        }
        
        // POST: Post_User_Likes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Post")] Post_User_Likes post_User_Likes)
        {
            var post = await _context.Post.FindAsync(post_User_Likes.Post.Post_Id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            post_User_Likes.User = user;
            post_User_Likes.Post = post;
            
            if (user != null && post != null)
            {
                _context.Add(post_User_Likes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Posts", new { id = post_User_Likes.Post.Post_Id});
            }
            return View(post_User_Likes);
        }

        // GET: Post_User_Likes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post_User_Likes == null)
            {
                return NotFound();
            }

            var post_User_Likes = await _context.Post_User_Likes.FindAsync(id);
            if (post_User_Likes == null)
            {
                return NotFound();
            }
            return View(post_User_Likes);
        }

        // GET: Post_User_Likes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return RedirectToAction("Details", "Posts", new { id = id});
        }

        // POST: Post_User_Likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int postId)
        {
            if (_context.Post_User_Likes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post_User_Likes'  is null.");
            }
            var post = await _context.Post.FindAsync(postId);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var post_User_Likes = await _context.Post_User_Likes
                .FirstOrDefaultAsync(m => m.User == user && m.Post == post);
            if (post_User_Likes != null)
            {
                _context.Post_User_Likes.Remove(post_User_Likes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Posts", new { id = post.Post_Id});
        }

        private bool Post_User_LikesExists(int id)
        {
          return (_context.Post_User_Likes?.Any(e => e.Like_Id == id)).GetValueOrDefault();
        }
    }
}
