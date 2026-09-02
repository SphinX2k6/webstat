using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200199F RID: 6559
public class TipsLockButton : UiPanelBase
{
	// Token: 0x0600BC55 RID: 48213 RVA: 0x0031FCF5 File Offset: 0x0031DEF5
	[NullableContext(1)]
	public TipsLockButton(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600BC56 RID: 48214 RVA: 0x0031FD0C File Offset: 0x0031DF0C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.LockButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnDeprecateToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BC57 RID: 48215 RVA: 0x0031FDD5 File Offset: 0x0031DFD5
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.CanExecuteChange.Unbind();
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600BC58 RID: 48216 RVA: 0x0031FDFF File Offset: 0x0031DFFF
	private bool OnCanExecuteChange()
	{
		return this.CanClickLockButton == null || this.CanClickLockButton(this.IncId);
	}

	// Token: 0x0600BC59 RID: 48217 RVA: 0x0031FE1C File Offset: 0x0031E01C
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshFuncState));
	}

	// Token: 0x0600BC5A RID: 48218 RVA: 0x0031FE3A File Offset: 0x0031E03A
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshFuncState));
	}

	// Token: 0x0600BC5B RID: 48219 RVA: 0x0031FE58 File Offset: 0x0031E058
	[NullableContext(2)]
	public void Refresh(int incId, Func<int, bool> canClickFunction = null)
	{
		this.IncId = incId;
		this.RefreshUi(incId);
		if (canClickFunction != null)
		{
			this.CanClickLockButton = canClickFunction;
			return;
		}
		this.CanClickLockButton = null;
	}

	// Token: 0x0600BC5C RID: 48220 RVA: 0x0031FE7C File Offset: 0x0031E07C
	private void RefreshUi(int incId)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(incId);
		if (attributeItemData == null)
		{
			return;
		}
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(attributeItemData.CanLock());
		base.GetExtendToggle(1).RootUIComp.Get().SetUIActive(attributeItemData.CanDeprecate());
		EToggleState state = attributeItemData.GetIsLock() ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
		EToggleState state2 = attributeItemData.GetIsDeprecated() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleStateForce(state2, false, false, false);
	}

	// Token: 0x0600BC5D RID: 48221 RVA: 0x0031FF14 File Offset: 0x0031E114
	public void SetDeprecateToggleVisible(bool state)
	{
		base.GetExtendToggle(1).RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x0600BC5E RID: 48222 RVA: 0x0031FF3B File Offset: 0x0031E13B
	private void RefreshFuncState(int incId)
	{
		if (incId != this.IncId)
		{
			return;
		}
		this.RefreshUi(incId);
	}

	// Token: 0x0600BC5F RID: 48223 RVA: 0x0031FF50 File Offset: 0x0031E150
	private void LockButtonClick(EToggleState toggleState)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.IncId);
		if (attributeItemData == null)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemLockRequest(this.IncId, !attributeItemData.GetIsLock());
	}

	// Token: 0x0600BC60 RID: 48224 RVA: 0x0031FF8C File Offset: 0x0031E18C
	private void OnDeprecateToggleClick(EToggleState toggleState)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.IncId);
		if (attributeItemData == null)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemDeprecateRequest(this.IncId, !attributeItemData.GetIsDeprecated());
	}

	// Token: 0x04005924 RID: 22820
	private int IncId;

	// Token: 0x04005925 RID: 22821
	[Nullable(2)]
	private Func<int, bool> CanClickLockButton;

	// Token: 0x02007CA3 RID: 31907
	private class ETipsLockButtonNode
	{
		// Token: 0x0402A8DE RID: 174302
		public const int LockToggle = 0;

		// Token: 0x0402A8DF RID: 174303
		public const int DeprecateToggle = 1;
	}
}
