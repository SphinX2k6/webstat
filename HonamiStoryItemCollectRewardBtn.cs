using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F23 RID: 7971
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryItemCollectRewardBtn : UiPanelBase
{
	// Token: 0x0600EE7E RID: 61054 RVA: 0x00412328 File Offset: 0x00410528
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EE7F RID: 61055 RVA: 0x00412434 File Offset: 0x00410634
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryItemCollectRewardBtn.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryItemCollectRewardBtn.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE80 RID: 61056 RVA: 0x00412478 File Offset: 0x00410678
	[NullableContext(1)]
	public void RefreshView(HonamiStoryItemCollectionData itemData)
	{
		this.CurSelectItemData = itemData;
		base.GetSprite(2).SetUIActive(this.CurSelectItemData.State == EHonamiStoryCollectState.Finished);
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		using (Dictionary<int, int>.Enumerator enumerator = ConfigDropPackageById.GetConfig(itemData.DropId, true).Value.DropPreview().GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int itemId = num;
				int count = num2;
				TItem data = new TItem(new InventoryDefine.GetItemData(itemId, 0), count);
				CommonItemSmallItemGrid rewardItem = this.RewardItem;
				if (rewardItem != null)
				{
					rewardItem.Refresh(data);
				}
			}
		}
		this.RewardItem.SetLockBlackVisible(itemData.State == EHonamiStoryCollectState.Unfinished);
		this.RewardItem.SetRedDotVisible(new bool?(itemData.State == EHonamiStoryCollectState.Finished));
		base.GetItem(3).SetUIActive(itemData.State == EHonamiStoryCollectState.Finished);
		base.GetItem(4).SetUIActive(itemData.State == EHonamiStoryCollectState.Finished);
		this.RewardItem.SetReceivedVisible(itemData.State == EHonamiStoryCollectState.GotReward);
	}

	// Token: 0x0600EE81 RID: 61057 RVA: 0x004125B4 File Offset: 0x004107B4
	private void OnClickRewardBtn()
	{
		if (this.CurSelectItemData == null)
		{
			return;
		}
		switch (this.CurSelectItemData.State)
		{
		case EHonamiStoryCollectState.Unfinished:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ConditionGroup_12902001_HintText", Array.Empty<object>());
			return;
		case EHonamiStoryCollectState.Finished:
			ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryItemCollectionRequest(new List<int>
			{
				this.CurSelectItemData.Id
			});
			return;
		case EHonamiStoryCollectState.GotReward:
			return;
		default:
			return;
		}
	}

	// Token: 0x04007275 RID: 29301
	private HonamiStoryItemCollectionData CurSelectItemData;

	// Token: 0x04007276 RID: 29302
	private CommonItemSmallItemGrid RewardItem;
}
