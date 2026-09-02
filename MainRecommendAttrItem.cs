using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200250F RID: 9487
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class MainRecommendAttrItem : GridProxyAbstract<IMainRecommendAttrItemData>
{
	// Token: 0x060126AD RID: 75437 RVA: 0x0051084C File Offset: 0x0050EA4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x060126AE RID: 75438 RVA: 0x005108BC File Offset: 0x0050EABC
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<AttrContent, RecommendItemData>(base.GetVerticalLayout(1), new Func<AttrContent>(this.InitItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x060126AF RID: 75439 RVA: 0x005108EF File Offset: 0x0050EAEF
	private AttrContent InitItem()
	{
		return new AttrContent();
	}

	// Token: 0x060126B0 RID: 75440 RVA: 0x005108F8 File Offset: 0x0050EAF8
	public override void Refresh(IMainRecommendAttrItemData data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), data.CostLabel, Array.Empty<object>());
		GenericLayout<AttrContent, RecommendItemData> layout = this.Layout;
		if (layout != null)
		{
			layout.RefreshByData(data.Items, null, false);
		}
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.Items.Count == 0);
	}

	// Token: 0x04008FAC RID: 36780
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AttrContent, RecommendItemData> Layout;
}
