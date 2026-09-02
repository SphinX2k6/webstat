using System;
using System.Runtime.CompilerServices;

// Token: 0x0200146F RID: 5231
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewPlayerSupportTaskItemData : IActivityNewPlayerSupportTaskItemData
{
	// Token: 0x17000C25 RID: 3109
	// (get) Token: 0x06009257 RID: 37463 RVA: 0x002698E3 File Offset: 0x00267AE3
	// (set) Token: 0x06009258 RID: 37464 RVA: 0x002698EB File Offset: 0x00267AEB
	public ActivityNewPlayerSupportTaskData TaskData { get; set; }

	// Token: 0x17000C26 RID: 3110
	// (get) Token: 0x06009259 RID: 37465 RVA: 0x002698F4 File Offset: 0x00267AF4
	// (set) Token: 0x0600925A RID: 37466 RVA: 0x002698FC File Offset: 0x00267AFC
	public bool ShowDecoration { get; set; }
}
