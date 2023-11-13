using System.ComponentModel.DataAnnotations;

namespace AspNetBlog.Models;

public class Country
{
    [Key]
    public int Country_Id { get; set; }
    public string Country_Name { get; set; }
}