using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002031 RID: 8241
[NullableContext(1)]
[Nullable(0)]
internal class ConvertShowItem : UiPanelBase
{
	// Token: 0x0600FB03 RID: 64259 RVA: 0x0044E94C File Offset: 0x0044CB4C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600FB04 RID: 64260 RVA: 0x0044E9D6 File Offset: 0x0044CBD6
	protected override void OnStart()
	{
		this.ItemScrollView = new LoopScrollView<CommonItemSmallItemGrid, TItem>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<CommonItemSmallItemGrid>(this.OnGridProxyCreate), false);
	}

	// Token: 0x0600FB05 RID: 64261 RVA: 0x0044EA08 File Offset: 0x0044CC08
	private CommonItemSmallItemGrid OnGridProxyCreate()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600FB06 RID: 64262 RVA: 0x0044EA0F File Offset: 0x0044CC0F
	public void Refresh(string title, IReadOnlyList<TItem> itemList)
	{
		LoopScrollView<CommonItemSmallItemGrid, TItem> itemScrollView = this.ItemScrollView;
		if (itemScrollView != null)
		{
			itemScrollView.RefreshByData(itemList.ToList<TItem>(), false, null, false);
		}
		base.GetText(0).ShowTextNew(title);
	}

	// Token: 0x0400788E RID: 30862
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<CommonItemSmallItemGrid, TItem> ItemScrollView;
}
