using System.ComponentModel;
using System.Globalization;

namespace FMX.EasyUlid.Core
{
	public class EasyUlidTypeConverter<T> : TypeConverter
		where T : IEasyUlid<T>
	{
		public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
		{
			return value switch
			{
				string str => T.Parse(str),
				_ => base.ConvertFrom(context, culture, value)
			};
		}

		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
		{
			return destinationType == typeof(string) ? value!.ToString() : base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
