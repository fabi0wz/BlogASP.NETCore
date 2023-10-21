using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetBlog.Data;
using AspNetBlog.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Post.Include(p => p.CreatedBy).Include(p => p.UpdatedBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.CreatedBy)
                .Include(p => p.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Post_Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["Created_ById"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["Updated_ById"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Post_Id,Post_Title,Post_Content,Post_Description,CreatedAt,UpdatedAt,Created_ById,Updated_ById")] Post post)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // Assuming you have UserManager configured for Identity

                var Post = new Post
                {
                    Post_Title = post.Post_Title,
                    Post_Content = post.Post_Content,
                    Post_Description = post.Post_Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null,
                    CreatedBy = user,
                    UpdatedBy = null
                };
                
                _context.Add(Post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Created_ById"] = new SelectList(_context.Users, "Id", "Id", post.Created_ById);
            ViewData["Updated_ById"] = new SelectList(_context.Users, "Id", "Id", post.Updated_ById);
            return View(post);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["Created_ById"] = new SelectList(_context.Users, "Id", "Id", post.Created_ById);
            ViewData["Updated_ById"] = new SelectList(_context.Users, "Id", "Id", post.Updated_ById);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Post_Id,Post_Title,Post_Content,Post_Description,CreatedAt,UpdatedAt,Created_ById,Updated_ById")] Post post)
        {
            if (id != post.Post_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Post_Id))
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
            ViewData["Created_ById"] = new SelectList(_context.Users, "Id", "Id", post.Created_ById);
            ViewData["Updated_ById"] = new SelectList(_context.Users, "Id", "Id", post.Updated_ById);
            return View(post);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.CreatedBy)
                .Include(p => p.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Post_Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return (_context.Post?.Any(e => e.Post_Id == id)).GetValueOrDefault();
        }
    }
}
