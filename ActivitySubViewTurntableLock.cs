using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015E6 RID: 5606
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewTurntableLock : ActivitySubViewBase
{
	// Token: 0x06009DEF RID: 40431 RVA: 0x002956BC File Offset: 0x002938BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009DF0 RID: 40432 RVA: 0x00295788 File Offset: 0x00293988
	protected override void OnSetData()
	{
		this.ActivityTurntableData = (this.ActivityBaseData as ActivityTurntableData);
	}

	// Token: 0x06009DF1 RID: 40433 RVA: 0x0029579C File Offset: 0x0029399C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewTurntableLock.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewTurntableLock.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009DF2 RID: 40434 RVA: 0x002957E0 File Offset: 0x002939E0
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
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
		if (this.ActivityTurntableData.IsUnLock())
		{
			this.ActivityTurntableData.SaveUnlockRedDot();
		}
	}

	// Token: 0x06009DF3 RID: 40435 RVA: 0x0029590C File Offset: 0x00293B0C
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		this.RefreshCondition();
		this.RefreshRedDot();
	}

	// Token: 0x06009DF4 RID: 40436 RVA: 0x00295920 File Offset: 0x00293B20
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06009DF5 RID: 40437 RVA: 0x00295928 File Offset: 0x00293B28
	private void RefreshCondition()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
		if (functionButton != null)
		{
			functionButton.SetUiActive(flag);
		}
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			ActivityButtonItem functionButton2 = this.FunctionalComponent.FunctionButton;
			if (functionButton2 != null)
			{
				functionButton2.SetUiActive(false);
			}
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
	}

	// Token: 0x06009DF6 RID: 40438 RVA: 0x002959A4 File Offset: 0x00293BA4
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06009DF7 RID: 40439 RVA: 0x002959E4 File Offset: 0x00293BE4
	private void RefreshRedDot()
	{
		bool functionRedDotVisible = this.ActivityTurntableData.IsHasPreQuestRedDot();
		this.FunctionalComponent.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x06009DF8 RID: 40440 RVA: 0x00295A0C File Offset: 0x00293C0C
	private void FunctionExecute()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			this.ActivityTurntableData.SavePreQuestRedDot(unFinishPreGuideQuestId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
		}
	}

	// Token: 0x040048AB RID: 18603
	protected ActivityTurntableData ActivityTurntableData;

	// Token: 0x040048AC RID: 18604
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x040048AD RID: 18605
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x040048AE RID: 18606
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x040048AF RID: 18607
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x020079A3 RID: 31139
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029C66 RID: 171110
		public const int PanelItem = 0;

		// Token: 0x04029C67 RID: 171111
		public const int TitleItem = 1;

		// Token: 0x04029C68 RID: 171112
		public const int DescriptionItem = 2;

		// Token: 0x04029C69 RID: 171113
		public const int RewardListItem = 3;

		// Token: 0x04029C6A RID: 171114
		public const int FunctionArea = 4;
	}
}
