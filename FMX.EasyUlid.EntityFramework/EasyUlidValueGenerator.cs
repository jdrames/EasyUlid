using FMX.EasyUlid.Core;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace FMX.EasyUlid.EntityFramework
{
	public class EasyUlidValueGenerator<TEasyUlid> : ValueGenerator<TEasyUlid>
		where TEasyUlid : IEasyUlid<TEasyUlid>
	{
		public override bool GeneratesTemporaryValues => false;

		public override TEasyUlid Next(EntityEntry entry)
		{
			return TEasyUlid.New();
		}
	}
}
