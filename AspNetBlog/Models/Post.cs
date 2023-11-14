using System.ComponentModel;
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
    [Required]
    [StringLength(255)]
    public string Post_Title { get; set; }
    
    [Display(Name = "Post Content")]
    [Required]

    public string Post_Content { get; set; }
    
    
    [Display(Name = "Post Description")]
    [Required]
    [StringLength(500)]
    public string Post_Description { get; set; }
    
    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }
    
    [Display(Name = "Updated At")]
    public DateTime? UpdatedAt { get; set; }
    
    //Foreign Keys    
    [DisplayName("Created By")]
    public ApplicationUser? CreatedBy { get; set; }
    
    [DisplayName("Updated By")]
    
    public ApplicationUser? UpdatedBy { get; set; }
}