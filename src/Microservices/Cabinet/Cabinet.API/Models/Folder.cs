using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public enum FolderType
	{
		Default,
		Incoming,
		Outgoing
	}

	public class Folder
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public FolderType Type { get; set; }

		public int OrganizationID { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

		[System.Text.Json.Serialization.JsonIgnore]
		public IEnumerable<DocumentAccess> DocumentAccesses { get; set; }
	}
}
