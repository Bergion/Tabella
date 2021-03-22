using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Cabinet.Storage.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cabinet.API.Controllers
{
	[Route("api/document")]
	[ApiController]
	public class DocumentsController : ControllerBase
	{
		private readonly IDocumentService _documentService;

		public DocumentsController(IDocumentService documentService)
		{
			_documentService = documentService;
		}

		// POST api/document
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CreateDocumentsAsync([FromForm] AggregatedDocumentInputModel documentsInputModel)
		{
			if (!ModelState.IsValid || documentsInputModel.Files is null)
			{
				return BadRequest("Invalid parameters");
			}

			var documents = documentsInputModel.Files.Select(f => new DocumentWithFileInputModel
			{
				File = f,
				OrganizationID = documentsInputModel.OrganizationID,
				DocumentTypeID = documentsInputModel.DocumentTypeID,
			});
			IEnumerable<IResult<Document>> result;
			try
			{
				result = await _documentService.CreateDocumentsAsync(documents);
			}
			catch (Exception e)
			{
				return BadRequest("Unable to create document");
			}

			return Ok(result);
		}
	}
}
