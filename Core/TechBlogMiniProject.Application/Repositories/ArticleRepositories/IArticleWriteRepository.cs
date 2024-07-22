using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Domain.Entities;

namespace TechBlogMiniProject.Application.Repositories.ArticleRepositories
{
    public interface IArticleWriteRepository:IWriteRepository<Article>
    {
    }
}
