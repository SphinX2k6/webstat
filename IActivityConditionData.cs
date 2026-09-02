using System;
using System.Runtime.CompilerServices;

// Token: 0x02001174 RID: 4468
[NullableContext(1)]
public interface IActivityConditionData
{
	// Token: 0x170009DD RID: 2525
	// (get) Token: 0x06007594 RID: 30100
	// (set) Token: 0x06007595 RID: 30101
	int ConditionId { get; set; }

	// Token: 0x170009DE RID: 2526
	// (get) Token: 0x06007596 RID: 30102
	// (set) Token: 0x06007597 RID: 30103
	string ConditionTextId { get; set; }

	// Token: 0x170009DF RID: 2527
	// (get) Token: 0x06007598 RID: 30104
	// (set) Token: 0x06007599 RID: 30105
	bool IsFinished { get; set; }

	// Token: 0x170009E0 RID: 2528
	// (get) Token: 0x0600759A RID: 30106
	// (set) Token: 0x0600759B RID: 30107
	int AccessId { get; set; }

	// Token: 0x170009E1 RID: 2529
	// (get) Token: 0x0600759C RID: 30108
	// (set) Token: 0x0600759D RID: 30109
	int AccessType { get; set; }
}
