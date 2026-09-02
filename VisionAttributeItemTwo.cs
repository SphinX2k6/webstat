using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Module.Vision.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024F0 RID: 9456
[NullableContext(1)]
[Nullable(0)]
public class VisionAttributeItemTwo : UiPanelBase
{
	// Token: 0x060125CF RID: 75215 RVA: 0x0050CBAB File Offset: 0x0050ADAB
	public VisionAttributeItemTwo(UUIItem root)
	{
		this.LoadingPromise = new CustomPromise<bool>();
		base.CreateThenShowByResourceIdAsync("UiItem_VisionIAttriItemB", root, false);
	}

	// Token: 0x060125D0 RID: 75216 RVA: 0x0050CBCC File Offset: 0x0050ADCC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060125D1 RID: 75217 RVA: 0x0050CC14 File Offset: 0x0050AE14
	protected override void OnStart()
	{
		this.Layout = new GenericScrollView<AttributeItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AttributeItem>(this.InitItem), null);
	}

	// Token: 0x060125D2 RID: 75218 RVA: 0x0050CC38 File Offset: 0x0050AE38
	private ILayoutItem<AttributeItem> InitItem(object data, UUIItem uiItem, int index)
	{
		AttributeItem attributeItem = new AttributeItem(uiItem);
		attributeItem.Update((VisionAttributeVariantTwoData)data);
		return new LayoutItem<AttributeItem>
		{
			Key = index,
			Value = attributeItem
		};
	}

	// Token: 0x060125D3 RID: 75219 RVA: 0x0050CC70 File Offset: 0x0050AE70
	public void Update(List<VisionAttributeVariantTwoData> data)
	{
		this.Layout.RefreshByData<VisionAttributeVariantTwoData>(data, null);
	}

	// Token: 0x060125D4 RID: 75220 RVA: 0x0050CC92 File Offset: 0x0050AE92
	protected override void OnBeforeDestroy()
	{
		this.Layout.ClearChildren();
	}

	// Token: 0x04008F3A RID: 36666
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AttributeItem> Layout;

	// Token: 0x04008F3B RID: 36667
	public CustomPromise<bool> LoadingPromise;

	// Token: 0x02008806 RID: 34822
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF43 RID: 188227
		Scroller
	}
}
