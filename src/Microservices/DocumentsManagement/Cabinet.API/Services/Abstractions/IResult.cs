using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Services.Abstractions
{
	public interface IResult
	{
		bool Success { get; }

		string ErrorMessage { get; }
	}

	public interface IResult<T> : IResult
	{
		T Value { get; }
	}
}
