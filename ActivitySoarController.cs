using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020015B9 RID: 5561
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivitySoarController : ActivityControllerBase<ActivitySoarController>
{
	// Token: 0x06009CB5 RID: 40117 RVA: 0x00290C68 File Offset: 0x0028EE68
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009CB6 RID: 40118 RVA: 0x00290C6A File Offset: 0x0028EE6A
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009CB7 RID: 40119 RVA: 0x00290C6D File Offset: 0x0028EE6D
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivitySoar";
	}

	// Token: 0x06009CB8 RID: 40120 RVA: 0x00290C74 File Offset: 0x0028EE74
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySoarSubView();
	}

	// Token: 0x06009CB9 RID: 40121 RVA: 0x00290C7B File Offset: 0x0028EE7B
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivitySoarData();
	}

	// Token: 0x06009CBA RID: 40122 RVA: 0x00290C84 File Offset: 0x0028EE84
	public override void OnActivityFirstUnlock(ActivityBaseData data)
	{
		int questId = (data as ActivitySoarData).GetQuestId();
		if (ModelBase<QuestNewModel>.Instance.CheckQuestFinished(questId))
		{
			return;
		}
		if (!ModelBase<QuestNewModel>.Instance.IsTrackingQuest(questId))
		{
			ControllerBase<QuestNewController>.Instance.RequestTrackQuest(questId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
		}
	}
}
