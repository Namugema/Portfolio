using System;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core;

namespace Portfolio.Data
{
	public class PortfolioDbContext: DbContext
	{
		public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
			:base(options)
		{

		}
		public DbSet<Project> Projects { get; set; }
	}
}

