using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x0200141F RID: 5151
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityMoraleController : ActivityControllerBase<ActivityMoraleController>
{
	// Token: 0x06008ECE RID: 36558 RVA: 0x002580BD File Offset: 0x002562BD
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06008ECF RID: 36559 RVA: 0x002580C0 File Offset: 0x002562C0
	protected override void OnOpenView(ActivityBaseData data)
	{
		if (!data.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = data.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleAreaSumView, null, null);
	}

	// Token: 0x06008ED0 RID: 36560 RVA: 0x00258104 File Offset: 0x00256304
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_MoraleMain";
	}

	// Token: 0x06008ED1 RID: 36561 RVA: 0x0025810B File Offset: 0x0025630B
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewMorale();
	}

	// Token: 0x06008ED2 RID: 36562 RVA: 0x00258112 File Offset: 0x00256312
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.Data = new ActivityMoraleData();
		return this.Data;
	}

	// Token: 0x06008ED3 RID: 36563 RVA: 0x00258125 File Offset: 0x00256325
	protected override void OnRegisterNetEvent()
	{
	}

	// Token: 0x06008ED4 RID: 36564 RVA: 0x00258127 File Offset: 0x00256327
	protected override void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x06008ED5 RID: 36565 RVA: 0x00258129 File Offset: 0x00256329
	[NullableContext(2)]
	private ActivityMoraleController GetController()
	{
		return ActivityManager.GetActivityController(ActivityType.MoraleActivity) as ActivityMoraleController;
	}

	// Token: 0x06008ED6 RID: 36566 RVA: 0x00258137 File Offset: 0x00256337
	[NullableContext(2)]
	public ActivityMoraleData GetData()
	{
		ActivityMoraleController controller = this.GetController();
		if (controller == null)
		{
			return null;
		}
		return controller.Data;
	}

	// Token: 0x06008ED7 RID: 36567 RVA: 0x0025814C File Offset: 0x0025634C
	public void RefreshActivityRedDot()
	{
		ActivityMoraleData data = this.GetData();
		int? num = (data != null) ? new int?(data.Id) : null;
		if (num != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, num.Value);
		}
	}

	// Token: 0x0400427E RID: 17022
	[Nullable(2)]
	public ActivityMoraleData Data;
}
