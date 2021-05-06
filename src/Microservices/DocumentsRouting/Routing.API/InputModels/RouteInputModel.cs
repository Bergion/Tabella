using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.InputModels
{
	public class RouteInputModel
	{
		public Guid DocumentID { get; set; }

		public int OrganizationOwnerID { get; set; }

		public List<RecipientInputModel> Recipients { get; set; }

		public bool IsValid 
		{
			get => OrganizationOwnerID > 0
				&& DocumentID != Guid.Empty
				&& Recipients is { }
				&& Recipients.Any()
				&& Recipients.All(r => r.IsValid);
		}
	}
}
