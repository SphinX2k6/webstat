using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using FilterDefine;
using UnrealEngine;

// Token: 0x02002020 RID: 8224
public class SettingGridBig : SettingGridBase
{
	// Token: 0x0600F9ED RID: 63981 RVA: 0x00446C84 File Offset: 0x00444E84
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickedSwitch));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F9EE RID: 63982 RVA: 0x00446D90 File Offset: 0x00444F90
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
		if (data.IsEmpty)
		{
			this.SetEmptyState();
			return;
		}
		base.GetButton(4).SetSelfInteractive(data.IsEditing);
		if (data.IsAdd)
		{
			this.SetAddState();
			return;
		}
		this.SetNormalState();
	}

	// Token: 0x0600F9EF RID: 63983 RVA: 0x00446DF4 File Offset: 0x00444FF4
	private bool CheckShow()
	{
		InventoryDefine.IManageConfigSettingGridData data = this.Data;
		if (data.IsFirst)
		{
			return data.IsEditing || (data.IsEmpty && !data.IsEditing);
		}
		return data.IsSelect;
	}

	// Token: 0x0600F9F0 RID: 63984 RVA: 0x00446E3C File Offset: 0x0044503C
	private void SetEmptyState()
	{
		base.GetTexture(2).SetUIActive(false);
		base.GetTexture(3).SetUIActive(false);
		base.GetTexture(0).SetUIActive(false);
		base.GetButton(4).SetSelfInteractive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PhantomProject_EmptyChose", Array.Empty<object>());
	}

	// Token: 0x0600F9F1 RID: 63985 RVA: 0x00446E98 File Offset: 0x00445098
	private void SetAddState()
	{
		base.GetTexture(2).SetUIActive(true);
		base.GetTexture(3).SetUIActive(false);
		base.GetTexture(0).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PhantomProject_AddChose", Array.Empty<object>());
	}

	// Token: 0x0600F9F2 RID: 63986 RVA: 0x00446EE8 File Offset: 0x004450E8
	private void SetNormalState()
	{
		InventoryDefine.IManageConfigSettingGridData data = this.Data;
		base.GetTexture(2).SetUIActive(false);
		base.GetTexture(3).SetUIActive(data.IsEditing);
		int filterType = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(data.RuleId).Value.FilterType;
		FilterItemData filterItemData = ModelBase<FilterModel>.Instance.GetFilterDataFuncByFilterType((FilterDefine.EFilterType)filterType)(new int[]
		{
			data.Value
		})[0];
		base.GetText(1).SetText(filterItemData.Content ?? "", true);
		this.SetIcon(filterItemData);
	}

	// Token: 0x0600F9F3 RID: 63987 RVA: 0x00446F84 File Offset: 0x00445184
	[NullableContext(1)]
	private void SetIcon(FilterItemData filterData)
	{
		string iconPath = filterData.GetIconPath();
		UUITexture texture = base.GetTexture(0);
		if (StringUtils.IsBlank(iconPath))
		{
			texture.SetUIActive(false);
			return;
		}
		texture.SetUIActive(true);
		base.SetTextureByPath(iconPath, texture, null, null);
		UUIItem uuiitem = texture;
		bool needChangeColor = filterData.NeedChangeColor;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(needChangeColor, fcolor);
	}

	// Token: 0x0600F9F4 RID: 63988 RVA: 0x00446FE3 File Offset: 0x004451E3
	private void OnClickedSwitch()
	{
		if (this.CallbackOnClicked != null && this.Data != null)
		{
			this.CallbackOnClicked(this.Data, this.Data.IsAdd);
		}
	}

	// Token: 0x0400781A RID: 30746
	[Nullable(2)]
	private InventoryDefine.IManageConfigSettingGridData Data;

	// Token: 0x020083BD RID: 33725
	private enum EComponentBig
	{
		// Token: 0x0402CAB0 RID: 182960
		TextureIcon,
		// Token: 0x0402CAB1 RID: 182961
		TextName,
		// Token: 0x0402CAB2 RID: 182962
		TextureAdd,
		// Token: 0x0402CAB3 RID: 182963
		TextureDelete,
		// Token: 0x0402CAB4 RID: 182964
		BtnSwitch
	}
}
