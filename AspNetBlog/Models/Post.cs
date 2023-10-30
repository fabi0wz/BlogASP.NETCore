using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetBlog.Models;

public class Post
{
    [Key]// defines Post_Id as primary key of this table
    public int Post_Id { get; set; }
    [Display(Name = "Post Title")]
    public string Post_Title { get; set; }
    [Display(Name = "Post Content")]
    public string Post_Content { get; set; }
    [Display(Name = "Post Description")]
    public string Post_Description { get; set; }
    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }
    [Display(Name = "Updated At")]
    public DateTime? UpdatedAt { get; set; }
    
    [Display(Name = "Updated By")]
    public ApplicationUser? CreatedBy { get; set; }
    
    [Display(Name = "Created By")]
    public ApplicationUser? UpdatedBy { get; set; }

}