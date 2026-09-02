using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x0200452C RID: 17708
	public class SoVersion
	{
		// Token: 0x0401A7C3 RID: 108483
		public int CurVer = -1;

		// Token: 0x0401A7C4 RID: 108484
		[Nullable(1)]
		public Dictionary<int, VersionInfo> Versions = new Dictionary<int, VersionInfo>();

		// Token: 0x0401A7C5 RID: 108485
		public int UpdateTime = -1;
	}
}
