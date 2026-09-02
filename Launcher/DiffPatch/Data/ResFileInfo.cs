using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004640 RID: 17984
	[NullableContext(1)]
	[Nullable(0)]
	[JsonConverter(typeof(ResFileInfoConverter))]
	public class ResFileInfo
	{
		// Token: 0x0401AB94 RID: 109460
		public string Name = "";

		// Token: 0x0401AB95 RID: 109461
		public long Size;

		// Token: 0x0401AB96 RID: 109462
		public string Hash = "";
	}
}
