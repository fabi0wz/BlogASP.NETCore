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
        public DbSet<Post> Post { get; set; } = default!;
        public DbSet<Post_User_Comments> Post_User_Comments { get; set; } = default!;
        public DbSet<Post_User_Likes> Post_User_Likes { get; set; } = default!;
        public DbSet<Post_User_Views> Post_User_Views { get; set; } = default!;
        public DbSet<Post_Images> Post_Images { get; set; } = default!;
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = default!;
        
        // We dont need to create Country Tables because they'll be created manually on the database via script
        // we just assign countries to the posts
        // we could also get the countries via API 
        
        
        //implement logic to delete user posts if desired else the post created by will be "deleted user"
    }
}