using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Managers.Options
{
	/// <summary>
	/// Specifies options for file requirements
	/// </summary>
	public class OriginalOptions
	{
		/// <summary>
		/// Maximal file size. Defaults to 50 mb
		/// </summary>
		public int MaxFileSize { get; set; } = 52428800;
	}
}
