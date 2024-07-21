using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Commands.CategoryCommands;
using TechBlogMiniProject.Application.Repositories.CategoryRepositories;
using TechBlogMiniProject.Domain.Entities;

namespace TechBlogMiniProject.Application.Features.Mediatr.Handlers.CategoryHandlers
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
	{
		private readonly ICategoryWriteRepository _categoryWriteRepository;

		public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
		{
			_categoryWriteRepository = categoryWriteRepository;
		}

		public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			await _categoryWriteRepository.AddAsync(new Category
			{
				Name = request.Name,
			});
		}
	}
}
