using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x020011C7 RID: 4551
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AvignonController : ActivityControllerBase<AvignonController>
{
	// Token: 0x060077EF RID: 30703 RVA: 0x001F64B7 File Offset: 0x001F46B7
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<AvignonTaskNotify>(ENotifyMessageId.AvignonTaskNotify, new Action<AvignonTaskNotify, Net.CallbackStatus>(this.AvignonInfoUpdate));
	}

	// Token: 0x060077F0 RID: 30704 RVA: 0x001F64D5 File Offset: 0x001F46D5
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AvignonTaskNotify);
	}

	// Token: 0x060077F1 RID: 30705 RVA: 0x001F64E8 File Offset: 0x001F46E8
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (EUiViewName viewName in new List<EUiViewName>
		{
			EUiViewName.AvignonActivityMainView,
			EUiViewName.AvignonStageTaskView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060077F2 RID: 30706 RVA: 0x001F6560 File Offset: 0x001F4760
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060077F3 RID: 30707 RVA: 0x001F6562 File Offset: 0x001F4762
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_CollegeThemeGuide";
	}

	// Token: 0x060077F4 RID: 30708 RVA: 0x001F6569 File Offset: 0x001F4769
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new AvignonActivitySubView();
	}

	// Token: 0x060077F5 RID: 30709 RVA: 0x001F6570 File Offset: 0x001F4770
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return ModelBase<AvignonModel>.Instance.GetAvigonoProtocolData();
	}

	// Token: 0x060077F6 RID: 30710 RVA: 0x001F657C File Offset: 0x001F477C
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipAvignonView, null, null);
	}

	// Token: 0x060077F7 RID: 30711 RVA: 0x001F658F File Offset: 0x001F478F
	private void AvignonInfoUpdate(AvignonTaskNotify notify, [Nullable(2)] Net.CallbackStatus tatus)
	{
		ModelBase<AvignonModel>.Instance.AvignonInfoUpdate(notify);
	}

	// Token: 0x060077F8 RID: 30712 RVA: 0x001F659C File Offset: 0x001F479C
	public void RequestTaskReward(int taskId)
	{
		AvignonRewardRequest avignonRewardRequest = AvignonRewardRequest.Create();
		avignonRewardRequest.TaskId = taskId;
		int avignonActivityId = ModelBase<AvignonModel>.Instance.GetAvignonActivityId();
		avignonRewardRequest.ActivityId = avignonActivityId;
		Singleton<Net>.Instance.Call<AvignonRewardResponse>(ERequestMessageId.AvignonRewardRequest, avignonRewardRequest, delegate(AvignonRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20565, null, true, true);
				return;
			}
			ModelBase<AvignonModel>.Instance.UpdateTaskRewardStatus(taskId);
		}, 0);
	}
}
