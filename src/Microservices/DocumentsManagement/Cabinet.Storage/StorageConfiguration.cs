using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Storage
{
	public class StorageConfiguration
	{
		public string Source { get; set; }

		public StorageProvider Provider { get; set; }
	}
}
