using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Queries.ArticleQueries;
using TechBlogMiniProject.Application.Features.Mediatr.Results.ArticleResults;
using TechBlogMiniProject.Application.Repositories.ArticleRepositories;

namespace TechBlogMiniProject.Application.Features.Mediatr.Handlers.ArticleHandlers
{
    public class GetRecent4ArticlesQueryHandler : IRequestHandler<GetRecent4ArticlesQuery, List<GetRecent4ArticlesQueryResult>>
    {
        private readonly IArticleReadRepository _articleReadRepository;

        public GetRecent4ArticlesQueryHandler(IArticleReadRepository articleReadRepository)
        {
            _articleReadRepository = articleReadRepository;
        }
        public async Task<List<GetRecent4ArticlesQueryResult>> Handle(GetRecent4ArticlesQuery request, CancellationToken cancellationToken)
        {
            var values = _articleReadRepository.Table.Include(x => x.Category).Include(y => y.AppUser).Take(4);

            return values.Select(x => new GetRecent4ArticlesQueryResult
            {
                ArticleID = x.ArticleID,
                Title = x.Title,
                Content = x.Content,
                ImageUrl = x.ImageUrl,
                CreatedDate = x.CreatedDate,
                CategoryName = x.Category.Name,
                ArticleWriterFullName = x.AppUser.Name + " " + x.AppUser.Surname
            }).ToList();
        }
    }
}
