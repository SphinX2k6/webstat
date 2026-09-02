using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B47 RID: 6983
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FormationDragController : UiControllerBase<FormationDragController>
{
	// Token: 0x0600C9E1 RID: 51681 RVA: 0x0035A89E File Offset: 0x00358A9E
	public void InitDragData(FormationDragData data)
	{
		this.DragData = data;
		this.IsGamepad = Singleton<Info>.Instance.IsInGamepad();
		this.DraggingIndex = 0;
		this.GamePadSelectModel = false;
	}

	// Token: 0x0600C9E2 RID: 51682 RVA: 0x0035A8C5 File Offset: 0x00358AC5
	public void SetCustomShield(bool active)
	{
		ModelBase<UiNavigationModel>.Instance.CustomShieldHotKeyComponent(this.DragData.CustomShieldHotKeyComponentSet, active);
	}

	// Token: 0x0600C9E3 RID: 51683 RVA: 0x0035A8DD File Offset: 0x00358ADD
	public void AddCustomShieldHotKeyComponentSetData(int index)
	{
		FormationDragData dragData = this.DragData;
		if (dragData == null)
		{
			return;
		}
		dragData.CustomShieldHotKeyComponentSet.Add(index);
	}

	// Token: 0x0600C9E4 RID: 51684 RVA: 0x0035A8F6 File Offset: 0x00358AF6
	public void ClearDragData()
	{
		FormationDragData dragData = this.DragData;
		if (dragData != null)
		{
			dragData.ClearData();
		}
		this.DragData = null;
	}

	// Token: 0x0600C9E5 RID: 51685 RVA: 0x0035A910 File Offset: 0x00358B10
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
	}

	// Token: 0x0600C9E6 RID: 51686 RVA: 0x0035A92E File Offset: 0x00358B2E
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
	}

	// Token: 0x0600C9E7 RID: 51687 RVA: 0x0035A94C File Offset: 0x00358B4C
	private void InputControllerChange(EInputControllerType eInputControllerType, EInputControllerType inputControllerType)
	{
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "Formation-InputControllerChange", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.IsGamepad != Singleton<Info>.Instance.IsInGamepad())
		{
			if (this.IsGamepad)
			{
				this.CancelDrag();
			}
			else
			{
				FormationDragData dragData = this.DragData;
				if (dragData != null)
				{
					FormationRoleSlot formationRoleSlot = dragData.FormationRoleViewList[this.DragData.DragItemPosition - 1];
					if (formationRoleSlot != null)
					{
						formationRoleSlot.MouseCancelDrag();
					}
				}
			}
		}
		this.IsGamepad = Singleton<Info>.Instance.IsInGamepad();
	}

	// Token: 0x0600C9E8 RID: 51688 RVA: 0x0035A9D4 File Offset: 0x00358BD4
	[NullableContext(2)]
	public void OnFormationRoleViewPointDown(ULGUIPointerEventData eventData, int configId, int roleSkinId, int editPosition)
	{
		if (this.DragData == null || eventData == null)
		{
			return;
		}
		FormationDragData dragData = this.DragData;
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(eventData.pointerPosition, dragData.LastDragPos);
		dragData.TempPointerPosition.Set(dragData.LastDragPos.X, 0.0, dragData.LastDragPos.Y);
		FormationRoleDragItem dragRoleItem = dragData.DragRoleItem;
		if (dragRoleItem != null)
		{
			UUIItem rootItem = dragRoleItem.GetRootItem();
			FVector fvector = dragData.TempPointerPosition.ToUeVectorOld();
			rootItem.SetUIWorldLocation(fvector);
		}
		FormationRoleDragItem dragRoleItem2 = dragData.DragRoleItem;
		if (dragRoleItem2 != null)
		{
			dragRoleItem2.RefreshRoleIcon(configId, roleSkinId);
		}
		dragData.DragItemPosition = editPosition;
		foreach (FormationRoleSlot formationRoleSlot in dragData.FormationRoleViewList)
		{
			if (dragData.FormationRoleViewList.IndexOf(formationRoleSlot) + 1 != dragData.DragItemPosition)
			{
				formationRoleSlot.EndShowDragItem();
			}
		}
	}

	// Token: 0x0600C9E9 RID: 51689 RVA: 0x0035AAD0 File Offset: 0x00358CD0
	public void OnFormationRoleViewGamePadDown(UUIItem item, int configId, int roleSkinId, int editPosition)
	{
		if (this.DragData == null)
		{
			return;
		}
		FormationDragData dragData = this.DragData;
		this.GamePadSelectPositionHandle = item.GetUIWorldPosition();
		this.GamePadSelectPositionHandle.Set(this.GamePadSelectPositionHandle.X + 30f, this.GamePadSelectPositionHandle.Y, this.GamePadSelectPositionHandle.Z - 50f);
		FormationRoleDragItem dragRoleItem = dragData.DragRoleItem;
		if (dragRoleItem != null)
		{
			dragRoleItem.RefreshRoleIcon(configId, roleSkinId);
		}
		dragData.DragItemPosition = editPosition;
		foreach (FormationRoleSlot formationRoleSlot in dragData.FormationRoleViewList)
		{
			if (dragData.FormationRoleViewList.IndexOf(formationRoleSlot) + 1 != dragData.DragItemPosition)
			{
				formationRoleSlot.EndShowDragItem();
			}
		}
	}

	// Token: 0x0600C9EA RID: 51690 RVA: 0x0035ABA8 File Offset: 0x00358DA8
	public void OnFormationRoleViewEndDrag(bool? isCancel = null)
	{
		if (this.DragData == null)
		{
			return;
		}
		FormationDragData dragData = this.DragData;
		foreach (FormationRoleSlot formationRoleSlot in (((dragData != null) ? dragData.FormationRoleViewList : null) ?? new List<FormationRoleSlot>()))
		{
			formationRoleSlot.RefreshLockItemState(false);
		}
		FormationDragData dragData2 = this.DragData;
		FormationRoleDragItem dragRoleItem = dragData2.DragRoleItem;
		if (dragRoleItem != null)
		{
			dragRoleItem.GetRootItem().SetUIActive(false);
		}
		int num = -1;
		int num2 = 0;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		foreach (FormationRoleSlot formationRoleSlot2 in dragData2.FormationRoleViewList)
		{
			int playerId = formationRoleSlot2.GetPlayerId();
			int? num3 = id;
			if ((playerId == num3.GetValueOrDefault() & num3 != null) && this.GetPositionInRange(formationRoleSlot2.GetRootItem()))
			{
				num = dragData2.FormationRoleViewList.IndexOf(formationRoleSlot2) + 1;
				num2 = formationRoleSlot2.GetConfigId().GetValueOrDefault();
			}
			formationRoleSlot2.EndShowDragItem();
		}
		if (num <= 0 || num2 <= 0 || num == dragData2.DragItemPosition || isCancel.GetValueOrDefault())
		{
			return;
		}
		int valueOrDefault = dragData2.FormationRoleViewList[dragData2.DragItemPosition - 1].GetConfigId().GetValueOrDefault();
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "编队角色更换-拖拽", default(ReadOnlySpan<ValueTuple<string, object>>));
		Action<int, int, int, int> exchangeRoleCallBack = dragData2.ExchangeRoleCallBack;
		if (exchangeRoleCallBack == null)
		{
			return;
		}
		exchangeRoleCallBack(num, dragData2.DragItemPosition, valueOrDefault, num2);
	}

	// Token: 0x0600C9EB RID: 51691 RVA: 0x0035AD4C File Offset: 0x00358F4C
	[NullableContext(2)]
	public void OnFormationRoleViewMoveDrag(ULGUIPointerEventData eventData)
	{
		if (this.DragData == null || eventData == null)
		{
			return;
		}
		FormationDragData dragData = this.DragData;
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(eventData.pointerPosition, dragData.CurDragPos);
		if (Vector2D.Create(dragData.CurDragPos.X, dragData.CurDragPos.Y).SubtractionEqual(dragData.LastDragPos).IsNearlyZero(0.0))
		{
			return;
		}
		double num = dragData.CurDragPos.X - dragData.LastDragPos.X;
		double num2 = dragData.CurDragPos.Y - dragData.LastDragPos.Y;
		dragData.TempAnchorOffset.FromUeVector2D(dragData.DragRoleItem.GetRootItem().GetAnchorOffset());
		dragData.TempAnchorOffset.X += num;
		dragData.TempAnchorOffset.Y += num2;
		dragData.DragRoleItem.GetRootItem().SetAnchorOffset(dragData.TempAnchorOffset.ToUeVector2D(false));
		dragData.LastDragPos.DeepCopy(dragData.CurDragPos);
		foreach (FormationRoleSlot formationRoleSlot in dragData.FormationRoleViewList)
		{
			if (formationRoleSlot.GetConfigId().GetValueOrDefault() > 0 && this.GetPositionInRange(formationRoleSlot.GetRootItem()))
			{
				formationRoleSlot.ShowOtherItemUpState();
			}
			else
			{
				formationRoleSlot.EndShowDragItem();
			}
		}
	}

	// Token: 0x0600C9EC RID: 51692 RVA: 0x0035AED0 File Offset: 0x003590D0
	public void OnGamePadPress()
	{
		if (this.DragData == null)
		{
			return;
		}
		this.DragData.FormationRoleViewList[this.DragData.DragItemPosition - 1].GamePadPress();
	}

	// Token: 0x0600C9ED RID: 51693 RVA: 0x0035AEFD File Offset: 0x003590FD
	public void OnGamePadRelease()
	{
		if (this.DragData == null)
		{
			return;
		}
		this.DragData.FormationRoleViewList[this.DragData.DragItemPosition - 1].GamePadRelease();
	}

	// Token: 0x0600C9EE RID: 51694 RVA: 0x0035AF2C File Offset: 0x0035912C
	public void OnFormationRoleViewStartDrag()
	{
		FormationDragData dragData = this.DragData;
		if (dragData != null)
		{
			FormationRoleDragItem dragRoleItem = dragData.DragRoleItem;
			if (dragRoleItem != null)
			{
				dragRoleItem.GetRootItem().SetUIActive(true);
			}
		}
		FormationDragData dragData2 = this.DragData;
		foreach (FormationRoleSlot formationRoleSlot in (((dragData2 != null) ? dragData2.FormationRoleViewList : null) ?? new List<FormationRoleSlot>()))
		{
			formationRoleSlot.RefreshLockItemState(true);
		}
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.DragStartMoveFirstRelease = true;
			this.SetGamePadSelectModel(true);
		}
	}

	// Token: 0x0600C9EF RID: 51695 RVA: 0x0035AFD8 File Offset: 0x003591D8
	public bool GetPositionInRange(UUIItem item)
	{
		if (this.DragData == null)
		{
			return false;
		}
		FVector lguispaceAbsolutePosition = item.GetLGUISpaceAbsolutePosition();
		float num = item.GetWidth() / 2f;
		float num2 = lguispaceAbsolutePosition.X + num;
		float num3 = lguispaceAbsolutePosition.X - num;
		FVector lguispaceAbsolutePosition2 = this.DragData.DragRoleItem.GetRootItem().GetLGUISpaceAbsolutePosition();
		if (lguispaceAbsolutePosition2.X < num3 || lguispaceAbsolutePosition2.X > num2)
		{
			return false;
		}
		float num4 = item.GetHeight() / 2f;
		float num5 = lguispaceAbsolutePosition.Y + num4;
		float num6 = lguispaceAbsolutePosition.Y - num4;
		return lguispaceAbsolutePosition2.Y >= num6 && lguispaceAbsolutePosition2.Y <= num5;
	}

	// Token: 0x0600C9F0 RID: 51696 RVA: 0x0035B080 File Offset: 0x00359280
	public void SetGamePadSelectPosition(int position)
	{
		if (this.DragData == null)
		{
			return;
		}
		if (!this.GamePadSelectModel)
		{
			this.DragData.DragItemPosition = position;
			using (List<FormationRoleSlot>.Enumerator enumerator = this.DragData.FormationRoleViewList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FormationRoleSlot formationRoleSlot = enumerator.Current;
					formationRoleSlot.GamePadUp(false);
				}
				goto IL_5D;
			}
		}
		this.SelectPositionHandle = position;
		IL_5D:
		this.GamePadSelectPositionHandle = this.DragData.FormationRoleViewList[position - 1].GetRootItem().GetUIWorldPosition();
		this.GamePadSelectPositionHandle.Set(this.GamePadSelectPositionHandle.X + 30f, this.GamePadSelectPositionHandle.Y, this.GamePadSelectPositionHandle.Z - 50f);
		FormationRoleDragItem dragRoleItem = this.DragData.DragRoleItem;
		if (dragRoleItem != null)
		{
			dragRoleItem.GetRootItem().SetUIWorldLocation(this.GamePadSelectPositionHandle);
		}
		if (!this.DragData.DragRoleItem.GetRootItem().IsUIActiveSelf())
		{
			return;
		}
		for (int i = 0; i < this.DragData.FormationRoleViewList.Count; i++)
		{
			FormationRoleSlot formationRoleSlot2 = this.DragData.FormationRoleViewList[i];
			if (i == position - 1)
			{
				formationRoleSlot2.ShowOtherItemUpState();
			}
			else
			{
				formationRoleSlot2.EndShowDragItem();
			}
		}
	}

	// Token: 0x0600C9F1 RID: 51697 RVA: 0x0035B1D0 File Offset: 0x003593D0
	public void SetGamePadSelectModel(bool isSelect)
	{
		this.GamePadSelectModel = isSelect;
		if (this.DragData == null)
		{
			return;
		}
		if (!this.GamePadSelectModel)
		{
			this.DragData.DragItemPosition = this.SelectPositionHandle;
		}
		else
		{
			this.SelectPositionHandle = this.DragData.DragItemPosition;
		}
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		ModelBase<UiNavigationModel>.Instance.CustomShieldHotKeyComponent(this.DragData.CustomShieldHotKeyComponentSet, !this.GamePadSelectModel);
	}

	// Token: 0x0600C9F2 RID: 51698 RVA: 0x0035B244 File Offset: 0x00359444
	public bool GetDragItemUiActive()
	{
		FormationDragData dragData = this.DragData;
		bool? flag;
		if (dragData == null)
		{
			flag = null;
		}
		else
		{
			FormationRoleDragItem dragRoleItem = dragData.DragRoleItem;
			flag = ((dragRoleItem != null) ? new bool?(dragRoleItem.GetRootItem().IsUIActiveSelf()) : null);
		}
		bool? flag2 = flag;
		return flag2.GetValueOrDefault();
	}

	// Token: 0x0600C9F3 RID: 51699 RVA: 0x0035B294 File Offset: 0x00359494
	public void DragConfirm()
	{
		if (this.DragData == null)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "Formation-GamePad-DragConfirm", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.DragData.FormationRoleViewList[this.DragData.DragItemPosition - 1].GamePadUp(false);
		this.SetGamePadSelectModel(false);
	}

	// Token: 0x0600C9F4 RID: 51700 RVA: 0x0035B2F0 File Offset: 0x003594F0
	public void CancelDrag()
	{
		if (this.DragData == null || !this.GamePadSelectModel)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "Formation-GamePad-CancelDrag", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.DragData.FormationRoleViewList[this.DragData.DragItemPosition - 1].GamePadUp(true);
		this.SetGamePadSelectModel(false);
	}

	// Token: 0x0400609F RID: 24735
	[Nullable(2)]
	private FormationDragData DragData;

	// Token: 0x040060A0 RID: 24736
	private bool IsGamepad;

	// Token: 0x040060A1 RID: 24737
	private int SelectPositionHandle;

	// Token: 0x040060A2 RID: 24738
	public bool GamePadSelectModel;

	// Token: 0x040060A3 RID: 24739
	private FVector GamePadSelectPositionHandle = new FVector();

	// Token: 0x040060A4 RID: 24740
	public bool DragStartMoveFirstRelease;

	// Token: 0x040060A5 RID: 24741
	public int DraggingIndex;
}
