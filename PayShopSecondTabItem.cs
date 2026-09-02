using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023E5 RID: 9189
public class PayShopSecondTabItem : UiPanelBase
{
	// Token: 0x06011C75 RID: 72821 RVA: 0x004E3A85 File Offset: 0x004E1C85
	[NullableContext(1)]
	public PayShopSecondTabItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06011C76 RID: 72822 RVA: 0x004E3A9C File Offset: 0x004E1C9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011C77 RID: 72823 RVA: 0x004E3B42 File Offset: 0x004E1D42
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(2);
		this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		this.SetToggleState(false);
	}

	// Token: 0x06011C78 RID: 72824 RVA: 0x004E3B74 File Offset: 0x004E1D74
	protected override void OnBeforeDestroy()
	{
		this.SetToggleState(false);
		this.Toggle.CanExecuteChange.Unbind();
	}

	// Token: 0x06011C79 RID: 72825 RVA: 0x004E3B8D File Offset: 0x004E1D8D
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.IsSelected = true;
			Action<int> toggleFunction = this.ToggleFunction;
			if (toggleFunction == null)
			{
				return;
			}
			toggleFunction(this.TabId);
		}
	}

	// Token: 0x06011C7A RID: 72826 RVA: 0x004E3BB0 File Offset: 0x004E1DB0
	private bool CanExecuteChange()
	{
		EToggleState toggleState = this.Toggle.GetToggleState();
		return !this.IsSelected || toggleState != EToggleState.ETT_Checked;
	}

	// Token: 0x06011C7B RID: 72827 RVA: 0x004E3BD8 File Offset: 0x004E1DD8
	public void SetName(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		this.TabId = tabId;
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		base.GetText(0).SetText((payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.Name : "", true);
	}

	// Token: 0x06011C7C RID: 72828 RVA: 0x004E3C16 File Offset: 0x004E1E16
	[NullableContext(1)]
	public void SetToggleFunction(Action<int> callBack)
	{
		this.ToggleFunction = callBack;
	}

	// Token: 0x06011C7D RID: 72829 RVA: 0x004E3C20 File Offset: 0x004E1E20
	public void SetToggleState(bool bSelected)
	{
		this.IsSelected = bSelected;
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.Toggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x04008B30 RID: 35632
	protected int TabId;

	// Token: 0x04008B31 RID: 35633
	protected bool IsSelected;

	// Token: 0x04008B32 RID: 35634
	[Nullable(2)]
	protected Action<int> ToggleFunction;

	// Token: 0x04008B33 RID: 35635
	[Nullable(2)]
	protected UUIExtendToggle Toggle;

	// Token: 0x0200871E RID: 34590
	private class EPayShopSecondTabItemDefine
	{
		// Token: 0x0402DB40 RID: 187200
		public const int Name = 0;

		// Token: 0x0402DB41 RID: 187201
		public const int RedDotActor = 1;

		// Token: 0x0402DB42 RID: 187202
		public const int Toggle = 2;
	}
}
