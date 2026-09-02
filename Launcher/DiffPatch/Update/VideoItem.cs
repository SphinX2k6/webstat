using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CSharpScript.Launcher.Util.Json;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x0200462F RID: 17967
	[NullableContext(1)]
	[Nullable(0)]
	public class VideoItem
	{
		// Token: 0x0401AB55 RID: 109397
		public string PakName = "";

		// Token: 0x0401AB56 RID: 109398
		[JsonConverter(typeof(TsBigIntJsonConverter))]
		public long PakSize;

		// Token: 0x0401AB57 RID: 109399
		public string PakHash = "";

		// Token: 0x0401AB58 RID: 109400
		public string SigName = "";

		// Token: 0x0401AB59 RID: 109401
		[JsonConverter(typeof(TsBigIntJsonConverter))]
		public long SigSize;

		// Token: 0x0401AB5A RID: 109402
		public string SigHash = "";
	}
}
