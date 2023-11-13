using AspNetBlog.Models;

namespace AspNetBlog.ViewModels
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }
        public List<Post_Images> PostImages { get; set; }
        public List<Post_User_Comments> PostUserComments { get; set; }
        public List<Post_User_Likes> PostUserLikes { get; set; }
    }
}