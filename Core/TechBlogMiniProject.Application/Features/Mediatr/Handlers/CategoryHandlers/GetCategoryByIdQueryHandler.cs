using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Queries.CategoryQueries;
using TechBlogMiniProject.Application.Features.Mediatr.Results.CategoryResults;
using TechBlogMiniProject.Application.Repositories.CategoryRepositories;

namespace TechBlogMiniProject.Application.Features.Mediatr.Handlers.CategoryHandlers
{
	public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuey, GetCategoryByIdQueryResult>
	{
		private readonly ICategoryReadRepository _categoryReadRepository;

		public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository)
		{
			_categoryReadRepository = categoryReadRepository;
		}
		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuey request, CancellationToken cancellationToken)
		{
			var category = await _categoryReadRepository.GetByIdAsync(request.Id);

			return new GetCategoryByIdQueryResult
			{
				CategoryID = category.CategoryID,
				Name = category.Name,
			};
		}
	}
}
