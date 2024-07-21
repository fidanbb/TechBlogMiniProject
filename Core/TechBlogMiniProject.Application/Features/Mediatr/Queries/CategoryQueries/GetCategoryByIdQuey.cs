using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Features.Mediatr.Results.CategoryResults;

namespace TechBlogMiniProject.Application.Features.Mediatr.Queries.CategoryQueries
{
	public class GetCategoryByIdQuey:IRequest<GetCategoryByIdQueryResult>
	{
        public int Id { get; set; }

		public GetCategoryByIdQuey(int id)
		{
			Id = id;
		}
	}
}
