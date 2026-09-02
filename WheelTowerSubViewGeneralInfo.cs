using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001704 RID: 5892
internal sealed class WheelTowerSubViewGeneralInfo : ActivitySubViewGeneralInfo
{
	// Token: 0x0600A341 RID: 41793 RVA: 0x002B200C File Offset: 0x002B020C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	protected override ValueTuple<bool, string, long> GetTimeVisibleAndRemainTime()
	{
		return ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, ConfigMultiTextLang.GetLocalTextNew("WheelTower_ActivityLimitTimeText", null) ?? string.Empty);
	}
}
