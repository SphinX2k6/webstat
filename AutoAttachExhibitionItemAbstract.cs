using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200185F RID: 6239
[NullableContext(1)]
[Nullable(0)]
public abstract class AutoAttachExhibitionItemAbstract : UiPanelBase, IAutoAttachExhibitionItem
{
	// Token: 0x0600B2B4 RID: 45748 RVA: 0x002FBB6F File Offset: 0x002F9D6F
	public AutoAttachExhibitionItemAbstract(AActor uiItem)
	{
		base.CreateThenShowByActor(uiItem, null);
	}

	// Token: 0x0600B2B5 RID: 45749 RVA: 0x002FBB7F File Offset: 0x002F9D7F
	public void SetShowItemIndex(int showIndex)
	{
		this.CurrentShowItemIndex = showIndex;
	}

	// Token: 0x0600B2B6 RID: 45750 RVA: 0x002FBB88 File Offset: 0x002F9D88
	public int GetShowItemIndex()
	{
		return this.CurrentShowItemIndex;
	}

	// Token: 0x0600B2B7 RID: 45751 RVA: 0x002FBB90 File Offset: 0x002F9D90
	public void OnChangeDirection(int direction)
	{
	}

	// Token: 0x0600B2B8 RID: 45752 RVA: 0x002FBB92 File Offset: 0x002F9D92
	public virtual void RefreshItem(int showItemIndex)
	{
	}

	// Token: 0x0600B2B9 RID: 45753 RVA: 0x002FBB94 File Offset: 0x002F9D94
	public virtual void SetData(object param)
	{
	}

	// Token: 0x0600B2BA RID: 45754 RVA: 0x002FBB96 File Offset: 0x002F9D96
	public virtual void OnMoveItem(float offset)
	{
	}

	// Token: 0x0600B2BB RID: 45755 RVA: 0x002FBB98 File Offset: 0x002F9D98
	public virtual void OnUnSelect()
	{
	}

	// Token: 0x0600B2BC RID: 45756 RVA: 0x002FBB9A File Offset: 0x002F9D9A
	public virtual void OnSelect()
	{
	}

	// Token: 0x0600B2BD RID: 45757 RVA: 0x002FBB9C File Offset: 0x002F9D9C
	public void SetAttachItem(AutoAttachExhibitionItem item)
	{
		this.AttachItem = item;
	}

	// Token: 0x0600B2BE RID: 45758 RVA: 0x002FBBA5 File Offset: 0x002F9DA5
	[NullableContext(2)]
	public AutoAttachExhibitionItem GetAttachItem()
	{
		return this.AttachItem;
	}

	// Token: 0x0600B2BF RID: 45759 RVA: 0x002FBBAD File Offset: 0x002F9DAD
	public virtual void Clear()
	{
	}

	// Token: 0x04005483 RID: 21635
	public int CurrentShowItemIndex;

	// Token: 0x04005484 RID: 21636
	[Nullable(2)]
	protected AutoAttachExhibitionItem AttachItem;
}
