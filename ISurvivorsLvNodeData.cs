using System;

// Token: 0x02002B68 RID: 11112
public interface ISurvivorsLvNodeData
{
	// Token: 0x17001CCD RID: 7373
	// (get) Token: 0x06016247 RID: 90695
	int Lv { get; }

	// Token: 0x17001CCE RID: 7374
	// (get) Token: 0x06016248 RID: 90696
	bool IsImportant { get; }

	// Token: 0x17001CCF RID: 7375
	// (get) Token: 0x06016249 RID: 90697
	ESurvivorsLvState State { get; }
}
