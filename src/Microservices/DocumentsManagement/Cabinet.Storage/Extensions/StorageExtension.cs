using Cabinet.Storage.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cabinet.Storage
{
	public static class StorageExtension
	{
		public static void AddFileStorage(this IServiceCollection services)
		{
			services.AddTransient<IStorage, DefaultStorage>();
		}
	}
}
