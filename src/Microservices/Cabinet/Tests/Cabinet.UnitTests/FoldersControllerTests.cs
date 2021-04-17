using Cabinet.API.Controllers;
using Cabinet.API.Models;
using Cabinet.API.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.UnitTests
{
	public class FoldersControllerTests
	{
		private Mock<IFolderService> _folderServiceMock;

		[SetUp]
		public void Setup()
		{
			_folderServiceMock = new Mock<IFolderService>();
		}

		[Test]
		public async Task GetFolders_Success()
		{
			var fakeFolder1 = getFakeFolder(1);
			var fakeFolder2 = getFakeFolder(2);
			var orgToSearch = 1;
			IEnumerable<Folder> fakeGetResult = new List<Folder> { fakeFolder1 };
			_folderServiceMock.Setup(x => x.GetFoldersAsync(It.Is<int>((x) => x == orgToSearch)))
				.Returns(Task.FromResult(fakeGetResult));

			var foldersController = new FoldersController(_folderServiceMock.Object);
			var actionResult = await foldersController.GetDocumentsAsync(orgToSearch);

			var foldersResult = ((ObjectResult)actionResult.Result).Value as List<Folder>;
			Assert.AreEqual(1, foldersResult.Count);
			Assert.AreEqual(fakeFolder1.ID, foldersResult.First().ID);
		}

		private Folder getFakeFolder(int orgOwner)
		{
			return new Folder
			{
				OrganizationID = orgOwner,
				ID = new Random().Next(1, 10000)
			};
		}
	}
}
