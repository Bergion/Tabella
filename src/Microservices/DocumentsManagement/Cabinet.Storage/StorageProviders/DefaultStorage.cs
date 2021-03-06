using Cabinet.Storage.Abstractions;
using System.Threading.Tasks;
using System;
using System.IO;

namespace Cabinet.Storage
{
	public class DefaultStorage : IStorage
	{
		private readonly StorageOptions _options;

		public DefaultStorage(StorageOptions options)
		{
			_options = options;
		}

		public string DownloadObjectAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UploadObjectAsync(string name, byte[] file)
		{
			var path = Path.Combine(_options.Source, name);
			try
			{
				await File.WriteAllBytesAsync(path, file);
			}
			catch (Exception)
			{
				// log
				return false;
			}

			return true;
		}
	}
}
