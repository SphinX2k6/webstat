using System;

// Token: 0x02002B7A RID: 11130
public interface ISurvivorsExitViewParams
{
	// Token: 0x17001CDA RID: 7386
	// (get) Token: 0x0601629A RID: 90778
	bool IsExternal { get; }

	// Token: 0x17001CDB RID: 7387
	// (get) Token: 0x0601629B RID: 90779
	int Batch { get; }

	// Token: 0x17001CDC RID: 7388
	// (get) Token: 0x0601629C RID: 90780
	int MaxBatch { get; }
}
