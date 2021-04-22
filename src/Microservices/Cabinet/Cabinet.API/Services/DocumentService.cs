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
				var result = await CreateDocumentAsync(documentModel);
				// TODO: move?
				if (result.Success)
				{
					_context.DocumentsAccesses.Add(new DocumentAccess
					{
						DocumentID = result.Value.ID,
						FolderID = documentModel.FolderID
					});
				}

				results.Add(result);
			}

			await _context.SaveChangesAsync();

			return results;
		}

		public async Task<IResult<Document>> CreateDocumentAsync(DocumentWithFileInputModel documentInputModel)
		{
			if (documentInputModel is null)
			{
				throw new ArgumentNullException(nameof(documentInputModel));
			}

			var document = (Document)documentInputModel;
			document.ID = Guid.NewGuid();
			document.DocumentTypeID = document.DocumentTypeID;
			try
			{
				await _documentManager.CreateAsync(document);
				await _documentManager.AddOriginalAsync(document,
					new Original
					{
						File = documentInputModel.File,
						ForSign = true
					});
				return Result.Ok(document);
			}
			catch (CabinetDomainException e)
			{
				return (IResult<Document>)Result.Fail(
					$"Unable to save file {documentInputModel.File.FileName} " + e.Message);
			}
			catch (Exception e)
			{
				// log
			}

			return (IResult<Document>)Result.Fail(
					$"Unable to save file {documentInputModel.File.FileName}");
		}

		public async Task<PaginatedItemsViewModel<Document>> GetDocumentsPaginatedAsync(
			DocumentsFilter parameters,
			int pageSize,
			int pageIndex)
		{
			var documentsQuery = _context.Documents.Filter(parameters);
			var totalCount = await documentsQuery.LongCountAsync();
			var documentsOnPage = await documentsQuery
				.OrderByDescending(d => d.CreationDate)
				.Skip(pageSize * pageIndex)
				.Take(pageSize)
				.ToListAsync();

			var model = new PaginatedItemsViewModel<Document>(
				pageIndex, pageSize, totalCount, documentsOnPage);

			return model;
		}
	}
}
