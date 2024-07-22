using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Repositories.ArticleRepositories;
using TechBlogMiniProject.Domain.Entities;
using TechBlogMiniProject.Persistence.Context;

namespace TechBlogMiniProject.Persistence.Repositories.ArticleRepositories
{
    public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
    {
        public ArticleWriteRepository(TechBlogContext context) : base(context)
        {
        }
    }
}
