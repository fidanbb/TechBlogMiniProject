using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Domain.Entities;

namespace TechBlogMiniProject.Application.Repositories.ArticleRepositories
{
    public interface IArticleReadRepository:IReadRepository<Article>
    {
        //Task<IQueryable<Article>> GetAllArticlesWithIncludes(bool tracking = true);

        //Task<IQueryable<Article>> GetRecent4ArticlesWithIncludes(bool tracking = true);
    }
}
