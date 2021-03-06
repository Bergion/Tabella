using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class DocumentInputModel
	{
		public int DocumentTypeId { get; set; }

		public IEnumerable<IFormFile> Files { get; set; }
	}
}
