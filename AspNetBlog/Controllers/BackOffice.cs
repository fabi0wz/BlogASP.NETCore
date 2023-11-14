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


namespace AspNetBlog.Controllers;

public class BackOffice : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public BackOffice(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    // GET
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var BackOfficeViewModel = new BackOfficeViewModel
        {
            User = await _context.Users.FirstOrDefaultAsync(),
            Users = await _context.Users.ToListAsync()
        };
        return View(BackOfficeViewModel);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminRights(string id)
    {
      
        var user = await _userManager.FindByIdAsync(id);
        
        if (await _userManager.IsInRoleAsync(user, "Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
        }
        else
        {
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        // Redirect back to the page you were at
        return RedirectToAction("Index"); // Change "Index" to the action you want to redirect to
    }
    
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Users == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
}