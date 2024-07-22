using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Commands.ArticleCommands;
using TechBlogMiniProject.Application.Repositories.ArticleRepositories;

namespace TechBlogMiniProject.Application.Features.Mediatr.Handlers.ArticleHandlers
{
    public class RemoveArticleCommandHandler : IRequestHandler<RemoveArticleCommand>
    {
        private readonly IArticleWriteRepository _articleWriteRepository;
        private readonly IArticleReadRepository _articleReadRepository;

        public RemoveArticleCommandHandler(IArticleWriteRepository articleWriteRepository, IArticleReadRepository articleReadRepository)
        {
            _articleWriteRepository = articleWriteRepository;
            _articleReadRepository = articleReadRepository;
        }
        public async Task Handle(RemoveArticleCommand request, CancellationToken cancellationToken)
        {
            var value = await _articleReadRepository.Table.AsNoTracking().FirstOrDefaultAsync(x => x.ArticleID == request.Id);

            await _articleWriteRepository.RemoveAsync(value);
        }

       
}
}
