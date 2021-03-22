using Cabinet.API.InputModels;
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

		public int OrganizationID { get; set; }

		public int DocumentTypeID { get; set; }

		public DocumentType DocumentType { get; set; }

		public IEnumerable<OriginalDescription> Originals { get; set; }

		public static explicit operator Document(DocumentInputModel model)
		{
			return new Document()
			{
				OrganizationID = model.OrganizationID,
				DocumentTypeID = model.DocumentTypeID
			};
		}
	}
}
