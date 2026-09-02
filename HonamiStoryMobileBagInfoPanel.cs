using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EFC RID: 7932
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryMobileBagInfoPanel : HonamiStoryBackpackPanelBase
{
	// Token: 0x0600EC75 RID: 60533 RVA: 0x00405520 File Offset: 0x00403720
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
	}

	// Token: 0x0600EC76 RID: 60534 RVA: 0x00405590 File Offset: 0x00403790
	protected override void OnStart()
	{
		this.ScrollSpeed = ConfigBase<HonamiStoryConfig>.Instance.GetScrollingSpeed();
		base.GetSprite(3).SetUIActive(false);
		base.GetSprite(1).SetUIActive(false);
		base.GetSprite(1).SetHierarchyIndex(99);
		base.GetSprite(2).SetUIActive(false);
		base.GetSprite(2).SetHierarchyIndex(100);
	}

	// Token: 0x0600EC77 RID: 60535 RVA: 0x004055F0 File Offset: 0x004037F0
	protected override void OnBeforeShow()
	{
		this.AddEventListener();
		this.CurrentValueItem.RefreshInGame();
	}

	// Token: 0x0600EC78 RID: 60536 RVA: 0x00405603 File Offset: 0x00403803
	private void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
	}

	// Token: 0x0600EC79 RID: 60537 RVA: 0x00405624 File Offset: 0x00403824
	public UniTask Init()
	{
		HonamiStoryMobileBagInfoPanel.<Init>d__26 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<Init>d__26>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC7A RID: 60538 RVA: 0x00405668 File Offset: 0x00403868
	public UniTask UpdateViewportItems()
	{
		HonamiStoryMobileBagInfoPanel.<UpdateViewportItems>d__27 <UpdateViewportItems>d__;
		<UpdateViewportItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateViewportItems>d__.<>4__this = this;
		<UpdateViewportItems>d__.<>1__state = -1;
		<UpdateViewportItems>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<UpdateViewportItems>d__27>(ref <UpdateViewportItems>d__);
		return <UpdateViewportItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC7B RID: 60539 RVA: 0x004056AC File Offset: 0x004038AC
	protected HashSet<int> GetAvailableGrid(int start, int end)
	{
		HashSet<int> hashSet = new HashSet<int>();
		HashSet<HonamiStoryItemDataBase> hashSet2 = new HashSet<HonamiStoryItemDataBase>();
		for (int i = start; i <= end; i++)
		{
			HonamiStoryItemDataBase itemDataByPosition = this.BackpackData.GetItemDataByPosition(i);
			if (itemDataByPosition == null)
			{
				hashSet.Add(i);
			}
			else if (!hashSet2.Contains(itemDataByPosition))
			{
				hashSet2.Add(itemDataByPosition);
				hashSet.Add(i);
			}
		}
		return hashSet;
	}

	// Token: 0x0600EC7C RID: 60540 RVA: 0x00405708 File Offset: 0x00403908
	private UniTask UpdateWhenOverflowChange(int changeNum)
	{
		HonamiStoryMobileBagInfoPanel.<UpdateWhenOverflowChange>d__29 <UpdateWhenOverflowChange>d__;
		<UpdateWhenOverflowChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateWhenOverflowChange>d__.<>4__this = this;
		<UpdateWhenOverflowChange>d__.<>1__state = -1;
		<UpdateWhenOverflowChange>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<UpdateWhenOverflowChange>d__29>(ref <UpdateWhenOverflowChange>d__);
		return <UpdateWhenOverflowChange>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC7D RID: 60541 RVA: 0x0040574C File Offset: 0x0040394C
	[NullableContext(2)]
	private void RefreshMask(HonamiStoryItemDataBase itemData)
	{
		if (itemData == null)
		{
			base.GetSprite(1).SetUIActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
		int num = this.BackpackData.GetCellWidth() + this.BackpackData.GetCellHorizontalInterval();
		int num2 = this.BackpackData.GetCellHeight() + this.BackpackData.GetCellVerticalInterval();
		sprite.SetWidth((float)(num * itemData.GetGridWidth()));
		sprite.SetHeight((float)(num2 * itemData.GetGridHeight()));
		this.SetItemOffset(sprite, itemData.GetPosition());
	}

	// Token: 0x0600EC7E RID: 60542 RVA: 0x004057D8 File Offset: 0x004039D8
	[NullableContext(2)]
	private void RefreshHoverTip(IHonamiStoryDragItemHoverInfo hoverInfo)
	{
		if (hoverInfo == null)
		{
			base.GetSprite(2).SetUIActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(2);
		sprite.SetUIActive(true);
		int num = this.BackpackData.GetCellWidth() + this.BackpackData.GetCellHorizontalInterval();
		int num2 = this.BackpackData.GetCellHeight() + this.BackpackData.GetCellVerticalInterval();
		sprite.SetWidth((float)(num * hoverInfo.Width));
		sprite.SetHeight((float)(num2 * hoverInfo.Height));
		UUIItem uuiitem = sprite;
		bool isValid = hoverInfo.IsValid;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(isValid, fcolor);
		this.SetItemOffset(sprite, hoverInfo.StartPosition);
	}

	// Token: 0x0600EC7F RID: 60543 RVA: 0x0040587C File Offset: 0x00403A7C
	private UniTask CreateHonamiStoryGridItem(int position)
	{
		HonamiStoryMobileBagInfoPanel.<CreateHonamiStoryGridItem>d__32 <CreateHonamiStoryGridItem>d__;
		<CreateHonamiStoryGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateHonamiStoryGridItem>d__.<>4__this = this;
		<CreateHonamiStoryGridItem>d__.position = position;
		<CreateHonamiStoryGridItem>d__.<>1__state = -1;
		<CreateHonamiStoryGridItem>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<CreateHonamiStoryGridItem>d__32>(ref <CreateHonamiStoryGridItem>d__);
		return <CreateHonamiStoryGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC80 RID: 60544 RVA: 0x004058C8 File Offset: 0x00403AC8
	private UniTask CreateEmptyGridItem(int position)
	{
		HonamiStoryMobileBagInfoPanel.<CreateEmptyGridItem>d__33 <CreateEmptyGridItem>d__;
		<CreateEmptyGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateEmptyGridItem>d__.<>4__this = this;
		<CreateEmptyGridItem>d__.position = position;
		<CreateEmptyGridItem>d__.<>1__state = -1;
		<CreateEmptyGridItem>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<CreateEmptyGridItem>d__33>(ref <CreateEmptyGridItem>d__);
		return <CreateEmptyGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC81 RID: 60545 RVA: 0x00405914 File Offset: 0x00403B14
	private void SetItemOffset(UUIItem item, int position)
	{
		int num = position / this.BackpackData.GetWidthCount();
		int num2 = position % this.BackpackData.GetWidthCount();
		int num3 = num2 * this.BackpackData.GetCellWidth() + num2 * this.BackpackData.GetCellHorizontalInterval();
		int num4 = -num * this.BackpackData.GetCellHeight() - num * this.BackpackData.GetCellVerticalInterval();
		item.SetAnchorOffsetX((float)num3);
		item.SetAnchorOffsetY((float)num4);
	}

	// Token: 0x0600EC82 RID: 60546 RVA: 0x00405988 File Offset: 0x00403B88
	private UniTask FillBackpackItemMap(HonamiStoryItemDataBase itemData, HonamiStoryGridItemBase item)
	{
		HonamiStoryMobileBagInfoPanel.<FillBackpackItemMap>d__35 <FillBackpackItemMap>d__;
		<FillBackpackItemMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FillBackpackItemMap>d__.<>4__this = this;
		<FillBackpackItemMap>d__.itemData = itemData;
		<FillBackpackItemMap>d__.item = item;
		<FillBackpackItemMap>d__.<>1__state = -1;
		<FillBackpackItemMap>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<FillBackpackItemMap>d__35>(ref <FillBackpackItemMap>d__);
		return <FillBackpackItemMap>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC83 RID: 60547 RVA: 0x004059DC File Offset: 0x00403BDC
	private UniTask RecycleGridItem(int position)
	{
		HonamiStoryMobileBagInfoPanel.<RecycleGridItem>d__36 <RecycleGridItem>d__;
		<RecycleGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RecycleGridItem>d__.<>4__this = this;
		<RecycleGridItem>d__.position = position;
		<RecycleGridItem>d__.<>1__state = -1;
		<RecycleGridItem>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<RecycleGridItem>d__36>(ref <RecycleGridItem>d__);
		return <RecycleGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC84 RID: 60548 RVA: 0x00405A28 File Offset: 0x00403C28
	private UniTask RecycleChangeGridItem(int position)
	{
		HonamiStoryMobileBagInfoPanel.<RecycleChangeGridItem>d__37 <RecycleChangeGridItem>d__;
		<RecycleChangeGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RecycleChangeGridItem>d__.<>4__this = this;
		<RecycleChangeGridItem>d__.position = position;
		<RecycleChangeGridItem>d__.<>1__state = -1;
		<RecycleChangeGridItem>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<RecycleChangeGridItem>d__37>(ref <RecycleChangeGridItem>d__);
		return <RecycleChangeGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC85 RID: 60549 RVA: 0x00405A74 File Offset: 0x00403C74
	private UniTask RecycleEmptyGridItem(int position)
	{
		HonamiStoryMobileBagInfoPanel.<RecycleEmptyGridItem>d__38 <RecycleEmptyGridItem>d__;
		<RecycleEmptyGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RecycleEmptyGridItem>d__.<>4__this = this;
		<RecycleEmptyGridItem>d__.position = position;
		<RecycleEmptyGridItem>d__.<>1__state = -1;
		<RecycleEmptyGridItem>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<RecycleEmptyGridItem>d__38>(ref <RecycleEmptyGridItem>d__);
		return <RecycleEmptyGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC86 RID: 60550 RVA: 0x00405AC0 File Offset: 0x00403CC0
	private UniTask RefreshBackpackContextUpdate(HonamiStoryBagUpdateContext updateContext)
	{
		HonamiStoryMobileBagInfoPanel.<RefreshBackpackContextUpdate>d__39 <RefreshBackpackContextUpdate>d__;
		<RefreshBackpackContextUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshBackpackContextUpdate>d__.<>4__this = this;
		<RefreshBackpackContextUpdate>d__.updateContext = updateContext;
		<RefreshBackpackContextUpdate>d__.<>1__state = -1;
		<RefreshBackpackContextUpdate>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<RefreshBackpackContextUpdate>d__39>(ref <RefreshBackpackContextUpdate>d__);
		return <RefreshBackpackContextUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC87 RID: 60551 RVA: 0x00405B0C File Offset: 0x00403D0C
	private UniTask FillEmptyGridInViewport()
	{
		HonamiStoryMobileBagInfoPanel.<FillEmptyGridInViewport>d__40 <FillEmptyGridInViewport>d__;
		<FillEmptyGridInViewport>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FillEmptyGridInViewport>d__.<>4__this = this;
		<FillEmptyGridInViewport>d__.<>1__state = -1;
		<FillEmptyGridInViewport>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<FillEmptyGridInViewport>d__40>(ref <FillEmptyGridInViewport>d__);
		return <FillEmptyGridInViewport>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC88 RID: 60552 RVA: 0x00405B50 File Offset: 0x00403D50
	private bool CheckItemInViewport(HonamiStoryGridItemBase item)
	{
		HonamiStoryItemDataBase data = item.GetData();
		return data != null && this.CheckItemDataInViewport(data);
	}

	// Token: 0x0600EC89 RID: 60553 RVA: 0x00405B70 File Offset: 0x00403D70
	private bool CheckItemDataInViewport(HonamiStoryItemDataBase itemData)
	{
		List<int> gridFillPositionList = itemData.GetGridFillPositionList();
		bool result = false;
		foreach (int position in gridFillPositionList)
		{
			if (this.CheckPositionInViewport(position))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600EC8A RID: 60554 RVA: 0x00405BCC File Offset: 0x00403DCC
	private bool CheckPositionInViewport(int position)
	{
		return position >= this.CurViewportStartPosition && position <= this.CurViewportEndPosition;
	}

	// Token: 0x0600EC8B RID: 60555 RVA: 0x00405BE3 File Offset: 0x00403DE3
	protected override void OnBeforeHide()
	{
		this.RemoveEventListener();
	}

	// Token: 0x0600EC8C RID: 60556 RVA: 0x00405BEB File Offset: 0x00403DEB
	private void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
	}

	// Token: 0x0600EC8D RID: 60557 RVA: 0x00405C0C File Offset: 0x00403E0C
	[NullableContext(2)]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<HonamiStoryGridItemBase> GetHonamiStoryGridItem(bool needItem = false, HonamiStoryItemDataBase itemData = null)
	{
		HonamiStoryMobileBagInfoPanel.<GetHonamiStoryGridItem>d__46 <GetHonamiStoryGridItem>d__;
		<GetHonamiStoryGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<HonamiStoryGridItemBase>.Create();
		<GetHonamiStoryGridItem>d__.<>4__this = this;
		<GetHonamiStoryGridItem>d__.needItem = needItem;
		<GetHonamiStoryGridItem>d__.itemData = itemData;
		<GetHonamiStoryGridItem>d__.<>1__state = -1;
		<GetHonamiStoryGridItem>d__.<>t__builder.Start<HonamiStoryMobileBagInfoPanel.<GetHonamiStoryGridItem>d__46>(ref <GetHonamiStoryGridItem>d__);
		return <GetHonamiStoryGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EC8E RID: 60558 RVA: 0x00405C5F File Offset: 0x00403E5F
	public override int GetBackpackType()
	{
		return (int)this.BackpackData.BackpackType;
	}

	// Token: 0x0600EC8F RID: 60559 RVA: 0x00405C6C File Offset: 0x00403E6C
	public override void OnHover(ULGUIPointerEventData eventData, HonamiStoryInteractOperateAgent operateAgent)
	{
		int dragItemPositionInContent = this.GetDragItemPositionInContent(eventData);
		this.RefreshScrollMoveState(eventData);
		if (dragItemPositionInContent == -1)
		{
			return;
		}
		if (this.HoverPosition == dragItemPositionInContent)
		{
			return;
		}
		if (operateAgent.OperateData == null)
		{
			return;
		}
		this.DragItemHoverInfo = this.GetDragItemHoverInfo(operateAgent, dragItemPositionInContent);
		this.HoverPosition = dragItemPositionInContent;
		this.RefreshHoverTip(this.DragItemHoverInfo);
	}

	// Token: 0x0600EC90 RID: 60560 RVA: 0x00405CC1 File Offset: 0x00403EC1
	public override void OnHoverEnd()
	{
		this.HoverPosition = -1;
		this.DragItemHoverInfo = null;
		this.RefreshScrollMoveState(null);
		this.RefreshHoverTip(null);
	}

	// Token: 0x0600EC91 RID: 60561 RVA: 0x00405CDF File Offset: 0x00403EDF
	public override bool OnDragBegin([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(item.GetData());
		this.RefreshScrollMoveState(null);
		return base.OnDragBegin(eventData, item);
	}

	// Token: 0x0600EC92 RID: 60562 RVA: 0x00405CFC File Offset: 0x00403EFC
	public override bool OnDrag([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(item.GetData());
		return base.OnDrag(eventData, item);
	}

	// Token: 0x0600EC93 RID: 60563 RVA: 0x00405D12 File Offset: 0x00403F12
	public override void OnDragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.RefreshMask(null);
		this.RefreshScrollMoveState(null);
		base.OnDragEnd(eventData, item);
	}

	// Token: 0x0600EC94 RID: 60564 RVA: 0x00405D2C File Offset: 0x00403F2C
	public int GetDragItemPositionInContent(ULGUIPointerEventData eventData)
	{
		UUIItem item = base.GetItem(0);
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = item.GetUIWorldPosition();
		float num = uiworldPosition.X - item.GetWidth() / 2f;
		float num2 = num + item.GetWidth();
		float num3 = uiworldPosition.Z - item.GetHeight() / 2f;
		float num4 = num3 + item.GetHeight();
		if (offsetVector.X < num || offsetVector.X > num2 || offsetVector.Z < num3 || offsetVector.Z > num4)
		{
			return -1;
		}
		double num5 = (double)(offsetVector.X - num);
		float num6 = num4 - offsetVector.Z;
		int num7 = this.BackpackData.GetCellWidth() + this.BackpackData.GetCellHorizontalInterval();
		int num8 = this.BackpackData.GetCellHeight() + this.BackpackData.GetCellVerticalInterval();
		int num9 = (int)Math.Floor(num5 / (double)((float)num7));
		return (int)Math.Floor((double)(num6 / (float)num8)) * this.BackpackData.GetWidthCount() + num9;
	}

	// Token: 0x0600EC95 RID: 60565 RVA: 0x00405E28 File Offset: 0x00404028
	public override bool CheckDragItemInViewport(ULGUIPointerEventData eventData)
	{
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		UUIItem item = base.GetItem(0);
		FVector uiworldPosition = item.GetUIWorldPosition();
		float num = uiworldPosition.X - item.GetWidth() / 2f;
		float num2 = num + item.GetWidth();
		float num3 = uiworldPosition.Z - item.GetHeight() / 2f;
		float num4 = num3 + item.GetHeight();
		return offsetVector.X >= num && offsetVector.X <= num2 && offsetVector.Z >= num3 && offsetVector.Z <= num4;
	}

	// Token: 0x0600EC96 RID: 60566 RVA: 0x00405EB4 File Offset: 0x004040B4
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase itemData)
	{
		if (this.DragItemHoverInfo == null || !this.DragItemHoverInfo.IsValid)
		{
			return null;
		}
		if (this.DragItemHoverInfo.StartPosition == itemData.GetPosition() && itemData.GetIsCross() == itemData.GetIsDragCross())
		{
			return null;
		}
		HashSet<int> hashSet = new HashSet<int>();
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(itemData, this.DragItemHoverInfo.StartPosition);
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo);
		hashSet.Add(itemData.GetIncId());
		List<int> fillPosList = this.DragItemHoverInfo.FillPosList;
		foreach (int position in fillPosList)
		{
			HonamiStoryItemDataBase itemDataByPosition = this.BackpackData.GetItemDataByPosition(position);
			if (itemDataByPosition != null && !hashSet.Contains(itemDataByPosition.GetIncId()))
			{
				int exchangeItemPosition = this.GetExchangeItemPosition(this.DragItemHoverInfo, itemData.GetPosition(), itemDataByPosition.GetPosition(), itemData, itemDataByPosition);
				List<int> gridFillPositionByPosition = itemDataByPosition.GetGridFillPositionByPosition(exchangeItemPosition, itemDataByPosition.GetIsDragCross());
				bool flag = true;
				foreach (int num in gridFillPositionByPosition)
				{
					if (num >= this.BackpackData.GetCapacity())
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoSpaceForQuickAll", Array.Empty<object>());
						return null;
					}
					if (fillPosList.Contains(num))
					{
						Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.WHJ, "SwapInfo Error", default(ReadOnlySpan<ValueTuple<string, object>>));
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					return null;
				}
				hashSet.Add(itemDataByPosition.GetIncId());
				HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo2 = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(itemDataByPosition, exchangeItemPosition);
				honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo2);
			}
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC97 RID: 60567 RVA: 0x004060C8 File Offset: 0x004042C8
	private int GetExchangeItemPosition(IHonamiStoryDragItemHoverInfo hoverInfo, int itemPosition, int position, HonamiStoryItemDataBase oriItemData, HonamiStoryItemDataBase otherData)
	{
		if (oriItemData.GetIsCross() == oriItemData.GetIsDragCross())
		{
			return this.GetExchangeItemPositionNoCrossChange(hoverInfo, itemPosition, position, otherData);
		}
		return this.GetExchangeItemPositionCrossChange(hoverInfo, itemPosition, position, oriItemData, otherData);
	}

	// Token: 0x0600EC98 RID: 60568 RVA: 0x004060F4 File Offset: 0x004042F4
	private int GetExchangeItemPositionNoCrossChange(IHonamiStoryDragItemHoverInfo hoverInfo, int itemPosition, int position, HonamiStoryItemDataBase otherData)
	{
		int startPosition = hoverInfo.StartPosition;
		int widthCount = this.BackpackData.GetWidthCount();
		int num = startPosition / widthCount;
		int num2 = startPosition % widthCount;
		int num3 = itemPosition / widthCount;
		int num4 = itemPosition % widthCount;
		int num5 = num2 - num4;
		int num6 = num - num3;
		if (Math.Abs(num5) >= hoverInfo.Width || Math.Abs(num6) >= hoverInfo.Height)
		{
			return itemPosition - startPosition + position;
		}
		if (num5 == 0 && num6 == 0)
		{
			return 0;
		}
		if (num5 == 0 || num6 == 0)
		{
			int num7 = (num5 == 0) ? 0 : ((num5 > 0) ? 1 : -1);
			object obj = (num6 == 0) ? 0 : ((num6 > 0) ? 1 : -1);
			int num8 = -num7;
			object obj2 = obj;
			int num9 = -obj2;
			int num10 = Math.Abs(num7) * hoverInfo.Width;
			int num11 = Math.Abs(obj2) * hoverInfo.Height;
			int num12 = num9 * num11;
			int num13 = num8 * num10;
			return num12 * widthCount + num13 + position;
		}
		return itemPosition + hoverInfo.EndPosition - position + 1 - otherData.GetGridWidth() - (otherData.GetGridHeight() - 1) * this.BackpackData.GetWidthCount();
	}

	// Token: 0x0600EC99 RID: 60569 RVA: 0x004061EC File Offset: 0x004043EC
	private int GetExchangeItemPositionCrossChange(IHonamiStoryDragItemHoverInfo hoverInfo, int itemPosition, int position, HonamiStoryItemDataBase oriItemData, HonamiStoryItemDataBase otherData)
	{
		if (otherData.GetGridWidth() != otherData.GetGridHeight())
		{
			otherData.SetIsDragCross(!otherData.GetIsCross());
		}
		List<int> gridFillPositionByPosition = oriItemData.GetGridFillPositionByPosition(itemPosition, oriItemData.GetIsCross());
		List<int> gridFillPositionByPosition2 = oriItemData.GetGridFillPositionByPosition(hoverInfo.StartPosition, oriItemData.GetIsDragCross());
		int num = 0;
		while (num < gridFillPositionByPosition2.Count && gridFillPositionByPosition2[num] != position)
		{
			num++;
		}
		int transPosIndex = oriItemData.GetTransPosIndex(num);
		return gridFillPositionByPosition[transPosIndex];
	}

	// Token: 0x0600EC9A RID: 60570 RVA: 0x0040626C File Offset: 0x0040446C
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateData, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int item in operateData.GetGridFillPositionList())
		{
			hashSet.Add(item);
		}
		foreach (int item2 in this.BackpackData.GetEmptyGridSet())
		{
			hashSet.Add(item2);
		}
		List<int> list = new List<int>();
		List<HonamiStoryItemDataBase> list2 = new List<HonamiStoryItemDataBase>(exchangeItemSet);
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in list2)
		{
			if (honamiStoryItemDataBase != null)
			{
				IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindAvailablePosition(hashSet, honamiStoryItemDataBase, this.BackpackData.GetWidthCount(), false, null);
				if (honamiStoryAvailablePosInfo.Position == -1)
				{
					return null;
				}
				List<int> gridFillPositionByPosition = honamiStoryItemDataBase.GetGridFillPositionByPosition(honamiStoryAvailablePosInfo.Position, honamiStoryAvailablePosInfo.IsCross);
				honamiStoryItemDataBase.SetIsDragCross(honamiStoryAvailablePosInfo.IsCross);
				HonamiStoryUtil.RemoveEmptyGridPosition(hashSet, gridFillPositionByPosition.ToArray());
				list.Add(honamiStoryAvailablePosInfo.Position);
			}
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(operateData);
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
		for (int i = 0; i < list2.Count; i++)
		{
			HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(list2[i], list[i]);
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC9B RID: 60571 RVA: 0x00406430 File Offset: 0x00404630
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateData, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		if (this.DragItemHoverInfo == null || !this.DragItemHoverInfo.IsValid)
		{
			return null;
		}
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = this.BackpackData.BackpackId;
		HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(operateData, this.DragItemHoverInfo.StartPosition);
		honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
		foreach (HonamiStoryItemDataBase itemData in exchangeItemSet)
		{
			HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(itemData);
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EC9C RID: 60572 RVA: 0x004064D8 File Offset: 0x004046D8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override HashSet<HonamiStoryItemDataBase> GetExchangeItemSet(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem)
	{
		if (this.DragItemHoverInfo == null || !this.DragItemHoverInfo.IsValid)
		{
			return null;
		}
		HashSet<HonamiStoryItemDataBase> hashSet = new HashSet<HonamiStoryItemDataBase>();
		foreach (int key in this.DragItemHoverInfo.FillPosList)
		{
			HonamiStoryGridItemBase honamiStoryGridItemBase;
			if (this.BackpackItemMap.TryGetValue(key, out honamiStoryGridItemBase) && honamiStoryGridItemBase != null)
			{
				HonamiStoryItemDataBase data = honamiStoryGridItemBase.GetData();
				if (data != null && !hashSet.Contains(data))
				{
					hashSet.Add(data);
				}
			}
		}
		return hashSet;
	}

	// Token: 0x0600EC9D RID: 60573 RVA: 0x0040657C File Offset: 0x0040477C
	private IHonamiStoryDragItemHoverInfo GetDragItemHoverInfo(HonamiStoryInteractOperateAgent operateAgent, int centerPosition)
	{
		HonamiStoryItemDataBase operateData = operateAgent.OperateData;
		int widthCount = this.BackpackData.GetWidthCount();
		bool needOverflow = this.BackpackData.BackpackType == EHonamiStoryBackpackType.Inventory;
		int heightCount = this.BackpackData.GetHeightCount(needOverflow);
		int num = centerPosition % widthCount;
		int num2 = centerPosition / widthCount;
		bool flag = operateData.GetBaseGridWidth(false) == operateData.GetBaseGridHeight(false);
		int num3 = operateData.GetBaseGridWidth(false) / 2;
		int num4 = operateData.GetBaseGridHeight(false) / 2;
		int num5 = num - num3;
		int startRow = num2 - num4;
		ValueTuple<List<int>, IHonamiStoryDragItemHoverInfo> valueTuple = this.CreateDragItemHoverInfo(operateData, num5, startRow, widthCount, heightCount, false);
		List<int> item = valueTuple.Item1;
		IHonamiStoryDragItemHoverInfo item2 = valueTuple.Item2;
		int num6 = item[0];
		bool flag2 = item.Count < operateData.GetGridFillPositionList().Count;
		bool flag3 = operateAgent.StartOperateBackpack == operateAgent.TargetOperateBackpack && operateData.GetPosition() == num6 && !operateData.GetIsCross();
		bool flag4 = this.CheckSwapValid(operateData, item, false, null, operateData, false);
		if (flag3 || (!flag2 && flag4 && !flag3))
		{
			item2.IsValid = !flag3;
			this.InteractController.RefreshDragItem(operateAgent, false);
			return item2;
		}
		int num7 = operateData.GetBaseGridWidth(true) / 2;
		int num8 = num5 - 1 + operateData.GetBaseGridWidth(false) - num;
		int startColumn = num - num7;
		int startRow2 = num2 - num8;
		ValueTuple<List<int>, IHonamiStoryDragItemHoverInfo> valueTuple2 = this.CreateDragItemHoverInfo(operateData, startColumn, startRow2, widthCount, heightCount, true);
		List<int> item3 = valueTuple2.Item1;
		IHonamiStoryDragItemHoverInfo item4 = valueTuple2.Item2;
		bool flag5 = this.CheckSwapValid(operateData, item3, false, null, operateData, true);
		bool flag6 = item3.Count < operateData.GetGridFillPositionList().Count;
		int num9 = item3[0];
		bool flag7 = operateAgent.StartOperateBackpack == operateAgent.TargetOperateBackpack && operateData.GetPosition() == num9 && operateData.GetIsCross();
		if (flag7 || (flag5 && !flag6 && !flag7 && !flag))
		{
			item4.IsValid = !flag7;
			this.InteractController.RefreshDragItem(operateAgent, true);
			return item4;
		}
		if (!flag2 && this.CheckSwapValid(operateData, item, true, item2, operateData, false))
		{
			item2.IsValid = true;
			this.InteractController.RefreshDragItem(operateAgent, false);
			return item2;
		}
		if (!flag6 && !flag && this.CheckSwapValid(operateData, item3, true, item4, operateData, true))
		{
			item4.IsValid = true;
			this.InteractController.RefreshDragItem(operateAgent, true);
			return item4;
		}
		this.InteractController.RefreshDragItem(operateAgent, false);
		return item2;
	}

	// Token: 0x0600EC9E RID: 60574 RVA: 0x004067CC File Offset: 0x004049CC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private ValueTuple<List<int>, IHonamiStoryDragItemHoverInfo> CreateDragItemHoverInfo(HonamiStoryItemDataBase data, int startColumn, int startRow, int backpackWidth, int backpackHeight, bool isCross)
	{
		int num = 10000;
		int num2 = -1;
		int num3 = 10000;
		int num4 = -1;
		List<int> list = new List<int>();
		for (int i = 0; i < data.GetBaseGridWidth(isCross); i++)
		{
			for (int j = 0; j < data.GetBaseGridHeight(isCross); j++)
			{
				int num5 = i + startColumn;
				int num6 = j + startRow;
				if (num5 >= 0 && num5 < backpackWidth && num6 >= 0 && num6 < backpackHeight)
				{
					int item = num6 * backpackWidth + num5;
					list.Add(item);
					num = Math.Min(num, num6);
					num2 = Math.Max(num2, num6);
					num3 = Math.Min(num3, num5);
					num4 = Math.Max(num4, num5);
				}
			}
		}
		int startPosition = list[0];
		int endPosition = list[list.Count - 1];
		HonamiStoryDragItemHoverInfo item2 = new HonamiStoryDragItemHoverInfo
		{
			IsValid = false,
			StartPosition = startPosition,
			EndPosition = endPosition,
			Width = ((num4 >= num3) ? (num4 - num3 + 1) : 0),
			Height = ((num2 >= num) ? (num2 - num + 1) : 0),
			FillPosList = list
		};
		return new ValueTuple<List<int>, IHonamiStoryDragItemHoverInfo>(list, item2);
	}

	// Token: 0x0600EC9F RID: 60575 RVA: 0x004068E9 File Offset: 0x00404AE9
	public override void OnBackpackLogicStateChange(EHonamiStoryBackpackLogicState state)
	{
		if (state == EHonamiStoryBackpackLogicState.Normal)
		{
			this.RefreshAllDataItem();
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Sell)
		{
			this.RefreshAllDataItem();
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.TipsWithPlugins || state == EHonamiStoryBackpackLogicState.Tips || state != EHonamiStoryBackpackLogicState.DraggingPlugins)
		{
		}
	}

	// Token: 0x0600ECA0 RID: 60576 RVA: 0x00406910 File Offset: 0x00404B10
	private bool CheckSwapValid(HonamiStoryItemDataBase data, List<int> fillPosList, bool canSwap, [Nullable(2)] IHonamiStoryDragItemHoverInfo hoverInfo, HonamiStoryItemDataBase oriItemData, bool isDragCross)
	{
		HashSet<int> hashSet = new HashSet<int>();
		int capacity = this.BackpackData.GetCapacity();
		foreach (int num in fillPosList)
		{
			if (num >= capacity)
			{
				return false;
			}
			hashSet.Add(num);
		}
		HashSet<HonamiStoryItemDataBase> hashSet2 = new HashSet<HonamiStoryItemDataBase>();
		foreach (int key in hashSet)
		{
			HonamiStoryGridItemBase honamiStoryGridItemBase;
			if (this.BackpackItemMap.TryGetValue(key, out honamiStoryGridItemBase) && honamiStoryGridItemBase != null && honamiStoryGridItemBase.GetData() != data)
			{
				HonamiStoryItemDataBase data2 = honamiStoryGridItemBase.GetData();
				if (data2 != null && !hashSet2.Contains(data2))
				{
					if (!canSwap)
					{
						return false;
					}
					foreach (int item in data2.GetGridFillPositionList())
					{
						if (!hashSet.Contains(item))
						{
							return false;
						}
					}
					if (!this.CheckSwapWithItemValid(fillPosList, hoverInfo, oriItemData, data2, isDragCross))
					{
						return false;
					}
					hashSet2.Add(data2);
				}
			}
		}
		return true;
	}

	// Token: 0x0600ECA1 RID: 60577 RVA: 0x00406A78 File Offset: 0x00404C78
	private bool CheckSwapWithItemValid(List<int> fillPosList, [Nullable(2)] IHonamiStoryDragItemHoverInfo hoverInfo, HonamiStoryItemDataBase oriItemData, HonamiStoryItemDataBase gridItemData, bool isDragCross)
	{
		bool itemDataByInstanceId = this.BackpackData.GetItemDataByInstanceId(oriItemData.GetIncId(), false) != null;
		HonamiStoryItemDataBase itemDataByInstanceId2 = this.BackpackData.GetItemDataByInstanceId(gridItemData.GetIncId(), false);
		if (!itemDataByInstanceId || itemDataByInstanceId2 == null)
		{
			return true;
		}
		bool isDragCross2 = oriItemData.GetIsDragCross();
		oriItemData.SetIsDragCross(isDragCross);
		bool isDragCross3 = gridItemData.GetIsDragCross();
		int exchangeItemPosition = this.GetExchangeItemPosition(hoverInfo, oriItemData.GetPosition(), gridItemData.GetPosition(), oriItemData, gridItemData);
		foreach (int item in gridItemData.GetGridFillPositionByPosition(exchangeItemPosition, gridItemData.GetIsDragCross()))
		{
			if (fillPosList.Contains(item))
			{
				oriItemData.SetIsDragCross(isDragCross2);
				gridItemData.SetIsDragCross(isDragCross3);
				return false;
			}
		}
		oriItemData.SetIsDragCross(isDragCross2);
		gridItemData.SetIsDragCross(isDragCross3);
		return true;
	}

	// Token: 0x0600ECA2 RID: 60578 RVA: 0x00406B5C File Offset: 0x00404D5C
	[NullableContext(2)]
	protected void RefreshScrollMoveState(ULGUIPointerEventData eventData)
	{
		if (eventData == null)
		{
			this.MoveUpItem.SetUIActive(false);
			this.MoveDownItem.SetUIActive(false);
			return;
		}
		float stretchTop = this.ContentItem.GetStretchTop();
		bool flag = HonamiStoryUtil.CheckEventDataInItemViewport(eventData, this.MoveUpItem, true) && stretchTop < 0f;
		float stretchBottom = this.ContentItem.GetStretchBottom();
		bool flag2 = HonamiStoryUtil.CheckEventDataInItemViewport(eventData, this.MoveDownItem, true) && stretchBottom < 0f;
		this.MoveUpItem.SetUIActive(flag);
		this.MoveDownItem.SetUIActive(flag2);
		if (flag || flag2)
		{
			float scrollSpeedMulti = this.GetScrollSpeedMulti(flag, eventData);
			this.IsScrollUp = flag;
			this.OnHoveringUpDownPanel(scrollSpeedMulti);
		}
	}

	// Token: 0x0600ECA3 RID: 60579 RVA: 0x00406C0C File Offset: 0x00404E0C
	private void OnHoveringUpDownPanel(float multi)
	{
		FVector location = this.ContentItem.GetRelativeTransform().GetLocation();
		float num = (float)(this.IsScrollUp ? (-(float)this.ScrollSpeed) : this.ScrollSpeed) * multi;
		this.ScrollView.SetScrollValue(new FVector2D(0f, Math.Max(0f, location.Y + num)));
		float stretchTop = this.ContentItem.GetStretchTop();
		float stretchBottom = this.ContentItem.GetStretchBottom();
		if (this.IsScrollUp && stretchTop >= 0f)
		{
			this.MoveUpItem.SetUIActive(false);
			return;
		}
		if (!this.IsScrollUp && stretchBottom >= 0f)
		{
			this.MoveDownItem.SetUIActive(false);
		}
	}

	// Token: 0x0600ECA4 RID: 60580 RVA: 0x00406CC4 File Offset: 0x00404EC4
	private float GetScrollSpeedMulti(bool isUp, ULGUIPointerEventData eventData)
	{
		UUIItem uuiitem = isUp ? this.MoveUpItem : this.MoveDownItem;
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = uuiitem.GetUIWorldPosition();
		if (isUp)
		{
			return (float)((offsetVector.Z > uiworldPosition.Z) ? 2 : 1);
		}
		return (float)((offsetVector.Z > uiworldPosition.Z) ? 1 : 2);
	}

	// Token: 0x0600ECA5 RID: 60581 RVA: 0x00406D20 File Offset: 0x00404F20
	private void OnHonamiStoryBackpackUpdate(HonamiStoryBagUpdateContext updateContext)
	{
		if (updateContext.BackPackConfigId != this.BackpackData.BackpackId)
		{
			return;
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.HonamiStoryPickUpMobileView, true);
		this.RefreshBackpackContextUpdate(updateContext).ContinueWith(delegate()
		{
			if (this.GetBackpackType() == 1)
			{
				this.CurrentValueItem.RefreshInGame();
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.HonamiStoryPickUpMobileView, false);
			foreach (HonamiStoryGridItemBase honamiStoryGridItemBase in this.GetUpdateContextEffectGridItems(updateContext))
			{
				honamiStoryGridItemBase.PlayPosChangeSweepAnimation();
			}
		});
	}

	// Token: 0x0600ECA6 RID: 60582 RVA: 0x00406D90 File Offset: 0x00404F90
	public override List<HonamiStoryGridItemBase> GetUpdateContextEffectGridItems(HonamiStoryBagUpdateContext updateContext)
	{
		List<HonamiStoryGridItemBase> list = new List<HonamiStoryGridItemBase>();
		foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo in updateContext.HonamiStoryBagUpdateInfo)
		{
			bool needLog = honamiStoryBagUpdateInfo.Type != 2;
			if (this.BackpackData.GetItemDataByInstanceId(honamiStoryBagUpdateInfo.ItemIncrId, needLog) != null && (honamiStoryBagUpdateInfo.Type == 0 || honamiStoryBagUpdateInfo.Type == 1))
			{
				int position = honamiStoryBagUpdateInfo.HonamiStoryPosInfo.Position;
				HonamiStoryGridItemBase honamiStoryGridItemBase;
				if (this.BackpackItemMap.TryGetValue(position, out honamiStoryGridItemBase) && honamiStoryGridItemBase != null)
				{
					list.Add(honamiStoryGridItemBase);
				}
			}
		}
		return list;
	}

	// Token: 0x0600ECA7 RID: 60583 RVA: 0x00406E3C File Offset: 0x0040503C
	public override void RefreshSingleItem(HonamiStoryItemDataBase itemData)
	{
		int position = itemData.GetPosition();
		HonamiStoryGridItemBase honamiStoryGridItemBase;
		if (this.BackpackItemMap.TryGetValue(position, out honamiStoryGridItemBase) && honamiStoryGridItemBase != null)
		{
			if (honamiStoryGridItemBase.GetData() != itemData)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HonamiStory;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "Get Error Grid With Data";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pos", position);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			honamiStoryGridItemBase.Refresh(itemData, itemData.GetPosition());
		}
	}

	// Token: 0x0600ECA8 RID: 60584 RVA: 0x00406EAC File Offset: 0x004050AC
	protected void RefreshAllDataItem()
	{
		HashSet<HonamiStoryGridItemBase> hashSet = new HashSet<HonamiStoryGridItemBase>();
		foreach (KeyValuePair<int, HonamiStoryGridItemBase> keyValuePair in this.BackpackItemMap)
		{
			HonamiStoryGridItemBase value = keyValuePair.Value;
			if (!hashSet.Contains(value) && value != null)
			{
				hashSet.Add(value);
				HonamiStoryItemDataBase data = value.GetData();
				if (data != null)
				{
					value.Refresh(data, data.GetPosition());
				}
			}
		}
	}

	// Token: 0x040071A5 RID: 29093
	private const int EQUIP_OFFSET = 300;

	// Token: 0x040071A6 RID: 29094
	private HonamiStoryBackpackData BackpackData;

	// Token: 0x040071A7 RID: 29095
	public UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x040071A8 RID: 29096
	public UUIItem ViewportItem;

	// Token: 0x040071A9 RID: 29097
	public float ViewportHeight;

	// Token: 0x040071AA RID: 29098
	public int EquipCount;

	// Token: 0x040071AB RID: 29099
	public UUIItem ContentItem;

	// Token: 0x040071AC RID: 29100
	public UUIItem MoveUpItem;

	// Token: 0x040071AD RID: 29101
	public UUIItem MoveDownItem;

	// Token: 0x040071AE RID: 29102
	public HonamiStoryBackpackValueCountItem CurrentValueItem;

	// Token: 0x040071AF RID: 29103
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<int, HonamiStoryGridItemBase> BackpackItemMap = new Dictionary<int, HonamiStoryGridItemBase>();

	// Token: 0x040071B0 RID: 29104
	private readonly HashSet<HonamiStoryGridItemBase> BackpackItemPool = new HashSet<HonamiStoryGridItemBase>();

	// Token: 0x040071B1 RID: 29105
	[Nullable(2)]
	private IHonamiStoryDragItemHoverInfo DragItemHoverInfo;

	// Token: 0x040071B2 RID: 29106
	private int HoverPosition = -1;

	// Token: 0x040071B3 RID: 29107
	private int LastViewportStartPosition = -1;

	// Token: 0x040071B4 RID: 29108
	private int LastViewportEndPosition = -1;

	// Token: 0x040071B5 RID: 29109
	private int CurViewportStartPosition = -1;

	// Token: 0x040071B6 RID: 29110
	private int CurViewportEndPosition = -1;

	// Token: 0x040071B7 RID: 29111
	private bool IsScrollUp;

	// Token: 0x040071B8 RID: 29112
	private int ScrollSpeed = 10;

	// Token: 0x040071B9 RID: 29113
	private readonly HashSet<int> GridCreateAsyncLock = new HashSet<int>();

	// Token: 0x0200823F RID: 33343
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402C2C3 RID: 180931
		Panel,
		// Token: 0x0402C2C4 RID: 180932
		SpriteMask,
		// Token: 0x0402C2C5 RID: 180933
		SpriteState,
		// Token: 0x0402C2C6 RID: 180934
		SpriteSelect
	}
}
