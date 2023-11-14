using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class ApplicationUser : IdentityUser
{
    [MaxLength(100)]
    public string? Description { get; set; }

    public string? ProfilePictureUrl { get; set; }
    
    public string? personalUserName { get; set; }
}