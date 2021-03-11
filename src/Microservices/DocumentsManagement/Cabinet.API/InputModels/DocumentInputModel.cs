using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class DocumentInputModel
	{
		/// <summary>
		/// Organization creator
		/// </summary>
		public int OrganizationID { get; set; }

		/// <summary>
		/// Document type identifier 
		/// </summary>
		public int DocumentTypeID { get; set; }
	}

	public class DocumentWithFileInputModel : DocumentInputModel
	{
		public IFormFile File { get; set; }
	}

	public class AggregatedDocumentInputModel : DocumentInputModel
	{
		public IEnumerable<IFormFile> File { get; set; }
	}
}
