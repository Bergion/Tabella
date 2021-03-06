using Cabinet.Storage.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cabinet.Storage
{
	public static class StorageExtension
	{
		public static void AddFileStorage(this IServiceCollection services, Action<StorageOptions> optionsAction)
		{
			var options = new StorageOptions();
			optionsAction(options);
			if (!options.IsValid)
			{
				throw new ArgumentException("Invalid storage source");
			}
			
			services.AddSingleton(options);
			services.AddTransient<IStorage, DefaultStorage>();
		}
	}
}
