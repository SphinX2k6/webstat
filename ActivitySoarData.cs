using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015BA RID: 5562
public class ActivitySoarData : ActivityBaseData
{
	// Token: 0x06009CBC RID: 40124 RVA: 0x00290CD0 File Offset: 0x0028EED0
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		JinzhouFlyData jinzhouFlyData = data.JinzhouFlyData;
		if (jinzhouFlyData == null)
		{
			return;
		}
		this.QuestId = jinzhouFlyData.QuestId;
	}

	// Token: 0x06009CBD RID: 40125 RVA: 0x00290CF4 File Offset: 0x0028EEF4
	protected override bool GetExDataFinishShowState()
	{
		return ModelBase<QuestNewModel>.Instance.CheckQuestFinished(this.QuestId);
	}

	// Token: 0x06009CBE RID: 40126 RVA: 0x00290D06 File Offset: 0x0028EF06
	public override bool GetExDataRedPointShowState()
	{
		return !this.GetExDataFinishShowState() && this.IsFirstClick();
	}

	// Token: 0x06009CBF RID: 40127 RVA: 0x00290D18 File Offset: 0x0028EF18
	public bool IsFirstClick()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 0;
	}

	// Token: 0x06009CC0 RID: 40128 RVA: 0x00290D34 File Offset: 0x0028EF34
	public void SaveFirstClick()
	{
		if (this.IsFirstClick())
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}
	}

	// Token: 0x06009CC1 RID: 40129 RVA: 0x00290D69 File Offset: 0x0028EF69
	public int GetQuestId()
	{
		return this.QuestId;
	}

	// Token: 0x04004808 RID: 18440
	private const int SOAR_RED_DOT_CACHE_KEY = 100;

	// Token: 0x04004809 RID: 18441
	private int QuestId;
}
