using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x0200465D RID: 18013
	[EnumExtensions]
	public enum EResType
	{
		// Token: 0x0401AC0D RID: 109581
		Launcher,
		// Token: 0x0401AC0E RID: 109582
		Resource,
		// Token: 0x0401AC0F RID: 109583
		Lang,
		// Token: 0x0401AC10 RID: 109584
		Video,
		// Token: 0x0401AC11 RID: 109585
		[EnumStringMember("Option")]
		Optional
	}
}
