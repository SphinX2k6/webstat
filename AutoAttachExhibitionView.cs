using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001863 RID: 6243
[NullableContext(1)]
[Nullable(0)]
public class AutoAttachExhibitionView
{
	// Token: 0x17000E87 RID: 3719
	// (get) Token: 0x0600B2D8 RID: 45784 RVA: 0x002FBDB7 File Offset: 0x002F9FB7
	public EAutoAttachExhibitionViewDirection? Direction
	{
		get
		{
			return this.CurrentDirection;
		}
	}

	// Token: 0x0600B2D9 RID: 45785 RVA: 0x002FBDC0 File Offset: 0x002F9FC0
	public AutoAttachExhibitionView(AActor controllerActor)
	{
		this.Actor = controllerActor;
		this.ItemActor = (controllerActor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
	}

	// Token: 0x0600B2DA RID: 45786 RVA: 0x002FBE8C File Offset: 0x002FA08C
	public void SetVelocitySupport(bool state)
	{
		this.SupportVelocity = state;
	}

	// Token: 0x0600B2DB RID: 45787 RVA: 0x002FBE95 File Offset: 0x002FA095
	public void SetVelocityFactor(Number factor)
	{
		this.VelocityFactor = factor;
	}

	// Token: 0x0600B2DC RID: 45788 RVA: 0x002FBE9E File Offset: 0x002FA09E
	public void SetItemOnSelectTime(EItemOnSelectTime onSelectTime)
	{
		this.ItemOnSelectTime = onSelectTime;
	}

	// Token: 0x0600B2DD RID: 45789 RVA: 0x002FBEA7 File Offset: 0x002FA0A7
	public void SetBoundDistance(Number distance)
	{
		this.BoundDistance = distance;
	}

	// Token: 0x0600B2DE RID: 45790 RVA: 0x002FBEB0 File Offset: 0x002FA0B0
	public int GetDataLength()
	{
		return this.DataLength;
	}

	// Token: 0x0600B2DF RID: 45791 RVA: 0x002FBEB8 File Offset: 0x002FA0B8
	public void Destroy()
	{
		if (this.Actor != null)
		{
			Singleton<ActorSystem>.Instance.Put("AutoAttachExhibitionView.Destroy", this.Actor, null);
		}
		this.Actor = null;
	}

	// Token: 0x0600B2E0 RID: 45792 RVA: 0x002FBEE0 File Offset: 0x002FA0E0
	public void CreateItems(AActor itemActor, int showItemNum, Number initGap, Func<AActor, int, int, AutoAttachExhibitionItem> createFunction, EAutoAttachExhibitionViewDirection? direction = null)
	{
		this.AddDragEvent();
		this.CreateItemFunction = createFunction;
		this.CreateSourceActor = itemActor;
		this.CreateSourceUiActor = (this.CreateSourceActor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		this.ShowItemNum = showItemNum;
		this.CheckItemSizeChange();
		this.Gap = initGap;
	}

	// Token: 0x0600B2E1 RID: 45793 RVA: 0x002FBF38 File Offset: 0x002FA138
	private void CheckItemSizeChange()
	{
		this.ItemSizeX = this.CreateSourceUiActor.GetWidth();
		this.ItemSizeY = this.CreateSourceUiActor.GetHeight();
		this.Width = this.ItemActor.GetWidth();
		this.Height = this.ItemActor.GetHeight();
		EAutoAttachExhibitionViewDirection? currentDirection = this.CurrentDirection;
		EAutoAttachExhibitionViewDirection eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
		if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
		{
			this.BoundDistance = this.ItemSizeX;
			return;
		}
		this.BoundDistance = this.ItemSizeY;
	}

	// Token: 0x0600B2E2 RID: 45794 RVA: 0x002FBFD3 File Offset: 0x002FA1D3
	public void ReloadView(int showItemNum, object data)
	{
	}

	// Token: 0x0600B2E3 RID: 45795 RVA: 0x002FBFD8 File Offset: 0x002FA1D8
	public void DisableDragEvent()
	{
		if (this.Actor != null)
		{
			UUIDraggableComponent uuidraggableComponent = this.Actor.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
			if (uuidraggableComponent != null)
			{
				uuidraggableComponent.OnPointerBeginDragCallBack.Unbind();
				uuidraggableComponent.OnPointerDragCallBack.Unbind();
				uuidraggableComponent.OnPointerEndDragCallBack.Unbind();
			}
		}
	}

	// Token: 0x0600B2E4 RID: 45796 RVA: 0x002FC02C File Offset: 0x002FA22C
	public void AddDragEvent()
	{
		if (this.Actor != null)
		{
			UUIDraggableComponent uuidraggableComponent = this.Actor.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
			if (uuidraggableComponent != null)
			{
				uuidraggableComponent.OnPointerBeginDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnPointerBeginDrag(eventData);
				});
				uuidraggableComponent.OnPointerDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnPointerDrag(eventData);
				});
				uuidraggableComponent.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
				{
					this.OnPointerEndDrag(eventData);
				});
			}
		}
	}

	// Token: 0x0600B2E5 RID: 45797 RVA: 0x002FC0A4 File Offset: 0x002FA2A4
	protected void SetData(object data)
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].SetData(data);
		}
	}

	// Token: 0x0600B2E6 RID: 45798 RVA: 0x002FC0DC File Offset: 0x002FA2DC
	protected void InitItems()
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].Init(this);
		}
		this.RefreshItemsView();
	}

	// Token: 0x0600B2E7 RID: 45799 RVA: 0x002FC118 File Offset: 0x002FA318
	protected void ForceUnSelectItems()
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].ForceUnSelectItem();
		}
		this.CurrentSelectState = false;
	}

	// Token: 0x0600B2E8 RID: 45800 RVA: 0x002FC153 File Offset: 0x002FA353
	public void SetAttachTime(Number attachTime)
	{
		this.AttachTime = attachTime;
	}

	// Token: 0x0600B2E9 RID: 45801 RVA: 0x002FC15C File Offset: 0x002FA35C
	protected void RefreshItemsView()
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].RefreshItem();
		}
	}

	// Token: 0x0600B2EA RID: 45802 RVA: 0x002FC190 File Offset: 0x002FA390
	[NullableContext(2)]
	public AutoAttachExhibitionItem FindNearestMiddleItem()
	{
		AutoAttachExhibitionItem autoAttachExhibitionItem = this.Items[0];
		if (autoAttachExhibitionItem == null)
		{
			return null;
		}
		Number b = 0;
		EAutoAttachExhibitionViewDirection? currentDirection = this.CurrentDirection;
		EAutoAttachExhibitionViewDirection eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
		if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
		{
			b = Math.Abs(this.Items[0].GetItemPositionX());
		}
		else
		{
			b = Math.Abs(this.Items[0].GetItemPositionY());
		}
		for (int i = 0; i < this.Items.Count; i++)
		{
			Number number = 0;
			currentDirection = this.CurrentDirection;
			eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
			if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
			{
				number = Math.Abs(this.Items[i].GetItemPositionX());
			}
			else
			{
				number = Math.Abs(this.Items[i].GetItemPositionY());
			}
			if (number < b)
			{
				autoAttachExhibitionItem = this.Items[i];
				b = number;
			}
		}
		return autoAttachExhibitionItem;
	}

	// Token: 0x0600B2EB RID: 45803 RVA: 0x002FC2C0 File Offset: 0x002FA4C0
	public List<AutoAttachExhibitionItem> GetItems()
	{
		return this.Items;
	}

	// Token: 0x0600B2EC RID: 45804 RVA: 0x002FC2C8 File Offset: 0x002FA4C8
	[NullableContext(2)]
	public AutoAttachExhibitionItem GetItemByShowIndex(int showItemIndex)
	{
		foreach (AutoAttachExhibitionItem autoAttachExhibitionItem in this.Items)
		{
			if (autoAttachExhibitionItem.ShowItemIndex == showItemIndex)
			{
				return autoAttachExhibitionItem;
			}
		}
		return null;
	}

	// Token: 0x0600B2ED RID: 45805 RVA: 0x002FC324 File Offset: 0x002FA524
	public void ScrollToItem(int finishTick, AutoAttachExhibitionItem item)
	{
		if (this.InertiaState)
		{
			return;
		}
		Number number = 0;
		EAutoAttachExhibitionViewDirection? currentDirection = this.CurrentDirection;
		EAutoAttachExhibitionViewDirection eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
		if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
		{
			number = item.GetItemPositionX();
		}
		else
		{
			number = item.GetItemPositionY();
		}
		this.Distance = -number;
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].UnSelect();
		}
		this.CurrentSelectState = false;
		this.CurrentShowItemIndex = item.ShowItemIndex;
		if (finishTick == 0)
		{
			this.MoveItems(-number);
			return;
		}
		this.CurrentTick = 0;
		this.FinishTick = finishTick;
		this.InertiaState = true;
	}

	// Token: 0x0600B2EE RID: 45806 RVA: 0x002FC3EC File Offset: 0x002FA5EC
	protected void ScrollToIndex(int finishTick, int itemIndex)
	{
		this.AttachToIndex(finishTick, itemIndex);
	}

	// Token: 0x0600B2EF RID: 45807 RVA: 0x002FC3F6 File Offset: 0x002FA5F6
	public void AttachToIndex(int finishTick, int showItemIndex)
	{
		this.AttachToIndex2(finishTick, showItemIndex);
	}

	// Token: 0x0600B2F0 RID: 45808 RVA: 0x002FC400 File Offset: 0x002FA600
	private void AttachToIndex2(int finishTick, int showItemIndex)
	{
		if (this.InertiaState)
		{
			return;
		}
		AutoAttachExhibitionItem showIndexItem = this.GetShowIndexItem(showItemIndex);
		if (showIndexItem != null)
		{
			this.ScrollToItem(finishTick, showIndexItem);
			return;
		}
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].UnSelect();
		}
		this.CurrentSelectState = false;
		this.CurrentShowItemIndex = showItemIndex;
		AutoAttachExhibitionItem autoAttachExhibitionItem = this.FindNearestMiddleItem();
		if (autoAttachExhibitionItem == null)
		{
			return;
		}
		int value = showItemIndex - autoAttachExhibitionItem.ShowItemIndex;
		Number number = 0;
		EAutoAttachExhibitionViewDirection? currentDirection = this.CurrentDirection;
		EAutoAttachExhibitionViewDirection eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
		if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
		{
			number = (this.ItemSizeX + this.Gap) * value - autoAttachExhibitionItem.GetItemPositionX();
		}
		else
		{
			number = -1 * ((this.ItemSizeY + this.Gap) * value - autoAttachExhibitionItem.GetItemPositionY());
		}
		this.Distance = -number;
		if (finishTick == 0)
		{
			this.MoveItems(-number);
			return;
		}
		this.CurrentTick = 0;
		this.FinishTick = finishTick;
		this.InertiaState = true;
	}

	// Token: 0x0600B2F1 RID: 45809 RVA: 0x002FC53C File Offset: 0x002FA73C
	public void Tick(Number deltaTime)
	{
		if (this.DragState || (!this.InertiaState && !this.VelocityMoveState))
		{
			if (this.InertiaState)
			{
				this.InertiaState = false;
				this.CurrentTick = 0;
				if (!this.CurrentSelectState && this.ItemOnSelectTime == EItemOnSelectTime.EndMove)
				{
					for (int i = 0; i < this.Items.Count; i++)
					{
						AutoAttachExhibitionItem autoAttachExhibitionItem = this.Items[i];
						if (autoAttachExhibitionItem.ShowItemIndex == this.CurrentShowItemIndex && !autoAttachExhibitionItem.GetSelectState())
						{
							autoAttachExhibitionItem.Select();
							this.CurrentSelectState = true;
						}
					}
				}
			}
			this.VelocityMoveState = false;
			return;
		}
		if (this.VelocityMoveState)
		{
			this.CurrentVelocity = this.ReCalculateOffset(this.CurrentVelocity);
			this.DoVelocityMove(deltaTime);
			return;
		}
		if (this.CurrentTick < this.FinishTick)
		{
			this.DoElasticMove();
			return;
		}
		this.InertiaState = false;
	}

	// Token: 0x0600B2F2 RID: 45810 RVA: 0x002FC614 File Offset: 0x002FA814
	private void DoVelocityMove(Number deltaTime)
	{
		this.CurrentVelocityTime += deltaTime / 100;
		if (this.VelocityDirection > 0)
		{
			this.MoveItems(this.CurrentVelocity);
			this.CurrentVelocity -= this.VelocityFactor * this.CurrentVelocityTime;
			if (this.CurrentVelocity <= 0)
			{
				this.EndVelocityMove();
				return;
			}
		}
		else if (this.VelocityDirection < 0)
		{
			this.MoveItems(this.CurrentVelocity);
			this.CurrentVelocity += this.VelocityFactor * this.CurrentVelocityTime;
			if (this.CurrentVelocity >= 0)
			{
				this.EndVelocityMove();
			}
		}
	}

	// Token: 0x0600B2F3 RID: 45811 RVA: 0x002FC6E0 File Offset: 0x002FA8E0
	protected Number ReCalculateOffset(Number offset)
	{
		return offset;
	}

	// Token: 0x0600B2F4 RID: 45812 RVA: 0x002FC6E4 File Offset: 0x002FA8E4
	protected void EndVelocityMove()
	{
		this.VelocityMoveState = false;
		this.InertiaState = false;
		AutoAttachExhibitionItem autoAttachExhibitionItem = this.FindAutoAttachItem();
		this.ScrollToIndex(this.AttachTime, autoAttachExhibitionItem.ShowItemIndex);
	}

	// Token: 0x0600B2F5 RID: 45813 RVA: 0x002FC71D File Offset: 0x002FA91D
	private void DoElasticMove()
	{
		this.MoveItems(this.Distance / this.FinishTick);
		this.CurrentTick++;
	}

	// Token: 0x0600B2F6 RID: 45814 RVA: 0x002FC74C File Offset: 0x002FA94C
	protected void MoveItems(Number offset)
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			AutoAttachExhibitionItem autoAttachExhibitionItem = this.Items[i];
			autoAttachExhibitionItem.MoveItem(offset);
			bool debugMode = this.DebugMode;
			if (!this.CurrentSelectState && this.ItemOnSelectTime == EItemOnSelectTime.OnMoving && autoAttachExhibitionItem.ShowItemIndex == this.CurrentShowItemIndex && !autoAttachExhibitionItem.GetSelectState())
			{
				autoAttachExhibitionItem.Select();
				this.CurrentSelectState = true;
			}
		}
	}

	// Token: 0x0600B2F7 RID: 45815 RVA: 0x002FC7BD File Offset: 0x002FA9BD
	public bool MovingState()
	{
		return this.DragState || this.InertiaState;
	}

	// Token: 0x0600B2F8 RID: 45816 RVA: 0x002FC7D0 File Offset: 0x002FA9D0
	protected void OnPointerBeginDrag(ULGUIPointerEventData eventData)
	{
		this.DragState = true;
		this.InertiaState = false;
		this.VelocityMoveState = false;
		this.BeginPlanePosition = new FVector?(eventData.GetWorldPointInPlane());
		this.CurrentPlanePosition = new FVector?(eventData.GetWorldPointInPlane());
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].OnControllerDragStart();
		}
	}

	// Token: 0x0600B2F9 RID: 45817 RVA: 0x002FC83C File Offset: 0x002FAA3C
	protected void OnPointerDrag(ULGUIPointerEventData eventData)
	{
		FVector worldPointInPlane = eventData.GetWorldPointInPlane();
		this.CurrentPlanePosition = new FVector?(eventData.GetWorldPointInPlane());
		Number number = 0;
		EAutoAttachExhibitionViewDirection? currentDirection = this.CurrentDirection;
		EAutoAttachExhibitionViewDirection eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
		if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
		{
			number = worldPointInPlane.X - this.BeginPlanePosition.Value.X;
		}
		else
		{
			number = worldPointInPlane.Z - this.BeginPlanePosition.Value.Z;
		}
		if (number != 0)
		{
			this.MoveItems(number);
			this.BeginPlanePosition = new FVector?(worldPointInPlane);
		}
	}

	// Token: 0x0600B2FA RID: 45818 RVA: 0x002FC8E4 File Offset: 0x002FAAE4
	protected void OnPointerEndDrag(ULGUIPointerEventData eventData)
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].OnControllerDragEnd();
		}
		this.DragState = false;
		this.CurrentTick = 0;
		if (!this.SupportVelocity)
		{
			AutoAttachExhibitionItem autoAttachExhibitionItem = this.FindAutoAttachItem();
			this.ScrollToIndex(this.AttachTime, autoAttachExhibitionItem.ShowItemIndex);
			return;
		}
		FVector worldPointInPlane = eventData.GetWorldPointInPlane();
		Number number = 0;
		EAutoAttachExhibitionViewDirection? currentDirection = this.CurrentDirection;
		EAutoAttachExhibitionViewDirection eautoAttachExhibitionViewDirection = EAutoAttachExhibitionViewDirection.Horizontal;
		if (currentDirection.GetValueOrDefault() == eautoAttachExhibitionViewDirection & currentDirection != null)
		{
			number = worldPointInPlane.X - this.CurrentPlanePosition.Value.X;
		}
		else
		{
			number = worldPointInPlane.Z - this.CurrentPlanePosition.Value.Z;
		}
		if (Math.Abs(number) < this.VelocityFactor)
		{
			AutoAttachExhibitionItem autoAttachExhibitionItem2 = this.FindAutoAttachItem();
			this.ScrollToIndex(this.AttachTime, autoAttachExhibitionItem2.ShowItemIndex);
			return;
		}
		this.VelocityMoveState = true;
		this.CurrentVelocity = number;
		this.VelocityDirection = ((this.CurrentVelocity > 0) ? 1 : -1);
		this.CurrentVelocityTime = 0;
	}

	// Token: 0x0600B2FB RID: 45819 RVA: 0x002FCA30 File Offset: 0x002FAC30
	[NullableContext(2)]
	protected AutoAttachExhibitionItem GetShowIndexItem(int showIndex)
	{
		AutoAttachExhibitionItem result = null;
		for (int i = 0; i < this.Items.Count; i++)
		{
			if (this.Items[i].ShowItemIndex == showIndex)
			{
				result = this.Items[i];
				break;
			}
		}
		return result;
	}

	// Token: 0x0600B2FC RID: 45820 RVA: 0x002FCA79 File Offset: 0x002FAC79
	[NullableContext(2)]
	public AutoAttachExhibitionItem AttachItem(int direction)
	{
		return null;
	}

	// Token: 0x0600B2FD RID: 45821 RVA: 0x002FCA7C File Offset: 0x002FAC7C
	protected AutoAttachExhibitionItem FindAutoAttachItem()
	{
		return this.FindNearestMiddleItem();
	}

	// Token: 0x0600B2FE RID: 45822 RVA: 0x002FCA84 File Offset: 0x002FAC84
	public Number GetWidth()
	{
		return this.Width;
	}

	// Token: 0x0600B2FF RID: 45823 RVA: 0x002FCA8C File Offset: 0x002FAC8C
	public Number GetHeight()
	{
		return this.Height;
	}

	// Token: 0x0600B300 RID: 45824 RVA: 0x002FCA94 File Offset: 0x002FAC94
	public void Clear()
	{
		for (int i = 0; i < this.Items.Count; i++)
		{
			this.Items[i].Clear();
		}
	}

	// Token: 0x04005498 RID: 21656
	public const int DEFAULT_ATTACH_TIME = 8;

	// Token: 0x04005499 RID: 21657
	private FVector? BeginPlanePosition;

	// Token: 0x0400549A RID: 21658
	private FVector? CurrentPlanePosition;

	// Token: 0x0400549B RID: 21659
	protected EAutoAttachExhibitionViewDirection? CurrentDirection;

	// Token: 0x0400549C RID: 21660
	[Nullable(2)]
	public AActor Actor;

	// Token: 0x0400549D RID: 21661
	public UUIItem ItemActor;

	// Token: 0x0400549E RID: 21662
	[Nullable(2)]
	protected AActor CreateSourceActor;

	// Token: 0x0400549F RID: 21663
	[Nullable(2)]
	protected UUIItem CreateSourceUiActor;

	// Token: 0x040054A0 RID: 21664
	protected List<AutoAttachExhibitionItem> Items = new List<AutoAttachExhibitionItem>();

	// Token: 0x040054A1 RID: 21665
	public int SelectedIndex;

	// Token: 0x040054A2 RID: 21666
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Func<AActor, int, int, AutoAttachExhibitionItem> CreateItemFunction;

	// Token: 0x040054A3 RID: 21667
	protected bool DragState;

	// Token: 0x040054A4 RID: 21668
	protected bool InertiaState;

	// Token: 0x040054A5 RID: 21669
	protected Number Distance = 0;

	// Token: 0x040054A6 RID: 21670
	public Number AttachTime = 8;

	// Token: 0x040054A7 RID: 21671
	protected Number ItemSizeX = 0;

	// Token: 0x040054A8 RID: 21672
	protected Number ItemSizeY = 0;

	// Token: 0x040054A9 RID: 21673
	protected Number Gap = 0;

	// Token: 0x040054AA RID: 21674
	protected int ShowItemNum;

	// Token: 0x040054AB RID: 21675
	protected int DataLength;

	// Token: 0x040054AC RID: 21676
	public int CurrentShowItemIndex;

	// Token: 0x040054AD RID: 21677
	protected Number Width = 0;

	// Token: 0x040054AE RID: 21678
	protected Number Height = 0;

	// Token: 0x040054AF RID: 21679
	private EItemOnSelectTime ItemOnSelectTime;

	// Token: 0x040054B0 RID: 21680
	protected bool SupportVelocity = true;

	// Token: 0x040054B1 RID: 21681
	protected Number CurrentVelocity = 0;

	// Token: 0x040054B2 RID: 21682
	protected int VelocityDirection;

	// Token: 0x040054B3 RID: 21683
	protected bool VelocityMoveState;

	// Token: 0x040054B4 RID: 21684
	protected Number CurrentVelocityTime = 0;

	// Token: 0x040054B5 RID: 21685
	protected Number VelocityFactor = 30;

	// Token: 0x040054B6 RID: 21686
	protected Number BoundDistance = 0;

	// Token: 0x040054B7 RID: 21687
	protected readonly bool DebugMode;

	// Token: 0x040054B8 RID: 21688
	protected bool CurrentSelectState;

	// Token: 0x040054B9 RID: 21689
	private int FinishTick;

	// Token: 0x040054BA RID: 21690
	private int CurrentTick;
}
