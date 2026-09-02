using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200201C RID: 8220
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomManageConfigTypeItem : GridProxyAbstract<InventoryDefine.IManageConfigTypeItemData>, IStaticVariableResetter
{
	// Token: 0x0600F9D2 RID: 63954 RVA: 0x004466A6 File Offset: 0x004448A6
	static PhantomManageConfigTypeItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomManageConfigTypeItem.CreateStaticDefaultValue), new Action(PhantomManageConfigTypeItem.ResetStaticDefaultValue));
	}

	// Token: 0x0600F9D3 RID: 63955 RVA: 0x004466C5 File Offset: 0x004448C5
	public static void CreateStaticDefaultValue()
	{
		PhantomManageConfigTypeItem.ViewModel = null;
	}

	// Token: 0x0600F9D4 RID: 63956 RVA: 0x004466CD File Offset: 0x004448CD
	public static void ResetStaticDefaultValue()
	{
		PhantomManageConfigTypeItem.ViewModel = null;
	}

	// Token: 0x0600F9D5 RID: 63957 RVA: 0x004466D8 File Offset: 0x004448D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickedSelect));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F9D6 RID: 63958 RVA: 0x0044679F File Offset: 0x0044499F
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600F9D7 RID: 63959 RVA: 0x004467CC File Offset: 0x004449CC
	[NullableContext(1)]
	public override void Refresh(InventoryDefine.IManageConfigTypeItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		EToggleState state = this.GetSelectState() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600F9D8 RID: 63960 RVA: 0x0044681A File Offset: 0x00444A1A
	[NullableContext(1)]
	public override object GetKey(InventoryDefine.IManageConfigTypeItemData data, int displayIndex)
	{
		return data.Type;
	}

	// Token: 0x0600F9D9 RID: 63961 RVA: 0x00446828 File Offset: 0x00444A28
	private bool OnCanExecuteChange()
	{
		EToggleState toggleState = base.GetExtendToggle(1).GetToggleState();
		return !this.GetSelectState() || toggleState != EToggleState.ETT_Checked;
	}

	// Token: 0x0600F9DA RID: 63962 RVA: 0x00446851 File Offset: 0x00444A51
	private void OnClickedSelect(EToggleState toggleState)
	{
		if (this.Data != null && PhantomManageConfigTypeItem.ViewModel != null)
		{
			if (PhantomManageConfigTypeItem.ViewModel.GetSelectType() == this.Data.Type)
			{
				return;
			}
			PhantomManageConfigTypeItem.ViewModel.SetSelectType(this.Data.Type, false);
		}
	}

	// Token: 0x0600F9DB RID: 63963 RVA: 0x00446890 File Offset: 0x00444A90
	private bool GetSelectState()
	{
		return this.Data != null && PhantomManageConfigTypeItem.ViewModel != null && PhantomManageConfigTypeItem.ViewModel.GetSelectType() == this.Data.Type;
	}

	// Token: 0x04007812 RID: 30738
	[Nullable(2)]
	private InventoryDefine.IManageConfigTypeItemData Data;

	// Token: 0x04007813 RID: 30739
	[Nullable(2)]
	public static PhantomManageConfigViewModel ViewModel;

	// Token: 0x020083B8 RID: 33720
	private enum EComponent
	{
		// Token: 0x0402CA9E RID: 182942
		TextName,
		// Token: 0x0402CA9F RID: 182943
		BtnSelect,
		// Token: 0x0402CAA0 RID: 182944
		ItemReddot
	}
}
