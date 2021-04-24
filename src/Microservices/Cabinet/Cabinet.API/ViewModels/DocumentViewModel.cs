using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.ViewModels
{
	public class DocumentViewModel
	{
		public Guid ID { get; set; }

		public string Name { get; set; }

		public string Extension { get; set; }

		public string DocumentType { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

	}
}
