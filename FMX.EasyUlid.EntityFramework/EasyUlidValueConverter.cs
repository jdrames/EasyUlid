using FMX.EasyUlid.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FMX.EasyUlid.EntityFramework
{

	public class EasyUlidValueConverter<TEasyUlid> : ValueConverter<TEasyUlid, string>
		where TEasyUlid : IEasyUlid<TEasyUlid>
	{
		private static readonly ConverterMappingHints _hints = new ConverterMappingHints(size: 26);

		public EasyUlidValueConverter() : this(null)
		{

		}

		public EasyUlidValueConverter(ConverterMappingHints? mappingHints = null) : base(
			convertToProviderExpression: x => x.ToString(),
			convertFromProviderExpression: x => ToEasyUlid(x),
			mappingHints: _hints.With(mappingHints))
		{

		}

		private static TEasyUlid ToEasyUlid(string value)
		{
			return TEasyUlid.Parse(value);
		}
	}
}
