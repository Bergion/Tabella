using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Storage.Abstractions
{
	public interface IStorage
	{
		string Source { get; }

		/// <summary>
		/// Upload object (File) to storage
		/// </summary>
		/// <param name="path">Path on storage</param>
		/// <param name="file">File's bytes</param>
		/// <returns></returns>
		Task<string> UploadObjectAsync(string path, byte[] file);

		string DownloadObjectAsync();
	}
}
