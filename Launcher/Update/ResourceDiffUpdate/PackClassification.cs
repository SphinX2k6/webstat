using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044D4 RID: 17620
	[NullableContext(1)]
	[Nullable(0)]
	public class PackClassification
	{
		// Token: 0x0401A688 RID: 108168
		public List<ResPackageInfo> MinPacks = new List<ResPackageInfo>();

		// Token: 0x0401A689 RID: 108169
		public List<ResPackageInfo> MaxPacks = new List<ResPackageInfo>();

		// Token: 0x0401A68A RID: 108170
		public long MinSize;

		// Token: 0x0401A68B RID: 108171
		public long MaxSize;
	}
}
