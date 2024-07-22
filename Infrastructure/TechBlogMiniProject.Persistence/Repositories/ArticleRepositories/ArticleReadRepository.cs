using Microsoft.EntityFrameworkCore;
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
    public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
    {
        public ArticleReadRepository(TechBlogContext context) : base(context)
        {
        }

        //public async Task<IQueryable<Article>> GetAllArticlesWithIncludes(bool tracking = true)
        //{
        //    using var context = new TechBlogContext();

        //    var query = context.Articles.Include(x=>x.Category).Include(x=>x.AppUser).AsQueryable();
        //    if (!tracking)
        //        query = query.AsNoTracking();
        //    return query;

        //}

        //public async Task<IQueryable<Article>> GetRecent4ArticlesWithIncludes(bool tracking = true)
        //{
        //    using var context = new TechBlogContext();

        //    var query = context.Articles.Include(x => x.Category).Include(x => x.AppUser).Take(4).AsQueryable();
        //    if (!tracking)
        //        query = query.AsNoTracking();
        //    return query;
        //}
    }
}
