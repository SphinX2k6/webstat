using System;
using System.Runtime.CompilerServices;

// Token: 0x020022A7 RID: 8871
[NullableContext(1)]
[Nullable(0)]
public class MotorLevelConditionData : IMotorLevelConditionData
{
	// Token: 0x170014AD RID: 5293
	// (get) Token: 0x06010C4D RID: 68685 RVA: 0x00497E99 File Offset: 0x00496099
	// (set) Token: 0x06010C4E RID: 68686 RVA: 0x00497EA1 File Offset: 0x004960A1
	public int ConditionId { get; set; }

	// Token: 0x170014AE RID: 5294
	// (get) Token: 0x06010C4F RID: 68687 RVA: 0x00497EAA File Offset: 0x004960AA
	// (set) Token: 0x06010C50 RID: 68688 RVA: 0x00497EB2 File Offset: 0x004960B2
	public string ConditionTextId { get; set; }

	// Token: 0x170014AF RID: 5295
	// (get) Token: 0x06010C51 RID: 68689 RVA: 0x00497EBB File Offset: 0x004960BB
	// (set) Token: 0x06010C52 RID: 68690 RVA: 0x00497EC3 File Offset: 0x004960C3
	public bool IsFinished { get; set; }

	// Token: 0x170014B0 RID: 5296
	// (get) Token: 0x06010C53 RID: 68691 RVA: 0x00497ECC File Offset: 0x004960CC
	// (set) Token: 0x06010C54 RID: 68692 RVA: 0x00497ED4 File Offset: 0x004960D4
	public int AccessId { get; set; }

	// Token: 0x170014B1 RID: 5297
	// (get) Token: 0x06010C55 RID: 68693 RVA: 0x00497EDD File Offset: 0x004960DD
	// (set) Token: 0x06010C56 RID: 68694 RVA: 0x00497EE5 File Offset: 0x004960E5
	public int AccessType { get; set; }

	// Token: 0x170014B2 RID: 5298
	// (get) Token: 0x06010C57 RID: 68695 RVA: 0x00497EEE File Offset: 0x004960EE
	// (set) Token: 0x06010C58 RID: 68696 RVA: 0x00497EF6 File Offset: 0x004960F6
	public int RecommendQuestId { get; set; }
}
