using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045AB RID: 17835
	[NullableContext(1)]
	[Nullable(0)]
	public class IGetAccessTokenResponse
	{
		// Token: 0x0401A99F RID: 108959
		public IGetAccessTokenResponseData data;

		// Token: 0x0401A9A0 RID: 108960
		public int code;

		// Token: 0x0401A9A1 RID: 108961
		public string msg;

		// Token: 0x0401A9A2 RID: 108962
		public long timestamp;
	}
}
