using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001860 RID: 6240
[NullableContext(1)]
[Nullable(0)]
public class AutoAttachExhibitionItem
{
	// Token: 0x0600B2C0 RID: 45760 RVA: 0x002FBBB0 File Offset: 0x002F9DB0
	public AutoAttachExhibitionItem(AActor actor, int index, int showNum)
	{
		this.Actor = (actor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		this.FullSizeX = this.Actor.GetWidth();
		this.FullSizeY = this.Actor.GetHeight();
		this.Index = index;
		this.ShowItemNum = showNum;
	}

	// Token: 0x0600B2C1 RID: 45761 RVA: 0x002FBC24 File Offset: 0x002F9E24
	public void SetViewItem(AutoAttachExhibitionItemAbstract view)
	{
		this.ViewItem = view;
		this.ViewItem.SetAttachItem(this);
	}

	// Token: 0x0600B2C2 RID: 45762 RVA: 0x002FBC39 File Offset: 0x002F9E39
	public void SetActive(bool state)
	{
		this.Actor.SetUIActive(state);
	}

	// Token: 0x0600B2C3 RID: 45763 RVA: 0x002FBC47 File Offset: 0x002F9E47
	public void Init(AutoAttachExhibitionView exhibitionView)
	{
		this.ExhibitionView = exhibitionView;
		this.CurrentDirection = exhibitionView.Direction;
		this.DataLength = exhibitionView.GetDataLength();
		this.OnInit();
		this.SelectState = false;
		this.OnUnSelect();
	}

	// Token: 0x0600B2C4 RID: 45764 RVA: 0x002FBC7B File Offset: 0x002F9E7B
	public void ForceUnSelectItem()
	{
		this.SelectState = false;
		this.OnUnSelect();
	}

	// Token: 0x0600B2C5 RID: 45765 RVA: 0x002FBC8A File Offset: 0x002F9E8A
	protected virtual void OnInit()
	{
	}

	// Token: 0x0600B2C6 RID: 45766 RVA: 0x002FBC8C File Offset: 0x002F9E8C
	public void OnControllerDragStart()
	{
		this.DragState = true;
	}

	// Token: 0x0600B2C7 RID: 45767 RVA: 0x002FBC95 File Offset: 0x002F9E95
	public void MoveItem(Number offset)
	{
		this.OnMoveItem(offset);
		this.ViewItem.OnMoveItem(offset);
	}

	// Token: 0x0600B2C8 RID: 45768 RVA: 0x002FBCB0 File Offset: 0x002F9EB0
	protected virtual void OnMoveItem(Number vectorX)
	{
	}

	// Token: 0x0600B2C9 RID: 45769 RVA: 0x002FBCB2 File Offset: 0x002F9EB2
	protected void OnMoveFromRightToLeft()
	{
		this.ViewItem.OnChangeDirection(1);
	}

	// Token: 0x0600B2CA RID: 45770 RVA: 0x002FBCC0 File Offset: 0x002F9EC0
	protected void OnMoveFromLeftToRight()
	{
		this.ViewItem.OnChangeDirection(-1);
	}

	// Token: 0x0600B2CB RID: 45771 RVA: 0x002FBCCE File Offset: 0x002F9ECE
	protected void OnMoveFromDownToUp()
	{
		this.ViewItem.OnChangeDirection(1);
	}

	// Token: 0x0600B2CC RID: 45772 RVA: 0x002FBCDC File Offset: 0x002F9EDC
	protected void OnMoveFromUpToDown()
	{
		this.ViewItem.OnChangeDirection(-1);
	}

	// Token: 0x0600B2CD RID: 45773 RVA: 0x002FBCEA File Offset: 0x002F9EEA
	public void RefreshItem()
	{
		this.ViewItem.SetShowItemIndex(this.ShowItemIndex);
		this.ViewItem.RefreshItem(this.ShowItemIndex);
	}

	// Token: 0x0600B2CE RID: 45774 RVA: 0x002FBD0E File Offset: 0x002F9F0E
	public void SetData(object param)
	{
		this.ViewItem.SetData(param);
	}

	// Token: 0x0600B2CF RID: 45775 RVA: 0x002FBD1C File Offset: 0x002F9F1C
	public void OnControllerDragEnd()
	{
		this.DragState = false;
	}

	// Token: 0x0600B2D0 RID: 45776 RVA: 0x002FBD25 File Offset: 0x002F9F25
	public Number GetItemPositionX()
	{
		return this.Actor.GetAnchorOffsetX();
	}

	// Token: 0x0600B2D1 RID: 45777 RVA: 0x002FBD37 File Offset: 0x002F9F37
	public Number GetItemPositionY()
	{
		return this.Actor.GetAnchorOffsetY();
	}

	// Token: 0x0600B2D2 RID: 45778 RVA: 0x002FBD49 File Offset: 0x002F9F49
	public bool GetSelectState()
	{
		return this.SelectState;
	}

	// Token: 0x0600B2D3 RID: 45779 RVA: 0x002FBD51 File Offset: 0x002F9F51
	public void Select()
	{
		if (!this.SelectState)
		{
			this.SelectState = true;
			this.ExhibitionView.SelectedIndex = this.ShowItemIndex;
			this.OnSelect();
		}
	}

	// Token: 0x0600B2D4 RID: 45780 RVA: 0x002FBD79 File Offset: 0x002F9F79
	protected virtual void OnSelect()
	{
		this.ViewItem.OnSelect();
	}

	// Token: 0x0600B2D5 RID: 45781 RVA: 0x002FBD86 File Offset: 0x002F9F86
	public void UnSelect()
	{
		if (this.SelectState)
		{
			this.SelectState = false;
			this.OnUnSelect();
		}
	}

	// Token: 0x0600B2D6 RID: 45782 RVA: 0x002FBD9D File Offset: 0x002F9F9D
	protected virtual void OnUnSelect()
	{
		this.ViewItem.OnUnSelect();
	}

	// Token: 0x0600B2D7 RID: 45783 RVA: 0x002FBDAA File Offset: 0x002F9FAA
	public void Clear()
	{
		this.ViewItem.Clear();
	}

	// Token: 0x04005485 RID: 21637
	protected bool SelectState;

	// Token: 0x04005486 RID: 21638
	protected EAutoAttachExhibitionViewDirection? CurrentDirection;

	// Token: 0x04005487 RID: 21639
	protected int Index;

	// Token: 0x04005488 RID: 21640
	public Number InitGap = 0;

	// Token: 0x04005489 RID: 21641
	protected int ShowItemNum;

	// Token: 0x0400548A RID: 21642
	protected int DataLength;

	// Token: 0x0400548B RID: 21643
	protected bool DragState;

	// Token: 0x0400548C RID: 21644
	protected readonly UUIItem Actor;

	// Token: 0x0400548D RID: 21645
	protected readonly Number FullSizeX;

	// Token: 0x0400548E RID: 21646
	protected readonly Number FullSizeY;

	// Token: 0x0400548F RID: 21647
	[Nullable(2)]
	public AutoAttachExhibitionView ExhibitionView;

	// Token: 0x04005490 RID: 21648
	[Nullable(2)]
	private AutoAttachExhibitionItemAbstract ViewItem;

	// Token: 0x04005491 RID: 21649
	public int ShowItemIndex;
}
