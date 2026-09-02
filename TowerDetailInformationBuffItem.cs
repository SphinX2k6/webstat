using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BEC RID: 11244
[NullableContext(1)]
[Nullable(0)]
public class TowerDetailInformationBuffItem : UiPanelBase
{
	// Token: 0x06016704 RID: 91908 RVA: 0x0063B8E6 File Offset: 0x00639AE6
	public TowerDetailInformationBuffItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06016705 RID: 91909 RVA: 0x0063B8FC File Offset: 0x00639AFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016706 RID: 91910 RVA: 0x0063B965 File Offset: 0x00639B65
	protected override void OnStart()
	{
		this.BuffScroller = new GenericLayoutNew<TowerDetailInformationBuffSubItem>(base.GetVerticalLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TowerDetailInformationBuffSubItem>(this.CreateBuffItem), null);
	}

	// Token: 0x06016707 RID: 91911 RVA: 0x0063B988 File Offset: 0x00639B88
	private ILayoutItem<TowerDetailInformationBuffSubItem> CreateBuffItem(object tempData, UUIItem uiItem, int index)
	{
		TowerDetailBuff data = (TowerDetailBuff)tempData;
		TowerDetailInformationBuffSubItem towerDetailInformationBuffSubItem = new TowerDetailInformationBuffSubItem(uiItem);
		towerDetailInformationBuffSubItem.Update(data);
		return new LayoutItem<TowerDetailInformationBuffSubItem>
		{
			Key = index,
			Value = towerDetailInformationBuffSubItem
		};
	}

	// Token: 0x06016708 RID: 91912 RVA: 0x0063B9C2 File Offset: 0x00639BC2
	public void Update(TowerDetailBuffData data)
	{
		this.BuffData = data;
		this.RefreshView();
	}

	// Token: 0x06016709 RID: 91913 RVA: 0x0063B9D4 File Offset: 0x00639BD4
	private void RefreshView()
	{
		this.BuffScroller.RebuildLayoutByDataNew<TowerDetailBuff>(this.BuffData.Buffs, null);
	}

	// Token: 0x0601670A RID: 91914 RVA: 0x0063BA00 File Offset: 0x00639C00
	protected override void OnBeforeDestroy()
	{
		this.BuffScroller.ClearChildren();
	}

	// Token: 0x0400ADC0 RID: 44480
	[Nullable(2)]
	private TowerDetailBuffData BuffData;

	// Token: 0x0400ADC1 RID: 44481
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TowerDetailInformationBuffSubItem> BuffScroller;

	// Token: 0x02008EE1 RID: 36577
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402FFF8 RID: 196600
		public const int BuffItem = 0;

		// Token: 0x0402FFF9 RID: 196601
		public const int BuffScroller = 1;
	}
}
