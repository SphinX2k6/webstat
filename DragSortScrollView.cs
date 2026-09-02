using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002315 RID: 8981
[NullableContext(1)]
[Nullable(0)]
public class DragSortScrollView<[Nullable(0)] TProxy, [Nullable(2)] TData> where TProxy : DragSortGridAbstract<TData>
{
	// Token: 0x1700151D RID: 5405
	// (get) Token: 0x0601112A RID: 69930 RVA: 0x004AFB38 File Offset: 0x004ADD38
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public TWeakObjectPtr<UUIItem>? ContentItem
	{
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		get
		{
			UUIScrollViewWithScrollbarComponent targetScroll = this.TargetScroll;
			if (targetScroll == null)
			{
				return null;
			}
			return new TWeakObjectPtr<UUIItem>?(targetScroll.ContentUIItem);
		}
	}

	// Token: 0x0601112B RID: 69931 RVA: 0x004AFB64 File Offset: 0x004ADD64
	public DragSortScrollView(UUIScrollViewWithScrollbarComponent scrollView, Func<TProxy> gridProxyCreateFunction, [Nullable(2)] AUIBaseActor gridActor = null)
	{
		this.TargetScroll = scrollView;
		AUIBaseActor content = this.TargetScroll.GetContent();
		UUIVerticalLayout uuiverticalLayout = ((content != null) ? content.GetComponentByClass(UUIVerticalLayout.StaticClass()) : null) as UUIVerticalLayout;
		if (uuiverticalLayout != null)
		{
			AUIBaseActor auibaseActor = uuiverticalLayout.GetOwner() as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnPreDestroyed.Add(new Action<AActor>(this.OnDestroy));
			}
		}
		if (uuiverticalLayout != null)
		{
			uuiverticalLayout.SetEnable(false);
		}
		AUIBaseActor auibaseActor2 = gridActor;
		if (gridActor == null && uuiverticalLayout != null)
		{
			UUIItem attachUIChild = uuiverticalLayout.RootUIComp.Get().GetAttachUIChild(0);
			auibaseActor2 = (((attachUIChild != null) ? attachUIChild.GetOwner() : null) as AUIBaseActor);
		}
		if (auibaseActor2 == null)
		{
			return;
		}
		this.TemplateGrid = auibaseActor2.GetUIItem();
		if (this.TemplateGrid != null)
		{
			this.TemplateGrid.SetUIActive(false);
		}
		if (uuiverticalLayout != null)
		{
			this.Spacing = uuiverticalLayout.Spacing;
		}
		if (auibaseActor2.GetUIItem() != null)
		{
			this.ItemHeight = auibaseActor2.GetUIItem().Height;
		}
		this.GridProxyCreateFunction = gridProxyCreateFunction;
		if (scrollView != null)
		{
			scrollView.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		}
	}

	// Token: 0x0601112C RID: 69932 RVA: 0x004AFCF8 File Offset: 0x004ADEF8
	private void OnDestroy(AActor aActor)
	{
		for (int i = 0; i < this.PoolItemList.Count; i++)
		{
			this.PoolItemList[i].Destroy(null);
		}
		this.PoolItemList.Clear();
		for (int j = 0; j < this.CopyItemList.Count; j++)
		{
			this.CopyItemList[j].Destroy(null);
		}
		this.CopyItemList.Clear();
		if (this.TargetScroll != null)
		{
			this.TargetScroll.OnScrollValueChange.Unbind();
		}
		this.TargetScroll = null;
		this.DragItem = null;
		this.PoolItemList.Clear();
		this.CopyItemList.Clear();
		this.CopyItemMap.Clear();
		this.DataList = new List<TData>();
		this.DragDataList.Clear();
		this.TemplateGrid = null;
		this.GridProxyCreateFunction = null;
		this.OnItemPointerDownCallback = null;
		this.OnItemPointerUpCallback = null;
	}

	// Token: 0x1700151E RID: 5406
	// (get) Token: 0x0601112D RID: 69933 RVA: 0x004AFDF0 File Offset: 0x004ADFF0
	public float ScrollWidth
	{
		get
		{
			UUIScrollViewWithScrollbarComponent targetScroll = this.TargetScroll;
			float? num;
			if (targetScroll == null)
			{
				num = null;
			}
			else
			{
				UUIItem uuiitem = targetScroll.RootUIComp.Get();
				num = ((uuiitem != null) ? new float?(uuiitem.Width) : null);
			}
			float? num2 = num;
			return num2.GetValueOrDefault();
		}
	}

	// Token: 0x1700151F RID: 5407
	// (get) Token: 0x0601112E RID: 69934 RVA: 0x004AFE40 File Offset: 0x004AE040
	public float ScrollHeight
	{
		get
		{
			UUIScrollViewWithScrollbarComponent targetScroll = this.TargetScroll;
			float? num;
			if (targetScroll == null)
			{
				num = null;
			}
			else
			{
				UUIItem uuiitem = targetScroll.RootUIComp.Get();
				num = ((uuiitem != null) ? new float?(uuiitem.Height) : null);
			}
			float? num2 = num;
			return num2.GetValueOrDefault();
		}
	}

	// Token: 0x0601112F RID: 69935 RVA: 0x004AFE90 File Offset: 0x004AE090
	private void OnScrollValueChange(FVector2D delta)
	{
		if (this.DragItem != null)
		{
			this.DragItem.RefreshDragPosition();
			this.OnDragItemPositionChanged();
		}
		this.UpdateItem();
	}

	// Token: 0x06011130 RID: 69936 RVA: 0x004AFEB1 File Offset: 0x004AE0B1
	public float CalcGridOffsetY(int index)
	{
		return (float)(-(float)index) * (this.ItemHeight + this.Spacing) - this.ItemHeight * 0.5f;
	}

	// Token: 0x06011131 RID: 69937 RVA: 0x004AFED4 File Offset: 0x004AE0D4
	public void SetGridIndex(DragSortGridAbstract<TData> item, int index, bool isTween = true)
	{
		if (item.DragData == null)
		{
			return;
		}
		item.DragData.Index = index;
		DragSortGridData dragData = item.DragData;
		dragData.TargetOffsetY = this.CalcGridOffsetY(item.DragData.Index);
		if (isTween)
		{
			dragData.IsTweenMoving = true;
			return;
		}
		item.GetRootItem().SetAnchorOffsetY(dragData.TargetOffsetY);
		dragData.IsTweenMoving = false;
	}

	// Token: 0x06011132 RID: 69938 RVA: 0x004AFF38 File Offset: 0x004AE138
	public UniTask RefreshByDataAsync(IReadOnlyList<TData> data, bool playGridAnim = false)
	{
		DragSortScrollView<TProxy, TData>.<RefreshByDataAsync>d__29 <RefreshByDataAsync>d__;
		<RefreshByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByDataAsync>d__.<>4__this = this;
		<RefreshByDataAsync>d__.data = data;
		<RefreshByDataAsync>d__.<>1__state = -1;
		<RefreshByDataAsync>d__.<>t__builder.Start<DragSortScrollView<TProxy, TData>.<RefreshByDataAsync>d__29>(ref <RefreshByDataAsync>d__);
		return <RefreshByDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011133 RID: 69939 RVA: 0x004AFF84 File Offset: 0x004AE184
	private void OnItemDragBegin(DragSortGridAbstract<TData> item)
	{
		if (item.DragData == null || item.DragData.IsTweenMoving)
		{
			return;
		}
		this.DragItem = item;
		this.DragItemBeginIndex = item.DragData.Index;
		item.GetRootItem().SetHierarchyIndex(this.CopyItemList.Count);
	}

	// Token: 0x06011134 RID: 69940 RVA: 0x004AFFD5 File Offset: 0x004AE1D5
	public bool IsDragging()
	{
		return this.DragItem != null;
	}

	// Token: 0x06011135 RID: 69941 RVA: 0x004AFFE0 File Offset: 0x004AE1E0
	public void CancelDrag()
	{
		if (this.DragItem == null)
		{
			return;
		}
		bool flag = true;
		int index = this.DragItem.DragData.Index;
		if (index > this.DragItemBeginIndex)
		{
			flag = true;
			using (List<DragSortGridData>.Enumerator enumerator = this.DragDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DragSortGridData dragSortGridData = enumerator.Current;
					if (dragSortGridData.Index >= this.DragItemBeginIndex && dragSortGridData.Index < index)
					{
						dragSortGridData.Index++;
					}
					dragSortGridData.TargetOffsetY = this.CalcGridOffsetY(dragSortGridData.Index);
					dragSortGridData.IsTweenMoving = true;
				}
				goto IL_146;
			}
		}
		if (index < this.DragItemBeginIndex)
		{
			flag = false;
			using (List<DragSortGridData>.Enumerator enumerator = this.DragDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DragSortGridData dragSortGridData2 = enumerator.Current;
					if (dragSortGridData2.Index <= this.DragItemBeginIndex && dragSortGridData2.Index > index)
					{
						dragSortGridData2.Index--;
					}
					dragSortGridData2.TargetOffsetY = this.CalcGridOffsetY(dragSortGridData2.Index);
					dragSortGridData2.IsTweenMoving = true;
				}
				goto IL_146;
			}
		}
		if (this.DragItem.DragData != null)
		{
			this.DragItem.DragData.Index = this.DragItemBeginIndex;
		}
		this.OnItemDragEnd(this.DragItem);
		return;
		IL_146:
		if (this.DragItem.DragData != null)
		{
			this.DragItem.DragData.Index = this.DragItemBeginIndex;
		}
		this.OnItemDragEnd(this.DragItem);
		this.UpdateItem();
		foreach (TProxy tproxy in this.CopyItemList)
		{
			if (tproxy.DragData != null)
			{
				DragSortGridData dragData = tproxy.DragData;
				if (dragData.Index <= index && flag && dragData.Index > this.DragItemBeginIndex)
				{
					tproxy.GetRootItem().SetAnchorOffsetY(this.CalcGridOffsetY(dragData.Index - 1));
					dragData.IsTweenMoving = true;
				}
				else if (dragData.Index >= index && !flag && dragData.Index < this.DragItemBeginIndex)
				{
					tproxy.GetRootItem().SetAnchorOffsetY(this.CalcGridOffsetY(dragData.Index + 1));
					dragData.IsTweenMoving = true;
				}
			}
		}
	}

	// Token: 0x06011136 RID: 69942 RVA: 0x004B0274 File Offset: 0x004AE474
	private void UpdateItem()
	{
		List<TProxy> list = new List<TProxy>();
		if (this.ContentItem == null || !this.ContentItem.Value.IsValid(false, false))
		{
			return;
		}
		float num = Math.Max(0f, this.ContentItem.Value.Get().GetAnchorOffsetY() / (this.ItemHeight + this.Spacing) - 1f);
		float num2 = Math.Min((this.ContentItem.Value.Get().GetAnchorOffsetY() + this.ScrollHeight) / (this.ItemHeight + this.Spacing) + 1f, (float)(this.DataList.Count - 1));
		foreach (TProxy tproxy in this.CopyItemList)
		{
			if (tproxy.DragData != null && ((float)tproxy.DragData.Index < num || (float)tproxy.DragData.Index > num2) && tproxy != this.DragItem)
			{
				list.Add(tproxy);
			}
		}
		foreach (TProxy item in list)
		{
			this.RecycleToPool(item);
		}
		foreach (DragSortGridData dragSortGridData in this.DragDataList)
		{
			if (!this.CopyItemMap.ContainsKey(dragSortGridData) && (float)dragSortGridData.Index >= num && (float)dragSortGridData.Index <= num2)
			{
				this.GetFromPool(dragSortGridData);
			}
		}
	}

	// Token: 0x06011137 RID: 69943 RVA: 0x004B0474 File Offset: 0x004AE674
	private void OnDragItemPositionChanged()
	{
		if (this.DragItem == null || this.DragItem.DragData == null)
		{
			return;
		}
		UUIItem rootItem = this.DragItem.GetRootItem();
		int num = this.DragItem.DragData.Index - 1;
		if (num >= 0)
		{
			DragSortGridAbstract<TData> dragSortGridAbstract = null;
			foreach (TProxy tproxy in this.CopyItemList)
			{
				if (tproxy.DragData != null && tproxy.DragData.Index == num)
				{
					dragSortGridAbstract = tproxy;
					break;
				}
			}
			if (dragSortGridAbstract != null && dragSortGridAbstract.DragData != null && rootItem.GetAnchorOffsetY() > dragSortGridAbstract.DragData.TargetOffsetY - 0.5f * this.ItemHeight)
			{
				this.DragItem.DragData.Index--;
				this.DragItem.DragData.TargetOffsetY = this.CalcGridOffsetY(this.DragItem.DragData.Index);
				this.SetGridIndex(dragSortGridAbstract, num + 1, true);
				return;
			}
		}
		int num2 = this.DragItem.DragData.Index + 1;
		if (num2 < this.DataList.Count)
		{
			DragSortGridAbstract<TData> dragSortGridAbstract2 = null;
			foreach (TProxy tproxy2 in this.CopyItemList)
			{
				if (tproxy2.DragData != null && tproxy2.DragData.Index == num2)
				{
					dragSortGridAbstract2 = tproxy2;
					break;
				}
			}
			if (dragSortGridAbstract2 != null && dragSortGridAbstract2.DragData != null && rootItem.GetAnchorOffsetY() < dragSortGridAbstract2.DragData.TargetOffsetY + 0.5f * this.ItemHeight)
			{
				this.DragItem.DragData.Index++;
				this.DragItem.DragData.TargetOffsetY = this.CalcGridOffsetY(this.DragItem.DragData.Index);
				this.SetGridIndex(dragSortGridAbstract2, num2 - 1, true);
			}
		}
	}

	// Token: 0x06011138 RID: 69944 RVA: 0x004B06AC File Offset: 0x004AE8AC
	private void OnItemDrag(DragSortGridAbstract<TData> item)
	{
		if (item == this.DragItem)
		{
			FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
			if (pointerEventDataPosition != null && (double)pointerEventDataPosition.Value.Y < this.AutoScrollThreshold)
			{
				UUIScrollViewWithScrollbarComponent targetScroll = this.TargetScroll;
				UUIScrollbarComponent uuiscrollbarComponent = (targetScroll != null) ? targetScroll.VerticalScrollbarComp.Get() : null;
				if (uuiscrollbarComponent != null)
				{
					uuiscrollbarComponent.SetValue((float)((double)uuiscrollbarComponent.Value - Singleton<MathUtils>.Instance.RangeClamp((double)pointerEventDataPosition.Value.Y, this.AutoScrollThreshold, 0.0, this.MinScrollSpeed, this.MaxScrollSpeed)), true);
				}
			}
			double y = Singleton<UiLayer>.Instance.GetViewportSize().Y;
			if (pointerEventDataPosition != null && (double)pointerEventDataPosition.Value.Y > y - this.AutoScrollThreshold)
			{
				UUIScrollViewWithScrollbarComponent targetScroll2 = this.TargetScroll;
				UUIScrollbarComponent uuiscrollbarComponent2 = (targetScroll2 != null) ? targetScroll2.VerticalScrollbarComp.Get() : null;
				if (uuiscrollbarComponent2 != null)
				{
					uuiscrollbarComponent2.SetValue((float)((double)uuiscrollbarComponent2.Value + Singleton<MathUtils>.Instance.RangeClamp(y - (double)pointerEventDataPosition.Value.Y, this.AutoScrollThreshold, 0.0, this.MinScrollSpeed, this.MaxScrollSpeed)), true);
				}
			}
			item.RefreshDragPosition();
			this.OnDragItemPositionChanged();
		}
	}

	// Token: 0x06011139 RID: 69945 RVA: 0x004B07F1 File Offset: 0x004AE9F1
	private void OnItemDragEnd(DragSortGridAbstract<TData> item)
	{
		if (this.DragItem == null)
		{
			return;
		}
		if (this.DragItem.DragData != null)
		{
			this.SetGridIndex(this.DragItem, this.DragItem.DragData.Index, true);
		}
		this.DragItem = null;
	}

	// Token: 0x0601113A RID: 69946 RVA: 0x004B082D File Offset: 0x004AEA2D
	private void OnItemPointerDown(DragSortGridAbstract<TData> item)
	{
		if (item.DragData != null && !item.DragData.IsTweenMoving)
		{
			ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(true);
		}
		Action<DragSortGridAbstract<TData>> onItemPointerDownCallback = this.OnItemPointerDownCallback;
		if (onItemPointerDownCallback == null)
		{
			return;
		}
		onItemPointerDownCallback(item);
	}

	// Token: 0x0601113B RID: 69947 RVA: 0x004B0860 File Offset: 0x004AEA60
	private void OnItemPointerUp(DragSortGridAbstract<TData> item)
	{
		Action<DragSortGridAbstract<TData>> onItemPointerUpCallback = this.OnItemPointerUpCallback;
		if (onItemPointerUpCallback != null)
		{
			onItemPointerUpCallback(item);
		}
		ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
	}

	// Token: 0x0601113C RID: 69948 RVA: 0x004B0880 File Offset: 0x004AEA80
	private void RecycleToPool(TProxy item)
	{
		int num = this.CopyItemList.IndexOf(item);
		if (num != -1)
		{
			this.CopyItemList.RemoveAt(num);
		}
		if (item.DragData != null)
		{
			this.CopyItemMap.Remove(item.DragData);
		}
		if (item.DragData != null)
		{
			item.DragData.IsTweenMoving = false;
			item.DragData = null;
		}
		if (item != null)
		{
			item.SetUiActive(false);
			this.PoolItemList.Add(item);
		}
	}

	// Token: 0x0601113D RID: 69949 RVA: 0x004B0918 File Offset: 0x004AEB18
	private void RecycleAll()
	{
		foreach (TProxy item in new List<TProxy>(this.CopyItemList))
		{
			this.RecycleToPool(item);
		}
	}

	// Token: 0x0601113E RID: 69950 RVA: 0x004B0970 File Offset: 0x004AEB70
	private TProxy CreateCopyItem(DragSortGridData dragData)
	{
		if (this.TemplateGrid == null || this.ContentItem == null || !this.ContentItem.Value.Get().IsValid())
		{
			throw new Exception("TemplateGrid or ContentItem is null");
		}
		UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(this.TemplateGrid, this.ContentItem.Value);
		if (this.GridProxyCreateFunction == null)
		{
			throw new Exception("GridProxyCreateFunction is null");
		}
		TProxy tproxy = this.GridProxyCreateFunction();
		tproxy.OnDragBeginCallback = new Action<DragSortGridAbstract<TData>>(this.OnItemDragBegin);
		tproxy.OnDragCallback = new Action<DragSortGridAbstract<TData>>(this.OnItemDrag);
		tproxy.OnDragEndCallback = new Action<DragSortGridAbstract<TData>>(this.OnItemDragEnd);
		tproxy.OnPointerDownCallback = new Action<DragSortGridAbstract<TData>>(this.OnItemPointerDown);
		tproxy.OnPointerUpCallback = new Action<DragSortGridAbstract<TData>>(this.OnItemPointerUp);
		if (uuiitem.GetOwner() != null)
		{
			tproxy.CreateThenShowByActor(uuiitem.GetOwner());
		}
		return tproxy;
	}

	// Token: 0x0601113F RID: 69951 RVA: 0x004B0A90 File Offset: 0x004AEC90
	private TProxy GetFromPool(DragSortGridData dragData)
	{
		TProxy tproxy = default(TProxy);
		if (this.PoolItemList.Count > 0)
		{
			int index = this.PoolItemList.Count - 1;
			tproxy = this.PoolItemList[index];
			this.PoolItemList.RemoveAt(index);
		}
		if (tproxy == null)
		{
			tproxy = this.CreateCopyItem(dragData);
		}
		tproxy.SetUiActive(true);
		tproxy.DragData = dragData;
		this.SetGridIndex(tproxy, tproxy.DragData.Index, false);
		tproxy.Refresh(this.DataList[dragData.OriginDataIndex], false, dragData.Index);
		this.CopyItemList.Add(tproxy);
		this.CopyItemMap[dragData] = tproxy;
		return tproxy;
	}

	// Token: 0x06011140 RID: 69952 RVA: 0x004B0B5C File Offset: 0x004AED5C
	public void Tick(float delta)
	{
		List<TProxy> copyItemList = this.CopyItemList;
		if (copyItemList == null)
		{
			return;
		}
		foreach (TProxy tproxy in copyItemList)
		{
			UUIItem rootItem = tproxy.GetRootItem();
			if (tproxy.DragData != null)
			{
				DragSortGridData dragData = tproxy.DragData;
				if (dragData.IsTweenMoving)
				{
					float anchorOffsetY = rootItem.GetAnchorOffsetY();
					if (Math.Abs(dragData.TargetOffsetY - anchorOffsetY) > 0.1f)
					{
						rootItem.SetAnchorOffsetY(Singleton<MathUtils>.Instance.Lerp(anchorOffsetY, dragData.TargetOffsetY, delta * 0.001f * this.SwapSpeed));
					}
					else
					{
						rootItem.SetAnchorOffsetY(dragData.TargetOffsetY);
						dragData.IsTweenMoving = false;
					}
				}
			}
		}
	}

	// Token: 0x06011141 RID: 69953 RVA: 0x004B0C40 File Offset: 0x004AEE40
	public List<TData> GetSortedData()
	{
		List<DragSortGridData> list = new List<DragSortGridData>(this.DragDataList);
		list.Sort((DragSortGridData a, DragSortGridData b) => a.Index.CompareTo(b.Index));
		List<TData> list2 = new List<TData>();
		foreach (DragSortGridData dragSortGridData in list)
		{
			list2.Add(this.DataList[dragSortGridData.OriginDataIndex]);
		}
		return list2;
	}

	// Token: 0x06011142 RID: 69954 RVA: 0x004B0CD4 File Offset: 0x004AEED4
	public bool HasChanged()
	{
		foreach (DragSortGridData dragSortGridData in this.DragDataList)
		{
			if (dragSortGridData.Index != dragSortGridData.OriginDataIndex)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400863F RID: 34367
	[Nullable(2)]
	private UUIScrollViewWithScrollbarComponent TargetScroll;

	// Token: 0x04008640 RID: 34368
	private readonly float Spacing;

	// Token: 0x04008641 RID: 34369
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private DragSortGridAbstract<TData> DragItem;

	// Token: 0x04008642 RID: 34370
	private readonly float ItemHeight;

	// Token: 0x04008643 RID: 34371
	private readonly float SwapSpeed = ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetDragSwapSpeed();

	// Token: 0x04008644 RID: 34372
	private readonly double AutoScrollThreshold = 100.0;

	// Token: 0x04008645 RID: 34373
	private readonly double MinScrollSpeed = (double)ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetDragScrollSpeedRange().Item1;

	// Token: 0x04008646 RID: 34374
	private readonly double MaxScrollSpeed = (double)ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetDragScrollSpeedRange().Item2;

	// Token: 0x04008647 RID: 34375
	private List<TProxy> PoolItemList = new List<TProxy>();

	// Token: 0x04008648 RID: 34376
	private List<TProxy> CopyItemList = new List<TProxy>();

	// Token: 0x04008649 RID: 34377
	private readonly Dictionary<DragSortGridData, TProxy> CopyItemMap = new Dictionary<DragSortGridData, TProxy>();

	// Token: 0x0400864A RID: 34378
	private List<DragSortGridData> DragDataList = new List<DragSortGridData>();

	// Token: 0x0400864B RID: 34379
	[Nullable(2)]
	private UUIItem TemplateGrid;

	// Token: 0x0400864C RID: 34380
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<TProxy> GridProxyCreateFunction;

	// Token: 0x0400864D RID: 34381
	private IReadOnlyList<TData> DataList = new List<TData>();

	// Token: 0x0400864E RID: 34382
	private int DragItemBeginIndex;

	// Token: 0x0400864F RID: 34383
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnItemPointerDownCallback;

	// Token: 0x04008650 RID: 34384
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnItemPointerUpCallback;
}
