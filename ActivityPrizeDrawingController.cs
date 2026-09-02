using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020014E5 RID: 5349
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityPrizeDrawingController : ActivityControllerBase<ActivityPrizeDrawingController>
{
	// Token: 0x17000CF1 RID: 3313
	// (get) Token: 0x060095A2 RID: 38306 RVA: 0x00270B5D File Offset: 0x0026ED5D
	[Nullable(2)]
	public ActivityPrizeDrawingData ActivityData
	{
		[NullableContext(2)]
		get
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityPrizeDrawingData;
		}
	}

	// Token: 0x060095A3 RID: 38307 RVA: 0x00270B74 File Offset: 0x0026ED74
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060095A4 RID: 38308 RVA: 0x00270B76 File Offset: 0x0026ED76
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_PrizeDrawingActivity";
	}

	// Token: 0x060095A5 RID: 38309 RVA: 0x00270B7D File Offset: 0x0026ED7D
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivityPrizeDrawingSubView();
	}

	// Token: 0x060095A6 RID: 38310 RVA: 0x00270B84 File Offset: 0x0026ED84
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new ActivityPrizeDrawingData();
	}

	// Token: 0x060095A7 RID: 38311 RVA: 0x00270B97 File Offset: 0x0026ED97
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060095A8 RID: 38312 RVA: 0x00270B9A File Offset: 0x0026ED9A
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChanged));
		Singleton<EventSystem>.Instance.Add<TQuest>(EEventName.OnAddNewQuest, new Action<TQuest>(this.OnAddNewQuest));
	}

	// Token: 0x060095A9 RID: 38313 RVA: 0x00270BD4 File Offset: 0x0026EDD4
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChanged));
		Singleton<EventSystem>.Instance.Remove<TQuest>(EEventName.OnAddNewQuest, new Action<TQuest>(this.OnAddNewQuest));
	}

	// Token: 0x060095AA RID: 38314 RVA: 0x00270C10 File Offset: 0x0026EE10
	[NullableContext(0)]
	protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		ActivityPrizeDrawingController.<OnOpenSubView>d__10 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.<>4__this = this;
		<OnOpenSubView>d__.viewName = viewName;
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<ActivityPrizeDrawingController.<OnOpenSubView>d__10>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x060095AB RID: 38315 RVA: 0x00270C5B File Offset: 0x0026EE5B
	private void OnQuestStateChanged(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		if (state != QuestState.Finish)
		{
			return;
		}
		ActivityPrizeDrawingData activityData = this.ActivityData;
		if (activityData == null)
		{
			return;
		}
		activityData.QuestCompletedNotify(questId);
	}

	// Token: 0x060095AC RID: 38316 RVA: 0x00270C74 File Offset: 0x0026EE74
	private void OnAddNewQuest(TQuest quest)
	{
		Quest quest2 = quest as Quest;
		if (quest2 == null)
		{
			return;
		}
		ActivityPrizeDrawingData activityData = this.ActivityData;
		if (activityData == null)
		{
			return;
		}
		activityData.QuestAddNotify(quest2.Id);
	}

	// Token: 0x060095AD RID: 38317 RVA: 0x00270CA4 File Offset: 0x0026EEA4
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<WuWuKujiGachaResponse> GachaRequest()
	{
		ActivityPrizeDrawingController.<GachaRequest>d__13 <GachaRequest>d__;
		<GachaRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<WuWuKujiGachaResponse>.Create();
		<GachaRequest>d__.<>4__this = this;
		<GachaRequest>d__.<>1__state = -1;
		<GachaRequest>d__.<>t__builder.Start<ActivityPrizeDrawingController.<GachaRequest>d__13>(ref <GachaRequest>d__);
		return <GachaRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0400454D RID: 17741
	public int ActivityId;
}
