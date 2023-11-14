using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetBlog.Models;

public class Post_Images
{
    [Key]
    public int Image_Id { get; set; }
    public string Image_Path { get; set; }
    

    [DisplayName("Post Id")]
    public virtual Post Post { get; set; }
}