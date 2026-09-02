using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using FilterDefine;
using UnrealEngine;

// Token: 0x0200201F RID: 8223
public class SettingGridSmall : SettingGridBase
{
	// Token: 0x0600F9E5 RID: 63973 RVA: 0x00446A24 File Offset: 0x00444C24
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickedSwitch));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F9E6 RID: 63974 RVA: 0x00446ACA File Offset: 0x00444CCA
	protected override void OnStart()
	{
		base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.OnCheckCanChange));
	}

	// Token: 0x0600F9E7 RID: 63975 RVA: 0x00446AEC File Offset: 0x00444CEC
	[NullableContext(1)]
	public override void Refresh(InventoryDefine.IManageConfigSettingGridData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		if (!this.CheckShow())
		{
			base.SetUiActive(false);
			return;
		}
		base.SetUiActive(true);
		base.GetExtendToggle(1).SetSelfInteractive(data.IsEditing);
		if (data.IsEmpty)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PhantomProject_EmptyChose", Array.Empty<object>());
			base.GetExtendToggle(1).SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
			return;
		}
		this.SetNormalState();
	}

	// Token: 0x0600F9E8 RID: 63976 RVA: 0x00446B64 File Offset: 0x00444D64
	private bool CheckShow()
	{
		InventoryDefine.IManageConfigSettingGridData data = this.Data;
		if (data.IsFirst)
		{
			return data.IsEmpty && !data.IsEditing;
		}
		return data.IsEditing || data.IsSelect;
	}

	// Token: 0x0600F9E9 RID: 63977 RVA: 0x00446BA8 File Offset: 0x00444DA8
	private void SetNormalState()
	{
		InventoryDefine.IManageConfigSettingGridData data = this.Data;
		int filterType = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(data.RuleId).Value.FilterType;
		FilterItemData filterItemData = ModelBase<FilterModel>.Instance.GetFilterDataFuncByFilterType((FilterDefine.EFilterType)filterType)(new int[]
		{
			data.Value
		})[0];
		EToggleState etoggleState = data.IsSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleStateForce((!data.IsEditing) ? EToggleState.ETT_UnDetermined : etoggleState, false, false, false);
		base.GetText(0).SetText(filterItemData.Content ?? "", true);
	}

	// Token: 0x0600F9EA RID: 63978 RVA: 0x00446C46 File Offset: 0x00444E46
	private bool OnCheckCanChange()
	{
		return this.Data != null && this.Data.IsEditing;
	}

	// Token: 0x0600F9EB RID: 63979 RVA: 0x00446C5D File Offset: 0x00444E5D
	private void OnClickedSwitch(EToggleState state)
	{
		if (this.CallbackOnClicked != null)
		{
			this.CallbackOnClicked(this.Data, state == EToggleState.ETT_Checked);
		}
	}

	// Token: 0x04007819 RID: 30745
	[Nullable(2)]
	private InventoryDefine.IManageConfigSettingGridData Data;

	// Token: 0x020083BC RID: 33724
	private enum EComponentSmall
	{
		// Token: 0x0402CAAD RID: 182957
		TextName,
		// Token: 0x0402CAAE RID: 182958
		BtnSwitch
	}
}
