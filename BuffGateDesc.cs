using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F56 RID: 3926
public class BuffGateDesc : IBuffGateDesc
{
	// Token: 0x17000760 RID: 1888
	// (get) Token: 0x060062A4 RID: 25252 RVA: 0x00189C41 File Offset: 0x00187E41
	// (set) Token: 0x060062A5 RID: 25253 RVA: 0x00189C49 File Offset: 0x00187E49
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	public ValueTuple<string, List<string>> Desc { [return: Nullable(new byte[]
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

	// Token: 0x17000761 RID: 1889
	// (get) Token: 0x060062A6 RID: 25254 RVA: 0x00189C52 File Offset: 0x00187E52
	// (set) Token: 0x060062A7 RID: 25255 RVA: 0x00189C5A File Offset: 0x00187E5A
	public int BuffGateId { get; set; }

	// Token: 0x17000762 RID: 1890
	// (get) Token: 0x060062A8 RID: 25256 RVA: 0x00189C63 File Offset: 0x00187E63
	// (set) Token: 0x060062A9 RID: 25257 RVA: 0x00189C6B File Offset: 0x00187E6B
	public bool IsDropBuffGate { get; set; }
}
