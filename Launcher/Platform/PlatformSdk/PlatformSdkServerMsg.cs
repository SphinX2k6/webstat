using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045BD RID: 17853
	[EnumExtensions]
	public enum PlatformSdkServerMsg
	{
		// Token: 0x0401A9C3 RID: 108995
		[EnumStringMember("HttpFail")]
		BadHttp,
		// Token: 0x0401A9C4 RID: 108996
		[EnumStringMember("PsnAuthFail")]
		PsnAuthFail
	}
}
