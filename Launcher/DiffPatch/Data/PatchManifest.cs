using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004643 RID: 17987
	[NullableContext(1)]
	[Nullable(0)]
	[JsonConverter(typeof(PatchManifestConverter))]
	public class PatchManifest
	{
		// Token: 0x0401ABA1 RID: 109473
		public List<ResFileInfo> BaseFiles = new List<ResFileInfo>();

		// Token: 0x0401ABA2 RID: 109474
		public List<ResFileInfo> PatchFiles = new List<ResFileInfo>();

		// Token: 0x0401ABA3 RID: 109475
		public Dictionary<string, List<PatchInfo>> BaseDiffMap = new Dictionary<string, List<PatchInfo>>();

		// Token: 0x0401ABA4 RID: 109476
		public Dictionary<string, List<PatchInfo>> CurDiffMap = new Dictionary<string, List<PatchInfo>>();

		// Token: 0x0401ABA5 RID: 109477
		public Dictionary<string, List<PatchInfo>> RevertMap = new Dictionary<string, List<PatchInfo>>();
	}
}
