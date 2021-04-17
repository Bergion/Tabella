using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class Folder
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public int OrganizationID { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

		[System.Text.Json.Serialization.JsonIgnore]
		public IEnumerable<Document> Documents { get; set; }
	}
}
