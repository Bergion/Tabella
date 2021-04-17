using Cabinet.API.Infrastructure;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Services
{
	public class FolderService : IFolderService
	{
		private readonly CabinetContext _context;

		public FolderService(CabinetContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Folder>> GetFoldersAsync(int orgId)
		{
			var folders = await _context.Folders.Where(f => f.OrganizationID == orgId).ToListAsync();

			return folders;
		}
	}
}
