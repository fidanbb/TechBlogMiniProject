﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Repositories;
using TechBlogMiniProject.Persistence.Context;

namespace TechBlogMiniProject.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class
	{
		private readonly TechBlogContext _context;

		public WriteRepository(TechBlogContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveAsync(T entity)
		{
			 Table.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			 Table.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
