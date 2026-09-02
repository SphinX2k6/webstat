using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200009C RID: 156
public class TickEntityGroup
{
	// Token: 0x060003F4 RID: 1012 RVA: 0x00017956 File Offset: 0x00015B56
	public TickEntityGroup(int priority)
	{
		this.Priority = priority;
	}

	// Token: 0x040003CD RID: 973
	[Nullable(1)]
	public readonly Dictionary<int, Entity> Entities = new Dictionary<int, Entity>();

	// Token: 0x040003CE RID: 974
	public readonly int Priority;
}
