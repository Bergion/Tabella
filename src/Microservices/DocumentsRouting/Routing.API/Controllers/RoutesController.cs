using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routing.API.InputModels;
using Routing.API.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Routing.API.Controllers
{
	[Route("routing-api/v1/[controller]")]
	[ApiController]
	public class RoutesController : ControllerBase
	{
		private readonly IRouteService _routeService;

		public RoutesController(IRouteService routeService)
		{
			_routeService = routeService;
		}

		// POST routing-api/v1/routes
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CreateRouteAsync(RouteInputModel routeInput)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid parameters");
			}

			var route = await _routeService.CreateRouteAsync(routeInput);
			return Created(nameof(CreateRouteAsync), route);
		}
	}
}
