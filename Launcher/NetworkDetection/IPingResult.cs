using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045D6 RID: 17878
	public class IPingResult
	{
		// Token: 0x0401AA52 RID: 109138
		[Nullable(1)]
		public string IpAddress = "";

		// Token: 0x0401AA53 RID: 109139
		public float Time;

		// Token: 0x0401AA54 RID: 109140
		public int ResponseState;
	}
}
