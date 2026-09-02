using System;
using System.Runtime.CompilerServices;

// Token: 0x02003192 RID: 12690
[NullableContext(2)]
[Nullable(0)]
public class NpcSitOnChairParams : INpcSitOnChairParams
{
	// Token: 0x170023C1 RID: 9153
	// (get) Token: 0x0601A506 RID: 107782 RVA: 0x007BFA73 File Offset: 0x007BDC73
	// (set) Token: 0x0601A507 RID: 107783 RVA: 0x007BFA7B File Offset: 0x007BDC7B
	public int ChairEntityId { get; set; }

	// Token: 0x170023C2 RID: 9154
	// (get) Token: 0x0601A508 RID: 107784 RVA: 0x007BFA84 File Offset: 0x007BDC84
	// (set) Token: 0x0601A509 RID: 107785 RVA: 0x007BFA8C File Offset: 0x007BDC8C
	public string MontagePath { get; set; }

	// Token: 0x170023C3 RID: 9155
	// (get) Token: 0x0601A50A RID: 107786 RVA: 0x007BFA95 File Offset: 0x007BDC95
	// (set) Token: 0x0601A50B RID: 107787 RVA: 0x007BFA9D File Offset: 0x007BDC9D
	[Nullable(1)]
	public Func<bool> InterruptCondition { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170023C4 RID: 9156
	// (get) Token: 0x0601A50C RID: 107788 RVA: 0x007BFAA6 File Offset: 0x007BDCA6
	// (set) Token: 0x0601A50D RID: 107789 RVA: 0x007BFAAE File Offset: 0x007BDCAE
	public Action Finish { get; set; }

	// Token: 0x170023C5 RID: 9157
	// (get) Token: 0x0601A50E RID: 107790 RVA: 0x007BFAB7 File Offset: 0x007BDCB7
	// (set) Token: 0x0601A50F RID: 107791 RVA: 0x007BFABF File Offset: 0x007BDCBF
	public Action Abort { get; set; }

	// Token: 0x170023C6 RID: 9158
	// (get) Token: 0x0601A510 RID: 107792 RVA: 0x007BFAC8 File Offset: 0x007BDCC8
	// (set) Token: 0x0601A511 RID: 107793 RVA: 0x007BFAD0 File Offset: 0x007BDCD0
	public int[] TeleportEffect { get; set; }
}
