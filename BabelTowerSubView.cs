using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001246 RID: 4678
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerSubView : ActivitySubViewBase
{
	// Token: 0x06007CAF RID: 31919 RVA: 0x0020D020 File Offset: 0x0020B220
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickQuestBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007CB0 RID: 31920 RVA: 0x0020D18C File Offset: 0x0020B38C
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007CB1 RID: 31921 RVA: 0x0020D1CF File Offset: 0x0020B3CF
	protected override void OnStart()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerQuestRedDot, base.GetItem(5), null, 0);
	}

	// Token: 0x06007CB2 RID: 31922 RVA: 0x0020D1E9 File Offset: 0x0020B3E9
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerQuestRedDot, base.GetItem(5), 0);
	}

	// Token: 0x06007CB3 RID: 31923 RVA: 0x0020D204 File Offset: 0x0020B404
	protected override void OnRefreshView()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.RefreshDesc();
		this.RefreshTitle();
		this.RefreshReward();
		this.RefreshState();
		this.RefreshBtnRedDot();
		this.RefreshQuestText();
	}

	// Token: 0x06007CB4 RID: 31924 RVA: 0x0020D24C File Offset: 0x0020B44C
	private void RefreshQuestText()
	{
		ValueTuple<int, int> normalQuestCount = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetNormalQuestCount();
		int item = normalQuestCount.Item1;
		int item2 = normalQuestCount.Item2;
		int value = item;
		int value2 = item2;
		UUIText text = base.GetText(6);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text2 = base.GetText(7);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06007CB5 RID: 31925 RVA: 0x0020D2D0 File Offset: 0x0020B4D0
	private void RefreshDesc()
	{
		Activity value = this.ActivityBaseData.LocalConfig.Value;
		string descTheme = value.DescTheme;
		string desc = value.Desc;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
	}

	// Token: 0x06007CB6 RID: 31926 RVA: 0x0020D33C File Offset: 0x0020B53C
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06007CB7 RID: 31927 RVA: 0x0020D3A0 File Offset: 0x0020B5A0
	private void RefreshReward()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x06007CB8 RID: 31928 RVA: 0x0020D3D0 File Offset: 0x0020B5D0
	private void RefreshState()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
		this.FunctionalComponent.FunctionButton.SetUiActive(flag);
	}

	// Token: 0x06007CB9 RID: 31929 RVA: 0x0020D430 File Offset: 0x0020B630
	private void FunctionExecute()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerMainView, null, null);
	}

	// Token: 0x06007CBA RID: 31930 RVA: 0x0020D480 File Offset: 0x0020B680
	private void RefreshBtnRedDot()
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		bool functionRedDotVisible = babelTowerData.GetDifficultyNewLevelRedDot(0) || babelTowerData.GetDifficultyNewLevelRedDot(1);
		this.FunctionalComponent.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x06007CBB RID: 31931 RVA: 0x0020D4B8 File Offset: 0x0020B6B8
	private void OnClickQuestBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x04003BA4 RID: 15268
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003BA5 RID: 15269
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04003BA6 RID: 15270
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04003BA7 RID: 15271
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x020075BD RID: 30141
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040289E4 RID: 166372
		public const int TitleItem = 0;

		// Token: 0x040289E5 RID: 166373
		public const int DescItem = 1;

		// Token: 0x040289E6 RID: 166374
		public const int RewardItem = 2;

		// Token: 0x040289E7 RID: 166375
		public const int FunctionalAreaItem = 3;

		// Token: 0x040289E8 RID: 166376
		public const int QuestBtn = 4;

		// Token: 0x040289E9 RID: 166377
		public const int QuestRedDotItem = 5;

		// Token: 0x040289EA RID: 166378
		public const int QuestText1 = 6;

		// Token: 0x040289EB RID: 166379
		public const int QuestText2 = 7;
	}
}
