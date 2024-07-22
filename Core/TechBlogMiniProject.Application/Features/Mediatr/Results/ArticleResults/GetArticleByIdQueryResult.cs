using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Application.Features.Mediatr.Results.ArticleResults
{
    public class GetArticleByIdQueryResult
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ArticleWriterFullName { get; set; }
        public string CategoryName { get; set; }
    }
}
