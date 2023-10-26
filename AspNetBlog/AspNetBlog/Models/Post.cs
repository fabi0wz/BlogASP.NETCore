using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    
    public string? CreatedById { get; set; }
    public string? UpdatedById { get; set; }
    
    [ForeignKey("CreatedById")]
    public ApplicationUser? CreatedBy { get; set; }
    [ForeignKey("UpdatedById")]
    public ApplicationUser? UpdatedBy { get; set; }
}