using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EF4 RID: 7924
[NullableContext(1)]
[Nullable(0)]
public abstract class HonamiStoryBackpackPanelBase : UiPanelBase
{
	// Token: 0x0600EBD6 RID: 60374 RVA: 0x004025A2 File Offset: 0x004007A2
	[NullableContext(2)]
	protected void OnEnterItem(HonamiStoryItemGridItem item)
	{
		if (this.OnEnterGridCb != null)
		{
			this.OnEnterGridCb(item, (EHonamiStoryBackpackType)this.GetBackpackType());
		}
	}

	// Token: 0x0600EBD7 RID: 60375 RVA: 0x004025BE File Offset: 0x004007BE
	protected void OnExitItem()
	{
		Action onExitGridCb = this.OnExitGridCb;
		if (onExitGridCb == null)
		{
			return;
		}
		onExitGridCb();
	}

	// Token: 0x0600EBD8 RID: 60376 RVA: 0x004025D0 File Offset: 0x004007D0
	protected void OnDownItem()
	{
		Action onDownGridCb = this.OnDownGridCb;
		if (onDownGridCb == null)
		{
			return;
		}
		onDownGridCb();
	}

	// Token: 0x0600EBD9 RID: 60377 RVA: 0x004025E2 File Offset: 0x004007E2
	protected void OnClickItem([Nullable(2)] HonamiStoryItemGridItem item, Vector2D loc, Vector2D size)
	{
		if (this.OnClickedGridCb != null)
		{
			this.OnClickedGridCb(item, loc, size, (EHonamiStoryBackpackType)this.GetBackpackType());
		}
	}

	// Token: 0x0600EBDA RID: 60378 RVA: 0x00402600 File Offset: 0x00400800
	protected void OnCheckAttrItem([Nullable(2)] HonamiStoryEquipGridItem item, HonamiStoryInteractOperateAgent operateAgent)
	{
		Action<HonamiStoryEquipGridItem, HonamiStoryInteractOperateAgent> onCheckAttrGridCb = this.OnCheckAttrGridCb;
		if (onCheckAttrGridCb == null)
		{
			return;
		}
		onCheckAttrGridCb(item, operateAgent);
	}

	// Token: 0x0600EBDB RID: 60379 RVA: 0x00402614 File Offset: 0x00400814
	public void RegisterDragController(HonamiStoryInteractController controller)
	{
		this.InteractController = controller;
	}

	// Token: 0x0600EBDC RID: 60380
	public abstract int GetBackpackType();

	// Token: 0x0600EBDD RID: 60381 RVA: 0x0040261D File Offset: 0x0040081D
	public virtual bool OnDragBegin([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.InteractController.DragBegin(this, item);
		return true;
	}

	// Token: 0x0600EBDE RID: 60382 RVA: 0x0040262E File Offset: 0x0040082E
	public virtual bool OnDrag([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.InteractController.OnDrag(eventData);
		return true;
	}

	// Token: 0x0600EBDF RID: 60383 RVA: 0x0040263D File Offset: 0x0040083D
	public virtual void OnDragEnd([Nullable(2)] ULGUIPointerEventData eventData, HonamiStoryGridItemBase item)
	{
		this.InteractController.DragEnd(eventData, item);
	}

	// Token: 0x0600EBE0 RID: 60384 RVA: 0x0040264C File Offset: 0x0040084C
	public virtual void RefreshSingleItem(HonamiStoryItemDataBase itemData)
	{
	}

	// Token: 0x0600EBE1 RID: 60385
	public abstract void OnHover(ULGUIPointerEventData eventData, HonamiStoryInteractOperateAgent operateAgent);

	// Token: 0x0600EBE2 RID: 60386
	public abstract void OnHoverEnd();

	// Token: 0x0600EBE3 RID: 60387
	public abstract bool CheckDragItemInViewport(ULGUIPointerEventData eventData);

	// Token: 0x0600EBE4 RID: 60388
	[return: Nullable(2)]
	public abstract HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase item);

	// Token: 0x0600EBE5 RID: 60389
	[return: Nullable(2)]
	public abstract HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet);

	// Token: 0x0600EBE6 RID: 60390
	[return: Nullable(2)]
	public abstract HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpack(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet);

	// Token: 0x0600EBE7 RID: 60391
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public abstract HashSet<HonamiStoryItemDataBase> GetExchangeItemSet(ULGUIPointerEventData eventData, HonamiStoryItemDataBase operateItem);

	// Token: 0x0600EBE8 RID: 60392
	public abstract void OnBackpackLogicStateChange(EHonamiStoryBackpackLogicState state);

	// Token: 0x0600EBE9 RID: 60393
	public abstract List<HonamiStoryGridItemBase> GetUpdateContextEffectGridItems(HonamiStoryBagUpdateContext updateContext);

	// Token: 0x0600EBEA RID: 60394 RVA: 0x0040264E File Offset: 0x0040084E
	public virtual List<HonamiStoryGridItemBase> GetCurrentGridListGamepad()
	{
		return new List<HonamiStoryGridItemBase>();
	}

	// Token: 0x0600EBEB RID: 60395 RVA: 0x00402655 File Offset: 0x00400855
	public virtual bool CheckPositionValidGamepad(int position)
	{
		return false;
	}

	// Token: 0x0600EBEC RID: 60396 RVA: 0x00402658 File Offset: 0x00400858
	public virtual void OnScrollValueChangedGamepad(bool isUp)
	{
	}

	// Token: 0x0600EBED RID: 60397 RVA: 0x0040265A File Offset: 0x0040085A
	public virtual void OnScrollToTopOrBottomGamepad(bool toTop)
	{
	}

	// Token: 0x0600EBEE RID: 60398 RVA: 0x0040265C File Offset: 0x0040085C
	public virtual void OnHoverGamepad(HonamiStoryGridItemBase item, int position, HonamiStoryInteractOperateAgent operateAgent)
	{
	}

	// Token: 0x0600EBEF RID: 60399 RVA: 0x0040265E File Offset: 0x0040085E
	[return: Nullable(2)]
	public virtual HonamiStoryBagUpdateContext GetUpdateInfoInSameBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase item)
	{
		return null;
	}

	// Token: 0x0600EBF0 RID: 60400 RVA: 0x00402661 File Offset: 0x00400861
	[return: Nullable(2)]
	public virtual HonamiStoryBagUpdateContext GetUpdateInfoInSendBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		return null;
	}

	// Token: 0x0600EBF1 RID: 60401 RVA: 0x00402664 File Offset: 0x00400864
	[return: Nullable(2)]
	public virtual HonamiStoryBagUpdateContext GetUpdateInfoInReceiveBackpackGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem, HashSet<HonamiStoryItemDataBase> exchangeItemSet)
	{
		return null;
	}

	// Token: 0x0600EBF2 RID: 60402 RVA: 0x00402667 File Offset: 0x00400867
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public virtual HashSet<HonamiStoryItemDataBase> GetExchangeItemSetGamepad(HonamiStoryGridItemBase gridItem, HonamiStoryItemDataBase operateItem)
	{
		return null;
	}

	// Token: 0x04007176 RID: 29046
	[Nullable(2)]
	public Action<HonamiStoryItemGridItem, EHonamiStoryBackpackType> OnEnterGridCb;

	// Token: 0x04007177 RID: 29047
	[Nullable(2)]
	public Action OnExitGridCb;

	// Token: 0x04007178 RID: 29048
	[Nullable(2)]
	public Action OnDownGridCb;

	// Token: 0x04007179 RID: 29049
	[Nullable(new byte[]
	{
		2,
		2,
		1
	})]
	public Action<HonamiStoryEquipGridItem, HonamiStoryInteractOperateAgent> OnCheckAttrGridCb;

	// Token: 0x0400717A RID: 29050
	[Nullable(new byte[]
	{
		2,
		2,
		1,
		1
	})]
	public Action<HonamiStoryItemGridItem, Vector2D, Vector2D, EHonamiStoryBackpackType> OnClickedGridCb;

	// Token: 0x0400717B RID: 29051
	protected HonamiStoryInteractController InteractController;
}
