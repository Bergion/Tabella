
namespace Common.Types.Abstractions
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
