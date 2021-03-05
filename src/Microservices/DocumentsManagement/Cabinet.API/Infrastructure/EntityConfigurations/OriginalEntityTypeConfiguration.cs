using Cabinet.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Infrastructure.EntityConfigurations
{
	public class OriginalEntityTypeConfiguration
		: IEntityTypeConfiguration<Original>
	{
		public void Configure(EntityTypeBuilder<Original> builder)
		{
			builder.ToTable("Original");
		}
	}
}
