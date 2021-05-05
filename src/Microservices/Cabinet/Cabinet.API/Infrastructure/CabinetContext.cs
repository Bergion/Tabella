using Cabinet.API.Infrastructure.EntityConfigurations;
using Cabinet.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Infrastructure
{
	public class CabinetContext : DbContext
	{
		public CabinetContext(DbContextOptions<CabinetContext> options) 
			: base(options)
		{
		}
		public DbSet<Document> Documents { get; set; }
		public DbSet<DocumentType> DocumentTypes { get; set; }
		public DbSet<OriginalDescription> OriginalsDescriptions { get; set; }
		public DbSet<DocumentAccess> DocumentsAccesses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new DocumentEntityTypeConfiguration());
			builder.ApplyConfiguration(new DocumentTypeEntityTypeConfiguration());
			builder.ApplyConfiguration(new OriginalDescriptionEntityTypeConfiguration());
			builder.ApplyConfiguration(new DocumentAccessEntityTypeConfiguration());
		}
	}
}
