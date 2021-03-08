using Cabinet.API.Infrastructure;
using Cabinet.API.InputModels;
using Cabinet.API.Managers;
using Cabinet.API.Models;
using Cabinet.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cabinet.UnitTests.Application
{
	[TestFixture]
	public class DocumentManagerTest
	{
		private const string _testDirectory = "/Document manager tests";
		private StorageOptions _storageOptions;
		private DefaultStorage _storage;
		private DbContextOptions<CabinetContext> _dbOptions;

		[SetUp]
		public void Setup()
		{
			Directory.CreateDirectory(_testDirectory);
			_storageOptions = new StorageOptions()
			{
				Source = _testDirectory
			};
			_storage = new DefaultStorage(_storageOptions);
			_dbOptions = new DbContextOptionsBuilder<CabinetContext>()
				.UseInMemoryDatabase(databaseName: "in-memory")
				.Options;
		}

		[Test]
		public async Task AddOriginal_Success()
		{
			var cabinetContext = new CabinetContext(_dbOptions);
			var fakeDocument = getFakeDocument();
			var fakeOriginal = getFakeOriginal();

			var documentManager = new DocumentManager(cabinetContext, _storage);
			var original = await documentManager.AddOriginalAsync(fakeDocument, fakeOriginal);

			Assert.IsNotNull(original);
			Assert.AreEqual(fakeDocument.ID, original.DocumentID);
			Assert.IsTrue(File.Exists(Path.Combine(_testDirectory, original.StoragePath)));
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

		private Document getFakeDocument()
		{
			return new Document
			{
				ID = Guid.NewGuid()
			};
		}

		private OriginalInputModel getFakeOriginal()
		{
			var fileName = "test.pdf";
			var name = "testFile";
			var stream = new MemoryStream(getFakeFile());
			return new OriginalInputModel()
			{
				File = new FormFile(stream, 0, stream.Length, name, fileName)
			};
		}

		private byte[] getFakeFile()
		{
			return new byte[] { 37, 80, 68, 70, 45, 207, 206, 201 };
		}
	}
}
