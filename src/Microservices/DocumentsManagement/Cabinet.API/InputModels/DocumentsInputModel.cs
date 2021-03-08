using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class DocumentsInputModel
	{
		/// <summary>
		/// Organization creator
		/// </summary>
		public int OrganizationID { get; set; }

		/// <summary>
		/// Document type identifier 
		/// </summary>
		public int DocumentTypeID { get; set; }

		public IEnumerable<IFormFile> Files { get; set; }
	}
}
