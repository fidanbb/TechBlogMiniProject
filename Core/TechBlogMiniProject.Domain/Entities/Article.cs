using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
