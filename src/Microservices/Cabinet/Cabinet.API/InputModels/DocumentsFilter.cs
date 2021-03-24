using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class DocumentsFilter
	{
		public int? OrganizationID { get; set; }

		public int[] DocTypeID { get; set; }
	}
}
