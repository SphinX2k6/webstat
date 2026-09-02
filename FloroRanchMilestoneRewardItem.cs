using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C63 RID: 7267
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchMilestoneRewardItem : GridProxyAbstract<FloroRanchMilestoneData>
{
	// Token: 0x0600D414 RID: 54292 RVA: 0x00388EA0 File Offset: 0x003870A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D415 RID: 54293 RVA: 0x00388F2C File Offset: 0x0038712C
	protected override void OnStart()
	{
		this.RewardItemGrid = new SmallItemGrid();
		this.RewardItemGrid.Initialize(base.GetItem(2).GetOwner());
		this.RewardItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.RewardItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
	}

	// Token: 0x0600D416 RID: 54294 RVA: 0x00388F9C File Offset: 0x0038719C
	public override void Refresh(FloroRanchMilestoneData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.GetText(1).SetText(data.Goal.ToString(), true);
		base.GetSprite(0).SetUIActive(data.IsFinished);
		if (data.RewardList != null && data.RewardList.Count > 0)
		{
			this.RewardItem = new TItem?(data.RewardList[0]);
		}
		this.RefreshGrid();
	}

	// Token: 0x0600D417 RID: 54295 RVA: 0x00389010 File Offset: 0x00387210
	private void RefreshGrid()
	{
		bool lockBlackVisible = !this.Data.IsFinished;
		bool value = this.Data.IsFinished && !this.Data.IsReceive;
		bool isReceive = this.Data.IsReceive;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = this.Data,
			ItemConfigId = new int?(this.RewardItem.Value.ItemData.ItemId),
			BottomText = this.RewardItem.Value.Count.ToString(),
			IsReceivableVisible = new bool?(value),
			IsReceivedVisible = new bool?(isReceive),
			IsRedDotVisible = new bool?(value)
		};
		this.RewardItemGrid.Apply<PropSmallItemGrid>(parameters);
		this.RewardItemGrid.SetLockBlackVisible(lockBlackVisible);
	}

	// Token: 0x0600D418 RID: 54296 RVA: 0x003890E4 File Offset: 0x003872E4
	private void OnClickedGrid(MediumItemGridExtendCallback onExtendToggleClickedCallback)
	{
		if (!this.Data.IsFinished || this.Data.IsReceive)
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

	// Token: 0x040064E0 RID: 25824
	private FloroRanchMilestoneData Data;

	// Token: 0x040064E1 RID: 25825
	[Nullable(2)]
	private SmallItemGrid RewardItemGrid;

	// Token: 0x040064E2 RID: 25826
	private TItem? RewardItem;

	// Token: 0x040064E3 RID: 25827
	[Nullable(2)]
	public Action OnClickToGet;

	// Token: 0x02007F7D RID: 32637
	[NullableContext(0)]
	private class EItemComponent
	{
		// Token: 0x0402B684 RID: 177796
		public const int SpriteBg = 0;

		// Token: 0x0402B685 RID: 177797
		public const int TxtGoal = 1;

		// Token: 0x0402B686 RID: 177798
		public const int RewardItem = 2;
	}
}
