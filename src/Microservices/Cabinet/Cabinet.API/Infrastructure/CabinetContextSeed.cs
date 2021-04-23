using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Cabinet.Storage.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Infrastructure
{
	public class CabinetContextSeed
	{
        private CabinetContext _context;
        private IWebHostEnvironment _env;
        private IStorage _storage;
        private ILogger<CabinetContextSeed> _logger;

        public CabinetContextSeed(CabinetContext context, IWebHostEnvironment env,IStorage storage, ILogger<CabinetContextSeed> logger)
		{
            _context = context;
            _env = env;
            _storage = storage;
            _logger = logger;
		}

		public async Task SeedAsync()
		{
            var policy = createPolicy(_logger, nameof(CabinetContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                var contentRootPath = _env.ContentRootPath;


                var folder = createOutgoingFolder();
                if (!_context.Folders.Any())
                {
                    await _context.Folders.AddAsync(folder);
                    await _context.SaveChangesAsync();
                }

                var docType = createDefaultDocumentType();
                if (!_context.DocumentTypes.Any())
                {
                    await _context.DocumentTypes.AddAsync(docType);
                    await _context.SaveChangesAsync();
                }

                if (!_context.Documents.Any())
                {
                    var documents = await seedDocuments(_context, _storage, folder.OrganizationID, docType.ID);
                    await setDocumentsAccess(documents, folder.ID);
                }
            });
        }

        private async Task setDocumentsAccess(IEnumerable<Document> documents, int folderID)
		{
            _context.DocumentsAccesses.AddRange(documents.Select(d => new DocumentAccess
            {
                DocumentID = d.ID,
                FolderID = folderID
            }));

            await _context.SaveChangesAsync();
		}
   
        private DocumentType createDefaultDocumentType()
        {
            return new DocumentType
            {
                UniqueName = "DEFAULT",
                Name = "Document"
            };
        }

        private Folder createOutgoingFolder()
		{
            return new Folder
            {
                Name = "Outgoing",
                Type = FolderType.Outgoing,
                OrganizationID = 1
            };
		}

        private async Task<IEnumerable<Document>> seedDocuments(CabinetContext _context,
            IStorage storage,
            int organizationID,
            int documentTypeID)
		{
            var files = Directory.GetFiles($"{_env.WebRootPath}/Seed");
			foreach (var file in files)
			{
                var document = new Document
                {
                    ID = Guid.NewGuid(),
                    OrganizationID = organizationID,
                    DocumentTypeID = documentTypeID
                };
                var fileInfo = new FileInfo(file);
                var originalId = Guid.NewGuid();
                var originalDescription = new OriginalDescription
                {
                    ID = originalId,
                    DocumentID = document.ID,
                    Extension = fileInfo.Extension,
                    FileName = Path.GetFileNameWithoutExtension(file),
                    ForSign = true,
                    Size = fileInfo.Length,
                    StoragePath = Path.Combine(document.ID.ToString(), $"{originalId}{fileInfo.Extension}"),
                    StorageSource = storage.Source
                };


                await storage.UploadObjectAsync(originalDescription.StoragePath, File.ReadAllBytes(file));
                _context.Documents.Add(document);
                _context.OriginalsDescriptions.Add(originalDescription);
            }

            await _context.SaveChangesAsync();
            return await _context.Documents.ToListAsync();
        }

       
        private AsyncRetryPolicy createPolicy(ILogger<CabinetContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }

    }
}
