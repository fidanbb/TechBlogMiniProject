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
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, GetArticleByIdQueryResult>
    {
        private readonly IArticleReadRepository _articleReadRepository;

        public GetArticleByIdQueryHandler(IArticleReadRepository articleReadRepository)
        {
            _articleReadRepository = articleReadRepository;
        }
        public async Task<GetArticleByIdQueryResult> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _articleReadRepository.Table.Include(x => x.Category)
                                                    .Include(y => y.AppUser)
                                                    .FirstOrDefaultAsync(x => x.ArticleID == request.Id);

            return new GetArticleByIdQueryResult
            {
                ArticleID = value.ArticleID,
                CategoryID = value.Category.CategoryID,
                Title = value.Title,
                Content = value.Content,
                ImageUrl = value.ImageUrl,
                CreatedDate = value.CreatedDate,
                CategoryName = value.Category.Name,
                ArticleWriterFullName = value.AppUser.Name + " " + value.AppUser.Surname
            };
        }
    }
}
