using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetBlog.Models;

namespace AspNetBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AspNetBlog.Models.Post> Post { get; set; } = default!;
        public DbSet<AspNetBlog.Models.Post_User_Comments> Post_User_Comments { get; set; } = default!;
        public DbSet<AspNetBlog.Models.Post_User_Likes> Post_User_Likes { get; set; } = default!;
        public DbSet<AspNetBlog.Models.Post_User_Views> Post_User_Views { get; set; } = default!;
        
        public DbSet<AspNetBlog.Models.Country> Country { get; set; } = default!;
        
        public DbSet<AspNetBlog.Models.Post_Images> Post_Images { get; set; } = default!;
    }
}