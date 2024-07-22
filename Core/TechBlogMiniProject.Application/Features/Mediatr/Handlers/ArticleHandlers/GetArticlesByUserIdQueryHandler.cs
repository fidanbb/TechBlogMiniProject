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
    public class GetArticlesByUserIdQueryHandler : IRequestHandler<GetArticlesByUserIdQuery, List<GetArticlesByUserIdQueryResult>>
    {
        private readonly IArticleReadRepository _articleReadRepository;

        public GetArticlesByUserIdQueryHandler(IArticleReadRepository articleReadRepository)
        {
            _articleReadRepository = articleReadRepository;
        }
        public async Task<List<GetArticlesByUserIdQueryResult>> Handle(GetArticlesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _articleReadRepository.Table.Include(x => x.Category)
                                                     .Include(y => y.AppUser)
                                                     .Where(z => z.AppUserId == request.UserId);
                                                     

            return values.Select(x => new GetArticlesByUserIdQueryResult
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
