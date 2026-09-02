using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023F1 RID: 9201
public class GiftPackageItem : UiPanelBase
{
	// Token: 0x06011CEF RID: 72943 RVA: 0x004E65E9 File Offset: 0x004E47E9
	[NullableContext(1)]
	public void Initialize(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06011CF0 RID: 72944 RVA: 0x004E65F8 File Offset: 0x004E47F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011CF1 RID: 72945 RVA: 0x004E6682 File Offset: 0x004E4882
	protected override void OnStart()
	{
		this.CommonItemSimpleGrid = new CommonItemSmallItemGrid();
		this.CommonItemSimpleGrid.Initialize(base.GetItem(0).GetOwner());
	}

	// Token: 0x06011CF2 RID: 72946 RVA: 0x004E66A6 File Offset: 0x004E48A6
	public void SetBelongViewName(EUiViewName viewName)
	{
	}

	// Token: 0x06011CF3 RID: 72947 RVA: 0x004E66A8 File Offset: 0x004E48A8
	public void UpdateItem(int itemId, int count)
	{
		this.ItemId = itemId;
		this.CommonItemSimpleGrid.RefreshByConfigId(itemId, null, null, false, false);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		base.GetText(1).ShowTextNew(itemConfigData.Name);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "Quantity", new <>z__ReadOnlySingleElementList<object>(count));
	}

	// Token: 0x06011CF4 RID: 72948 RVA: 0x004E6713 File Offset: 0x004E4913
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x04008B56 RID: 35670
	[Nullable(2)]
	protected CommonItemSmallItemGrid CommonItemSimpleGrid;

	// Token: 0x04008B57 RID: 35671
	protected int ItemId;

	// Token: 0x0200872C RID: 34604
	private class EGiftPackageItem
	{
		// Token: 0x0402DB98 RID: 187288
		public const int CommonItemSimpleGrid = 0;

		// Token: 0x0402DB99 RID: 187289
		public const int Name = 1;

		// Token: 0x0402DB9A RID: 187290
		public const int Count = 2;
	}
}
