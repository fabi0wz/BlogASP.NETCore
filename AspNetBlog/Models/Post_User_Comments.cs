using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class Post_User_Comments
{
    [Key]
    public int Comment_Id { get; set; } //Id of the comment
    public string Comment { get; set; } //body of the comment
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } //null cuz its not required
    
    //Foreign Keys
    [DisplayName("Parent Comment")]
    public virtual Post_User_Comments? Post_User_Comments1 { get; set; }
    
    [DisplayName("Post Id")]
    public virtual Post Post { get; set; }
    
    [DisplayName("User Id")]
    public virtual ApplicationUser? User_Comment { get; set; }
    // can be null because the top level comment can be deleted but we want to keep responses to that comment
    // we'll handle it later with if user_id is null then display "deleted user"
}