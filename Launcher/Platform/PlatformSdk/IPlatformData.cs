using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004559 RID: 17753
	[NullableContext(1)]
	[Nullable(0)]
	public class IPlatformData
	{
		// Token: 0x0401A88E RID: 108686
		public string projectId;

		// Token: 0x0401A88F RID: 108687
		public string channelId;

		// Token: 0x0401A890 RID: 108688
		public string platform;

		// Token: 0x0401A891 RID: 108689
		public string version;

		// Token: 0x0401A892 RID: 108690
		public string sdkVersion;

		// Token: 0x0401A893 RID: 108691
		public string sdkServerVersion;

		// Token: 0x0401A894 RID: 108692
		public IPlatformReleaseData Development;

		// Token: 0x0401A895 RID: 108693
		public IPlatformReleaseData PreRelease;

		// Token: 0x0401A896 RID: 108694
		public IPlatformReleaseData Release;
	}
}
