using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using FilterDefine;
using UnrealEngine;

// Token: 0x02002038 RID: 8248
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SelectGroup : GridProxyAbstract<InventoryDefine.ISelectGroupData>
{
	// Token: 0x0600FB3E RID: 64318 RVA: 0x0044F98C File Offset: 0x0044DB8C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickedAll));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FB3F RID: 64319 RVA: 0x0044FA95 File Offset: 0x0044DC95
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<SelectItem, InventoryDefine.ISelectItemData>(base.GetLayoutBase(3), new Func<SelectItem>(this.InitSelectItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600FB40 RID: 64320 RVA: 0x0044FAC8 File Offset: 0x0044DCC8
	private SelectItem InitSelectItem()
	{
		return new SelectItem
		{
			CallbackClickItem = new Action<EToggleState, int>(this.OnClickedItem),
			CallbackGetState = new Func<int, bool>(this.GetSelectState)
		};
	}

	// Token: 0x0600FB41 RID: 64321 RVA: 0x0044FAF4 File Offset: 0x0044DCF4
	public override void Refresh(InventoryDefine.ISelectGroupData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.InitAllData();
		int filterRuleId = this.Data.FilterRuleId;
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(filterRuleId);
		base.GetText(0).ShowTextNew(filterRuleConfig.Value.Title);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(data.FilterId);
		base.GetItem(1).SetUIActive(filterConfig.Value.IsSupportSelectAll);
		this.RefreshToggleAll();
		this.Layout.RefreshByData(this.ItemDataList, null, false);
	}

	// Token: 0x0600FB42 RID: 64322 RVA: 0x0044FB88 File Offset: 0x0044DD88
	private void InitAllData()
	{
		List<InventoryDefine.ISelectItemData> list = new List<InventoryDefine.ISelectItemData>();
		InventoryDefine.ISelectGroupData data = this.Data;
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(data.FilterId);
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(data.FilterRuleId);
		int[] array = filterRuleConfig.Value.IdList();
		int filterType = filterRuleConfig.Value.FilterType;
		Func<int[], FilterItemData[]> filterDataFuncByFilterType = ModelBase<FilterModel>.Instance.GetFilterDataFuncByFilterType((FilterDefine.EFilterType)filterType);
		foreach (int num in array)
		{
			FilterItemData filterItemData = filterDataFuncByFilterType(new int[]
			{
				num
			})[0];
			InventoryDefine.SelectItemData item = new InventoryDefine.SelectItemData
			{
				FilterId = data.FilterId,
				FilterRuleId = data.FilterRuleId,
				Value = num,
				Name = filterItemData.Content,
				IconPath = filterItemData.GetIconPath(),
				IsShowIcon = filterConfig.Value.IsShowIcon,
				NeedChangeColor = filterRuleConfig.Value.NeedChangeColor
			};
			if (Array.IndexOf<int>(data.ValueList, num) >= 0 && !this.SelectValueMap.ContainsKey(num))
			{
				this.SelectValueMap.Add(num, num);
			}
			list.Add(item);
		}
		this.ItemDataList = list;
	}

	// Token: 0x0600FB43 RID: 64323 RVA: 0x0044FCD8 File Offset: 0x0044DED8
	public void RefreshToggleAll()
	{
		int filterId = this.Data.FilterId;
		if (!ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterId).Value.IsSupportSelectAll)
		{
			return;
		}
		EToggleState state = (this.SelectValueMap.Count == this.ItemDataList.Count) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(2).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600FB44 RID: 64324 RVA: 0x0044FD40 File Offset: 0x0044DF40
	public void RefreshGroupItem()
	{
		foreach (KeyValuePair<object, SelectItem> keyValuePair in this.Layout.GetLayoutItemMap())
		{
			keyValuePair.Value.RefreshToggleState();
		}
	}

	// Token: 0x0600FB45 RID: 64325 RVA: 0x0044FDA0 File Offset: 0x0044DFA0
	public void ResetSelect()
	{
		this.SelectValueMap.Clear();
		foreach (KeyValuePair<object, SelectItem> keyValuePair in this.Layout.GetLayoutItemMap())
		{
			keyValuePair.Value.RefreshToggleState();
		}
		this.RefreshToggleAll();
	}

	// Token: 0x0600FB46 RID: 64326 RVA: 0x0044FE10 File Offset: 0x0044E010
	public bool GetSelectState(int value)
	{
		return this.SelectValueMap.ContainsKey(value);
	}

	// Token: 0x0600FB47 RID: 64327 RVA: 0x0044FE20 File Offset: 0x0044E020
	public int[] GetSelectValueList()
	{
		int[] array = new int[this.SelectValueMap.Count];
		int num = 0;
		foreach (int num2 in this.SelectValueMap.Values)
		{
			array[num++] = num2;
		}
		return array;
	}

	// Token: 0x0600FB48 RID: 64328 RVA: 0x0044FE90 File Offset: 0x0044E090
	private void OnClickedAll(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			using (Dictionary<object, SelectItem>.KeyCollection.Enumerator enumerator = this.Layout.GetLayoutItemMap().Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					int num = (int)obj;
					if (!this.SelectValueMap.ContainsKey(num))
					{
						this.SelectValueMap.Add(num, num);
					}
				}
				goto IL_66;
			}
		}
		if (state == EToggleState.ETT_UnChecked)
		{
			this.ResetSelect();
		}
		IL_66:
		this.RefreshGroupItem();
	}

	// Token: 0x0600FB49 RID: 64329 RVA: 0x0044FF1C File Offset: 0x0044E11C
	private void OnClickedItem(EToggleState state, int value)
	{
		if (state == EToggleState.ETT_Checked)
		{
			if (!this.SelectValueMap.ContainsKey(value))
			{
				this.SelectValueMap.Add(value, value);
			}
		}
		else
		{
			this.SelectValueMap.Remove(value);
		}
		this.RefreshToggleAll();
	}

	// Token: 0x0600FB4A RID: 64330 RVA: 0x0044FF52 File Offset: 0x0044E152
	public override object GetKey(InventoryDefine.ISelectGroupData data, int displayIndex)
	{
		return this.Data.FilterRuleId;
	}

	// Token: 0x0600FB4B RID: 64331 RVA: 0x0044FF64 File Offset: 0x0044E164
	public int GetRuleId()
	{
		return this.Data.FilterRuleId;
	}

	// Token: 0x040078AA RID: 30890
	[Nullable(2)]
	private InventoryDefine.ISelectGroupData Data;

	// Token: 0x040078AB RID: 30891
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SelectItem, InventoryDefine.ISelectItemData> Layout;

	// Token: 0x040078AC RID: 30892
	private readonly Dictionary<int, int> SelectValueMap = new Dictionary<int, int>();

	// Token: 0x040078AD RID: 30893
	private List<InventoryDefine.ISelectItemData> ItemDataList = new List<InventoryDefine.ISelectItemData>();

	// Token: 0x020083E3 RID: 33763
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402CB5E RID: 183134
		Title,
		// Token: 0x0402CB5F RID: 183135
		SelectAllToggleRootItem,
		// Token: 0x0402CB60 RID: 183136
		SelectAllToggle,
		// Token: 0x0402CB61 RID: 183137
		Layout,
		// Token: 0x0402CB62 RID: 183138
		FilterItem
	}
}
