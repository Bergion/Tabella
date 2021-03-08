using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class OriginalInputModel
	{
		public IFormFile File { get; set; }
	}
}
