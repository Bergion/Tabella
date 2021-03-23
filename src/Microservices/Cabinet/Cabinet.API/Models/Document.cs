using Cabinet.API.InputModels;
using System;
using System.Collections.Generic;

namespace Cabinet.API.Models
{
	public class Document
	{
		public Guid ID { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.Now;

		public int OrganizationID { get; set; }

		public int DocumentTypeID { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		public DocumentType DocumentType { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
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
