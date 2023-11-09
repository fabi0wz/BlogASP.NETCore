using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetBlog.Data;
using AspNetBlog.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Controllers
{
    public class Post_User_CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public Post_User_CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Post_User_Comments
        public async Task<IActionResult> Index()
        {
              return _context.Post_User_Comments != null ? 
                          View(await _context.Post_User_Comments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Post_User_Comments'  is null.");
        }

        // GET: Post_User_Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post_User_Comments == null)
            {
                return NotFound();
            }

            var post_User_Comments = await _context.Post_User_Comments
                .FirstOrDefaultAsync(m => m.Comment_Id == id);
            if (post_User_Comments == null)
            {
                return NotFound();
            }

            return View(post_User_Comments);
        }

        // GET: Post_User_Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post_User_Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Comment_Id,Comment,CreatedAt,UpdatedAt,Post")] Post_User_Comments post_User_Comments)
        {
            post_User_Comments.Post = await _context.Post.FindAsync(post_User_Comments.Post.Post_Id);
            //post_User_Comments.User_Comment = await _userManager.GetUserAsync(User);
            post_User_Comments.CreatedAt = DateTime.Now;

            post_User_Comments.User_Comment = await _userManager.FindByIdAsync("652ad2b4-4534-41ad-9f7b-3ca0fd103fc9");

            ModelState.Clear();
            
            if (ModelState.IsValid)
            {
                _context.Add(post_User_Comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(post_User_Comments);
        }

        // GET: Post_User_Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post_User_Comments == null)
            {
                return NotFound();
            }

            var post_User_Comments = await _context.Post_User_Comments.FindAsync(id);
            if (post_User_Comments == null)
            {
                return NotFound();
            }
            return View(post_User_Comments);
        }

        // POST: Post_User_Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Comment_Id,Comment,CreatedAt,UpdatedAt")] Post_User_Comments post_User_Comments)
        {
            if (id != post_User_Comments.Comment_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post_User_Comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post_User_CommentsExists(post_User_Comments.Comment_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post_User_Comments);
        }

        // GET: Post_User_Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post_User_Comments == null)
            {
                return NotFound();
            }

            var post_User_Comments = await _context.Post_User_Comments
                .FirstOrDefaultAsync(m => m.Comment_Id == id);
            if (post_User_Comments == null)
            {
                return NotFound();
            }

            return View(post_User_Comments);
        }

        // POST: Post_User_Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post_User_Comments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post_User_Comments'  is null.");
            }
            var post_User_Comments = await _context.Post_User_Comments.FindAsync(id);
            if (post_User_Comments != null)
            {
                _context.Post_User_Comments.Remove(post_User_Comments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post_User_CommentsExists(int id)
        {
          return (_context.Post_User_Comments?.Any(e => e.Comment_Id == id)).GetValueOrDefault();
        }
    }
}
