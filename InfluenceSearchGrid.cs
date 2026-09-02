using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FEC RID: 8172
[NullableContext(1)]
[Nullable(0)]
internal class InfluenceSearchGrid : UiPanelBase
{
	// Token: 0x0600F6B7 RID: 63159 RVA: 0x00438C90 File Offset: 0x00436E90
	public InfluenceSearchGrid(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F6B8 RID: 63160 RVA: 0x00438CA8 File Offset: 0x00436EA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F6B9 RID: 63161 RVA: 0x00438D53 File Offset: 0x00436F53
	protected override void OnStart()
	{
		this.Layout = new GenericLayoutNew<InfluenceSearchItem>(base.GetVerticalLayout(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<InfluenceSearchItem>(this.InitItem), base.GetItem(3));
	}

	// Token: 0x0600F6BA RID: 63162 RVA: 0x00438D7C File Offset: 0x00436F7C
	private ILayoutItem<InfluenceSearchItem> InitItem(object influenceId, UUIItem uiItem, int index)
	{
		InfluenceSearchItem influenceSearchItem = new InfluenceSearchItem(uiItem);
		influenceSearchItem.UpdateItem((int)influenceId, this.CountryId);
		return new LayoutItem<InfluenceSearchItem>
		{
			Key = index,
			Value = influenceSearchItem
		};
	}

	// Token: 0x0600F6BB RID: 63163 RVA: 0x00438DBC File Offset: 0x00436FBC
	public void UpdateGrid(int countryId, int[] influenceIdList)
	{
		this.CountryId = countryId;
		Country value = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(countryId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Title, Array.Empty<object>());
		UUIItem item = base.GetItem(1);
		bool flag = influenceIdList.Length != 0;
		item.SetUIActive(!flag);
		this.Layout.RebuildLayoutByDataNew<int>(influenceIdList, null);
	}

	// Token: 0x0600F6BC RID: 63164 RVA: 0x00438E2C File Offset: 0x0043702C
	protected override void OnBeforeDestroy()
	{
		this.Layout.ClearChildren();
		this.Layout = null;
	}

	// Token: 0x04007731 RID: 30513
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<InfluenceSearchItem> Layout;

	// Token: 0x04007732 RID: 30514
	private int CountryId;

	// Token: 0x0200836A RID: 33642
	[NullableContext(0)]
	private enum EInfluenceSearchGrid
	{
		// Token: 0x0402C930 RID: 182576
		Title,
		// Token: 0x0402C931 RID: 182577
		NoSearchText,
		// Token: 0x0402C932 RID: 182578
		Layout,
		// Token: 0x0402C933 RID: 182579
		LayoutItem
	}
}
