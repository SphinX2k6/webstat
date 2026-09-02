using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003476 RID: 13430
[NullableContext(1)]
[Nullable(0)]
public class SkillButtonDebugInfo
{
	// Token: 0x0601C504 RID: 115972 RVA: 0x0087885C File Offset: 0x00876A5C
	public SkillButtonDebugInfo(int entityHandleId, List<string> button)
	{
		this.EntityHandleId = entityHandleId;
		this.Button = button;
	}

	// Token: 0x0400E3BC RID: 58300
	public int EntityHandleId;

	// Token: 0x0400E3BD RID: 58301
	public List<string> Button;
}
