using Cabinet.API.InputModels;
using Cabinet.API.Models;
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
		private readonly IStorage _storage;

		public DocumentsController(IStorage storage)
		{
			_storage = storage;
		}

		// POST api/document
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.Forbidden)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public Task<IActionResult> CreateDocumentAsync([FromForm] DocumentInputModel documents)
		{
			return null;
		}
	}
}
