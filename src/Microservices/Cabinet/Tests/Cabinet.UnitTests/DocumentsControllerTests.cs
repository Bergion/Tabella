using Moq;
using NUnit.Framework;
using Cabinet.API.Services.Abstractions;
using Cabinet.API.Models;
using System;
using Cabinet.API.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cabinet.API.Services;
using Cabinet.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Common.Types.Abstractions;
using Common.Types;

namespace Cabinet.UnitTests
{
	public class DocumentsControllerTests
	{
		private Mock<IDocumentService> _documentServiceMock;

		[SetUp]
		public void Setup()
		{
			_documentServiceMock = new Mock<IDocumentService>();
		}

		[Test]
		public void CreateDocumentsAsync_Success()
		{
			var fakeDocument = getFakeDocument();
			var documentsInputModel = new AggregatedDocumentInputModel
			{
				Files = new List<IFormFile>(),
				DocumentTypeID = fakeDocument.DocumentTypeID
			};
			IEnumerable<IResult<Document>> fakeCreateResult = new List<IResult<Document>> { Result.Ok(fakeDocument) };
			_documentServiceMock.Setup(x => x.CreateDocumentsAsync(It.IsAny<IEnumerable<DocumentWithFileInputModel>>()))
				.Returns(Task.FromResult(fakeCreateResult));

			var documentController = new DocumentsController(_documentServiceMock.Object);
			var actionResult = documentController.CreateDocumentsAsync(documentsInputModel);
			
			var documentsResult = ((ObjectResult)actionResult.Result).Value as List<IResult<Document>>;
			Assert.AreEqual(1, documentsResult.Count);
			Assert.AreEqual(fakeDocument.ID, documentsResult.First().Value.ID);
		}

		[Test]
		public void CreateDocumentsAsync_NullFiles_BadRequest()
		{
			var fakeDocument = getFakeDocument();
			var documentsInputModel = new AggregatedDocumentInputModel
			{
				DocumentTypeID = fakeDocument.DocumentTypeID
			};
			IEnumerable<IResult<Document>> fakeCreateResult = new List<IResult<Document>> { Result.Ok(fakeDocument) };
			_documentServiceMock.Setup(x => x.CreateDocumentsAsync(It.IsAny<IEnumerable<DocumentWithFileInputModel>>()))
				.Returns(Task.FromResult(fakeCreateResult));

			var documentController = new DocumentsController(_documentServiceMock.Object);
			var actionResult = documentController.CreateDocumentsAsync(documentsInputModel);

			Assert.AreEqual((int)System.Net.HttpStatusCode.BadRequest, (actionResult.Result as BadRequestObjectResult).StatusCode);
		}

		[Test]
		public void CreateDocumentsAsync_CatchException_BadRequest()
		{
			var fakeDocument = getFakeDocument();
			var documentsInputModel = new AggregatedDocumentInputModel
			{
				DocumentTypeID = fakeDocument.DocumentTypeID
			};
			IEnumerable<IResult<Document>> fakeCreateResult = new List<IResult<Document>> { Result.Ok(fakeDocument) };
			_documentServiceMock.Setup(x => x.CreateDocumentsAsync(It.IsAny<IEnumerable<DocumentWithFileInputModel>>()))
				.Throws(new Exception());

			var documentController = new DocumentsController(_documentServiceMock.Object);
			var actionResult = documentController.CreateDocumentsAsync(documentsInputModel);

			Assert.AreEqual((int)System.Net.HttpStatusCode.BadRequest, (actionResult.Result as BadRequestObjectResult).StatusCode);
		}

		private Document getFakeDocument()
		{
			return new Document
			{
				ID = Guid.NewGuid(),
				DocumentTypeID = 1
			};
		}
	}
}