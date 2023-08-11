using System;
using Microsoft.EntityFrameworkCore;
using RESTful_cs.Models;

namespace RESTful_cs.Context
{
	public class DatabaseContext : DbContext 
	{

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Account> Accounts { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}
	}
}

