using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016E9 RID: 5865
[NullableContext(1)]
[Nullable(0)]
public class ActivityWheelTowerRewardView : UiViewBase
{
	// Token: 0x0600A2A9 RID: 41641 RVA: 0x002AEB08 File Offset: 0x002ACD08
	public ActivityWheelTowerRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A2AA RID: 41642 RVA: 0x002AEB14 File Offset: 0x002ACD14
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A2AB RID: 41643 RVA: 0x002AEBE0 File Offset: 0x002ACDE0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityWheelTowerRewardView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityWheelTowerRewardView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A2AC RID: 41644 RVA: 0x002AEC24 File Offset: 0x002ACE24
	protected override void OnStart()
	{
		GenericScrollViewNew<ActivityWheelTowerRewardView.RewardTabItem, int> tabScroll = this.TabScroll;
		if (tabScroll != null)
		{
			tabScroll.RefreshByData(ActivityWheelTowerRewardView.WheelTowerDiffList, delegate
			{
				ActivityWheelTowerRewardView.RewardTabItem scrollItemByIndex = this.TabScroll.GetScrollItemByIndex(0);
				if (scrollItemByIndex == null)
				{
					return;
				}
				scrollItemByIndex.SetToggleStateForce(true, true);
			}, true);
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

	// Token: 0x0600A2AD RID: 41645 RVA: 0x002AEC70 File Offset: 0x002ACE70
	private void RefreshRewardScroll()
	{
		WheelTowerData data = ModelBase<WheelTowerModel>.Instance.ActivityData;
		NewTowerClimbingLevelRecord levelRecord = data.GetLevelRecord(this.IsEndless);
		IReadOnlyList<NewTowerScoreReward> rewardConfigListByLevelId = ConfigBase<WheelTowerConfig>.Instance.GetRewardConfigListByLevelId(levelRecord.LevelId);
		if (rewardConfigListByLevelId == null)
		{
			GenericScrollViewNew<ActivityWheelTowerRewardView.RewardItem, int> rewardScroll = this.RewardScroll;
			if (rewardScroll == null)
			{
				return;
			}
			rewardScroll.RefreshByData(Array.Empty<int>(), null, false);
			return;
		}
		else
		{
			List<int> data2 = (from config in rewardConfigListByLevelId
			orderby base.<RefreshRewardScroll>g__GetPriority|0(config.Id), config.Id
			select config.Id).ToList<int>();
			GenericScrollViewNew<ActivityWheelTowerRewardView.RewardItem, int> rewardScroll2 = this.RewardScroll;
			if (rewardScroll2 == null)
			{
				return;
			}
			rewardScroll2.RefreshByData(data2, null, true);
			return;
		}
	}

	// Token: 0x0600A2AE RID: 41646 RVA: 0x002AED44 File Offset: 0x002ACF44
	private ActivityWheelTowerRewardView.RewardTabItem CreateTabItem()
	{
		ActivityWheelTowerRewardView.RewardTabItem rewardTabItem = new ActivityWheelTowerRewardView.RewardTabItem();
		rewardTabItem.SetToggleClickCallback(new Action<int>(this.ToggleCallBack));
		return rewardTabItem;
	}

	// Token: 0x0600A2AF RID: 41647 RVA: 0x002AED5D File Offset: 0x002ACF5D
	private void ToggleCallBack(int diff)
	{
		GenericScrollViewNew<ActivityWheelTowerRewardView.RewardTabItem, int> tabScroll = this.TabScroll;
		if (tabScroll != null)
		{
			tabScroll.SelectGridProxy(diff, false);
		}
		this.IsEndless = (diff == 1);
		this.RefreshRewardScroll();
	}

	// Token: 0x0600A2B0 RID: 41648 RVA: 0x002AED82 File Offset: 0x002ACF82
	private ActivityWheelTowerRewardView.RewardItem CreateRewardItem()
	{
		ActivityWheelTowerRewardView.RewardItem rewardItem = new ActivityWheelTowerRewardView.RewardItem();
		rewardItem.SetOnClickReceiveCallback(new Action(this.ReceiveCallback));
		return rewardItem;
	}

	// Token: 0x0600A2B1 RID: 41649 RVA: 0x002AED9B File Offset: 0x002ACF9B
	private void ReceiveCallback()
	{
		ControllerBase<WheelTowerController>.Instance.RequestTaskReceive(this.IsEndless).ContinueWith(delegate()
		{
			GenericScrollViewNew<ActivityWheelTowerRewardView.RewardTabItem, int> tabScroll = this.TabScroll;
			if (tabScroll != null)
			{
				GenericLayout<ActivityWheelTowerRewardView.RewardTabItem, int> genericLayout = tabScroll.GetGenericLayout();
				if (genericLayout != null)
				{
					genericLayout.RefreshWithoutDataSync();
				}
			}
			this.RefreshRewardScroll();
		});
	}

	// Token: 0x0600A2B2 RID: 41650 RVA: 0x002AEDC0 File Offset: 0x002ACFC0
	// Note: this type is marked as 'beforefieldinit'.
	unsafe static ActivityWheelTowerRewardView()
	{
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = 0;
		num2++;
		*span[num2] = 1;
		ActivityWheelTowerRewardView.WheelTowerDiffList = list;
	}

	// Token: 0x04004D20 RID: 19744
	[StaticVariableRuleIgnore]
	private static readonly List<int> WheelTowerDiffList;

	// Token: 0x04004D21 RID: 19745
	[Nullable(2)]
	private PopupCaptionItem Caption;

	// Token: 0x04004D22 RID: 19746
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<ActivityWheelTowerRewardView.RewardTabItem, int> TabScroll;

	// Token: 0x04004D23 RID: 19747
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<ActivityWheelTowerRewardView.RewardItem, int> RewardScroll;

	// Token: 0x04004D24 RID: 19748
	private bool IsEndless;

	// Token: 0x02007A3D RID: 31293
	[NullableContext(0)]
	private class RewardTabItem : GridProxyAbstract<int>
	{
		// Token: 0x060478CE RID: 293070 RVA: 0x01312B48 File Offset: 0x01310D48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060478CF RID: 293071 RVA: 0x01312C30 File Offset: 0x01310E30
		protected override void OnStart()
		{
			UUIExtendToggle toggle = base.GetExtendToggle(0);
			toggle.CanExecuteChange.Bind(() => toggle.ToggleState != EToggleState.ETT_Checked);
			ModelBase<WheelTowerModel>.Instance.ActivityData.RecordReadReward();
		}

		// Token: 0x060478D0 RID: 293072 RVA: 0x01312C7C File Offset: 0x01310E7C
		public override void Refresh(int diff, bool isSelected, int gridIndex)
		{
			this.Diff = diff;
			bool flag = diff == 1;
			string key = flag ? "WheelBattleMode_Endless" : "WheelBattleMode_Normal";
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(key);
			}
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			EFilterMode filterMode = flag ? EFilterMode.Endless : EFilterMode.Normal;
			int totalRewardProgress = activityData.GetTotalRewardProgress(filterMode);
			int currentRewardProgress = activityData.GetCurrentRewardProgress(filterMode);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelBattleMode_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				currentRewardProgress,
				totalRewardProgress
			}));
			bool uiactive = activityData.HasAnyRewardCanReceive(filterMode);
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x060478D1 RID: 293073 RVA: 0x01312D2E File Offset: 0x01310F2E
		[NullableContext(1)]
		public void SetToggleClickCallback(Action<int> callback)
		{
			this.ToggleClickCallback = callback;
		}

		// Token: 0x060478D2 RID: 293074 RVA: 0x01312D37 File Offset: 0x01310F37
		public void SetToggleStateForce(bool isSelected, bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x060478D3 RID: 293075 RVA: 0x01312D54 File Offset: 0x01310F54
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleStateForce(false, false);
		}

		// Token: 0x060478D4 RID: 293076 RVA: 0x01312D5E File Offset: 0x01310F5E
		private void OnClickToggle(EToggleState state)
		{
			Action<int> toggleClickCallback = this.ToggleClickCallback;
			if (toggleClickCallback == null)
			{
				return;
			}
			toggleClickCallback(this.Diff);
		}

		// Token: 0x04029EB5 RID: 171701
		private int Diff = -1;

		// Token: 0x04029EB6 RID: 171702
		[Nullable(2)]
		private Action<int> ToggleClickCallback;
	}

	// Token: 0x02007A3E RID: 31294
	[NullableContext(0)]
	private class RewardItem : GridProxyAbstract<int>
	{
		// Token: 0x060478D6 RID: 293078 RVA: 0x01312D88 File Offset: 0x01310F88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickReceive));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060478D7 RID: 293079 RVA: 0x01312ED3 File Offset: 0x013110D3
		protected override void OnStart()
		{
			this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), () => new CommonItemSmallItemGrid(), null, false, true);
		}

		// Token: 0x060478D8 RID: 293080 RVA: 0x01312F0C File Offset: 0x0131110C
		public override void Refresh(int rewardId, bool isSelected, int gridIndex)
		{
			NewTowerScoreReward? rewardConfigById = ConfigBase<WheelTowerConfig>.Instance.GetRewardConfigById(rewardId);
			if (rewardConfigById == null)
			{
				return;
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(rewardConfigById.Value.Desc);
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardConfigById.Value.DropId);
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout != null)
			{
				rewardLayout.RefreshByData(dropPackagePreviewItemList, null, false);
			}
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			bool flag = activityData.IsRewardCanReceive(rewardId);
			bool flag2 = activityData.IsRewardCompleted(rewardId);
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(flag2);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag && !flag2);
		}

		// Token: 0x060478D9 RID: 293081 RVA: 0x01312FE8 File Offset: 0x013111E8
		[NullableContext(1)]
		public void SetOnClickReceiveCallback(Action callback)
		{
			this.OnClickReceiveCallback = callback;
		}

		// Token: 0x060478DA RID: 293082 RVA: 0x01312FF1 File Offset: 0x013111F1
		private void OnClickReceive()
		{
			Action onClickReceiveCallback = this.OnClickReceiveCallback;
			if (onClickReceiveCallback == null)
			{
				return;
			}
			onClickReceiveCallback();
		}

		// Token: 0x04029EB7 RID: 171703
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x04029EB8 RID: 171704
		[Nullable(2)]
		private Action OnClickReceiveCallback;
	}
}
