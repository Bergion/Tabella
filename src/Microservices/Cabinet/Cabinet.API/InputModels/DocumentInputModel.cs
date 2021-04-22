using Cabinet.API.Models;
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

		/// <summary>
		/// Folder identifier
		/// </summary>
		public int FolderID { get; set; }
	}

	public class DocumentWithFileInputModel : DocumentInputModel
	{
		public IFormFile File { get; set; }
	}

	public class AggregatedDocumentInputModel : DocumentInputModel
	{
		public IEnumerable<IFormFile> Files { get; set; }
	}
}
