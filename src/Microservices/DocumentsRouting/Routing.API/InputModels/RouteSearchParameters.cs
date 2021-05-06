using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.API.InputModels
{
	public class RouteSearchParameters
	{
		public Guid? DocumentID { get; set; }

		public int? RouteID { get; set; }
	}
}
