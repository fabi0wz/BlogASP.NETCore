using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetBlog.Data;
using AspNetBlog.Models;

namespace AspNetBlog.Controllers
{
    public class Post_User_LikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Post_User_LikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Post_User_Likes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Post_User_Likes.Include(p => p.Post).Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Post_User_Likes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post_User_Likes == null)
            {
                return NotFound();
            }

            var post_User_Likes = await _context.Post_User_Likes
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Like_Id == id);
            if (post_User_Likes == null)
            {
                return NotFound();
            }

            return View(post_User_Likes);
        }

        // GET: Post_User_Likes/Create
        public IActionResult Create()
        {
            ViewData["Post_Id"] = new SelectList(_context.Post, "Post_Id", "Post_Id");
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Post_User_Likes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Like_Id,Post_Id,User_Id")] Post_User_Likes post_User_Likes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post_User_Likes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Post_Id"] = new SelectList(_context.Post, "Post_Id", "Post_Id", post_User_Likes.Post_Id);
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id", post_User_Likes.User_Id);
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
            ViewData["Post_Id"] = new SelectList(_context.Post, "Post_Id", "Post_Id", post_User_Likes.Post_Id);
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id", post_User_Likes.User_Id);
            return View(post_User_Likes);
        }

        // POST: Post_User_Likes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Like_Id,Post_Id,User_Id")] Post_User_Likes post_User_Likes)
        {
            if (id != post_User_Likes.Like_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post_User_Likes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post_User_LikesExists(post_User_Likes.Like_Id))
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
            ViewData["Post_Id"] = new SelectList(_context.Post, "Post_Id", "Post_Id", post_User_Likes.Post_Id);
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id", post_User_Likes.User_Id);
            return View(post_User_Likes);
        }

        // GET: Post_User_Likes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post_User_Likes == null)
            {
                return NotFound();
            }

            var post_User_Likes = await _context.Post_User_Likes
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Like_Id == id);
            if (post_User_Likes == null)
            {
                return NotFound();
            }

            return View(post_User_Likes);
        }

        // POST: Post_User_Likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post_User_Likes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post_User_Likes'  is null.");
            }
            var post_User_Likes = await _context.Post_User_Likes.FindAsync(id);
            if (post_User_Likes != null)
            {
                _context.Post_User_Likes.Remove(post_User_Likes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post_User_LikesExists(int id)
        {
          return (_context.Post_User_Likes?.Any(e => e.Like_Id == id)).GetValueOrDefault();
        }
    }
}
