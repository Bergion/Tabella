using Cabinet.API.Infrastructure;
using Cabinet.API.InputModels;
using Cabinet.API.Managers;
using Cabinet.API.Models;
using Cabinet.API.Services;
using Cabinet.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.UnitTests.Application
{
	[TestFixture]
	public class DocumentServiceTests
	{
		private const string _testDirectory = "/Document service tests";
		private DefaultStorage _storage;
		private CabinetContext _cabinetContext;
		private DocumentManager _documentManager;

		[SetUp]
		public void Setup()
		{
			Directory.CreateDirectory(_testDirectory);
			var storageOptions = new StorageOptions()
			{
				Source = _testDirectory
			};
			_storage = new DefaultStorage(storageOptions);
			_cabinetContext = new CabinetContext(new DbContextOptionsBuilder<CabinetContext>()
				.UseInMemoryDatabase(databaseName: "in-memory")
				.Options);
			_documentManager = new DocumentManager(_cabinetContext, _storage);
			Directory.CreateDirectory(_testDirectory);
		}

		[Test]
		public async Task CreateDocumentsAsync_Success()
		{
			IEnumerable<DocumentWithFileInputModel> documents = getFakeDocumentWithFile();
			var documentService = new DocumentService(_cabinetContext, _documentManager);

			var result = await documentService.CreateDocumentsAsync(documents);

			Assert.IsTrue(result.All(r => r.Success));
		}

		[Test]
		public void CreateDocumentsAsync_NullInputDocuments_ThrowsArgumentNullException()
		{
			var documentService = new DocumentService(_cabinetContext, _documentManager);

			Assert.ThrowsAsync<ArgumentNullException>(() => documentService.CreateDocumentsAsync(null));
		}

		[TearDown]
		public void CleanUp()
		{
			var directories = Directory.GetDirectories(_testDirectory);
			foreach (string dir in directories)
			{
				var files = Directory.GetFiles(dir);
				foreach (var file in files)
				{
					File.Delete(file);
				}

				Directory.Delete(dir);
			}
			Directory.Delete(_testDirectory);
		}

		private IEnumerable<DocumentWithFileInputModel> getFakeDocumentWithFile()
		{
			var documents = new List<DocumentWithFileInputModel>();		
			documents.Add(new DocumentWithFileInputModel
			{
				File = TestHelper.GetFakeFile()
			});

			return documents;
		}

	}
}
