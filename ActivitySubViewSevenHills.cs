using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001361 RID: 4961
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewSevenHills : ActivitySubViewBase
{
	// Token: 0x060087F6 RID: 34806 RVA: 0x0023DF53 File Offset: 0x0023C153
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityLongShanData)this.ActivityBaseData;
	}

	// Token: 0x060087F7 RID: 34807 RVA: 0x0023DF68 File Offset: 0x0023C168
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
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060087F8 RID: 34808 RVA: 0x0023E058 File Offset: 0x0023C258
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewSevenHills.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewSevenHills.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060087F9 RID: 34809 RVA: 0x0023E09C File Offset: 0x0023C29C
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			string descThemeIcon = localConfig.Value.DescThemeIcon;
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			if (descThemeIcon != null)
			{
				ActivityTitleTypeA titleComponent = this.TitleComponent;
				if (titleComponent != null)
				{
					titleComponent.SetSubTitleIconByPath(descThemeIcon, null);
				}
			}
		}
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
		this.FunctionalComponent.FunctionButton.SetLocalTextNew("CollectActivity_reward", Array.Empty<object>());
		this.OnRefreshView();
	}

	// Token: 0x060087FA RID: 34810 RVA: 0x0023E1FA File Offset: 0x0023C3FA
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x060087FB RID: 34811 RVA: 0x0023E204 File Offset: 0x0023C404
	public void RefreshFunction()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent != null)
		{
			ActivityButtonItem functionButton = functionalComponent.FunctionButton;
			if (functionButton != null)
			{
				functionButton.SetUiActive(flag);
			}
		}
		ActivityFunctionalTypeA functionalComponent2 = this.FunctionalComponent;
		if (functionalComponent2 != null)
		{
			functionalComponent2.SetPanelConditionVisible(!flag);
		}
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
	}

	// Token: 0x060087FC RID: 34812 RVA: 0x0023E274 File Offset: 0x0023C474
	protected void RefreshTimerText()
	{
		if (this.HideRemainTimeInternal)
		{
			this.TitleComponent.SetTimeTextVisible(false);
			return;
		}
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x060087FD RID: 34813 RVA: 0x0023E2C6 File Offset: 0x0023C4C6
	public void HideRemainTime()
	{
		this.HideRemainTimeInternal = true;
		this.TitleComponent.SetTimeTextVisible(false);
	}

	// Token: 0x060087FE RID: 34814 RVA: 0x0023E2DB File Offset: 0x0023C4DB
	[NullableContext(1)]
	public void SetBtnText(string textId, params object[] args)
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		ActivityButtonItem functionButton = functionalComponent.FunctionButton;
		if (functionButton == null)
		{
			return;
		}
		functionButton.SetLocalTextNew(textId, args);
	}

	// Token: 0x060087FF RID: 34815 RVA: 0x0023E2F9 File Offset: 0x0023C4F9
	public void SetClickFunc([Nullable(new byte[]
	{
		1,
		2
	})] Action<ActivityBaseData> clickFunc)
	{
		this.ClickFunc = clickFunc;
	}

	// Token: 0x06008800 RID: 34816 RVA: 0x0023E302 File Offset: 0x0023C502
	private void FunctionExecute()
	{
		Action<ActivityBaseData> clickFunc = this.ClickFunc;
		if (clickFunc == null)
		{
			return;
		}
		clickFunc(this.ActivityBaseData);
	}

	// Token: 0x06008801 RID: 34817 RVA: 0x0023E31A File Offset: 0x0023C51A
	public void SetFunctionRedDotVisible(bool bVisible)
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		functionalComponent.SetFunctionRedDotVisible(bVisible);
	}

	// Token: 0x06008802 RID: 34818 RVA: 0x0023E32D File Offset: 0x0023C52D
	[NullableContext(1)]
	public void SetRewardButtonFunction(Action buttonFunction)
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		functionalComponent.SetRewardButtonFunction(buttonFunction);
	}

	// Token: 0x06008803 RID: 34819 RVA: 0x0023E340 File Offset: 0x0023C540
	public void SetPanelTipVisible(bool bVisible)
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		functionalComponent.SetPanelTipVisible(bVisible);
	}

	// Token: 0x06008804 RID: 34820 RVA: 0x0023E353 File Offset: 0x0023C553
	[NullableContext(1)]
	public void SetSubTitleTextById(string textId)
	{
		this.TitleComponent.SetSubTitleVisible(true);
		this.TitleComponent.SetSubTitleByTextId(textId, Array.Empty<string>());
	}

	// Token: 0x06008805 RID: 34821 RVA: 0x0023E372 File Offset: 0x0023C572
	public ActivityFunctionalTypeA GetFunctional()
	{
		return this.FunctionalComponent;
	}

	// Token: 0x06008806 RID: 34822 RVA: 0x0023E37A File Offset: 0x0023C57A
	protected override void OnBeforeShow()
	{
		this.SetClickFunc(delegate(ActivityBaseData _)
		{
			this.OnConfirmBtnClick();
		});
		this.SetBtnText("LongShanStage_Join01", Array.Empty<object>());
		this.RefreshRedDot();
		this.RefreshScoreNum();
	}

	// Token: 0x06008807 RID: 34823 RVA: 0x0023E3AC File Offset: 0x0023C5AC
	private void RefreshScoreNum()
	{
		int scoreItemCount = this.ActivityData.GetScoreItemCount();
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(scoreItemCount.ToString(), true);
		}
		int scoreItemTotal = this.ActivityData.ScoreItemTotal;
		UUIText text2 = base.GetText(5);
		if (text2 == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(scoreItemTotal);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06008808 RID: 34824 RVA: 0x0023E421 File Offset: 0x0023C621
	protected override void OnRefreshView()
	{
		this.RefreshFunction();
		this.RefreshTimerText();
		this.RefreshRedDot();
		this.RefreshScoreNum();
	}

	// Token: 0x06008809 RID: 34825 RVA: 0x0023E43C File Offset: 0x0023C63C
	private void RefreshRedDot()
	{
		bool functionRedDotVisible = this.ActivityData.CheckAnyStageRed() || this.ActivityData.CheckScoreRewardRedDot();
		this.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x0600880A RID: 34826 RVA: 0x0023E46C File Offset: 0x0023C66C
	protected virtual void OnConfirmBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SevenHillsMainView, this.ActivityData, null);
	}

	// Token: 0x04003FF8 RID: 16376
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003FF9 RID: 16377
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04003FFA RID: 16378
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04003FFB RID: 16379
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x04003FFC RID: 16380
	private Action<ActivityBaseData> ClickFunc;

	// Token: 0x04003FFD RID: 16381
	private bool HideRemainTimeInternal;

	// Token: 0x04003FFE RID: 16382
	protected ActivityLongShanData ActivityData;

	// Token: 0x0200770D RID: 30477
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029001 RID: 167937
		public const int TitleItem = 0;

		// Token: 0x04029002 RID: 167938
		public const int DescriptionItem = 1;

		// Token: 0x04029003 RID: 167939
		public const int RewardListItem = 2;

		// Token: 0x04029004 RID: 167940
		public const int FunctionArea = 3;

		// Token: 0x04029005 RID: 167941
		public const int TextCount = 4;

		// Token: 0x04029006 RID: 167942
		public const int TextTotal = 5;
	}
}
