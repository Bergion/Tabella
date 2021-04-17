using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
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
	public class FoldersController : ControllerBase
	{
		private readonly IFolderService _folderService;

		public FoldersController(IFolderService folderService)
		{
			_folderService = folderService;
		}
		// Get cabinet-api/v1/folders?orgId=12067
		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<ActionResult<IEnumerable<Folder>>> GetDocumentsAsync([FromQuery] int orgId)
		{
			var documents = await _folderService.GetFoldersAsync(orgId);

			return Ok(documents);
		}

	}
}
