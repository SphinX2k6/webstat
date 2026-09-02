using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F36 RID: 7990
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryLimitTaskScoreItem : GridProxyAbstract<HonamiStoryScoreRewardData>
{
	// Token: 0x0600EEDE RID: 61150 RVA: 0x00414BE8 File Offset: 0x00412DE8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EEDF RID: 61151 RVA: 0x00414C94 File Offset: 0x00412E94
	protected override void OnStart()
	{
		this.RewardItemGrid = new SmallItemGrid();
		this.RewardItemGrid.Initialize(base.GetItem(0).GetOwner());
		this.RewardItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		this.RewardItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
		this.RewardItemLevelSequence = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600EEE0 RID: 61152 RVA: 0x00414D15 File Offset: 0x00412F15
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer rewardItemLevelSequence = this.RewardItemLevelSequence;
		if (rewardItemLevelSequence != null)
		{
			rewardItemLevelSequence.Clear();
		}
		this.RewardItemLevelSequence = null;
	}

	// Token: 0x0600EEE1 RID: 61153 RVA: 0x00414D30 File Offset: 0x00412F30
	public override void Refresh(HonamiStoryScoreRewardData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.GetText(3).SetText(data.Score.ToString(), true);
		string resourceId;
		if (Singleton<HonamiStoryDefine>.Instance.collectStateToScoreRewardMap.TryGetValue(data.State, out resourceId))
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(this.Data.DropId);
		bool flag = data.State == EHonamiStoryCollectState.Finished;
		base.GetItem(2).SetUIActive(flag);
		if (flag)
		{
			LevelSequencePlayer rewardItemLevelSequence = this.RewardItemLevelSequence;
			if (rewardItemLevelSequence != null)
			{
				rewardItemLevelSequence.PlayLevelSequenceByName("Loop", false, null, false);
			}
		}
		this.RewardItem = new TItem?(dropPackagePreviewItemList[0]);
		this.RefreshGrid();
	}

	// Token: 0x0600EEE2 RID: 61154 RVA: 0x00414E0C File Offset: 0x0041300C
	private void RefreshGrid()
	{
		bool lockBlackVisible = this.Data.State == EHonamiStoryCollectState.Unfinished;
		bool value = this.Data.State == EHonamiStoryCollectState.Finished;
		bool value2 = this.Data.State == EHonamiStoryCollectState.GotReward;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = this.Data,
			ItemConfigId = new int?(this.RewardItem.Value.ItemData.ItemId),
			BottomText = this.RewardItem.Value.Count.ToString(),
			IsReceivableVisible = new bool?(value),
			IsReceivedVisible = new bool?(value2),
			IsRedDotVisible = new bool?(value)
		};
		this.RewardItemGrid.Apply<PropSmallItemGrid>(parameters);
		this.RewardItemGrid.SetLockBlackVisible(lockBlackVisible);
	}

	// Token: 0x0600EEE3 RID: 61155 RVA: 0x00414ED4 File Offset: 0x004130D4
	private void OnClickedGrid(MediumItemGridExtendCallback _)
	{
		if (this.Data.State != EHonamiStoryCollectState.Finished)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItem.Value.ItemData.ItemId, true, null);
			return;
		}
		Action onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet();
	}

	// Token: 0x040072E7 RID: 29415
	private HonamiStoryScoreRewardData Data;

	// Token: 0x040072E8 RID: 29416
	[Nullable(2)]
	private SmallItemGrid RewardItemGrid;

	// Token: 0x040072E9 RID: 29417
	private TItem? RewardItem;

	// Token: 0x040072EA RID: 29418
	[Nullable(2)]
	public Action OnClickToGet;

	// Token: 0x040072EB RID: 29419
	[Nullable(2)]
	private LevelSequencePlayer RewardItemLevelSequence;

	// Token: 0x020082A6 RID: 33446
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C4F2 RID: 181490
		RewardItem,
		// Token: 0x0402C4F3 RID: 181491
		SpriteBg,
		// Token: 0x0402C4F4 RID: 181492
		PnlCanGet,
		// Token: 0x0402C4F5 RID: 181493
		TxtPointNum
	}
}
