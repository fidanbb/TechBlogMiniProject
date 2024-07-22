using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Application.Features.Mediatr.Commands.ArticleCommands
{
    public class CreateArticleCommand:IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string AppUserId { get; set; }
        public int CategoryID { get; set; }
    }
}
