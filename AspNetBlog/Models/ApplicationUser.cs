using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class ApplicationUser : IdentityUser
{
    public string? Description { get; set; }
    public string? ProfilePictureUrl { get; set; }
}