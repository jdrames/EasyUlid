using FMX.EasyUlid.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Tracing;

namespace FMX.EasyUlid.Test.GeneratorTest
{
	public class UnitTest1
	{
		public static readonly string textSource = @"using FMX.EasyUlid.Core;

namespace SourceGeneratorTest.Test
{
	[EasyUlid]
	public partial record TestId { }
}";

		[EasyUlid]
		public partial record Initializer { }

		[Fact]
		public Task GeneratesSourceCorrectly()
		{
			return VerifyValue(textSource);
		}

		static Task VerifyValue(string source)
		{
			SyntaxTree tree = CSharpSyntaxTree.ParseText(source);
			var references = AppDomain.CurrentDomain.GetAssemblies()
				.Where(x => !x.IsDynamic)
				.Select(x => MetadataReference.CreateFromFile(x.Location))
				.Cast<MetadataReference>();

			CSharpCompilation compilation = CSharpCompilation.Create(assemblyName: "SourceGeneratorTests", [tree], references);

			var generator = new SourceGenerators.EasyUlidGenerator();

			GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
			driver = driver.RunGenerators(compilation);
			var result = driver.GetRunResult();
			return Verifier.Verify(driver).UseDirectory("Snapshots");
		}
	}
}