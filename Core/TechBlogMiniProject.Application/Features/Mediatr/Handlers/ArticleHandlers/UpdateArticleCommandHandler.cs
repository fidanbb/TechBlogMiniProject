using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Commands.ArticleCommands;
using TechBlogMiniProject.Application.Repositories.ArticleRepositories;
using TechBlogMiniProject.Domain.Entities;

namespace TechBlogMiniProject.Application.Features.Mediatr.Handlers.ArticleHandlers
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IArticleWriteRepository _articleWriteRepository;
        private readonly IArticleReadRepository _articleReadRepository;

        public UpdateArticleCommandHandler(IArticleWriteRepository articleWriteRepository, IArticleReadRepository articleReadRepository)
        {
            _articleWriteRepository = articleWriteRepository;
            _articleReadRepository = articleReadRepository;
        }

        public async Task Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var value = await _articleReadRepository.Table.AsNoTracking().FirstOrDefaultAsync(x => x.ArticleID == request.ArticleID);
            await _articleWriteRepository.UpdateAsync(new Article
            {
                ArticleID = value.ArticleID,
                CreatedDate = value.CreatedDate,
                Title = request.Title,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                CategoryID = request.CategoryID,
                AppUserId = request.AppUserId,
            });
        }
    }
}
