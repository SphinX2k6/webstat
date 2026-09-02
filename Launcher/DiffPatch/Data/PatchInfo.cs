using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CSharpScript.Launcher.Util.Json;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004642 RID: 17986
	[NullableContext(1)]
	[Nullable(0)]
	public class PatchInfo
	{
		// Token: 0x0401AB99 RID: 109465
		public bool Group;

		// Token: 0x0401AB9A RID: 109466
		public string GroupName = "";

		// Token: 0x0401AB9B RID: 109467
		public ResFileInfo DiffFile;

		// Token: 0x0401AB9C RID: 109468
		[JsonConverter(typeof(TsBigIntJsonConverter))]
		public long NewRefSize;

		// Token: 0x0401AB9D RID: 109469
		public HashSet<string> NewFiles = new HashSet<string>();

		// Token: 0x0401AB9E RID: 109470
		public HashSet<string> DelFiles = new HashSet<string>();

		// Token: 0x0401AB9F RID: 109471
		public HashSet<string> ModFiles = new HashSet<string>();

		// Token: 0x0401ABA0 RID: 109472
		public HashSet<IdenticalPair> SameFiles = new HashSet<IdenticalPair>();
	}
}
