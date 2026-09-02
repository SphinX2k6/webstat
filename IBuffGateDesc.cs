using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F55 RID: 3925
public interface IBuffGateDesc
{
	// Token: 0x1700075D RID: 1885
	// (get) Token: 0x0600629E RID: 25246
	// (set) Token: 0x0600629F RID: 25247
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	ValueTuple<string, List<string>> Desc { [return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] set; }

	// Token: 0x1700075E RID: 1886
	// (get) Token: 0x060062A0 RID: 25248
	// (set) Token: 0x060062A1 RID: 25249
	int BuffGateId { get; set; }

	// Token: 0x1700075F RID: 1887
	// (get) Token: 0x060062A2 RID: 25250
	// (set) Token: 0x060062A3 RID: 25251
	bool IsDropBuffGate { get; set; }
}
