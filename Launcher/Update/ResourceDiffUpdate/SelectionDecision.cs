using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044D8 RID: 17624
	[NullableContext(1)]
	[Nullable(0)]
	public class SelectionDecision
	{
		// Token: 0x0401A695 RID: 108181
		public long MinSize;

		// Token: 0x0401A696 RID: 108182
		public long MaxSize;

		// Token: 0x0401A697 RID: 108183
		public List<ResPackageInfo> MinPacks = new List<ResPackageInfo>();

		// Token: 0x0401A698 RID: 108184
		public List<ResPackageInfo> MaxPacks = new List<ResPackageInfo>();
	}
}
