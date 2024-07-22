using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Application.Features.Mediatr.Commands.ArticleCommands
{
    public class RemoveArticleCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveArticleCommand(int id)
        {
            Id = id;
        }
    }
}
