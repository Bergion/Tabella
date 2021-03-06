using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Storage
{
	public enum StorageProvider
	{
		[EnumMember(Value = "InMemoryStorage")]
		InMemory,

		[EnumMember(Value = "GoogleCloudStorage")]
		GoogleCloud
	}

	public class StorageOptions
	{
		public StorageOptions()
		{
		}

		public string Source { get; set; }

		public StorageProvider Provider { get; set; }

		public bool IsValid
		{
			get => !string.IsNullOrWhiteSpace(Source);
		}

		public void Configure(StorageConfiguration config)
		{
			Source = config.Source;
			Provider = config.Provider;
		}
	}
}
