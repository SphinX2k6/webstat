using System;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045D4 RID: 17876
	public enum EIcmpResponseStatus
	{
		// Token: 0x0401AA48 RID: 109128
		Success,
		// Token: 0x0401AA49 RID: 109129
		Timeout,
		// Token: 0x0401AA4A RID: 109130
		Unreachable,
		// Token: 0x0401AA4B RID: 109131
		Unresolvable,
		// Token: 0x0401AA4C RID: 109132
		InternalError,
		// Token: 0x0401AA4D RID: 109133
		NotImplemented
	}
}
