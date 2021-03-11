using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cabinet.API.Managers;
using Cabinet.API.Infrastructure;
using Cabinet.API.Infrastructure.Exceptions;
using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;

namespace Cabinet.API.Services
{
	public class DocumentService : IDocumentService
	{ 
		private readonly CabinetContext _context;
		private readonly DocumentManager _documentManager;

		public DocumentService(CabinetContext context, DocumentManager documentManager)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_documentManager = documentManager ?? throw new ArgumentNullException(nameof(documentManager));
		}

		public async Task<IEnumerable<IResult<Document>>> CreateDocuments(IEnumerable<DocumentWithFileInputModel> documentsModels)
		{
			var results = new List<IResult<Document>>();
			foreach (var documentModel in documentsModels)
			{
				var document = (Document)documentModel;
				document.ID = Guid.NewGuid();

				try
				{
					await _documentManager.CreateAsync(document);
					await _documentManager.AddOriginalAsync(document, new Original
					{
						File = documentModel.File,
						ForSign = true
					});
				}
				catch (CabinetDomainException e)
				{
					results.Add((IResult<Document>)Result.Fail(e.Message));
				}
				catch(Exception e)
				{
					// log
					results.Add((IResult<Document>)Result.Fail("Unable to save file"));
				}
			}

			return results;
		}
	}
}
