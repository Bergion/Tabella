using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.InputModels
{
	public class Original
	{
		public IFormFile File { get; set; }

		public bool ForSign { get; set; }
	}
}
