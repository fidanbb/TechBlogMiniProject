using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Domain.Entities;

namespace TechBlogMiniProject.Persistence.Context
{
	public class TechBlogContext: IdentityDbContext<AppUser>
	{
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //	optionsBuilder.UseSqlServer("Server=DESKTOP-FV06R42;initial Catalog=TechBlogDB; " +
        //	"integrated Security=true; TrustServerCertificate=true;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL8006.site4now.net;Initial Catalog=db_aab54c_fidantechblogdb;User Id=db_aab54c_fidantechblogdb_admin;Password=Fidan1234_");
        }

        public DbSet<Category> Categories { get; set; }
		public DbSet<Article> Articles { get; set; }
	}
}
