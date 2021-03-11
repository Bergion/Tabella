using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Services
{
	public interface IDocumentCreator
	{
		Task<IEnumerable<IResult<Document>>> CreateDocuments(IEnumerable<DocumentWithFileInputModel> documentModel);
	}

	
}
