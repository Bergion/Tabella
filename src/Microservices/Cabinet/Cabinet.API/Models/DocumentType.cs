using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class DocumentType
	{
		public int ID { get; set; }

		public string UniqueName { get; set; }

		public string Name { get; set; }

		public IEnumerable<Document> Documents { get; set; }
	}
}
