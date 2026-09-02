using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015A7 RID: 5543
[NullableContext(1)]
[Nullable(0)]
public class ScratchTicketActivityView : ActivitySubViewBase
{
	// Token: 0x06009C1B RID: 39963 RVA: 0x0028D9D4 File Offset: 0x0028BBD4
	protected override void OnSetData()
	{
		this.ScratchTicketData = (this.ActivityBaseData as ScratchTicketData);
	}

	// Token: 0x06009C1C RID: 39964 RVA: 0x0028D9E8 File Offset: 0x0028BBE8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
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
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009C1D RID: 39965 RVA: 0x0028DBA0 File Offset: 0x0028BDA0
	protected override UniTask OnBeforeStartAsync()
	{
		ScratchTicketActivityView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ScratchTicketActivityView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009C1E RID: 39966 RVA: 0x0028DBE4 File Offset: 0x0028BDE4
	protected override void OnStart()
	{
		Activity? localConfig = this.ScratchTicketData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.TitleItem.SetActivityBaseData(this.ScratchTicketData);
		this.TitleItem.SetTitleByText(this.ScratchTicketData.GetTitle());
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleItem.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleItem.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.DescriptionItem.SetContentByTextId(localConfig.Value.Desc, Array.Empty<string>());
		List<TItem> previewReward = this.ScratchTicketData.GetPreviewReward(null);
		this.RewardListItem.SetTitleByTextId("CollectActivity_reward");
		this.RewardListItem.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListItem.InitCommonGridItem));
		this.RewardListItem.RefreshItemLayout(previewReward, null);
		this.FunctionalItem.FunctionButton.SetFunction(new Action(this.FunctionExecute));
	}

	// Token: 0x06009C1F RID: 39967 RVA: 0x0028DCF4 File Offset: 0x0028BEF4
	protected override void OnRefreshView()
	{
		ScratchCardActivityRe? scratchCardActivityConfig = this.ScratchTicketData.GetScratchCardActivityConfig();
		if (scratchCardActivityConfig == null)
		{
			return;
		}
		bool flag = this.ScratchTicketData.IsUnLock();
		bool preGuideQuestFinishState = this.ScratchTicketData.GetPreGuideQuestFinishState();
		bool flag2 = this.ScratchTicketData.IsAllRoundFinish();
		this.FunctionalItem.SetPanelConditionVisible(!flag);
		this.RefreshTimerText();
		if (!flag)
		{
			this.FunctionalItem.SetPerformanceConditionLock(this.ScratchTicketData.ConditionGroupId, this.ScratchTicketData.Id);
		}
		this.FunctionalItem.FunctionButton.SetUiActive(flag);
		string showText = preGuideQuestFinishState ? "ScratchCardActivity_JoinIn02" : "ScratchCardActivity_JoinIn01";
		this.FunctionalItem.FunctionButton.SetShowText(showText);
		this.FunctionalItem.FunctionButton.SetRedDotVisible(this.ScratchTicketData.RedPointShowState);
		this.DescriptionItem.SetUiActive(!preGuideQuestFinishState);
		base.GetItem(9).SetUIActive(preGuideQuestFinishState && flag2);
		base.GetItem(4).SetUIActive(preGuideQuestFinishState);
		List<ScratchTicketRoundData> roundDataList = this.ScratchTicketData.GetRoundDataList();
		this.RoundLayout.RefreshByData(roundDataList, null, false);
		if (preGuideQuestFinishState && !flag2)
		{
			List<ScratchTicketConditionData> conditionDataList = this.ScratchTicketData.GetConditionDataList();
			this.ConditionLayout.RefreshByData(conditionDataList, null, false);
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new <>z__ReadOnlySingleElementList<int>(scratchCardActivityConfig.Value.ItemId));
		}
		base.GetItem(11).SetUIActive(!flag2);
		ScratchTicketRoundData firstProgressRoundData = this.ScratchTicketData.GetFirstProgressRoundData();
		if (firstProgressRoundData != null)
		{
			string togRoundIcon = firstProgressRoundData.Config.Value.TogRoundIcon;
			this.SetSpriteByPath(togRoundIcon, base.GetSprite(10), false, null, null);
		}
	}

	// Token: 0x06009C20 RID: 39968 RVA: 0x0028DEA8 File Offset: 0x0028C0A8
	private void RefreshTimerText()
	{
		string item = this.GetTimeVisibleAndRemainTime().Item2;
		this.TitleItem.SetTimeTextByText(item);
	}

	// Token: 0x06009C21 RID: 39969 RVA: 0x0028DECD File Offset: 0x0028C0CD
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06009C22 RID: 39970 RVA: 0x0028DED8 File Offset: 0x0028C0D8
	private void FunctionExecute()
	{
		if (!this.ScratchTicketData.ActivityHasClick())
		{
			this.ScratchTicketData.ClickRedDot();
		}
		if (!this.ScratchTicketData.GetPreGuideQuestFinishState())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ScratchTicketData.GetUnFinishPreGuideQuestId(), null);
			return;
		}
		ScratchCardActivityRe? scratchCardActivityConfig = this.ScratchTicketData.GetScratchCardActivityConfig();
		if (scratchCardActivityConfig.Value.JumpId == 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ScratchTicketMainView, this.ScratchTicketData, null);
			return;
		}
		SkipTaskManager.RunByConfigId(scratchCardActivityConfig.Value.JumpId, null);
	}

	// Token: 0x040047D6 RID: 18390
	private ActivityTitleTypeA TitleItem;

	// Token: 0x040047D7 RID: 18391
	private ActivityDescriptionTypeA DescriptionItem;

	// Token: 0x040047D8 RID: 18392
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListItem;

	// Token: 0x040047D9 RID: 18393
	[Nullable(2)]
	private ActivityFunctionalTypeA FunctionalItem;

	// Token: 0x040047DA RID: 18394
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ScratchTicketProgressItem, ScratchTicketRoundData> RoundLayout;

	// Token: 0x040047DB RID: 18395
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ScratchTicketConditionItem, ScratchTicketConditionData> ConditionLayout;

	// Token: 0x040047DC RID: 18396
	[Nullable(2)]
	private ScratchTicketData ScratchTicketData;

	// Token: 0x040047DD RID: 18397
	private readonly Func<ScratchTicketProgressItem> CreateRoundItem = () => new ScratchTicketProgressItem();

	// Token: 0x040047DE RID: 18398
	private readonly Func<ScratchTicketConditionItem> CreateConditionItem = () => new ScratchTicketConditionItem();

	// Token: 0x02007966 RID: 31078
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04029B37 RID: 170807
		public const int TitleItem = 0;

		// Token: 0x04029B38 RID: 170808
		public const int DescriptionItem = 1;

		// Token: 0x04029B39 RID: 170809
		public const int RewardItem = 2;

		// Token: 0x04029B3A RID: 170810
		public const int FunctionItem = 3;

		// Token: 0x04029B3B RID: 170811
		public const int ScratchTicketRootItem = 4;

		// Token: 0x04029B3C RID: 170812
		public const int ScratchTicketProgressLayout = 5;

		// Token: 0x04029B3D RID: 170813
		public const int CostItemIcon = 6;

		// Token: 0x04029B3E RID: 170814
		public const int CostItemCount = 7;

		// Token: 0x04029B3F RID: 170815
		public const int ScratchTicketConditionLayout = 8;

		// Token: 0x04029B40 RID: 170816
		public const int EmptyItem = 9;

		// Token: 0x04029B41 RID: 170817
		public const int RoundSprite = 10;

		// Token: 0x04029B42 RID: 170818
		public const int ScratchTicketConditionRoot = 11;
	}
}
