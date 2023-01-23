using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class Post:BaseEntity
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public DateTime Time { get; set; }
    }
}
