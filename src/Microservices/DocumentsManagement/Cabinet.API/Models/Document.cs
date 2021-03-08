using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Models
{
	public class Document
	{
		public Guid ID { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

		public int DocumentTypeID { get; set; }

		public DocumentType DocumentType { get; set; }

		public IEnumerable<Original> Originals { get; set; }
	}
}
