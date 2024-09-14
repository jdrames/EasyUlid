namespace FMX.EasyUlid.SourceGenerators.Models
{
	public readonly record struct EasyUlidSource
	{
		public readonly string Name;
		public readonly string Namespace;

		public EasyUlidSource(string name, string @namespace)
		{
			Name = name;
			Namespace = @namespace;
		}
	}
}
