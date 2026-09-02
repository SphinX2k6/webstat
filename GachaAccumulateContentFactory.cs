using System;
using System.Runtime.CompilerServices;

// Token: 0x02001CCA RID: 7370
[NullableContext(1)]
[Nullable(0)]
public static class GachaAccumulateContentFactory
{
	// Token: 0x0600D839 RID: 55353 RVA: 0x0039D4B4 File Offset: 0x0039B6B4
	public static GachaAccumulateBonusContentBase CreateBonusContent(int accumulateId)
	{
		EGachaAccumulateShowType showType = ConfigBase<GachaAccumulateConfig>.Instance.GetShowType(accumulateId);
		if (showType != EGachaAccumulateShowType.Default && showType == EGachaAccumulateShowType.Stage)
		{
			return new GachaAccumulateBonusViewContentStage();
		}
		return new GachaAccumulateBonusViewContent();
	}

	// Token: 0x0600D83A RID: 55354 RVA: 0x0039D4E0 File Offset: 0x0039B6E0
	public static GachaAccumulateTipsContentBase CreateTipsContent(int accumulateId)
	{
		EGachaAccumulateShowType showType = ConfigBase<GachaAccumulateConfig>.Instance.GetShowType(accumulateId);
		if (showType != EGachaAccumulateShowType.Default && showType == EGachaAccumulateShowType.Stage)
		{
			return new GachaAccumulateTipsItemContentStage();
		}
		return new GachaAccumulateTipsItemContent();
	}
}
