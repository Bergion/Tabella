using Common.Types.Abstractions;
using Routing.API.InputModels;
using Routing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.Services.Abstractions
{
	public interface IRouteService
	{
		Task<IResult<Route>> CreateRouteAsync(RouteInputModel route);
		Task<IEnumerable<Route>> GetRoutesAsync(RouteSearchParameters searchParameters);
 	}
}
