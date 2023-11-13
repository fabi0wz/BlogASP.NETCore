using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetBlog.Data;
using AspNetBlog.Models;
using AspNetBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            
            var PostDetailsViewModel = new PostDetailsViewModel
            {
                Posts = await _context.Post.ToListAsync(),
                PostImages = await _context.Post_Images.ToListAsync(),
            };
            
              return _context.Post != null ? 
                          View(PostDetailsViewModel) :
                          Problem("Entity set 'ApplicationDbContext.Post'  is null.");
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id, string commentAnchor)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(cb => cb.CreatedBy)
                .FirstOrDefaultAsync(m => m.Post_Id == id);
                
            if (post == null)
            {
                return NotFound();
            }
            var postImages = _context.Post_Images.Where(pi => pi.Post.Post_Id == id).ToList();

            var postUserComments = _context.Post_User_Comments
                .Include(puc => puc.User_Comment)
                .Where(puc => puc.Post.Post_Id == id)
                .OrderBy(puc => puc.CreatedAt)
                .ToList();
            
            var postUserLikes = _context.Post_User_Likes
                .Include(pul => pul.User)
                .Where(pul => pul.Post.Post_Id == id)
                .ToList();
<<<<<<< HEAD
            
=======

>>>>>>> parent of cf93c98 (Some UI Improvements and final touches)
            var viewModel = new PostDetailsViewModel
            {
                Post = post,
                PostImages = postImages,
                PostUserComments = postUserComments,
                PostUserLikes = postUserLikes
            };

            ViewBag.CommentAnchor = commentAnchor;
            
            return View(viewModel);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
<<<<<<< HEAD
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Post_Id,Post_Title,Post_Content,Post_Description,CreatedAt,UpdatedAt")] Post post, List<IFormFile> postImages)
{
    if (User.Identity.IsAuthenticated)
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        post.CreatedBy = currentUser;
        post.CreatedAt = DateTime.Now;
    }

    if (ModelState.IsValid)
    {
        _context.Add(post);
        
        // Save the new Post to the database
        await _context.SaveChangesAsync();

        var postImagesList = new List<Post_Images>();
        if (postImages != null && postImages.Count > 0)
Fabio2
=======
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Post_Id,Post_Title,Post_Content,Post_Description,CreatedAt,UpdatedAt")] Post post,
            List<IFormFile> postImages)
>>>>>>> parent of cf93c98 (Some UI Improvements and final touches)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                post.CreatedBy = currentUser;
                post.CreatedAt = DateTime.Now;
            }

            if (ModelState.IsValid)
            {
                _context.Add(post);

                // Save the new Post to the database
                await _context.SaveChangesAsync();

                var postImagesList = new List<Post_Images>();
                if (postImages != null && postImages.Count > 0)
                {
                    foreach (var imageFile in postImages)
                    {
                        if (imageFile.Length > 0)
                        {
                            // Define a unique filename for the image, e.g., using Guid
                            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                            // Get the path to your image folder (change to your desired folder path)
                            var imagePath = Path.Combine("wwwroot/images/PostPictures", uniqueFileName);

                            using (var stream = new FileStream(imagePath, FileMode.Create))
                            {
                                await imageFile.CopyToAsync(stream);
                            }

                            // Create a Post_Images instance and associate it with the Post
                            var postImage = new Post_Images
                            {
                                Image_Path = "/images/PostPictures/" + uniqueFileName, // Adjust the path as needed
                                Post = post // Associate with the new Post
                            };

                            // Add the Post_Images record to the list
                            postImagesList.Add(postImage);
                        }
                    }

<<<<<<< HEAD
                    // Add the associated Post_Images records to the context
                    _context.Post_Images.AddRange(postImagesList);

                    // Save changes to the database to save Post_Images records
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }

            return View(post);
        }


        // GET: Posts/Edit/5
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
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Post_Id,Post_Title,Post_Content,Post_Description,CreatedAt,UpdatedAt")] Post post, List<IFormFile> postImages)
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

                    // Remove imagens antigas associadas ao post
                    var oldImages = _context.Post_Images.Where(pi => pi.Post.Post_Id == post.Post_Id).ToList();
                    _context.Post_Images.RemoveRange(oldImages);

                    await _context.SaveChangesAsync();

                    var postImagesList = new List<Post_Images>();

                    if (postImages != null && postImages.Count > 0)
=======
                    if (ModelState.IsValid)
>>>>>>> parent of cf93c98 (Some UI Improvements and final touches)
                    {
                        foreach (var imageFile in postImages)
                        {
                            if (imageFile.Length > 0)
                            {
                                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                                var imagePath = Path.Combine("wwwroot/images/PostPictures", uniqueFileName);

                                using (var stream = new FileStream(imagePath, FileMode.Create))
                                {
                                    await imageFile.CopyToAsync(stream);
                                }

                                var postImage = new Post_Images
                                {
                                    Image_Path = "/images/PostPictures/" + uniqueFileName,
                                    Post = post
                                };

                                postImagesList.Add(postImage);
                            }
                        }

                        _context.Post_Images.AddRange(postImagesList);
                        await _context.SaveChangesAsync();
                    }
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
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Post_Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
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
