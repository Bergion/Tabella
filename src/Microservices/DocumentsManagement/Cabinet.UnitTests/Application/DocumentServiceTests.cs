using Cabinet.API.Infrastructure;
using Cabinet.API.Models;
using Cabinet.API.Services;
using Microsoft.EntityFrameworkCore;
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
		private DbContextOptions<CabinetContext> _dbOptions;

		[SetUp]
		public void Setup()
		{
			Directory.CreateDirectory(_testDirectory);
			_dbOptions = new DbContextOptionsBuilder<CabinetContext>()
				.UseInMemoryDatabase(databaseName: "in-memory")
				.Options;
		}

		[TearDown]
		public void CleanUp()
		{
			var files = Directory.GetFiles(_testDirectory);
			foreach (string file in files)
			{
				File.Delete(file);
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

		private byte[] getFakeFile()
		{
			return new byte[] { 37, 80, 68, 70, 45, 207, 206, 201 };
		}
	}
}
