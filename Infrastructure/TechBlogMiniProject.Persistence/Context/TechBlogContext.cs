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
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-FV06R42;initial Catalog=TechBlogDB; " +
			"integrated Security=true; TrustServerCertificate=true;");
		}

		public DbSet<Category> Categories { get; set; }
	}
}
