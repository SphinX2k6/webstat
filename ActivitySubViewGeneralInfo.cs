using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001738 RID: 5944
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewGeneralInfo : ActivitySubViewBase
{
	// Token: 0x0600A614 RID: 42516 RVA: 0x002BED20 File Offset: 0x002BCF20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A615 RID: 42517 RVA: 0x002BEDCB File Offset: 0x002BCFCB
	protected override void OnSetData()
	{
	}

	// Token: 0x0600A616 RID: 42518 RVA: 0x002BEDD0 File Offset: 0x002BCFD0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewGeneralInfo.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewGeneralInfo.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A617 RID: 42519 RVA: 0x002BEE14 File Offset: 0x002BD014
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
			if (!StringUtils.IsEmpty(descThemeIcon))
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
		this.RewardListComponent.ShowReceivedCallBack = this.ShowReceivedCallBack;
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
		this.FunctionalComponent.FunctionButton.SetLocalTextNew("CollectActivity_reward", Array.Empty<object>());
		this.OnRefreshView();
	}

	// Token: 0x0600A618 RID: 42520 RVA: 0x002BEF88 File Offset: 0x002BD188
	public new void OnRefreshView()
	{
		this.RefreshFunction();
		this.RefreshTimerText();
	}

	// Token: 0x0600A619 RID: 42521 RVA: 0x002BEF96 File Offset: 0x002BD196
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x0600A61A RID: 42522 RVA: 0x002BEFA0 File Offset: 0x002BD1A0
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

	// Token: 0x0600A61B RID: 42523 RVA: 0x002BF010 File Offset: 0x002BD210
	private void RefreshTimerText()
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

	// Token: 0x0600A61C RID: 42524 RVA: 0x002BF062 File Offset: 0x002BD262
	public void HideRemainTime()
	{
		this.HideRemainTimeInternal = true;
		this.TitleComponent.SetTimeTextVisible(false);
	}

	// Token: 0x0600A61D RID: 42525 RVA: 0x002BF077 File Offset: 0x002BD277
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

	// Token: 0x0600A61E RID: 42526 RVA: 0x002BF095 File Offset: 0x002BD295
	public void SetClickFunc([Nullable(new byte[]
	{
		1,
		2
	})] Action<ActivityBaseData> clickFunc)
	{
		this.ClickFunc = clickFunc;
	}

	// Token: 0x0600A61F RID: 42527 RVA: 0x002BF09E File Offset: 0x002BD29E
	[NullableContext(1)]
	public void SetShowReceivedCallBack(Func<TItem, bool> showReceivedCallBack)
	{
		this.ShowReceivedCallBack = showReceivedCallBack;
	}

	// Token: 0x0600A620 RID: 42528 RVA: 0x002BF0A7 File Offset: 0x002BD2A7
	private void FunctionExecute()
	{
		Action<ActivityBaseData> clickFunc = this.ClickFunc;
		if (clickFunc == null)
		{
			return;
		}
		clickFunc(this.ActivityBaseData);
	}

	// Token: 0x0600A621 RID: 42529 RVA: 0x002BF0BF File Offset: 0x002BD2BF
	public void SetFunctionRedDotVisible(bool bVisible)
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		functionalComponent.SetFunctionRedDotVisible(bVisible);
	}

	// Token: 0x0600A622 RID: 42530 RVA: 0x002BF0D2 File Offset: 0x002BD2D2
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

	// Token: 0x0600A623 RID: 42531 RVA: 0x002BF0E5 File Offset: 0x002BD2E5
	public void SetPanelTipVisible(bool bVisible)
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return;
		}
		functionalComponent.SetPanelTipVisible(bVisible);
	}

	// Token: 0x0600A624 RID: 42532 RVA: 0x002BF0F8 File Offset: 0x002BD2F8
	[NullableContext(1)]
	public void SetSubTitleTextById(string textId)
	{
		this.TitleComponent.SetSubTitleVisible(true);
		this.TitleComponent.SetSubTitleByTextId(textId, Array.Empty<string>());
	}

	// Token: 0x0600A625 RID: 42533 RVA: 0x002BF117 File Offset: 0x002BD317
	public ActivityFunctionalTypeA GetFunctional()
	{
		return this.FunctionalComponent;
	}

	// Token: 0x0600A626 RID: 42534 RVA: 0x002BF11F File Offset: 0x002BD31F
	public UUIItem GetFunctionalButtonItem()
	{
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent == null)
		{
			return null;
		}
		return functionalComponent.GetFunctionButtonItem();
	}

	// Token: 0x0600A627 RID: 42535 RVA: 0x002BF132 File Offset: 0x002BD332
	public void SetRewardComponentVisible(bool visible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(visible);
	}

	// Token: 0x04004EB2 RID: 20146
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004EB3 RID: 20147
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04004EB4 RID: 20148
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04004EB5 RID: 20149
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x04004EB6 RID: 20150
	private Action<ActivityBaseData> ClickFunc;

	// Token: 0x04004EB7 RID: 20151
	private Func<TItem, bool> ShowReceivedCallBack;

	// Token: 0x04004EB8 RID: 20152
	private bool HideRemainTimeInternal;

	// Token: 0x02007A93 RID: 31379
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029FEB RID: 172011
		public const int TitleItem = 0;

		// Token: 0x04029FEC RID: 172012
		public const int DescriptionItem = 1;

		// Token: 0x04029FED RID: 172013
		public const int RewardListItem = 2;

		// Token: 0x04029FEE RID: 172014
		public const int FunctionArea = 3;
	}
}
