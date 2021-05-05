using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Services.Abstractions
{
	public interface IDocumentService
	{
		Task<PaginatedItemsViewModel<DocumentViewModel>> GetDocumentsPaginatedAsync(
			DocumentsFilter parameters, 
			int pageSize,
			int pageIndex);

		Task<IEnumerable<IResult<Document>>> CreateDocumentsAsync(
			IEnumerable<DocumentWithFileInputModel> documentsModels);
	}
}
