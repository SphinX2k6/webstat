using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045DF RID: 17887
	public class INetworkDetectionHttpResult : INetworkDetectionResult
	{
		// Token: 0x0401AA6A RID: 109162
		[Nullable(1)]
		public List<IHttpPostResult> Results = new List<IHttpPostResult>();
	}
}
