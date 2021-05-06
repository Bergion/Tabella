using Routing.API.InputModels;
using System;
using System.Collections.Generic;

namespace Routing.API.Models
{
	public class Route
	{
		public int ID { get; set; }

		public Guid DocumentID { get; set; }

		public int OrganizationOwnerID { get; set; }

		public DateTime Created { get; set; } = DateTime.Now;

		public List<Recipient> Recipients { get; set; }

		public static explicit operator Route(RouteInputModel model)
		{
			return new Route()
			{
				DocumentID = model.DocumentID,
				OrganizationOwnerID = model.OrganizationOwnerID,
			};
		}
	}
}
