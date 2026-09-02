using System;

// Token: 0x02002AE6 RID: 10982
internal class SurvivorsChooseData : ISurvivorsChooseData
{
	// Token: 0x17001C80 RID: 7296
	// (get) Token: 0x06015F67 RID: 89959 RVA: 0x00619124 File Offset: 0x00617324
	public ESurvivorsObtainMode ObtainMode { get; }

	// Token: 0x06015F68 RID: 89960 RVA: 0x0061912C File Offset: 0x0061732C
	public SurvivorsChooseData(ESurvivorsObtainMode obtainMode)
	{
		this.ObtainMode = obtainMode;
	}
}
