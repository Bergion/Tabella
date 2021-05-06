using Cabinet.API.Services.Abstractions;
using Common.Types.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Cabinet.API.Managers.Validators
{
	/// <summary>
	/// Provides an abstraction for file validation
	/// </summary>
	public interface IOriginalValidator
	{
		/// <summary>
		/// Validates the specified file
		/// </summary>
		/// <param name="manager"></param>
		/// <param name="file"></param>
		/// <returns></returns>
		Task<IResult> ValidateAsync(DocumentManager manager, IFormFile file);
	}

	public class OriginalValidator : IOriginalValidator
	{
		public Task<IResult> ValidateAsync(DocumentManager manager, IFormFile file)
		{
			if (manager is null)
			{
				throw new ArgumentNullException(nameof(manager));
			}

			if (file is null)
			{
				throw new ArgumentNullException(nameof(file));
			}

			return null;
		}

		//private async Task<IResult> validateOriginalSize(DocumentManager manager, IFormFile original)
		//{

		//}
	}
}
