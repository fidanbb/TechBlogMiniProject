using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Repositories;
using TechBlogMiniProject.Application.Repositories.CategoryRepositories;
using TechBlogMiniProject.Domain.Entities;
using TechBlogMiniProject.Persistence.Context;

namespace TechBlogMiniProject.Persistence.Repositories.CategoryRepositories
{
	public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public CategoryWriteRepository(TechBlogContext context) : base(context)
		{
		}
	}
}
