using Microsoft.EntityFrameworkCore;
using Routing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.Infrastructure
{
	public class RoutingContext : DbContext
	{
		public RoutingContext(DbContextOptions<RoutingContext> options)
			: base(options)
		{
		}

		public DbSet<Recipient> Recipients { get; set; }
		public DbSet<Route> Routes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			
		}
	}
}
