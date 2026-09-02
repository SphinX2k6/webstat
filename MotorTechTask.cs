using System;
using System.Runtime.CompilerServices;

// Token: 0x020022AF RID: 8879
[NullableContext(1)]
[Nullable(0)]
public class MotorTechTask
{
	// Token: 0x170014BE RID: 5310
	// (get) Token: 0x06010C72 RID: 68722 RVA: 0x00497FCC File Offset: 0x004961CC
	// (set) Token: 0x06010C73 RID: 68723 RVA: 0x00497FD4 File Offset: 0x004961D4
	public MotorTechTaskNode[] TaskList { get; set; } = new MotorTechTaskNode[0];

	// Token: 0x170014BF RID: 5311
	// (get) Token: 0x06010C74 RID: 68724 RVA: 0x00497FDD File Offset: 0x004961DD
	// (set) Token: 0x06010C75 RID: 68725 RVA: 0x00497FE5 File Offset: 0x004961E5
	public int RewardedCount { get; set; }
}
