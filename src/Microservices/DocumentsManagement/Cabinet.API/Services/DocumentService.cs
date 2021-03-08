using Cabinet.API.Infrastructure;
using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Services
{
	public class DocumentService : IDocumentService
	{ 
		private readonly CabinetContext _context;

		public DocumentService(CabinetContext context)
		{
			_context = context ?? throw new ArgumentNullException();
		}

		public IEnumerable<IResult<Document>> CreateDocuments(DocumentsInputModel documentModel)
		{
			var results = new List<IResult<Document>>();
			foreach (IFormFile file in documentModel.Files)
			{

			}

			return results;
		}
	}
}
