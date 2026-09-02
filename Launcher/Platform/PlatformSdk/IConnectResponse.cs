using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200459B RID: 17819
	[NullableContext(1)]
	[Nullable(0)]
	public class IConnectResponse
	{
		// Token: 0x0401A94A RID: 108874
		public IConnectResponseData data;

		// Token: 0x0401A94B RID: 108875
		public int code;

		// Token: 0x0401A94C RID: 108876
		public string msg;

		// Token: 0x0401A94D RID: 108877
		public long timestamp;
	}
}
