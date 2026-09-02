using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045AD RID: 17837
	[NullableContext(1)]
	[Nullable(0)]
	public class IRenewAccessTokenResponse
	{
		// Token: 0x0401A9A5 RID: 108965
		public IRenewAccessTokenResponseData data;

		// Token: 0x0401A9A6 RID: 108966
		public int code;

		// Token: 0x0401A9A7 RID: 108967
		public string msg;

		// Token: 0x0401A9A8 RID: 108968
		public long timestamp;
	}
}
