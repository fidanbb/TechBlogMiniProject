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
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
	{
		private readonly ICategoryWriteRepository _categoryWriteRepository;
		private readonly ICategoryReadRepository _categoryReadRepository;

		public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
		{
			_categoryWriteRepository = categoryWriteRepository;
			_categoryReadRepository = categoryReadRepository;
		}
		public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _categoryReadRepository.GetByIdAsync(request.CategoryID);

			category.Name = request.Name;

			await _categoryWriteRepository.UpdateAsync(category);
		}
	}
}
