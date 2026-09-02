using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200199D RID: 6557
[NullableContext(1)]
[Nullable(0)]
public class TipsGetWayPanel : UiPanelBase
{
	// Token: 0x0600BC4A RID: 48202 RVA: 0x0031F969 File Offset: 0x0031DB69
	public TipsGetWayPanel(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600BC4B RID: 48203 RVA: 0x0031F980 File Offset: 0x0031DB80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BC4C RID: 48204 RVA: 0x0031F9E9 File Offset: 0x0031DBE9
	protected override void OnStart()
	{
		this.GetWayLayout = new GenericLayoutNew<TipsGetWayItem>(base.GetVerticalLayout(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TipsGetWayItem>(this.RefreshGetWayInfo), null);
	}

	// Token: 0x0600BC4D RID: 48205 RVA: 0x0031FA0A File Offset: 0x0031DC0A
	protected override void OnBeforeDestroy()
	{
		this.GetWayData = new IGetWayItemData[0];
	}

	// Token: 0x0600BC4E RID: 48206 RVA: 0x0031FA18 File Offset: 0x0031DC18
	public void Refresh(IGetWayItemData[] data)
	{
		IGetWayItemData[] getWayData2 = (from getWayData in data
		orderby getWayData.SortIndex descending, getWayData.Id descending
		select getWayData).ToArray<IGetWayItemData>();
		this.GetWayData = getWayData2;
		this.GetWayLayout.RebuildLayoutByDataNew<IGetWayItemData>(this.GetWayData, null);
		this.SetActive(this.GetWayData.Length != 0);
	}

	// Token: 0x0600BC4F RID: 48207 RVA: 0x0031FAA8 File Offset: 0x0031DCA8
	private ILayoutItem<TipsGetWayItem> RefreshGetWayInfo(object data, UUIItem uiItem, int index)
	{
		TipsGetWayItem value = new TipsGetWayItem(uiItem, (IGetWayItemData)data);
		return new LayoutItem<TipsGetWayItem>
		{
			Key = index,
			Value = value
		};
	}

	// Token: 0x04005920 RID: 22816
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IGetWayItemData[] GetWayData;

	// Token: 0x04005921 RID: 22817
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TipsGetWayItem> GetWayLayout;

	// Token: 0x02007CA0 RID: 31904
	[NullableContext(0)]
	private class ETipsGetWayNode
	{
		// Token: 0x0402A8D5 RID: 174293
		public const int PanelLink = 0;

		// Token: 0x0402A8D6 RID: 174294
		public const int ButtonLink = 1;
	}
}
