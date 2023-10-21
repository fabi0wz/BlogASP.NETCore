using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetBlog.Models;

public class Post
{
    [Key]// defines Post_Id as primary key of this table
    public int Post_Id { get; set; }
    public string Post_Title { get; set; }
    public string Post_Content { get; set; }
    public string Post_Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public string Created_ById { get; set; } // string because IdentityUser has string Id
    public string? Updated_ById { get; set; } // string because IdentityUser has string Id
    
    [ForeignKey("Created_ById")]
    public virtual IdentityUser CreatedBy { get; set; }
    
    [ForeignKey("Updated_ById")]
    public virtual IdentityUser UpdatedBy { get; set; }
}