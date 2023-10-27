using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class Post_User_Likes
{
    [Key]
    public int Like_Id { get; set; }
    public int Post_Id { get; set; }
    public string? User_Id { get; set; } // string because IdentityUser has string Id
    // can be null because if else there's a cascade delete error
    // we'll do logic to handle it later

    [ForeignKey("Post_Id")]
    public virtual Post Post { get; set; }
  
    [ForeignKey("User_Id")]
    public virtual ApplicationUser User { get; set; }
}