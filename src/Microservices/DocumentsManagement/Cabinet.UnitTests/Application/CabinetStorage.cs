using NUnit.Framework;
using Cabinet;
using Cabinet.Storage.Abstractions;
using Cabinet.Storage;
using System.IO;

namespace Cabinet.UnitTests
{
	[TestFixture]
	public class CabinetStorageTests
	{
		private IStorage _storage;
		private string _testDirectory;

		[SetUp]
		public void Setup()
		{
			_testDirectory = "/Cabinet storage test";
			Directory.CreateDirectory(_testDirectory);
			var options = new StorageOptions()
			{
				Destination = _testDirectory
			};
			_storage = new DefaultStorage(options);
		}

		[Test]
		public void Save_file_to_storage_success()
		{
			var fakeFileName = "textfile.txt";
			var fakeFile = getFakeFile();

			bool result = _storage.UploadObjectAsync(fakeFileName, fakeFile).Result;

			Assert.IsTrue(result);
		}

		[Test]
		public void Save_file_to_storage_duplicate_name_success()	
		{
			var fakeFileName = "textfile.txt";
			var fakeFile = getFakeFile();

			bool result1 = _storage.UploadObjectAsync(fakeFileName, fakeFile).Result;
			bool result2 = _storage.UploadObjectAsync(fakeFileName, fakeFile).Result;

			Assert.IsTrue(result1);
			Assert.IsTrue(result2);
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

		private byte[] getFakeFile()
		{
			return new byte[] { 37, 80, 68, 70, 45, 207, 206, 201 };
		}
	}
}