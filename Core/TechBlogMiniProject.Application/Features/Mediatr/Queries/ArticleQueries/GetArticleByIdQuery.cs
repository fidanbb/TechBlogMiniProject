using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Results.ArticleResults;

namespace TechBlogMiniProject.Application.Features.Mediatr.Queries.ArticleQueries
{
    public class GetArticleByIdQuery:IRequest<GetArticleByIdQueryResult>
    {
        public int Id { get; set; }

        public GetArticleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
