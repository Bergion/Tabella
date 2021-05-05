using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Cabinet.API.ViewModels;
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
	[Route("cabinet-api/v1/[controller]")]
	[ApiController]
	public class DocumentsController : ControllerBase
	{
		private readonly IDocumentService _documentService;

		public DocumentsController(IDocumentService documentService)
		{
			_documentService = documentService;
		}

		// Get cabinet-api/v1/documents?pageSize=50&pageIndex=0
		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<ActionResult<PaginatedItemsViewModel<Document>>> GetDocumentsAsync([FromQuery] DocumentsFilter filter,
			int pageSize = 50, int pageIndex = 0)
		{
			if (!filter.IsValid)
			{
				return BadRequest();
			}

			var documents = await _documentService.GetDocumentsPaginatedAsync(filter, pageSize, pageIndex);
			return Ok(documents);
		}

		// POST cabinet-api/v1/documents
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
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

			return Created(nameof(CreateDocumentsAsync), result);
		}
	}
}
