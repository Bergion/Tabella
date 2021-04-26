using Cabinet.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Infrastructure.EntityConfigurations
{
	public class DocumentAccessEntityTypeConfiguration
		: IEntityTypeConfiguration<DocumentAccess>
	{
		public void Configure(EntityTypeBuilder<DocumentAccess> builder)
		{
			builder.HasKey(a => new { a.DocumentID, a.OrganizationID });
		}
	}
}
