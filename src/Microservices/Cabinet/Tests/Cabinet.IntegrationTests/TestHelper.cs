using Cabinet.API.InputModels;
using Cabinet.API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.UnitTests
{
	internal static class TestHelper
	{
		internal static byte[] GetFakeFileBytes()
		{
			return new byte[] { 37, 80, 68, 70, 45, 207, 206, 201 };
		}

		internal static Document GetFakeDocument()
		{
			return new Document
			{
				ID = Guid.NewGuid()
			};
		}

		internal static Original GetFakeOriginal()
		{
			return new Original
			{
				File = GetFakeFile(),
				ForSign = true
			};
		}

		internal static IFormFile GetFakeFile()
		{
			var fileName = Guid.NewGuid().ToString() + ".pdf";
			var name = "testFile";
			var stream = new MemoryStream(GetFakeFileBytes());
			return new FormFile(stream, 0, stream.Length, name, fileName);
		}
	}
}
