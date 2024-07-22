using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Results.ArticleResults;

namespace TechBlogMiniProject.Application.Features.Mediatr.Queries.ArticleQueries
{
    public class GetAllArticlesQuery:IRequest<List<GetAllArticlesQueryResult>>
    {
    }
}
