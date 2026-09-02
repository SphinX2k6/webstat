using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200196F RID: 6511
internal class StarLayoutItem : UiPanelBase
{
	// Token: 0x0600BB11 RID: 47889 RVA: 0x0031BF66 File Offset: 0x0031A166
	[NullableContext(1)]
	public StarLayoutItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600BB12 RID: 47890 RVA: 0x0031BF7B File Offset: 0x0031A17B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600BB13 RID: 47891 RVA: 0x0031BFB4 File Offset: 0x0031A1B4
	protected override void OnStart()
	{
		this.StarLayout = new GenericLayoutNew<StarItem>(base.GetVerticalLayout(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<StarItem>(this.InitStarItem), base.GetItem(1));
	}

	// Token: 0x0600BB14 RID: 47892 RVA: 0x0031BFDC File Offset: 0x0031A1DC
	[NullableContext(1)]
	private ILayoutItem<StarItem> InitStarItem([Nullable(2)] object data, UUIItem uiItem, int index)
	{
		StarItem value = new StarItem(uiItem);
		return new LayoutItem<StarItem>
		{
			Key = index,
			Value = value
		};
	}

	// Token: 0x0600BB15 RID: 47893 RVA: 0x0031C008 File Offset: 0x0031A208
	[NullableContext(2)]
	public void RefreshStar(int[] starNum)
	{
		int num = (starNum != null) ? starNum.Length : 0;
		base.GetVerticalLayout(0).RootUIComp.Get().SetUIActive(num > 0);
		if (num > 0)
		{
			this.StarLayout.RebuildLayoutByDataNew<int>(starNum, null);
		}
	}

	// Token: 0x0600BB16 RID: 47894 RVA: 0x0031C055 File Offset: 0x0031A255
	protected override void OnBeforeDestroy()
	{
		this.StarLayout.ClearChildren();
	}

	// Token: 0x0400586D RID: 22637
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<StarItem> StarLayout;

	// Token: 0x02007C88 RID: 31880
	private enum EStarDefine
	{
		// Token: 0x0402A870 RID: 174192
		Layout,
		// Token: 0x0402A871 RID: 174193
		StarItem
	}
}
