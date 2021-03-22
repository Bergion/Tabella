using NUnit.Framework;
using Cabinet;
using Cabinet.Storage.Abstractions;
using Cabinet.Storage;
using System.IO;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cabinet.UnitTests
{
	[TestFixture]
	public class CabinetStorageTests
	{
		private const string _testDirectory = "/Cabinet storage test";
		private StorageOptions _options;

		[SetUp]
		public void Setup()
		{
			Directory.CreateDirectory(_testDirectory);
			_options = new StorageOptions()
			{
				Source = _testDirectory
			};
		}

		[Test]
		public void UploadObjectAsync_Success()
		{
			var fakeFileName = "textfile.txt";
			var fakeFile = TestHelper.GetFakeFileBytes();
			var storage = new DefaultStorage(_options);
			string path = storage.UploadObjectAsync(fakeFileName, fakeFile).Result;

			Assert.IsTrue(!string.IsNullOrWhiteSpace(path));
			Assert.IsTrue(File.Exists(Path.Combine(_testDirectory, path)));
		}

		[Test]
		public void UploadObjectAsync_DuplicateName_Success()	
		{
			var fakeFileName = "textfile.txt";
			var fakeFile = TestHelper.GetFakeFileBytes();
			var storage = new DefaultStorage(_options);

			string path1 = storage.UploadObjectAsync(fakeFileName, fakeFile).Result;
			string path2 = storage.UploadObjectAsync(fakeFileName, fakeFile).Result;

			Assert.IsTrue(!string.IsNullOrWhiteSpace(path1));
			Assert.IsTrue(File.Exists(Path.Combine(_testDirectory, path1)));

			Assert.IsTrue(!string.IsNullOrWhiteSpace(path2));
			Assert.IsTrue(File.Exists(Path.Combine(_testDirectory, path2)));
		}

		[Test]
		public void UploadObjectAsync_EmptyFileName_Exception()
		{
			var fakeFile = TestHelper.GetFakeFileBytes();
			var storage = new DefaultStorage(_options);

			Assert.ThrowsAsync<ArgumentNullException>(() => storage.UploadObjectAsync("", fakeFile));
		}

		[Test]
		public void UploadObjectAsync_NullBytes_Exception()
		{
			var fakeFileName = "textfile.txt";
			var storage = new DefaultStorage(_options);

			Assert.ThrowsAsync<ArgumentNullException>(() => storage.UploadObjectAsync(fakeFileName, null));
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
	}
}