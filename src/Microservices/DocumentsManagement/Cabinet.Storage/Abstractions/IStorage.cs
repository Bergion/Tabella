using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Storage.Abstractions
{
	public interface IStorage
	{
		Task<bool> UploadObjectAsync(string name, byte[] file);

		string DownloadObjectAsync();
	}
}
