using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x0200452E RID: 17710
	[NullableContext(2)]
	[Nullable(0)]
	public class VersionInfo
	{
		// Token: 0x0401A7C9 RID: 108489
		public int VerNum;

		// Token: 0x0401A7CA RID: 108490
		public bool IsPublished;

		// Token: 0x0401A7CB RID: 108491
		[Nullable(1)]
		public List<MobileFilter> Filters = new List<MobileFilter>();

		// Token: 0x0401A7CC RID: 108492
		public GrayInfo Gray;

		// Token: 0x0401A7CD RID: 108493
		public SoPatchFileInfo PatchInfo;
	}
}
