using AspNetBlog.Models;

namespace AspNetBlog.ViewModels;

public class UserDetailsViewModel
{
    public List<Post> Posts { get; set; }
    public ApplicationUser User { get; set; }
}