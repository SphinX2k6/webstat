using System;

// Token: 0x020030ED RID: 12525
public interface IPerformActionBase
{
	// Token: 0x17002311 RID: 8977
	// (get) Token: 0x06019E85 RID: 106117
	// (set) Token: 0x06019E86 RID: 106118
	int Id { get; set; }

	// Token: 0x17002312 RID: 8978
	// (get) Token: 0x06019E87 RID: 106119
	// (set) Token: 0x06019E88 RID: 106120
	EPerformMode Mode { get; set; }

	// Token: 0x17002313 RID: 8979
	// (get) Token: 0x06019E89 RID: 106121
	// (set) Token: 0x06019E8A RID: 106122
	EPerformGroup Group { get; set; }

	// Token: 0x17002314 RID: 8980
	// (get) Token: 0x06019E8B RID: 106123
	// (set) Token: 0x06019E8C RID: 106124
	bool IsValid { get; set; }

	// Token: 0x17002315 RID: 8981
	// (get) Token: 0x06019E8D RID: 106125
	bool IsAtomic { get; }

	// Token: 0x17002316 RID: 8982
	// (get) Token: 0x06019E8E RID: 106126
	// (set) Token: 0x06019E8F RID: 106127
	bool IsPersistent { get; set; }

	// Token: 0x06019E90 RID: 106128
	void Execute();

	// Token: 0x06019E91 RID: 106129
	void Interrupt();
}
