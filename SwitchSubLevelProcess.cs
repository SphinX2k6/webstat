using System;
using System.Runtime.CompilerServices;

// Token: 0x020034A2 RID: 13474
[NullableContext(1)]
[Nullable(0)]
public class SwitchSubLevelProcess : SubLevelProcess
{
	// Token: 0x0601C6B7 RID: 116407 RVA: 0x00884493 File Offset: 0x00882693
	public SwitchSubLevelProcess(SwitchSubLevelParams param) : base(ESubLevelProcessType.SwitchSubLevel)
	{
	}

	// Token: 0x0400E4AA RID: 58538
	public SwitchSubLevelParams Params = param;
}
