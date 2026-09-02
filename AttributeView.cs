using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020017A1 RID: 6049
public class AttributeView : UiViewBase
{
	// Token: 0x0600AAB3 RID: 43699 RVA: 0x002D95B3 File Offset: 0x002D77B3
	[NullableContext(1)]
	public AttributeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AAB4 RID: 43700 RVA: 0x002D95BC File Offset: 0x002D77BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x0600AAB5 RID: 43701 RVA: 0x002D95E0 File Offset: 0x002D77E0
	protected override void OnStart()
	{
		CommonAttributeData[] source = this.OpenParam as CommonAttributeData[];
		this.AttrScrollList = new GenericScrollView<CommonAttributeItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonAttributeItem>(this.InitAttrItem), null);
		this.AttrScrollList.RefreshByData<CommonAttributeData>(source.ToList<CommonAttributeData>(), null);
	}

	// Token: 0x0600AAB6 RID: 43702 RVA: 0x002D9634 File Offset: 0x002D7834
	[NullableContext(1)]
	private ILayoutItem<CommonAttributeItem> InitAttrItem(object data, UUIItem item, int index)
	{
		CommonAttributeItem commonAttributeItem = new CommonAttributeItem(item);
		commonAttributeItem.ShowTemp((CommonAttributeData)data);
		return new LayoutItem<CommonAttributeItem>
		{
			Key = index,
			Value = commonAttributeItem
		};
	}

	// Token: 0x0600AAB7 RID: 43703 RVA: 0x002D966C File Offset: 0x002D786C
	protected override void OnBeforeDestroy()
	{
		if (this.AttrScrollList != null)
		{
			this.AttrScrollList.ClearChildren();
			this.AttrScrollList = null;
		}
	}

	// Token: 0x0400512B RID: 20779
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<CommonAttributeItem> AttrScrollList;

	// Token: 0x02007AF6 RID: 31478
	private enum EAttributeView
	{
		// Token: 0x0402A1AC RID: 172460
		AttributeContent
	}
}
