namespace FMX.EasyUlid.Core
{
	public interface IEasyUlid<T>
	{
		Ulid Value { get; init; }
		static abstract T Parse(string value);
		static abstract bool TryParse(string value, out T? ulidId);
		static abstract T New();
		string ToString();
	}
}
