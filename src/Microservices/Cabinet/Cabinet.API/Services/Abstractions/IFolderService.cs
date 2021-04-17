using Cabinet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Services.Abstractions
{
	public interface IFolderService
	{
		Task<IEnumerable<Folder>> GetFoldersAsync(int orgId);
	}
}
