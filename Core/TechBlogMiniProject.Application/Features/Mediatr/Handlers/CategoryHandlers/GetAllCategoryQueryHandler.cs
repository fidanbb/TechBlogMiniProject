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
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryQueryResult>>
	{
		private readonly ICategoryReadRepository _categoryReadRepository;

		public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
		{
			_categoryReadRepository = categoryReadRepository;
		}

		public async Task<List<GetAllCategoryQueryResult>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
		{
			var categories =  _categoryReadRepository.GetAll();

			return categories.Select(x=>new GetAllCategoryQueryResult
			{
				CategoryID = x.CategoryID,
				Name = x.Name,
			}).ToList();
		}
	}
}
