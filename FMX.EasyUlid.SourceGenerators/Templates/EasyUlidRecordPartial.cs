using FMX.EasyUlid.SourceGenerators.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMX.EasyUlid.SourceGenerators.Templates
{
	public partial class EasyUlidRecord
	{
		public EasyUlidSource Model { get; set; }

        public EasyUlidRecord(EasyUlidSource model)
        {
			Model = model;
        }
    }
}
