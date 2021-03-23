using Cabinet.API.Managers.Options;
using Cabinet.API.Infrastructure;
using Cabinet.API.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Cabinet.API.InputModels;
using Cabinet.Storage.Abstractions;

namespace Cabinet.API.Managers
{
	public class DocumentManager
	{
		private readonly CabinetContext _context;
		private readonly IStorage _storage;

		public DocumentManager(CabinetContext cabinetContext, IStorage storage)
		{
			_context = cabinetContext;
			_storage = storage;
		}

		public CabinetOptions Options { get; set; }

		/// <summary>
		/// Gets or sets a flag indicating if changes should be persisted.
		/// </summary>
		/// <value>
		/// True if changes should be automatically persisted, otherwise false.
		/// </value>
		public bool AutoSaveChanges { get; set; } = true;

		/// <summary>
		/// Persist changes
		/// </summary>
		/// <returns></returns>
		protected Task SaveChangesAsync()
		{
			return AutoSaveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
		}

		/// <summary>
		/// Create document
		/// </summary>
		/// <param name="document">Document instance</param>
		/// <returns></returns>
		public async Task<Document> CreateAsync(Document document)
		{
			// TODO: Document validation
			_context.Documents.Add(document);
			await SaveChangesAsync();

			return document;
		}

		/// <summary>
		/// Add original to document
		/// </summary>
		/// <param name="document">Document object</param>
		/// <param name="original">Uploadable original</param>
		/// <returns></returns>
		public async Task<OriginalDescription> AddOriginalAsync(Document document, Original original)
		{
			if (document is null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			if (original is null)
			{
				throw new ArgumentNullException(nameof(document));
			}

			// TODO: Original validation
			byte[] bytes;
			using (var ms = new MemoryStream())
			{
				await original.File.CopyToAsync(ms);
				bytes = ms.ToArray();
			}

			var id = Guid.NewGuid();
			var extension = Path.GetExtension(original.File.FileName);
			var path = Path.Combine(document.ID.ToString(), id.ToString()) + extension;
			await _storage.UploadObjectAsync(path, bytes);

			var originalFileName = Path.GetFileNameWithoutExtension(original.File.FileName);
			var originalDescription = new OriginalDescription
			{
				ID = id,
				FileName = originalFileName,
				Extension = extension,
				StorageSource = _storage.Source,
				StoragePath = path,
				ForSign = original.ForSign,
				Size = original.File.Length,
				DocumentID = document.ID
			};

			return await SaveOriginalDescriptionAsync(document, originalDescription);
		}

		protected async Task<OriginalDescription> SaveOriginalDescriptionAsync(
			Document document,
			OriginalDescription originalDescription)
		{
			// TODO: Validate original description
			_context.OriginalsDescriptions.Add(originalDescription);
			await SaveChangesAsync();

			return originalDescription;
		}

		public async Task ValidateDocumentAsync(Document document)
		{
		}

		public async Task ValidateOriginalAsync(Original file)
		{
		}

		public async Task ValidateOriginalDescriptionAsync(OriginalDescription originalDescription)
		{
		}
	}
}