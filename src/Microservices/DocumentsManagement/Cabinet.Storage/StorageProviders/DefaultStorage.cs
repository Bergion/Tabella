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
			Source = _options.Source;
		}

		public string Source { get; }

		public string DownloadObjectAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<string> UploadObjectAsync(string path, byte[] file)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				throw new ArgumentNullException(nameof(path));
			}
			string fullPath = Path.Combine(_options.Source, path);
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
			await File.WriteAllBytesAsync(fullPath, file);
			
			return path;
		}
	}
}
