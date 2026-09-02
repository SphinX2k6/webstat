using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016CA RID: 5834
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerLimitRewardView : UiTickViewBase
{
	// Token: 0x0600A1EC RID: 41452 RVA: 0x002A9CB6 File Offset: 0x002A7EB6
	public WheelTowerLimitRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A1ED RID: 41453 RVA: 0x002A9CC0 File Offset: 0x002A7EC0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A1EE RID: 41454 RVA: 0x002A9DD0 File Offset: 0x002A7FD0
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerLimitRewardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerLimitRewardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1EF RID: 41455 RVA: 0x002A9E14 File Offset: 0x002A8014
	protected override void OnStart()
	{
		WheelTowerLimitRewardTabItem normalTabItem = this.NormalTabItem;
		if (normalTabItem != null)
		{
			normalTabItem.Refresh(WheelTowerLimitRewardView.WheelTowerDiffList[0]);
		}
		WheelTowerLimitRewardTabItem endlessTabItem = this.EndlessTabItem;
		if (endlessTabItem != null)
		{
			endlessTabItem.Refresh(WheelTowerLimitRewardView.WheelTowerDiffList[1]);
		}
		WheelTowerLimitRewardTabItem normalTabItem2 = this.NormalTabItem;
		if (normalTabItem2 != null)
		{
			normalTabItem2.SetToggleStateForce(true, true);
		}
		PopupCaptionItem caption = this.Caption;
		if (caption == null)
		{
			return;
		}
		caption.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x0600A1F0 RID: 41456 RVA: 0x002A9E88 File Offset: 0x002A8088
	protected override void OnTick(float delta)
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(ModelBase<WheelTowerModel>.Instance.ActivityData, ConfigMultiTextLang.GetLocalTextNew("WheelTower_LimitReward_RemainTime", null));
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.SetUIActive(item);
		}
		if (item && text != null)
		{
			text.SetText(item2, true);
		}
	}

	// Token: 0x0600A1F1 RID: 41457 RVA: 0x002A9EE4 File Offset: 0x002A80E4
	private void RefreshRewardScroll()
	{
		WheelTowerData data = ModelBase<WheelTowerModel>.Instance.ActivityData;
		NewTowerClimbingLevelRecord levelRecord = data.GetLevelRecord(this.IsEndless);
		IReadOnlyList<NewTowerScoreReward> rewardConfigListByLevelId = ConfigBase<WheelTowerConfig>.Instance.GetRewardConfigListByLevelId(levelRecord.LevelId);
		if (rewardConfigListByLevelId == null)
		{
			return;
		}
		List<NewTowerScoreReward> list = new List<NewTowerScoreReward>(rewardConfigListByLevelId);
		list.Sort(delegate(NewTowerScoreReward a, NewTowerScoreReward b)
		{
			int num = base.<RefreshRewardScroll>g__GetPriority|0(a.Id);
			int num2 = base.<RefreshRewardScroll>g__GetPriority|0(b.Id);
			if (num == num2)
			{
				return a.Index - b.Index;
			}
			return num - num2;
		});
		List<int> list2 = new List<int>();
		foreach (NewTowerScoreReward newTowerScoreReward in list)
		{
			list2.Add(newTowerScoreReward.Id);
		}
		GenericScrollViewNew<WheelTowerLimitRewardItem, int> rewardScroll = this.RewardScroll;
		if (rewardScroll == null)
		{
			return;
		}
		rewardScroll.RefreshByData(list2, null, true);
	}

	// Token: 0x0600A1F2 RID: 41458 RVA: 0x002A9FA8 File Offset: 0x002A81A8
	private void ToggleCallBack(int diff, UUIExtendToggle toggle)
	{
		if (this.CurrentTabToggle != null)
		{
			this.CurrentTabToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentTabToggle = toggle;
		this.CurrentTabToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		this.IsEndless = (diff == 1);
		this.RefreshRewardScroll();
	}

	// Token: 0x0600A1F3 RID: 41459 RVA: 0x002A9FE7 File Offset: 0x002A81E7
	private WheelTowerLimitRewardItem CreateRewardItem()
	{
		WheelTowerLimitRewardItem wheelTowerLimitRewardItem = new WheelTowerLimitRewardItem();
		wheelTowerLimitRewardItem.SetOnClickReceiveCallback(new Action(this.ReceiveCallback));
		return wheelTowerLimitRewardItem;
	}

	// Token: 0x0600A1F4 RID: 41460 RVA: 0x002AA000 File Offset: 0x002A8200
	private void ReceiveCallback()
	{
		ControllerBase<WheelTowerController>.Instance.RequestTaskReceive(this.IsEndless).ContinueWith(delegate()
		{
			WheelTowerLimitRewardTabItem normalTabItem = this.NormalTabItem;
			if (normalTabItem != null)
			{
				normalTabItem.Refresh(WheelTowerLimitRewardView.WheelTowerDiffList[0]);
			}
			WheelTowerLimitRewardTabItem endlessTabItem = this.EndlessTabItem;
			if (endlessTabItem != null)
			{
				endlessTabItem.Refresh(WheelTowerLimitRewardView.WheelTowerDiffList[1]);
			}
			this.RefreshRewardScroll();
		});
	}

	// Token: 0x0600A1F5 RID: 41461 RVA: 0x002AA024 File Offset: 0x002A8224
	// Note: this type is marked as 'beforefieldinit'.
	unsafe static WheelTowerLimitRewardView()
	{
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = 0;
		num2++;
		*span[num2] = 1;
		WheelTowerLimitRewardView.WheelTowerDiffList = list;
	}

	// Token: 0x04004C10 RID: 19472
	[StaticVariableRuleIgnore]
	private static readonly List<int> WheelTowerDiffList;

	// Token: 0x04004C11 RID: 19473
	[Nullable(2)]
	private PopupCaptionItem Caption;

	// Token: 0x04004C12 RID: 19474
	[Nullable(2)]
	private WheelTowerLimitRewardTabItem NormalTabItem;

	// Token: 0x04004C13 RID: 19475
	[Nullable(2)]
	private WheelTowerLimitRewardTabItem EndlessTabItem;

	// Token: 0x04004C14 RID: 19476
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<WheelTowerLimitRewardItem, int> RewardScroll;

	// Token: 0x04004C15 RID: 19477
	[Nullable(2)]
	private UUIExtendToggle CurrentTabToggle;

	// Token: 0x04004C16 RID: 19478
	private bool IsEndless;
}
