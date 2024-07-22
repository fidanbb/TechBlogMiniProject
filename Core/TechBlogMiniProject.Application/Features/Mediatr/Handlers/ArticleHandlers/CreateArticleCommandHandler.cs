using MediatR;
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
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand>
    {
        private readonly IArticleWriteRepository _articleWriteRepository;

        public CreateArticleCommandHandler(IArticleWriteRepository articleWriteRepository)
        {
            _articleWriteRepository = articleWriteRepository;
        }

        public async Task Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleWriteRepository.AddAsync(new Article
            {
                Title = request.Title,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                CreatedDate = DateTime.Now,
                CategoryID = request.CategoryID,
                AppUserId = request.AppUserId
            });
        }
    }
}
