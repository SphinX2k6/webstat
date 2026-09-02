using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A8 RID: 17576
	[EnumExtensions]
	public enum ESpecialValue
	{
		// Token: 0x0401A556 RID: 107862
		[EnumStringMember("___undefined___")]
		Undefined,
		// Token: 0x0401A557 RID: 107863
		[EnumStringMember("___NaN___")]
		NaN,
		// Token: 0x0401A558 RID: 107864
		[EnumStringMember("___Infinity___")]
		Infinity,
		// Token: 0x0401A559 RID: 107865
		[EnumStringMember("___-Infinity___")]
		InfinityNegative,
		// Token: 0x0401A55A RID: 107866
		[EnumStringMember("___BI___")]
		BigInt,
		// Token: 0x0401A55B RID: 107867
		[EnumStringMember("___1B___")]
		BooleanTrue,
		// Token: 0x0401A55C RID: 107868
		[EnumStringMember("___0B___")]
		BooleanFalse
	}
}
