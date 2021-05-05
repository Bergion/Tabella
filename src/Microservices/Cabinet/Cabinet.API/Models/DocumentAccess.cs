using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class DocumentAccess
	{
		public int OrganizationID { get; set; }

		public Guid DocumentID { get; set; }

		public Document Document { get; set; }
	}
}
