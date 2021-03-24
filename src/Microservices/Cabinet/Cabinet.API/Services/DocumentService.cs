using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cabinet.API.Managers;
using Cabinet.API.Infrastructure;
using Cabinet.API.Infrastructure.Exceptions;
using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Cabinet.API.ViewModels;
using Cabinet.API.Infrastructure.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
			_documentManager.AutoSaveChanges = false;
		}

		public async Task<IEnumerable<IResult<Document>>> CreateDocumentsAsync(IEnumerable<DocumentWithFileInputModel> documentsModels)
		{
			if (documentsModels is null)
			{
				throw new ArgumentNullException(nameof(documentsModels));
			}

			var results = new List<IResult<Document>>();
			foreach (var documentModel in documentsModels)
			{
				var document = (Document)documentModel;
				document.ID = Guid.NewGuid();
				// TODO: normal default type determinant
				document.DocumentTypeID = document.DocumentTypeID == 0 ? 1 : document.DocumentTypeID;
				try
				{
					await _documentManager.CreateAsync(document);
					await _documentManager.AddOriginalAsync(document, 
						new Original
						{
							File = documentModel.File,
							ForSign = true
						});
					results.Add(Result.Ok(document));
				}
				catch (CabinetDomainException e)
				{
					results.Add((IResult<Document>)Result.Fail(
						$"Unable to save file {documentModel.File.FileName} " + e.Message));
				}
				catch(Exception e)
				{
					// log
					results.Add((IResult<Document>)Result.Fail(
						$"Unable to save file {documentModel.File.FileName}"));
				}
			}

			await _context.SaveChangesAsync();

			return results;
		}

		public async Task<PaginatedItemsViewModel<Document>> GetDocumentsPaginatedAsync(
			DocumentsFilter parameters,
			int pageSize,
			int pageIndex)
		{
			var documentsQuery = _context.Documents.Filter(parameters);
			var totalCount = await documentsQuery.LongCountAsync();
			var documentsOnPage = await documentsQuery
				.Skip(pageSize * pageIndex)
				.Take(pageSize)
				.ToListAsync();

			var model = new PaginatedItemsViewModel<Document>(
				pageIndex, pageSize, totalCount, documentsOnPage);

			return model;
		}
	}
}
