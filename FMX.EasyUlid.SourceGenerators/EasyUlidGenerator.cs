using FMX.EasyUlid.SourceGenerators.Models;
using FMX.EasyUlid.SourceGenerators.Templates;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMX.EasyUlid.SourceGenerators
{
	[Generator]
	public class EasyUlidGenerator : IIncrementalGenerator
	{
		public void Initialize(IncrementalGeneratorInitializationContext context)
		{
			var easyUlidTypes = context.SyntaxProvider.ForAttributeWithMetadataName(
				"FMX.EasyUlid.Core.EasyUlidAttribute",
				predicate: static (s, _) => true,
				transform: static (ctx, _) => GetTypeToGenerate(ctx.SemanticModel, ctx.TargetNode))
				.Where(static i => i is not null);			

			context.RegisterSourceOutput(
				easyUlidTypes,
				static (spc, source) => Execute(source, spc));
		}

		static EasyUlidSource? GetTypeToGenerate(SemanticModel model, SyntaxNode node)
		{			
			if (model.GetDeclaredSymbol(node) is not INamedTypeSymbol easyUlid)
				return null;

			string name = easyUlid.Name;
			string nameSpace = easyUlid.ContainingNamespace.ToString();

			return new EasyUlidSource(name, nameSpace);
		}

		static void Execute(EasyUlidSource? source, SourceProductionContext context)
		{
			if(source is EasyUlidSource value)
			{
				var template = new EasyUlidRecord(value);
				string text = template.TransformText();

				context.AddSource(
					$"{value.Namespace}.{value.Name}.g.cs",
					SourceText.From(text, Encoding.UTF8));
			}
		}
	}
}
