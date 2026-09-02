using System;
using System.Runtime.CompilerServices;

// Token: 0x020022A6 RID: 8870
[NullableContext(1)]
public interface IMotorLevelConditionData
{
	// Token: 0x170014A7 RID: 5287
	// (get) Token: 0x06010C41 RID: 68673
	// (set) Token: 0x06010C42 RID: 68674
	int ConditionId { get; set; }

	// Token: 0x170014A8 RID: 5288
	// (get) Token: 0x06010C43 RID: 68675
	// (set) Token: 0x06010C44 RID: 68676
	string ConditionTextId { get; set; }

	// Token: 0x170014A9 RID: 5289
	// (get) Token: 0x06010C45 RID: 68677
	// (set) Token: 0x06010C46 RID: 68678
	bool IsFinished { get; set; }

	// Token: 0x170014AA RID: 5290
	// (get) Token: 0x06010C47 RID: 68679
	// (set) Token: 0x06010C48 RID: 68680
	int AccessId { get; set; }

	// Token: 0x170014AB RID: 5291
	// (get) Token: 0x06010C49 RID: 68681
	// (set) Token: 0x06010C4A RID: 68682
	int AccessType { get; set; }

	// Token: 0x170014AC RID: 5292
	// (get) Token: 0x06010C4B RID: 68683
	// (set) Token: 0x06010C4C RID: 68684
	int RecommendQuestId { get; set; }
}
