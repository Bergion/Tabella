using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Storage
{
	public class StorageOptions
	{
		public string Destination { get; set; }

		public bool IsValid
		{
			get => !string.IsNullOrWhiteSpace(Destination);
		}

		public StorageOptions()
		{
		}
	}
}
