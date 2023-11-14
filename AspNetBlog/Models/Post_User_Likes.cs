using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class Post_User_Likes
{
    [Key]
    public int Like_Id { get; set; }

    //Foreign Keys
    [DisplayName("Post Id")]
    public virtual Post Post { get; set; }
  
    [DisplayName("User Id")]
    public virtual ApplicationUser User { get; set; }
    // can be null because if else there's a cascade delete error
    // we'll do logic to handle it later
}