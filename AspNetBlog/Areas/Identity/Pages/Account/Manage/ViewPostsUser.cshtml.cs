// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspNetBlog.Data;
using AspNetBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetBlog.Areas.Identity.Pages.Account.Manage
{
    public class ViewPostsUserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        
        public ViewPostsUserModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public List<Post> UserPosts { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            // Verificar se o usuário está autenticado
            if (!_signInManager.IsSignedIn(User))
            {
                // Se não estiver autenticado, redirecionar para a página de login
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // Obter o usuário autenticado
            var user = await _userManager.GetUserAsync(User);

            // Obter os posts do usuário autenticado
            UserPosts = _context.Post
                .Where(p => p.CreatedBy.Id == user.Id)
                .ToList();

            return Page();
        }

    }
}
