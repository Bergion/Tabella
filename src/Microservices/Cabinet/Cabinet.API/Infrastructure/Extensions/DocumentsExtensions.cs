using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Infrastructure.Extensions
{
	public static class DocumentsExtensions
	{
		public static IQueryable<Document> Filter(this IQueryable<Document> d, DocumentsFilter filter)
		{
			if (filter.OrganizationID is { } orgId)
			{
				d.Where(x => x.OrganizationID == orgId);
			}

			if (filter.DocTypeID is not null && filter.DocTypeID.Any())
			{
				d.Where(x => filter.DocTypeID.Contains(x.DocumentTypeID));
			}

			if (filter.FolderID is { } folderId)
			{
				d.Include(d => d.DocumentAccesses)
					.Where(d => d.DocumentAccesses.Any(da => da.FolderID == folderId));
			}

			d.Include(d => d.DocumentType)
				.Include(d => d.Originals);

			return d;
		}
	}
}
