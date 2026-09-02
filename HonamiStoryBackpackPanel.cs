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

// Token: 0x02001EF3 RID: 7923
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryBackpackPanel : HonamiStoryBackpackPanelBase
{
	// Token: 0x0600EB8F RID: 60303 RVA: 0x003FFD48 File Offset: 0x003FDF48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem))
		};
	}

	// Token: 0x0600EB90 RID: 60304 RVA: 0x003FFEC8 File Offset: 0x003FE0C8
	protected override void OnStart()
	{
		this.ScrollSpeed = ConfigBase<HonamiStoryConfig>.Instance.GetScrollingSpeed();
		this.ScrollView = base.GetScrollViewWithScrollbar(2);
		this.ViewportItem = base.GetItem(3);
		this.ViewportHeight = this.ViewportItem.GetHeight();
		this.ContentItem = base.GetItem(4);
		base.GetSprite(5).SetUIActive(false);
		base.GetSprite(5).SetHierarchyIndex(99);
		base.GetSprite(6).SetUIActive(false);
		base.GetSprite(6).SetHierarchyIndex(100);
		this.RefreshScrollMoveState(null);
	}

	// Token: 0x0600EB91 RID: 60305 RVA: 0x003FFF5A File Offset: 0x003FE15A
	protected override void OnBeforeShow()
	{
		this.AddEventListener();
	}

	// Token: 0x0600EB92 RID: 60306 RVA: 0x003FFF64 File Offset: 0x003FE164
	private void AddEventListener()
	{
		this.ScrollView.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		Singleton<EventSystem>.Instance.Add<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStorySortSuccess, new Action(this.OnSortSuccess));
	}

	// Token: 0x0600EB93 RID: 60307 RVA: 0x003FFFC8 File Offset: 0x003FE1C8
	public UniTask Init(HonamiStoryBackpackData backpackData)
	{
		HonamiStoryBackpackPanel.<Init>d__29 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.backpackData = backpackData;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<Init>d__29>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB94 RID: 60308 RVA: 0x00400014 File Offset: 0x003FE214
	private UniTask InitBottomButton()
	{
		HonamiStoryBackpackPanel.<InitBottomButton>d__30 <InitBottomButton>d__;
		<InitBottomButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBottomButton>d__.<>4__this = this;
		<InitBottomButton>d__.<>1__state = -1;
		<InitBottomButton>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<InitBottomButton>d__30>(ref <InitBottomButton>d__);
		return <InitBottomButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB95 RID: 60309 RVA: 0x00400058 File Offset: 0x003FE258
	private UniTask UpdateViewportItems()
	{
		HonamiStoryBackpackPanel.<UpdateViewportItems>d__31 <UpdateViewportItems>d__;
		<UpdateViewportItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateViewportItems>d__.<>4__this = this;
		<UpdateViewportItems>d__.<>1__state = -1;
		<UpdateViewportItems>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<UpdateViewportItems>d__31>(ref <UpdateViewportItems>d__);
		return <UpdateViewportItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB96 RID: 60310 RVA: 0x0040009C File Offset: 0x003FE29C
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

	// Token: 0x0600EB97 RID: 60311 RVA: 0x004000F8 File Offset: 0x003FE2F8
	private UniTask UpdateWhenOverflowChange(int changeNum)
	{
		HonamiStoryBackpackPanel.<UpdateWhenOverflowChange>d__33 <UpdateWhenOverflowChange>d__;
		<UpdateWhenOverflowChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateWhenOverflowChange>d__.<>4__this = this;
		<UpdateWhenOverflowChange>d__.<>1__state = -1;
		<UpdateWhenOverflowChange>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<UpdateWhenOverflowChange>d__33>(ref <UpdateWhenOverflowChange>d__);
		return <UpdateWhenOverflowChange>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB98 RID: 60312 RVA: 0x0040013C File Offset: 0x003FE33C
	[NullableContext(2)]
	private void RefreshMask(HonamiStoryItemDataBase itemData)
	{
		if (itemData == null)
		{
			base.GetSprite(5).SetUIActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(5);
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

	// Token: 0x0600EB99 RID: 60313 RVA: 0x004001C8 File Offset: 0x003FE3C8
	[NullableContext(2)]
	private void RefreshHoverTip(IHonamiStoryDragItemHoverInfo hoverInfo)
	{
		if (hoverInfo == null)
		{
			base.GetSprite(6).SetUIActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(6);
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

	// Token: 0x0600EB9A RID: 60314 RVA: 0x0040026C File Offset: 0x003FE46C
	private UniTask CreateHonamiStoryGridItem(int position)
	{
		HonamiStoryBackpackPanel.<CreateHonamiStoryGridItem>d__36 <CreateHonamiStoryGridItem>d__;
		<CreateHonamiStoryGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateHonamiStoryGridItem>d__.<>4__this = this;
		<CreateHonamiStoryGridItem>d__.position = position;
		<CreateHonamiStoryGridItem>d__.<>1__state = -1;
		<CreateHonamiStoryGridItem>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<CreateHonamiStoryGridItem>d__36>(ref <CreateHonamiStoryGridItem>d__);
		return <CreateHonamiStoryGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB9B RID: 60315 RVA: 0x004002B8 File Offset: 0x003FE4B8
	private UniTask CreateEmptyGridItem(int position)
	{
		HonamiStoryBackpackPanel.<CreateEmptyGridItem>d__37 <CreateEmptyGridItem>d__;
		<CreateEmptyGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateEmptyGridItem>d__.<>4__this = this;
		<CreateEmptyGridItem>d__.position = position;
		<CreateEmptyGridItem>d__.<>1__state = -1;
		<CreateEmptyGridItem>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<CreateEmptyGridItem>d__37>(ref <CreateEmptyGridItem>d__);
		return <CreateEmptyGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB9C RID: 60316 RVA: 0x00400304 File Offset: 0x003FE504
	private void SetItemOffset(UUIItem item, int position)
	{
		int num = position / this.BackpackData.GetWidthCount();
		int num2 = position % this.BackpackData.GetWidthCount();
		int num3 = num2 * this.BackpackData.GetCellWidth() + (num2 + 1) * this.BackpackData.GetCellHorizontalInterval();
		int num4 = -num * this.BackpackData.GetCellHeight() - (num + 1) * this.BackpackData.GetCellVerticalInterval();
		item.SetAnchorOffsetX((float)num3);
		item.SetAnchorOffsetY((float)num4);
	}

	// Token: 0x0600EB9D RID: 60317 RVA: 0x0040037C File Offset: 0x003FE57C
	private UniTask FillBackpackItemMap(HonamiStoryItemDataBase itemData, HonamiStoryGridItemBase item)
	{
		HonamiStoryBackpackPanel.<FillBackpackItemMap>d__39 <FillBackpackItemMap>d__;
		<FillBackpackItemMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FillBackpackItemMap>d__.<>4__this = this;
		<FillBackpackItemMap>d__.itemData = itemData;
		<FillBackpackItemMap>d__.item = item;
		<FillBackpackItemMap>d__.<>1__state = -1;
		<FillBackpackItemMap>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<FillBackpackItemMap>d__39>(ref <FillBackpackItemMap>d__);
		return <FillBackpackItemMap>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB9E RID: 60318 RVA: 0x004003D0 File Offset: 0x003FE5D0
	private UniTask RecycleGridItem(int position)
	{
		HonamiStoryBackpackPanel.<RecycleGridItem>d__40 <RecycleGridItem>d__;
		<RecycleGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RecycleGridItem>d__.<>4__this = this;
		<RecycleGridItem>d__.position = position;
		<RecycleGridItem>d__.<>1__state = -1;
		<RecycleGridItem>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<RecycleGridItem>d__40>(ref <RecycleGridItem>d__);
		return <RecycleGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB9F RID: 60319 RVA: 0x0040041C File Offset: 0x003FE61C
	private UniTask RecycleChangeGridItem(int position)
	{
		HonamiStoryBackpackPanel.<RecycleChangeGridItem>d__41 <RecycleChangeGridItem>d__;
		<RecycleChangeGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RecycleChangeGridItem>d__.<>4__this = this;
		<RecycleChangeGridItem>d__.position = position;
		<RecycleChangeGridItem>d__.<>1__state = -1;
		<RecycleChangeGridItem>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<RecycleChangeGridItem>d__41>(ref <RecycleChangeGridItem>d__);
		return <RecycleChangeGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EBA0 RID: 60320 RVA: 0x00400468 File Offset: 0x003FE668
	private UniTask RecycleEmptyGridItem(int position)
	{
		HonamiStoryBackpackPanel.<RecycleEmptyGridItem>d__42 <RecycleEmptyGridItem>d__;
		<RecycleEmptyGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RecycleEmptyGridItem>d__.<>4__this = this;
		<RecycleEmptyGridItem>d__.position = position;
		<RecycleEmptyGridItem>d__.<>1__state = -1;
		<RecycleEmptyGridItem>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<RecycleEmptyGridItem>d__42>(ref <RecycleEmptyGridItem>d__);
		return <RecycleEmptyGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EBA1 RID: 60321 RVA: 0x004004B4 File Offset: 0x003FE6B4
	private UniTask RefreshBackpackContextUpdate(HonamiStoryBagUpdateContext updateContext)
	{
		HonamiStoryBackpackPanel.<RefreshBackpackContextUpdate>d__43 <RefreshBackpackContextUpdate>d__;
		<RefreshBackpackContextUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshBackpackContextUpdate>d__.<>4__this = this;
		<RefreshBackpackContextUpdate>d__.updateContext = updateContext;
		<RefreshBackpackContextUpdate>d__.<>1__state = -1;
		<RefreshBackpackContextUpdate>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<RefreshBackpackContextUpdate>d__43>(ref <RefreshBackpackContextUpdate>d__);
		return <RefreshBackpackContextUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0600EBA2 RID: 60322 RVA: 0x00400500 File Offset: 0x003FE700
	private UniTask FillEmptyGridInViewport()
	{
		HonamiStoryBackpackPanel.<FillEmptyGridInViewport>d__44 <FillEmptyGridInViewport>d__;
		<FillEmptyGridInViewport>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FillEmptyGridInViewport>d__.<>4__this = this;
		<FillEmptyGridInViewport>d__.<>1__state = -1;
		<FillEmptyGridInViewport>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<FillEmptyGridInViewport>d__44>(ref <FillEmptyGridInViewport>d__);
		return <FillEmptyGridInViewport>d__.<>t__builder.Task;
	}

	// Token: 0x0600EBA3 RID: 60323 RVA: 0x00400544 File Offset: 0x003FE744
	private bool CheckItemInViewport(HonamiStoryGridItemBase item)
	{
		HonamiStoryItemDataBase data = item.GetData();
		return data != null && this.CheckItemDataInViewport(data);
	}

	// Token: 0x0600EBA4 RID: 60324 RVA: 0x00400564 File Offset: 0x003FE764
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

	// Token: 0x0600EBA5 RID: 60325 RVA: 0x004005C0 File Offset: 0x003FE7C0
	private bool CheckPositionInViewport(int position)
	{
		return position >= this.CurViewportStartPosition && position <= this.CurViewportEndPosition;
	}

	// Token: 0x0600EBA6 RID: 60326 RVA: 0x004005D7 File Offset: 0x003FE7D7
	protected override void OnBeforeHide()
	{
		this.RemoveEventListener();
	}

	// Token: 0x0600EBA7 RID: 60327 RVA: 0x004005E0 File Offset: 0x003FE7E0
	private void RemoveEventListener()
	{
		this.ScrollView.OnScrollValueChange.Unbind();
		Singleton<EventSystem>.Instance.Remove<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, new Action<HonamiStoryBagUpdateContext>(this.OnHonamiStoryBackpackUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStorySortSuccess, new Action(this.OnSortSuccess));
	}

	// Token: 0x0600EBA8 RID: 60328 RVA: 0x00400638 File Offset: 0x003FE838
	[NullableContext(2)]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<HonamiStoryGridItemBase> GetHonamiStoryGridItem(bool needItem = false, HonamiStoryItemDataBase itemData = null)
	{
		HonamiStoryBackpackPanel.<GetHonamiStoryGridItem>d__50 <GetHonamiStoryGridItem>d__;
		<GetHonamiStoryGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<HonamiStoryGridItemBase>.Create();
		<GetHonamiStoryGridItem>d__.<>4__this = this;
		<GetHonamiStoryGridItem>d__.needItem = needItem;
		<GetHonamiStoryGridItem>d__.itemData = itemData;
		<GetHonamiStoryGridItem>d__.<>1__state = -1;
		<GetHonamiStoryGridItem>d__.<>t__builder.Start<HonamiStoryBackpackPanel.<GetHonamiStoryGridItem>d__50>(ref <GetHonamiStoryGridItem>d__);
		return <GetHonamiStoryGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EBA9 RID: 60329 RVA: 0x0040068B File Offset: 0x003FE88B
	private void OnScrollValueChange(FVector2D inVector)
	{
		ModelBase<HonamiStoryModel>.Instance.GetInteractController().RefreshSelectedUiItem();
		this.UpdateViewportItems();
	}

	// Token: 0x0600EBAA RID: 60330 RVA: 0x004006A3 File Offset: 0x003FE8A3
	public override int GetBackpackType()
	{
		return (int)this.BackpackData.BackpackType;
	}

	// Token: 0x0600EBAB RID: 60331 RVA: 0x004006B0 File Offset: 0x003FE8B0
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

	// Token: 0x0600EBAC RID: 60332 RVA: 0x00400705 File Offset: 0x003FE905
	public override void OnHoverEnd()
	{
		this.HoverPosition = -1;
		this.DragItemHoverInfo = null;
		this.RefreshScrollMoveState(null);
		this.RefreshHoverTip(null);
	}

	// Token: 0x0600EBAD RID: 60333 RVA: 0x00400723 File Offset: 0x003FE923
	public override bool OnDragBegin([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		HonamiStoryItemDataBase data = item.GetData();
		this.CurMaskingItemIncId = ((data != null) ? data.GetIncId() : -1);
		this.RefreshMask(item.GetData());
		this.RefreshScrollMoveState(null);
		return base.OnDragBegin(eventData, item);
	}

	// Token: 0x0600EBAE RID: 60334 RVA: 0x00400758 File Offset: 0x003FE958
	public override bool OnDrag([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		int curMaskingItemIncId = this.CurMaskingItemIncId;
		HonamiStoryItemDataBase data = item.GetData();
		if (curMaskingItemIncId == ((data != null) ? data.GetIncId() : -1))
		{
			this.RefreshMask(item.GetData());
		}
		else
		{
			this.RefreshMask(null);
		}
		return base.OnDrag(eventData, item);
	}

	// Token: 0x0600EBAF RID: 60335 RVA: 0x00400791 File Offset: 0x003FE991
	public override void OnDragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.CurMaskingItemIncId = -1;
		this.RefreshMask(null);
		base.OnDragEnd(eventData, item);
		this.RefreshScrollMoveState(null);
	}

	// Token: 0x0600EBB0 RID: 60336 RVA: 0x004007B0 File Offset: 0x003FE9B0
	public int GetDragItemPositionInContent(ULGUIPointerEventData eventData)
	{
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = this.ContentItem.GetUIWorldPosition();
		float num = uiworldPosition.X - this.ContentItem.GetWidth() / 2f;
		float num2 = num + this.ContentItem.GetWidth();
		float num3 = uiworldPosition.Z - this.ContentItem.GetHeight() / 2f;
		float num4 = num3 + this.ContentItem.GetHeight();
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

	// Token: 0x0600EBB1 RID: 60337 RVA: 0x004008B8 File Offset: 0x003FEAB8
	public override bool CheckDragItemInViewport(ULGUIPointerEventData eventData)
	{
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = this.ViewportItem.GetUIWorldPosition();
		float num = uiworldPosition.X - this.ViewportItem.GetWidth() / 2f;
		float num2 = num + this.ViewportItem.GetWidth();
		float num3 = uiworldPosition.Z - this.ViewportItem.GetHeight() / 2f;
		float num4 = num3 + this.ViewportItem.GetHeight();
		return offsetVector.X >= num && offsetVector.X <= num2 && offsetVector.Z >= num3 && offsetVector.Z <= num4;
	}

	// Token: 0x0600EBB2 RID: 60338 RVA: 0x00400954 File Offset: 0x003FEB54
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

	// Token: 0x0600EBB3 RID: 60339 RVA: 0x00400B68 File Offset: 0x003FED68
	private int GetExchangeItemPosition(IHonamiStoryDragItemHoverInfo hoverInfo, int itemPosition, int position, HonamiStoryItemDataBase oriItemData, HonamiStoryItemDataBase otherData)
	{
		if (oriItemData.GetIsCross() == oriItemData.GetIsDragCross())
		{
			return this.GetExchangeItemPositionNoCrossChange(hoverInfo, itemPosition, position, otherData);
		}
		return this.GetExchangeItemPositionCrossChange(hoverInfo, itemPosition, position, oriItemData, otherData);
	}

	// Token: 0x0600EBB4 RID: 60340 RVA: 0x00400B94 File Offset: 0x003FED94
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

	// Token: 0x0600EBB5 RID: 60341 RVA: 0x00400C8C File Offset: 0x003FEE8C
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

	// Token: 0x0600EBB6 RID: 60342 RVA: 0x00400D0C File Offset: 0x003FEF0C
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

	// Token: 0x0600EBB7 RID: 60343 RVA: 0x00400ED0 File Offset: 0x003FF0D0
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

	// Token: 0x0600EBB8 RID: 60344 RVA: 0x00400F78 File Offset: 0x003FF178
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

	// Token: 0x0600EBB9 RID: 60345 RVA: 0x0040101C File Offset: 0x003FF21C
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

	// Token: 0x0600EBBA RID: 60346 RVA: 0x0040126C File Offset: 0x003FF46C
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

	// Token: 0x0600EBBB RID: 60347 RVA: 0x0040138C File Offset: 0x003FF58C
	public override void OnBackpackLogicStateChange(EHonamiStoryBackpackLogicState state)
	{
		if (state == EHonamiStoryBackpackLogicState.Normal)
		{
			this.RefreshBottomButton(state);
			this.RefreshAllDataItem();
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Sell)
		{
			this.RefreshBottomButton(state);
			this.RefreshAllDataItem();
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.DraggingPlugins || state == EHonamiStoryBackpackLogicState.Dragging)
		{
			this.RefreshBottomButton(state);
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.TipsWithPlugins || state != EHonamiStoryBackpackLogicState.Tips)
		{
		}
	}

	// Token: 0x0600EBBC RID: 60348 RVA: 0x004013D8 File Offset: 0x003FF5D8
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

	// Token: 0x0600EBBD RID: 60349 RVA: 0x00401540 File Offset: 0x003FF740
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

	// Token: 0x0600EBBE RID: 60350 RVA: 0x00401624 File Offset: 0x003FF824
	private void OnHonamiStoryBackpackUpdate(HonamiStoryBagUpdateContext updateContext)
	{
		if (updateContext.BackPackConfigId != this.BackpackData.BackpackId)
		{
			return;
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.HonamiStoryBackpackView, true);
		this.RefreshBackpackContextUpdate(updateContext).ContinueWith(delegate()
		{
			HonamiStoryBackpackTitleItem titlePanel = this.TitlePanel;
			if (titlePanel != null)
			{
				titlePanel.Refresh();
			}
			if (HonamiStoryUtil.CheckInHonamiStoryDungeon() && this.GetBackpackType() == 1)
			{
				HonamiStoryBackpackValueCountItem currentValueItem = this.CurrentValueItem;
				if (currentValueItem != null)
				{
					currentValueItem.RefreshInGame();
				}
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.HonamiStoryBackpackView, false);
			foreach (HonamiStoryGridItemBase honamiStoryGridItemBase in this.GetUpdateContextEffectGridItems(updateContext))
			{
				honamiStoryGridItemBase.PlayPosChangeSweepAnimation();
			}
		});
	}

	// Token: 0x0600EBBF RID: 60351 RVA: 0x00401694 File Offset: 0x003FF894
	private void OnSortSuccess()
	{
		this.ScrollView.StopMovement();
		FVector2D fvector2D = new FVector2D();
		this.ScrollView.ScrollToTop(ref fvector2D, this.ContentItem, true);
	}

	// Token: 0x0600EBC0 RID: 60352 RVA: 0x004016C8 File Offset: 0x003FF8C8
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

	// Token: 0x0600EBC1 RID: 60353 RVA: 0x00401774 File Offset: 0x003FF974
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

	// Token: 0x0600EBC2 RID: 60354 RVA: 0x004017E4 File Offset: 0x003FF9E4
	protected void RefreshBottomButton(EHonamiStoryBackpackLogicState state)
	{
		if (this.GetBackpackType() == 2)
		{
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Normal || state == EHonamiStoryBackpackLogicState.Sell)
		{
			bool flag = state == EHonamiStoryBackpackLogicState.Normal;
			string textId = flag ? "HonamiStory_BackpackSort" : "HonamiStory_ClickSell";
			ButtonItem buttonRight = this.ButtonRight;
			if (buttonRight != null)
			{
				buttonRight.SetLocalTextNew(textId, Array.Empty<object>());
			}
			ButtonItem buttonSell = this.ButtonSell;
			if (buttonSell != null)
			{
				buttonSell.SetUiActive(flag);
			}
			bool flag2 = HonamiStoryUtil.CheckInHonamiStoryDungeon();
			this.CurrentValueItem.SetVisible(!flag || flag2);
			this.SetButtonAlpha(true);
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.DraggingPlugins || state == EHonamiStoryBackpackLogicState.Dragging)
		{
			this.SetButtonAlpha(false);
		}
	}

	// Token: 0x0600EBC3 RID: 60355 RVA: 0x00401870 File Offset: 0x003FFA70
	protected void SetButtonAlpha(bool isEnable)
	{
		ButtonItem buttonRight = this.ButtonRight;
		if (buttonRight != null)
		{
			buttonRight.SetEnableClick(isEnable);
		}
		ButtonItem buttonSell = this.ButtonSell;
		if (buttonSell != null)
		{
			buttonSell.SetEnableClick(isEnable);
		}
		float alpha = isEnable ? 1f : 0.4f;
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetAlpha(alpha);
	}

	// Token: 0x0600EBC4 RID: 60356 RVA: 0x004018C4 File Offset: 0x003FFAC4
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

	// Token: 0x0600EBC5 RID: 60357 RVA: 0x00401950 File Offset: 0x003FFB50
	[NullableContext(2)]
	protected void RefreshScrollMoveState(ULGUIPointerEventData eventData)
	{
		if (eventData != null)
		{
			float stretchTop = this.ContentItem.GetStretchTop();
			bool flag = HonamiStoryUtil.CheckEventDataInItemViewport(eventData, base.GetItem(12), true) && stretchTop < 0f;
			float stretchBottom = this.ContentItem.GetStretchBottom();
			bool flag2 = HonamiStoryUtil.CheckEventDataInItemViewport(eventData, base.GetItem(13), true) && stretchBottom < 0f;
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(13);
			if (item2 != null)
			{
				item2.SetUIActive(flag2);
			}
			if (flag || flag2)
			{
				float scrollSpeedMulti = this.GetScrollSpeedMulti(flag, eventData);
				this.IsScrollUp = flag;
				this.OnHoveringUpDownPanel(scrollSpeedMulti);
			}
			return;
		}
		UUIItem item3 = base.GetItem(12);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(13);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(false);
	}

	// Token: 0x0600EBC6 RID: 60358 RVA: 0x00401A20 File Offset: 0x003FFC20
	private void OnHoveringUpDownPanel(float multi)
	{
		FVector location = this.ContentItem.GetRelativeTransform().GetLocation();
		float num = (float)(this.IsScrollUp ? (-(float)this.ScrollSpeed) : this.ScrollSpeed) * multi;
		this.ScrollView.SetScrollValue(new FVector2D(0f, Math.Max(0f, location.Y + num)));
		float stretchTop = this.ContentItem.GetStretchTop();
		float stretchBottom = this.ContentItem.GetStretchBottom();
		if (!this.IsScrollUp || stretchTop < 0f)
		{
			if (!this.IsScrollUp && stretchBottom >= 0f)
			{
				UUIItem item = base.GetItem(13);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}
			return;
		}
		UUIItem item2 = base.GetItem(12);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600EBC7 RID: 60359 RVA: 0x00401AE4 File Offset: 0x003FFCE4
	private float GetScrollSpeedMulti(bool isUp, ULGUIPointerEventData eventData)
	{
		HonamiStoryBackpackPanel.EComponent name = isUp ? HonamiStoryBackpackPanel.EComponent.PanelGoTop : HonamiStoryBackpackPanel.EComponent.PanelGoDown;
		UUIItem item = base.GetItem((int)name);
		FVector offsetVector = HonamiStoryUtil.GetOffsetVector(eventData.GetWorldPointInPlane());
		FVector uiworldPosition = item.GetUIWorldPosition();
		if (isUp)
		{
			return (float)((offsetVector.Z > uiworldPosition.Z) ? 2 : 1);
		}
		return (float)((offsetVector.Z > uiworldPosition.Z) ? 1 : 2);
	}

	// Token: 0x0600EBC8 RID: 60360 RVA: 0x00401B40 File Offset: 0x003FFD40
	protected void SetBottomItemEnable(bool value)
	{
		UiPanelBase overflowBottomItem = this.OverflowBottomItem;
		if (overflowBottomItem != null)
		{
			overflowBottomItem.SetUiActive(value);
		}
		if (value && this.OverflowBottomItem != null)
		{
			int position = this.BackpackData.GetCapacity() + this.BackpackData.GetOverflowCapacity();
			this.SetItemOffset(this.OverflowBottomItem.GetRootItem(), position);
			UiPanelBase overflowBottomItem2 = this.OverflowBottomItem;
			if (overflowBottomItem2 == null)
			{
				return;
			}
			overflowBottomItem2.GetRootItem().SetAsLastHierarchy();
		}
	}

	// Token: 0x0600EBC9 RID: 60361 RVA: 0x00401BAC File Offset: 0x003FFDAC
	private void OnClickQuickSell(int _)
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Normal)
		{
			if (backpackLogic != null)
			{
				backpackLogic.SetLogicState(EHonamiStoryBackpackLogicState.Sell, null, null);
				return;
			}
		}
		else if ((backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || backpackLogicState == EHonamiStoryBackpackLogicState.Tips) && backpackLogic != null)
		{
			backpackLogic.CloseTips();
		}
	}

	// Token: 0x0600EBCA RID: 60362 RVA: 0x00401BF8 File Offset: 0x003FFDF8
	private void OnClickRight(int _)
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		EHonamiStoryBackpackLogicState logicState = backpackLogic.GetLogicState();
		if (logicState == EHonamiStoryBackpackLogicState.Normal)
		{
			ModelBase<HonamiStoryModel>.Instance.SortBackpack();
			return;
		}
		if (logicState == EHonamiStoryBackpackLogicState.Sell)
		{
			backpackLogic.DoSell();
			return;
		}
		if ((logicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || logicState == EHonamiStoryBackpackLogicState.Tips) && backpackLogic != null)
		{
			backpackLogic.CloseTips();
		}
	}

	// Token: 0x0600EBCB RID: 60363 RVA: 0x00401C44 File Offset: 0x003FFE44
	public override List<HonamiStoryGridItemBase> GetCurrentGridListGamepad()
	{
		List<HonamiStoryGridItemBase> list = new List<HonamiStoryGridItemBase>();
		List<int> list2 = new List<int>();
		foreach (KeyValuePair<int, HonamiStoryGridItemBase> keyValuePair in this.BackpackItemMap)
		{
			list2.Add(keyValuePair.Key);
		}
		list2.Sort((int a, int b) => a - b);
		foreach (int key in list2)
		{
			HonamiStoryGridItemBase honamiStoryGridItemBase;
			if (this.BackpackItemMap.TryGetValue(key, out honamiStoryGridItemBase) && honamiStoryGridItemBase != null)
			{
				list.Add(honamiStoryGridItemBase);
			}
		}
		return list;
	}

	// Token: 0x0600EBCC RID: 60364 RVA: 0x00401D24 File Offset: 0x003FFF24
	public override bool CheckPositionValidGamepad(int position)
	{
		return this.CheckPositionInViewport(position);
	}

	// Token: 0x0600EBCD RID: 60365 RVA: 0x00401D30 File Offset: 0x003FFF30
	public override void OnScrollToTopOrBottomGamepad(bool toTop)
	{
		if (toTop)
		{
			FVector2D fvector2D = new FVector2D();
			this.ScrollView.ScrollToTop(ref fvector2D, this.ContentItem, false);
			return;
		}
		FVector2D fvector2D2 = new FVector2D();
		this.ScrollView.ScrollToBottom(ref fvector2D2, this.ContentItem, false);
	}

	// Token: 0x0600EBCE RID: 60366 RVA: 0x00401D78 File Offset: 0x003FFF78
	public override void OnScrollValueChangedGamepad(bool isUp)
	{
		FVector location = this.ContentItem.GetRelativeTransform().GetLocation();
		int num = (isUp ? (-this.ScrollSpeed) : this.ScrollSpeed) * 15;
		float inY = Math.Max(0f, location.Y + (float)num);
		this.ScrollView.SetScrollValue(new FVector2D(0f, inY));
	}

	// Token: 0x0600EBCF RID: 60367 RVA: 0x00401DDC File Offset: 0x003FFFDC
	public override void OnHoverGamepad(HonamiStoryGridItemBase targetItem, int position, HonamiStoryInteractOperateAgent operateAgent)
	{
		if (position == -1)
		{
			return;
		}
		if (this.HoverPosition == position)
		{
			return;
		}
		if (operateAgent.OperateData == null)
		{
			return;
		}
		this.DragItemHoverInfo = this.GetDragItemHoverInfo(operateAgent, position);
		this.HoverPosition = position;
		this.RefreshHoverTip(this.DragItemHoverInfo);
		HonamiStoryBackpackView honamiStoryBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) as HonamiStoryBackpackView;
		if (honamiStoryBackpackView != null)
		{
			honamiStoryBackpackView.ShowTipsHotKeyOnly(targetItem);
		}
		HonamiStoryPickUpBackpackView honamiStoryPickUpBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) as HonamiStoryPickUpBackpackView;
		if (honamiStoryPickUpBackpackView != null)
		{
			honamiStoryPickUpBackpackView.ShowTipsHotKeyOnly(targetItem);
		}
	}

	// Token: 0x0600EBD0 RID: 60368 RVA: 0x00401E60 File Offset: 0x00400060
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase itemData)
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
				hashSet.Add(itemDataByPosition.GetIncId());
				int exchangeItemPosition = this.GetExchangeItemPosition(this.DragItemHoverInfo, itemData.GetPosition(), itemDataByPosition.GetPosition(), itemData, itemDataByPosition);
				List<int> gridFillPositionByPosition = itemDataByPosition.GetGridFillPositionByPosition(exchangeItemPosition, itemDataByPosition.GetIsDragCross());
				bool flag = true;
				foreach (int item in gridFillPositionByPosition)
				{
					if (fillPosList.Contains(item))
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
				HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo2 = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(itemDataByPosition, exchangeItemPosition);
				honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo2);
			}
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EBD1 RID: 60369 RVA: 0x00402030 File Offset: 0x00400230
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateData, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		HashSet<int> hashSet = new HashSet<int>(this.BackpackData.GetEmptyGridSet());
		foreach (int item in operateData.GetGridFillPositionList())
		{
			hashSet.Add(item);
		}
		List<int> list = new List<int>();
		List<HonamiStoryItemDataBase> list2 = new List<HonamiStoryItemDataBase>(exchangeItemSet);
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in list2)
		{
			if (honamiStoryItemDataBase != null)
			{
				IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(hashSet, honamiStoryItemDataBase, this.BackpackData.GetWidthCount(), null);
				if (honamiStoryAvailablePosInfo.Position == -1)
				{
					return null;
				}
				List<int> gridFillPositionByPosition = honamiStoryItemDataBase.GetGridFillPositionByPosition(honamiStoryAvailablePosInfo.Position, honamiStoryAvailablePosInfo.IsCross);
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

	// Token: 0x0600EBD2 RID: 60370 RVA: 0x004021A4 File Offset: 0x004003A4
	[return: Nullable(2)]
	public override HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateData, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
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

	// Token: 0x0600EBD3 RID: 60371 RVA: 0x0040224C File Offset: 0x0040044C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override HashSet<HonamiStoryItemDataBase> GetExchangeItemSetGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem)
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

	// Token: 0x0600EBD4 RID: 60372 RVA: 0x004022F0 File Offset: 0x004004F0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "BtnSell")
		{
			UUIItem guideUiItem = base.GetGuideUiItem("0");
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}
		else if (a == "ToggleSelect")
		{
			UUIItem guideUiItem2 = base.GetGuideUiItem("1");
			if (guideUiItem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem2,
				guideUiItem2
			};
		}
		else if (a == "BtnReset")
		{
			UUIItem guideUiItem3 = base.GetGuideUiItem("2");
			if (guideUiItem3 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem3,
				guideUiItem3
			};
		}
		else
		{
			if (!(a == "Item"))
			{
				if (a == "Plugin")
				{
					int num = int.Parse(configParams[1]);
					foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in this.BackpackData.GetItemDataList())
					{
						if (honamiStoryItemDataBase.GetItemId() == num)
						{
							int position = honamiStoryItemDataBase.GetPosition();
							HonamiStoryGridItemBase honamiStoryGridItemBase;
							UUIItem uuiitem;
							if (!this.BackpackItemMap.TryGetValue(position, out honamiStoryGridItemBase) || honamiStoryGridItemBase == null)
							{
								uuiitem = null;
							}
							else
							{
								HonamiStoryItemGridItem itemGridItem = honamiStoryGridItemBase.GetItemGridItem();
								uuiitem = ((itemGridItem != null) ? itemGridItem.GetRootItem() : null);
							}
							UUIItem uuiitem2 = uuiitem;
							UUIItem[] result;
							if (uuiitem2 == null)
							{
								result = null;
							}
							else
							{
								UUIItem[] array = new UUIItem[2];
								array[0] = uuiitem2;
								result = array;
								array[1] = uuiitem2;
							}
							return result;
						}
					}
				}
				return null;
			}
			int num2 = int.Parse(configParams[1]);
			HonamiStoryItemDataBase honamiStoryItemDataBase2 = this.BackpackData.GetItemDataList()[num2];
			if (honamiStoryItemDataBase2 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TZJ;
				string message = "引导获取背包物品失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", num2);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int position2 = honamiStoryItemDataBase2.GetPosition();
			HonamiStoryGridItemBase honamiStoryGridItemBase2;
			UUIItem uuiitem3;
			if (!this.BackpackItemMap.TryGetValue(position2, out honamiStoryGridItemBase2) || honamiStoryGridItemBase2 == null)
			{
				uuiitem3 = null;
			}
			else
			{
				HonamiStoryItemGridItem itemGridItem2 = honamiStoryGridItemBase2.GetItemGridItem();
				uuiitem3 = ((itemGridItem2 != null) ? itemGridItem2.GetRootItem() : null);
			}
			UUIItem uuiitem4 = uuiitem3;
			if (honamiStoryItemDataBase2 == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Guide;
				ELogAuthor author2 = ELogAuthor.TZJ;
				string message2 = "引导获取背包物品GridItem失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("position", position2);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			if (uuiitem4 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem4,
				uuiitem4
			};
		}
	}

	// Token: 0x0400715E RID: 29022
	private const int CONTENT_SMALL_OFFSET = 112;

	// Token: 0x0400715F RID: 29023
	private const int CONTENT_FOR_SAFE = 6;

	// Token: 0x04007160 RID: 29024
	private HonamiStoryBackpackData BackpackData;

	// Token: 0x04007161 RID: 29025
	private UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x04007162 RID: 29026
	private UUIItem ViewportItem;

	// Token: 0x04007163 RID: 29027
	private UUIItem ContentItem;

	// Token: 0x04007164 RID: 29028
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<int, HonamiStoryGridItemBase> BackpackItemMap = new Dictionary<int, HonamiStoryGridItemBase>();

	// Token: 0x04007165 RID: 29029
	private readonly HashSet<HonamiStoryGridItemBase> BackpackItemPool = new HashSet<HonamiStoryGridItemBase>();

	// Token: 0x04007166 RID: 29030
	[Nullable(2)]
	private IHonamiStoryDragItemHoverInfo DragItemHoverInfo;

	// Token: 0x04007167 RID: 29031
	private int HoverPosition = -1;

	// Token: 0x04007168 RID: 29032
	private float ViewportHeight;

	// Token: 0x04007169 RID: 29033
	private int LastViewportStartPosition = -1;

	// Token: 0x0400716A RID: 29034
	private int LastViewportEndPosition = -1;

	// Token: 0x0400716B RID: 29035
	private int CurViewportStartPosition = -1;

	// Token: 0x0400716C RID: 29036
	private int CurViewportEndPosition = -1;

	// Token: 0x0400716D RID: 29037
	[Nullable(2)]
	private ButtonItem ButtonSell;

	// Token: 0x0400716E RID: 29038
	[Nullable(2)]
	private ButtonItem ButtonRight;

	// Token: 0x0400716F RID: 29039
	[Nullable(2)]
	private HonamiStoryBackpackValueCountItem CurrentValueItem;

	// Token: 0x04007170 RID: 29040
	[Nullable(2)]
	private HonamiStoryBackpackTitleItem TitlePanel;

	// Token: 0x04007171 RID: 29041
	private bool IsScrollUp;

	// Token: 0x04007172 RID: 29042
	private int ScrollSpeed = 10;

	// Token: 0x04007173 RID: 29043
	private int CurMaskingItemIncId = -1;

	// Token: 0x04007174 RID: 29044
	private readonly HashSet<int> GridCreateAsyncLock = new HashSet<int>();

	// Token: 0x04007175 RID: 29045
	[Nullable(2)]
	private UiPanelBase OverflowBottomItem;

	// Token: 0x02008226 RID: 33318
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C21C RID: 180764
		TitleItem,
		// Token: 0x0402C21D RID: 180765
		GridBG,
		// Token: 0x0402C21E RID: 180766
		ScrollView,
		// Token: 0x0402C21F RID: 180767
		ViewportItem,
		// Token: 0x0402C220 RID: 180768
		ContentItem,
		// Token: 0x0402C221 RID: 180769
		SpriteHoverMask,
		// Token: 0x0402C222 RID: 180770
		SpriteHoverGridState,
		// Token: 0x0402C223 RID: 180771
		SpriteSelect,
		// Token: 0x0402C224 RID: 180772
		BtnLeft,
		// Token: 0x0402C225 RID: 180773
		BtnRight,
		// Token: 0x0402C226 RID: 180774
		ValueItem,
		// Token: 0x0402C227 RID: 180775
		PanelButton,
		// Token: 0x0402C228 RID: 180776
		PanelGoTop,
		// Token: 0x0402C229 RID: 180777
		PanelGoDown,
		// Token: 0x0402C22A RID: 180778
		PanelSelf,
		// Token: 0x0402C22B RID: 180779
		PanelGrid
	}
}
