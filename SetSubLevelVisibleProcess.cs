using System;
using System.Runtime.CompilerServices;

// Token: 0x020034A3 RID: 13475
[NullableContext(1)]
[Nullable(0)]
public class SetSubLevelVisibleProcess : SubLevelProcess
{
	// Token: 0x0601C6B8 RID: 116408 RVA: 0x008844A3 File Offset: 0x008826A3
	public SetSubLevelVisibleProcess(SetSubLevelVisibleParams param) : base(ESubLevelProcessType.SetSubLevelVisible)
	{
	}

	// Token: 0x0400E4AB RID: 58539
	public SetSubLevelVisibleParams Params = param;
}
