using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001182 RID: 4482
public class AdvanceNoticeData : ActivityBaseData
{
	// Token: 0x0600761A RID: 30234 RVA: 0x001EE3EC File Offset: 0x001EC5EC
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		AdvertisingPageData advertisingPageInfo = data.AdvertisingPageInfo;
		if (advertisingPageInfo == null)
		{
			this.IsShow = false;
			this.UnlockTimeStamp = 0L;
			return;
		}
		this.IsShow = advertisingPageInfo.Show;
		this.UnlockTimeStamp = Singleton<MathUtils>.Instance.LongToNumber(advertisingPageInfo.PointTime);
	}

	// Token: 0x0600761B RID: 30235 RVA: 0x001EE435 File Offset: 0x001EC635
	public bool GetIsShow()
	{
		return this.IsShow;
	}

	// Token: 0x0600761C RID: 30236 RVA: 0x001EE43D File Offset: 0x001EC63D
	public void SetIsShow(bool isShow)
	{
		this.IsShow = isShow;
	}

	// Token: 0x0600761D RID: 30237 RVA: 0x001EE446 File Offset: 0x001EC646
	public override bool CheckIfInShowTime()
	{
		if (!AdvanceNoticeData.DebugFlag)
		{
			return this.IsShow && base.CheckIfInShowTime();
		}
		return base.CheckIfInShowTime();
	}

	// Token: 0x0600761E RID: 30238 RVA: 0x001EE466 File Offset: 0x001EC666
	public long GetUnlockTimeStamp()
	{
		return this.UnlockTimeStamp;
	}

	// Token: 0x04003921 RID: 14625
	[StaticVariableRuleIgnore]
	public static bool DebugFlag;

	// Token: 0x04003922 RID: 14626
	private bool IsShow;

	// Token: 0x04003923 RID: 14627
	private long UnlockTimeStamp;
}
