using System.Runtime.CompilerServices;

namespace FMX.EasyUlid.Test.GeneratorTest
{
	public static class VerifyModuleInitializer
	{
		[ModuleInitializer]
		public static void Init()
		{
			VerifySourceGenerators.Initialize();
		}
	}
}
