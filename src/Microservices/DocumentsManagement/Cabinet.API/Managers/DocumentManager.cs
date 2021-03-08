using Cabinet.API.Infrastructure;
using Cabinet.API.Infrastructure.Exceptions;
using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Cabinet.Storage;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cabinet.API.Managers
{
	public class DocumentManager
	{
		/// <summary>
		/// 50 mb
		/// </summary>
		private const int _maxFileSize = 52428800;

		private readonly CabinetContext _context;
		private readonly DefaultStorage _storage;

		public DocumentManager(CabinetContext cabinetContext, DefaultStorage storage)
		{
			_context = cabinetContext;
			_storage = storage;
		}

		public Task<Document> CreateAsync(Document document)
		{
			if (document is null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			return null;
		}

		public async Task<Original> AddOriginalAsync(Document document, OriginalInputModel originalModel)
		{
			if (document is null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			if (originalModel is null)
			{
				throw new ArgumentNullException(nameof(originalModel));
			}

			if (originalModel.File.Length > _maxFileSize)
			{
				throw new CabinetDomainException($"File {originalModel.File.FileName} larger then 50 mb");
			}

			byte[] bytes;
			using (var ms = new MemoryStream())
			{
				await originalModel.File.CopyToAsync(ms);
				bytes = ms.ToArray();
			}

			var id = Guid.NewGuid();
			var extension = Path.GetExtension(originalModel.File.FileName);
			var path = Path.Combine(document.ID.ToString(), id.ToString()) + extension;
			await _storage.UploadObjectAsync(path, bytes);

			var originalFileName = Path.GetFileNameWithoutExtension(originalModel.File.FileName);
			var original = new Original
			{
				ID = id,
				FileName = originalFileName,
				Extension = extension,
				StorageSource = _storage.Source,
				StoragePath = path,
				DocumentID = document.ID
			};
			_context.Originals.Add(original);
			await _context.SaveChangesAsync();

			return original;
		}
	}
}