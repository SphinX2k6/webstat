using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200148B RID: 5259
[NullableContext(1)]
[Nullable(0)]
public class NoviceJourneyItem : GridProxyAbstract<NewbieCourse>
{
	// Token: 0x0600932E RID: 37678 RVA: 0x0026D52C File Offset: 0x0026B72C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.RequestReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600932F RID: 37679 RVA: 0x0026D6BC File Offset: 0x0026B8BC
	private void RequestReward()
	{
		if (this.CurrentState == NoviceJourneyDefine.EItemState.Unaccomplished)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewbieCourse_LevelTips", Array.Empty<object>());
			return;
		}
		if (this.CurrentState == NoviceJourneyDefine.EItemState.CanReceive)
		{
			(ActivityManager.GetActivityController(this.ActivityData.Type) as ActivityNoviceJourneyController).RequestReward(this.Config.Value.Id);
			foreach (RewardGridItem rewardGridItem in this.RewardItemList)
			{
				rewardGridItem.SetReceivableVisible(false);
			}
		}
	}

	// Token: 0x06009330 RID: 37680 RVA: 0x0026D764 File Offset: 0x0026B964
	private UniTask CreateRewardItem(AActor itemActor)
	{
		NoviceJourneyItem.<CreateRewardItem>d__8 <CreateRewardItem>d__;
		<CreateRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRewardItem>d__.<>4__this = this;
		<CreateRewardItem>d__.itemActor = itemActor;
		<CreateRewardItem>d__.<>1__state = -1;
		<CreateRewardItem>d__.<>t__builder.Start<NoviceJourneyItem.<CreateRewardItem>d__8>(ref <CreateRewardItem>d__);
		return <CreateRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x06009331 RID: 37681 RVA: 0x0026D7B0 File Offset: 0x0026B9B0
	private void HandleRewardItemClick(MediumItemGridExtendCallback parameter)
	{
		if (this.CurrentState != NoviceJourneyDefine.EItemState.CanReceive)
		{
			IItemData itemData = parameter.Data as IItemData;
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemData.ItemId, true, null);
			return;
		}
		(ActivityManager.GetActivityController(this.ActivityData.Type) as ActivityNoviceJourneyController).RequestReward(this.Config.Value.Id);
	}

	// Token: 0x06009332 RID: 37682 RVA: 0x0026D814 File Offset: 0x0026BA14
	protected override UniTask OnBeforeStartAsync()
	{
		NoviceJourneyItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NoviceJourneyItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009333 RID: 37683 RVA: 0x0026D858 File Offset: 0x0026BA58
	protected override void OnStart()
	{
		this.StateMap.Add(NoviceJourneyDefine.EItemState.Unaccomplished, new Action(this.HandleUnaccomplished));
		this.StateMap.Add(NoviceJourneyDefine.EItemState.CanReceive, new Action(this.HandleCanReceive));
		this.StateMap.Add(NoviceJourneyDefine.EItemState.HasReceived, new Action(this.HandleHasReceived));
	}

	// Token: 0x06009334 RID: 37684 RVA: 0x0026D8B0 File Offset: 0x0026BAB0
	protected override void OnBeforeDestroy()
	{
		foreach (RewardGridItem child in this.RewardItemList)
		{
			base.AddChild(child);
		}
	}

	// Token: 0x06009335 RID: 37685 RVA: 0x0026D904 File Offset: 0x0026BB04
	private void HandleUnaccomplished()
	{
		base.GetItem(5).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(4).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		foreach (RewardGridItem rewardGridItem in this.RewardItemList)
		{
			rewardGridItem.SetLockVisible(true);
		}
	}

	// Token: 0x06009336 RID: 37686 RVA: 0x0026D98C File Offset: 0x0026BB8C
	private void HandleCanReceive()
	{
		base.GetItem(5).SetUIActive(true);
		base.GetItem(7).SetUIActive(true);
		base.GetItem(4).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		base.GetText(6).SetText(this.Config.Value.Id.ToString(), true);
		foreach (RewardGridItem rewardGridItem in this.RewardItemList)
		{
			rewardGridItem.SetReceivableVisible(true);
		}
	}

	// Token: 0x06009337 RID: 37687 RVA: 0x0026DA3C File Offset: 0x0026BC3C
	private void HandleHasReceived()
	{
		base.GetItem(5).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(4).SetUIActive(true);
		base.GetItem(8).SetUIActive(true);
		foreach (RewardGridItem rewardGridItem in this.RewardItemList)
		{
			rewardGridItem.SetReceivedVisible(true);
		}
	}

	// Token: 0x06009338 RID: 37688 RVA: 0x0026DAC4 File Offset: 0x0026BCC4
	public void SetActivityData(ActivityNoviceJourneyData activityData)
	{
		this.ActivityData = activityData;
	}

	// Token: 0x06009339 RID: 37689 RVA: 0x0026DAD0 File Offset: 0x0026BCD0
	public override void Refresh(NewbieCourse config, bool isSelected, int gridIndex)
	{
		this.Config = new NewbieCourse?(config);
		base.GetText(0).SetText(config.Id.ToString(), true);
		IItemData[] rewardList = ConfigBase<ActivityNoviceJourneyConfig>.Instance.GetRewardList(this.Config.Value.Reward);
		int i = 0;
		int count = this.RewardItemList.Count;
		while (i < count)
		{
			RewardGridItem rewardGridItem = this.RewardItemList[i];
			if (i < rewardList.Length)
			{
				rewardGridItem.RefreshByData(rewardList[i]);
			}
			else
			{
				rewardGridItem.SetActive(false);
			}
			i++;
		}
		this.RefreshCurrentState();
	}

	// Token: 0x0600933A RID: 37690 RVA: 0x0026DB6C File Offset: 0x0026BD6C
	public void RefreshCurrentState()
	{
		this.CurrentState = this.ActivityData.GetRewardStateByLevel(this.Config.Value.Id);
		this.StateMap[this.CurrentState]();
	}

	// Token: 0x0600933B RID: 37691 RVA: 0x0026DBB4 File Offset: 0x0026BDB4
	public override object GetKey(NewbieCourse data, int displayIndex)
	{
		return this.Config.Value.Id;
	}

	// Token: 0x0400441D RID: 17437
	private readonly Dictionary<NoviceJourneyDefine.EItemState, Action> StateMap = new Dictionary<NoviceJourneyDefine.EItemState, Action>();

	// Token: 0x0400441E RID: 17438
	private NoviceJourneyDefine.EItemState CurrentState;

	// Token: 0x0400441F RID: 17439
	private readonly List<RewardGridItem> RewardItemList = new List<RewardGridItem>();

	// Token: 0x04004420 RID: 17440
	private NewbieCourse? Config;

	// Token: 0x04004421 RID: 17441
	[Nullable(2)]
	private ActivityNoviceJourneyData ActivityData;

	// Token: 0x02007894 RID: 30868
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029761 RID: 169825
		public const int LevelText = 0;

		// Token: 0x04029762 RID: 169826
		public const int RewardItem1 = 1;

		// Token: 0x04029763 RID: 169827
		public const int RewardItem2 = 2;

		// Token: 0x04029764 RID: 169828
		public const int Button = 3;

		// Token: 0x04029765 RID: 169829
		public const int ReceivedItem = 4;

		// Token: 0x04029766 RID: 169830
		public const int CanReceiveItem = 5;

		// Token: 0x04029767 RID: 169831
		public const int CanReceiveLevelText = 6;

		// Token: 0x04029768 RID: 169832
		public const int SpriteReward = 7;

		// Token: 0x04029769 RID: 169833
		public const int ReceivedItem2 = 8;
	}
}
