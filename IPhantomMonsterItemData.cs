using System;

// Token: 0x020027F4 RID: 10228
public interface IPhantomMonsterItemData : IUniversalSmallItemData<ERoleDevItemType>
{
	// Token: 0x170019DB RID: 6619
	// (get) Token: 0x06014318 RID: 82712
	// (set) Token: 0x06014319 RID: 82713
	int MonsterId { get; set; }

	// Token: 0x170019DC RID: 6620
	// (get) Token: 0x0601431A RID: 82714
	// (set) Token: 0x0601431B RID: 82715
	int QualityId { get; set; }

	// Token: 0x170019DD RID: 6621
	// (get) Token: 0x0601431C RID: 82716
	// (set) Token: 0x0601431D RID: 82717
	int RoleId { get; set; }
}
