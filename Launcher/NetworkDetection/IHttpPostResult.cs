using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045D7 RID: 17879
	public class IHttpPostResult
	{
		// Token: 0x0401AA55 RID: 109141
		public bool Success;

		// Token: 0x0401AA56 RID: 109142
		public int Code;

		// Token: 0x0401AA57 RID: 109143
		[Nullable(1)]
		public string Data = "";
	}
}
