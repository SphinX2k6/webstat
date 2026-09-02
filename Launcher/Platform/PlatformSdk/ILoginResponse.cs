using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045A9 RID: 17833
	[NullableContext(1)]
	[Nullable(0)]
	public class ILoginResponse
	{
		// Token: 0x0401A990 RID: 108944
		public ILoginResponseData data;

		// Token: 0x0401A991 RID: 108945
		public int code;

		// Token: 0x0401A992 RID: 108946
		public string msg;

		// Token: 0x0401A993 RID: 108947
		public long timestamp;
	}
}
