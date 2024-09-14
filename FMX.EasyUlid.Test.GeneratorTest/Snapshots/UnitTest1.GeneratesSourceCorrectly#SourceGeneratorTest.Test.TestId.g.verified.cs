﻿//HintName: SourceGeneratorTest.Test.TestId.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a FMX.EasyUlids.SourceGenerator
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using FMX.EasyUlid;
using FMX.EasyUlid.Core;
using System.ComponentModel;

namespace SourceGeneratorTest.Test
{
	[TypeConverter(typeof(EasyUlidTypeConverter<TestId>))]		
	public partial record TestId(Ulid Value) : IEasyUlid<TestId> {
		public static TestId New() => new(Ulid.NewUlid());
		public static TestId Parse(string input) => new(Ulid.Parse(input));
		public static bool TryParse(string input, out TestId? easyUlid)
		{
			if(!Ulid.TryParse(input, out var ulidId))
			{
				easyUlid = null;
				return false;
			}

			easyUlid = new(ulidId);
			return true;
		}

		public override string ToString() => Value.ToString();

		public static implicit operator string(TestId id) => id.ToString();
		public static implicit operator TestId(string input) => Parse(input);
	}	
}