using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004568 RID: 17768
	public class RequestEmailCodeResponse
	{
		// Token: 0x0401A8D0 RID: 108752
		public bool IfSuccess;

		// Token: 0x0401A8D1 RID: 108753
		public int Code;

		// Token: 0x0401A8D2 RID: 108754
		[Nullable(1)]
		public string Msg = "";
	}
}
