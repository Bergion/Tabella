﻿using Cabinet.API.Infrastructure;
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
		private DbContextOptions<CabinetContext> _dbOptions;
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
			_dbOptions = new DbContextOptionsBuilder<CabinetContext>()
				.UseInMemoryDatabase(databaseName: "in-memory")
				.Options;
			_documentManager = new DocumentManager(new CabinetContext(_dbOptions), _storage);
			Directory.CreateDirectory(_testDirectory);
		}

		[Test]
		public async Task CreateDocumentsAsync_Success()
		{
			var cabinetContext = new CabinetContext(_dbOptions);
			IEnumerable<DocumentWithFileInputModel> documents = getFakeDocumentWithFile();
			var documentService = new DocumentService(cabinetContext, _documentManager);

			var result = await documentService.CreateDocumentsAsync(documents);

			Assert.IsTrue(result.All(r => r.Success));
		}

		[Test]
		public void CreateDocumentsAsync_NullInputDocuments_ThrowsArgumentNullException()
		{
			var cabinetContext = new CabinetContext(_dbOptions);
			var documentService = new DocumentService(cabinetContext, _documentManager);

			Assert.ThrowsAsync<ArgumentNullException>(() => documentService.CreateDocumentsAsync(null));
		}

		[Test]
		public async Task GetDocumentsPaginatedAsync_Success()
		{
			var cabinetContext = new CabinetContext(_dbOptions);
			var docType = TestHelper.GetFakeDocumentType();
			cabinetContext.DocumentTypes.Add(docType);
			cabinetContext.SaveChanges();
			var document = TestHelper.GetFakeDocument();
			document.DocumentTypeID = docType.ID;
			cabinetContext.Documents.Add(document);
			cabinetContext.SaveChanges();
			var searchParameters = new DocumentsFilter
			{
				OrganizationOwnerID = document.OrganizationID
			};
			var documentService = new DocumentService(cabinetContext, _documentManager);

			var documents = await documentService.GetDocumentsPaginatedAsync(searchParameters, 50, 0);

			Assert.AreEqual(1, documents.Data.Count());
			Assert.AreEqual(document.ID, documents.Data.First().ID);
		}

		[Test]
		public async Task GetDocumentsPaginatedAsync_ByOrganizationReceiver_Success()
		{
			var cabinetContext = new CabinetContext(_dbOptions);
			var docType = TestHelper.GetFakeDocumentType();
			cabinetContext.DocumentTypes.Add(docType);
			cabinetContext.SaveChanges();
			var document = TestHelper.GetFakeDocument();
			document.DocumentTypeID = docType.ID;
			cabinetContext.Documents.Add(document);
			cabinetContext.SaveChanges();
			var searchParameters = new DocumentsFilter
			{
				OrganizationReceiverID = document.OrganizationID
			};
			var documentService = new DocumentService(cabinetContext, _documentManager);

			var documents = await documentService.GetDocumentsPaginatedAsync(searchParameters, 50, 0);

			Assert.AreEqual(0, documents.Data.Count());
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
			var cabinetContext = new CabinetContext(_dbOptions);
			cabinetContext.Documents.RemoveRange(cabinetContext.Documents);
			cabinetContext.DocumentTypes.RemoveRange(cabinetContext.DocumentTypes);
			cabinetContext.DocumentsAccesses.RemoveRange(cabinetContext.DocumentsAccesses);
			cabinetContext.SaveChanges();
		}

		private IEnumerable<DocumentWithFileInputModel> getFakeDocumentWithFile()
		{
			var documents = new List<DocumentWithFileInputModel>
			{
				new DocumentWithFileInputModel
				{
					File = TestHelper.GetFakeFile(),
				}
			};

			return documents;
		}

	}
}
