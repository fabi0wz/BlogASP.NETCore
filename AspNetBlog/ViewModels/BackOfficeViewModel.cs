using AspNetBlog.Models;

namespace AspNetBlog.ViewModels;

public class BackOfficeViewModel
{
    public ApplicationUser User { get; set; }
    public List<ApplicationUser> Users { get; set; }

}


