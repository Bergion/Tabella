using Common.Types.Abstractions;

namespace Common.Types
{
	public class Result : IResult
	{
		public bool Success { get; }

		public string ErrorMessage { get; }

		protected Result(bool success, string error)
		{
			Success = success;
			ErrorMessage = error;
		}

		public static IResult<T> Ok<T>(T value)
		{
			return new Result<T>(value, true, null);
		}

		public static IResult Fail(string error)
		{
			return new Result(false, error);
		}
	}

	public class Result<T> : Result, IResult<T>
	{
		protected internal Result(T value, bool success, string error)
			: base(success, error)
		{
			Value = value;
		}

		public T Value { get; }
	}
}
