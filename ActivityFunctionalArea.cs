using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001602 RID: 5634
[NullableContext(2)]
[Nullable(0)]
public class ActivityFunctionalArea : UiPanelBase
{
	// Token: 0x17000D65 RID: 3429
	// (get) Token: 0x06009ED4 RID: 40660 RVA: 0x00298AF6 File Offset: 0x00296CF6
	// (set) Token: 0x06009ED5 RID: 40661 RVA: 0x00298AFE File Offset: 0x00296CFE
	public ActivityButtonItem FunctionButton { get; set; }

	// Token: 0x17000D66 RID: 3430
	// (get) Token: 0x06009ED6 RID: 40662 RVA: 0x00298B07 File Offset: 0x00296D07
	// (set) Token: 0x06009ED7 RID: 40663 RVA: 0x00298B0F File Offset: 0x00296D0F
	public ButtonSpriteItem CircleButton { get; set; }

	// Token: 0x17000D67 RID: 3431
	// (get) Token: 0x06009ED8 RID: 40664 RVA: 0x00298B18 File Offset: 0x00296D18
	// (set) Token: 0x06009ED9 RID: 40665 RVA: 0x00298B20 File Offset: 0x00296D20
	public FunctionalPanelConditionLock PanelLock { get; set; }

	// Token: 0x06009EDA RID: 40666 RVA: 0x00298B29 File Offset: 0x00296D29
	public ActivityFunctionalArea(ActivityBaseData data)
	{
		this.Data = data;
	}

	// Token: 0x06009EDB RID: 40667 RVA: 0x00298B38 File Offset: 0x00296D38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009EDC RID: 40668 RVA: 0x00298C28 File Offset: 0x00296E28
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityFunctionalArea.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityFunctionalArea.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009EDD RID: 40669 RVA: 0x00298C6C File Offset: 0x00296E6C
	private UniTask CreatePanelLockAsync()
	{
		ActivityFunctionalArea.<CreatePanelLockAsync>d__17 <CreatePanelLockAsync>d__;
		<CreatePanelLockAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePanelLockAsync>d__.<>4__this = this;
		<CreatePanelLockAsync>d__.<>1__state = -1;
		<CreatePanelLockAsync>d__.<>t__builder.Start<ActivityFunctionalArea.<CreatePanelLockAsync>d__17>(ref <CreatePanelLockAsync>d__);
		return <CreatePanelLockAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009EDE RID: 40670 RVA: 0x00298CB0 File Offset: 0x00296EB0
	private UniTask CreateCircleButtonAsync()
	{
		ActivityFunctionalArea.<CreateCircleButtonAsync>d__18 <CreateCircleButtonAsync>d__;
		<CreateCircleButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateCircleButtonAsync>d__.<>4__this = this;
		<CreateCircleButtonAsync>d__.<>1__state = -1;
		<CreateCircleButtonAsync>d__.<>t__builder.Start<ActivityFunctionalArea.<CreateCircleButtonAsync>d__18>(ref <CreateCircleButtonAsync>d__);
		return <CreateCircleButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009EDF RID: 40671 RVA: 0x00298CF4 File Offset: 0x00296EF4
	private UniTask CreateFunctionButtonAsync()
	{
		ActivityFunctionalArea.<CreateFunctionButtonAsync>d__19 <CreateFunctionButtonAsync>d__;
		<CreateFunctionButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateFunctionButtonAsync>d__.<>4__this = this;
		<CreateFunctionButtonAsync>d__.<>1__state = -1;
		<CreateFunctionButtonAsync>d__.<>t__builder.Start<ActivityFunctionalArea.<CreateFunctionButtonAsync>d__19>(ref <CreateFunctionButtonAsync>d__);
		return <CreateFunctionButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009EE0 RID: 40672 RVA: 0x00298D37 File Offset: 0x00296F37
	protected override void OnStart()
	{
		this.FunctionButton.SetExtraFunction(new Action(this.ExtraButtonFunction));
		this.SetRewardRedDotVisible(false);
	}

	// Token: 0x06009EE1 RID: 40673 RVA: 0x00298D57 File Offset: 0x00296F57
	private void ExtraButtonFunction()
	{
		if (this.Data != null)
		{
			ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.Data);
		}
	}

	// Token: 0x06009EE2 RID: 40674 RVA: 0x00298D71 File Offset: 0x00296F71
	[NullableContext(1)]
	public void SetLockTextByTextId(string textId, params string[] args)
	{
		this.PanelLock.SetTextByTextId(textId, args);
	}

	// Token: 0x06009EE3 RID: 40675 RVA: 0x00298D80 File Offset: 0x00296F80
	[NullableContext(1)]
	public void SetLockTextByText(string text)
	{
		this.PanelLock.SetTextByText(text);
	}

	// Token: 0x06009EE4 RID: 40676 RVA: 0x00298D8E File Offset: 0x00296F8E
	public void SetLockSpriteVisible(bool bVisible)
	{
		this.PanelLock.SetSpriteVisible(bVisible);
	}

	// Token: 0x06009EE5 RID: 40677 RVA: 0x00298D9C File Offset: 0x00296F9C
	public void SetPanelConditionVisible(bool bVisible)
	{
		base.GetItem(0).SetUIActive(bVisible);
	}

	// Token: 0x06009EE6 RID: 40678 RVA: 0x00298DAB File Offset: 0x00296FAB
	public void SetRewardButtonVisible(bool state)
	{
		base.GetItem(2).SetUIActive(state);
	}

	// Token: 0x06009EE7 RID: 40679 RVA: 0x00298DBA File Offset: 0x00296FBA
	[NullableContext(1)]
	public void SetRewardButtonFunction(Action buttonFunction)
	{
		this.CircleButton.SetFunction(buttonFunction);
	}

	// Token: 0x06009EE8 RID: 40680 RVA: 0x00298DC8 File Offset: 0x00296FC8
	public void SetRewardRedDotVisible(bool bVisible)
	{
		this.CircleButton.SetRedDotVisible(bVisible);
	}

	// Token: 0x06009EE9 RID: 40681 RVA: 0x00298DD6 File Offset: 0x00296FD6
	public void BindRewardRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.CircleButton.BindRedDot(redDotName, uId);
	}

	// Token: 0x06009EEA RID: 40682 RVA: 0x00298DE5 File Offset: 0x00296FE5
	public void UnbindRewardRedDot()
	{
		this.CircleButton.UnBindRedDot();
	}

	// Token: 0x06009EEB RID: 40683 RVA: 0x00298DF2 File Offset: 0x00296FF2
	public void SetFunctionButtonVisible(bool bVisible)
	{
		ActivityButtonItem functionButton = this.FunctionButton;
		if (functionButton == null)
		{
			return;
		}
		functionButton.SetUiActive(bVisible);
	}

	// Token: 0x06009EEC RID: 40684 RVA: 0x00298E05 File Offset: 0x00297005
	[NullableContext(1)]
	public void SetPanelTipByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textId, args);
	}

	// Token: 0x06009EED RID: 40685 RVA: 0x00298E1A File Offset: 0x0029701A
	[NullableContext(1)]
	public void SetPanelTipByText(string text)
	{
		base.GetText(5).SetText(text, true);
	}

	// Token: 0x06009EEE RID: 40686 RVA: 0x00298E2A File Offset: 0x0029702A
	public void SetPanelTipVisible(bool bVisible)
	{
		base.GetItem(4).SetUIActive(bVisible);
	}

	// Token: 0x06009EEF RID: 40687 RVA: 0x00298E3C File Offset: 0x0029703C
	public void RefreshGeneralPerformance(IActivityFunctionAreaParams @params = null)
	{
		if (this.Data == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "未传递活动数据,请传递数据再刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		bool flag = this.Data.IsUnLock();
		bool flag2 = this.Data.CanPreOpen();
		bool flag3 = this.Data.HasPreOpenCondition();
		if (flag)
		{
			if (@params != null)
			{
				this.SetGeneralUnlockPerformance(@params);
			}
			return;
		}
		if (!flag3)
		{
			this.FunctionButton.SetUiActive(false);
			this.SetPerformanceConditionLock(this.Data.ConditionGroupId, this.Data.Id);
			return;
		}
		if (flag2)
		{
			this.SetPanelTipByTextId("ActivityPreOpenTip", Array.Empty<string>());
			this.SetPanelConditionVisible(true);
			this.FunctionButton.SetLocalTextNew("ActivityPreOpen", Array.Empty<object>());
			this.FunctionButton.SetFunction(delegate
			{
				IActivityFunctionAreaParams params2 = @params;
				if (((params2 != null) ? params2.BeforePreOpenCheck : null) != null && !@params.BeforePreOpenCheck())
				{
					return;
				}
				this.OpenPreOpenRequestConfirmBox();
			});
			this.FunctionButton.SetUiActive(true);
			this.SetPanelConditionVisible(false);
			return;
		}
		this.FunctionButton.SetUiActive(false);
		this.SetPerformanceConditionLock(this.Data.PreOpenConditionGroupId, this.Data.Id);
	}

	// Token: 0x06009EF0 RID: 40688 RVA: 0x00298F70 File Offset: 0x00297170
	[NullableContext(1)]
	public void SetGeneralUnlockPerformance(IActivityFunctionAreaParams @params)
	{
		this.SetPanelConditionVisible(false);
		if (@params.UnlockBtnTextId != null)
		{
			if (@params.UnlockBtnTextArgs != null)
			{
				ActivityButtonItem functionButton = this.FunctionButton;
				string unlockBtnTextId = @params.UnlockBtnTextId;
				object[] unlockBtnTextArgs = @params.UnlockBtnTextArgs;
				functionButton.SetLocalTextNew(unlockBtnTextId, unlockBtnTextArgs);
			}
			else
			{
				this.FunctionButton.SetLocalTextNew(@params.UnlockBtnTextId, Array.Empty<object>());
			}
		}
		if (@params.UnlockBtnFunction != null)
		{
			this.FunctionButton.SetFunction(@params.UnlockBtnFunction);
		}
		this.FunctionButton.SetUiActive(true);
	}

	// Token: 0x06009EF1 RID: 40689 RVA: 0x00298FEA File Offset: 0x002971EA
	public void SetPerformanceOpenTimeOver()
	{
		this.SetPanelConditionVisible(true);
		this.SetLockTextByTextId("Activity_EndDesc01", Array.Empty<string>());
		this.PanelLock.SetButtonVisible(false);
		this.SetRewardButtonVisible(false);
		this.FunctionButton.SetUiActive(false);
	}

	// Token: 0x06009EF2 RID: 40690 RVA: 0x00299024 File Offset: 0x00297224
	public void SetPerformanceConditionLock(int conditionGroupId, int activityId)
	{
		this.SetPanelConditionVisible(true);
		this.PanelLock.SetButtonVisible(true);
		string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(conditionGroupId);
		if (conditionGroupHintText != null)
		{
			this.SetLockTextByTextId(conditionGroupHintText, Array.Empty<string>());
		}
		this.PanelLock.ButtonCallBack = delegate()
		{
			ControllerBase<ActivityController>.Instance.OpenActivityConditionView(activityId);
		};
	}

	// Token: 0x06009EF3 RID: 40691 RVA: 0x00299080 File Offset: 0x00297280
	public void OpenPreOpenRequestConfirmBox()
	{
		if (this.Data == null)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityPreOpen);
		Action value = delegate()
		{
			Action<bool> callback = delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.Data.Id);
			};
			ControllerBase<ActivityController>.Instance.RequestPreOpenActivity(this.Data, callback);
		};
		confirmBoxDataNew.FunctionMap[2] = value;
		string preOpenText = this.Data.LocalConfig.Value.PreOpenText;
		if (preOpenText != null)
		{
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				ConfigMultiTextLang.GetLocalTextNew(preOpenText, null)
			});
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x040048FC RID: 18684
	protected readonly ActivityBaseData Data;

	// Token: 0x020079C3 RID: 31171
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029CE1 RID: 171233
		public const int PanelCondition = 0;

		// Token: 0x04029CE2 RID: 171234
		public const int ButtonFunction = 1;

		// Token: 0x04029CE3 RID: 171235
		public const int PanelCircle = 2;

		// Token: 0x04029CE4 RID: 171236
		public const int ButtonCircle = 3;

		// Token: 0x04029CE5 RID: 171237
		public const int PanelTip = 4;

		// Token: 0x04029CE6 RID: 171238
		public const int TxtTip = 5;
	}
}
