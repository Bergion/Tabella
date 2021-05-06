using Common.Types;
using Common.Types.Abstractions;
using Microsoft.EntityFrameworkCore;
using Routing.API.Infrastructure;
using Routing.API.Infrastructure.Extensions;
using Routing.API.InputModels;
using Routing.API.Models;
using Routing.API.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.Services
{
	public class RouteService : IRouteService
	{
		private readonly RoutingContext _context;

		public RouteService(RoutingContext context)
		{
			_context = context;
		}

		public async Task<IResult<Route>> CreateRouteAsync(RouteInputModel routeModel)
		{
			if (!routeModel.IsValid)
			{
				return (IResult<Route>)Result.Fail("Invalid route");
			}

			var route = (Route)routeModel;
			_context.Routes.Add(route);
			await _context.SaveChangesAsync();

			foreach (var recipientModel in routeModel.Recipients)
			{
				var recipient = (Recipient)recipientModel;
				recipient.Status = Status.Pending;
				recipient.RouteID = route.ID;

				_context.Recipients.Add(recipient);
			}

			await _context.SaveChangesAsync();
			return Result.Ok(route);
		}

		public async Task<IEnumerable<Route>> GetRoutesAsync(RouteSearchParameters searchParameters)
		{
			var routes = await _context.Routes.Search(searchParameters).ToListAsync();
			return routes;
		}
	}
}
