using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020016D6 RID: 5846
internal sealed class WheelTowerNewSubViewGeneralInfo : ActivitySubViewGeneralInfo
{
	// Token: 0x0600A25A RID: 41562 RVA: 0x002ACAEF File Offset: 0x002AACEF
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
