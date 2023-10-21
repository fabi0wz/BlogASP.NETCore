using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class Post_User_Comments
{
    [Key]
    public int Comment_Id { get; set; }
    public int Post_Id { get; set; }
    public string? User_Id { get; set; } //string because IdentityUser has string Id
    // can be null because the top level comment can be deleted but we want to keep responses to that comment
    // we'll handle it later with if user_id is null then display "deleted user"
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? Parent_Comment { get; set; }
    
    [ForeignKey("Parent_Comment")]
    public virtual Post_User_Comments Post_User_Comments1 { get; set; }
    
    [ForeignKey("Post_Id")]
    public virtual Post Post { get; set; }
    
    [ForeignKey("User_Id")]
    public virtual IdentityUser User_Comment { get; set; }
}