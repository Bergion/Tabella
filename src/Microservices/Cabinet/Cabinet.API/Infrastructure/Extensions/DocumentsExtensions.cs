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
			if (filter.OrganizationOwnerID is { } orgOwnerId)
			{
				d = d.Where(x => x.OrganizationID == orgOwnerId);
			}

			if (filter.DocTypeID is { } && filter.DocTypeID.Any())
			{
				d = d.Where(x => filter.DocTypeID.Contains(x.DocumentTypeID));
			}

			if (filter.OrganizationReceiverID is { } orgReceiverId)
			{
				d = d.Include(d => d.DocumentAccesses)
					.Where(d => d.DocumentAccesses.Any(d => d.OrganizationID == orgReceiverId));
			}

			d = d.Include(d => d.DocumentType)
				.Include(d => d.Originals);
			return d;
		}
	}
}
