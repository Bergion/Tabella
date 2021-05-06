using Microsoft.EntityFrameworkCore;
using Routing.API.InputModels;
using Routing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.Infrastructure.Extensions
{
	public static class RouteExtensions
	{
		public static IQueryable<Route> Search(this IQueryable<Route> r, RouteSearchParameters parameters)
		{
			if (parameters.RouteID is { } routeId)
			{
				r = r.Where(r => r.ID == routeId);
			}

			if (parameters.DocumentID is { } docId)
			{
				r = r.Where(r => r.DocumentID == docId);
			}

			r = r.Include(r => r.Recipients);
			return r;
		}
	}
}
