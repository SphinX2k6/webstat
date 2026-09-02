using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018CA RID: 6346
[NullableContext(1)]
[Nullable(0)]
public abstract class DropDownItemBase<[Nullable(2)] TData> : UiPanelBase
{
	// Token: 0x0600B672 RID: 46706 RVA: 0x003084B3 File Offset: 0x003066B3
	public DropDownItemBase(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B673 RID: 46707 RVA: 0x003084C8 File Offset: 0x003066C8
	protected override void OnStartImplement()
	{
		UUIExtendToggle dropDownToggle = this.GetDropDownToggle();
		dropDownToggle.OnStateChange.Clear();
		dropDownToggle.CanExecuteChange.Unbind();
		dropDownToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleFunction));
		dropDownToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600B674 RID: 46708 RVA: 0x0030851E File Offset: 0x0030671E
	private void OnToggleFunction(EToggleState state)
	{
		Action<int> toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(this.Index);
	}

	// Token: 0x0600B675 RID: 46709 RVA: 0x00308536 File Offset: 0x00306736
	private bool OnCanExecuteChange()
	{
		Func<int, bool> canExecuteFunction = this.CanExecuteFunction;
		return canExecuteFunction != null && canExecuteFunction(this.Index);
	}

	// Token: 0x0600B676 RID: 46710 RVA: 0x0030854F File Offset: 0x0030674F
	protected override void OnBeforeDestroyImplement()
	{
		UUIExtendToggle dropDownToggle = this.GetDropDownToggle();
		dropDownToggle.OnStateChange.Clear();
		dropDownToggle.CanExecuteChange.Unbind();
	}

	// Token: 0x0600B677 RID: 46711 RVA: 0x0030856C File Offset: 0x0030676C
	public void ShowDropDownItemBase(TData data, int index)
	{
		this.Index = index;
		this.OnShowDropDownItemBase(data);
	}

	// Token: 0x0600B678 RID: 46712 RVA: 0x0030857C File Offset: 0x0030677C
	public void SetToggleFunction(Action<int> callback)
	{
		this.ToggleFunction = callback;
	}

	// Token: 0x0600B679 RID: 46713 RVA: 0x00308585 File Offset: 0x00306785
	public void SetCanExecuteFunction(Func<int, bool> callback)
	{
		this.CanExecuteFunction = callback;
	}

	// Token: 0x0600B67A RID: 46714 RVA: 0x00308590 File Offset: 0x00306790
	public void SetToggle(bool bSelected)
	{
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.GetDropDownToggle().SetToggleState(state, bSelected, false, false);
	}

	// Token: 0x0600B67B RID: 46715 RVA: 0x003085B8 File Offset: 0x003067B8
	public void SetToggleForce(bool bSelected)
	{
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.GetDropDownToggle().SetToggleStateForce(state, bSelected, false, false);
	}

	// Token: 0x0600B67C RID: 46716
	protected abstract void OnShowDropDownItemBase(TData data);

	// Token: 0x0600B67D RID: 46717
	[NullableContext(2)]
	protected abstract UUIExtendToggle GetDropDownToggle();

	// Token: 0x040055F5 RID: 22005
	private int Index;

	// Token: 0x040055F6 RID: 22006
	[Nullable(2)]
	private Action<int> ToggleFunction;

	// Token: 0x040055F7 RID: 22007
	[Nullable(2)]
	private Func<int, bool> CanExecuteFunction;
}
