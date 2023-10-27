using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace AspNetBlog.Models;

public class Post_User_Views
{
    [Key]
    public int View_Id { get; set; }
    public int Post_Id { get; set; }
    public string? User_Id { get; set; } //string because IdentityUser has string Id
    // can be null because user can view post without being logged in
    
    [ForeignKey("Post_Id")]
    public virtual Post Post { get; set; }
    
    [ForeignKey("User_Id")]
    public virtual ApplicationUser User { get; set; }
}