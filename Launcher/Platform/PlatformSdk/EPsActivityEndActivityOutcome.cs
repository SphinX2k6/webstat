using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045C9 RID: 17865
	[EnumExtensions]
	public enum EPsActivityEndActivityOutcome
	{
		// Token: 0x0401AA16 RID: 109078
		[EnumStringMember("completed")]
		Completed,
		// Token: 0x0401AA17 RID: 109079
		[EnumStringMember("failed")]
		Failed,
		// Token: 0x0401AA18 RID: 109080
		[EnumStringMember("abandoned")]
		Abandoned
	}
}
