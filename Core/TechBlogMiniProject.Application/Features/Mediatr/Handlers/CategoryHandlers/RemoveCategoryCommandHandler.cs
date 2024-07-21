using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Commands.CategoryCommands;
using TechBlogMiniProject.Application.Repositories.CategoryRepositories;

namespace TechBlogMiniProject.Application.Features.Mediatr.Handlers.CategoryHandlers
{
	public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
	{
		private readonly ICategoryWriteRepository _categoryWriteRepository;
		private readonly ICategoryReadRepository _categoryReadRepository;

		public RemoveCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
		{
			_categoryWriteRepository = categoryWriteRepository;
			_categoryReadRepository = categoryReadRepository;
		}
		public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
		{
			var cateegory =await _categoryReadRepository.GetByIdAsync(request.Id);

			await _categoryWriteRepository.RemoveAsync(cateegory);
		}
	}
}
