using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010CE RID: 4302
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class GolemHackingCodeKeyListItem : GridProxyAbstract<List<GolemHackingCodeGridInfo>>
{
	// Token: 0x06006FFB RID: 28667 RVA: 0x001D2D72 File Offset: 0x001D0F72
	public GolemHackingCodeKeyListItem(GolemHackingGameProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x06006FFC RID: 28668 RVA: 0x001D2D84 File Offset: 0x001D0F84
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FFD RID: 28669 RVA: 0x001D2DED File Offset: 0x001D0FED
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<GolemHackingCodeKeyItem, GolemHackingCodeGridInfo>(base.GetHorizontalLayout(0), new Func<GolemHackingCodeKeyItem>(this.CreateItem), null, false, true);
	}

	// Token: 0x06006FFE RID: 28670 RVA: 0x001D2E10 File Offset: 0x001D1010
	public override void Refresh(List<GolemHackingCodeGridInfo> data, bool isSelected, int gridIndex)
	{
		this.Layout.RefreshByData(data, null, false);
	}

	// Token: 0x06006FFF RID: 28671 RVA: 0x001D2E20 File Offset: 0x001D1020
	private GolemHackingCodeKeyItem CreateItem()
	{
		return new GolemHackingCodeKeyItem(this.Proxy);
	}

	// Token: 0x06007000 RID: 28672 RVA: 0x001D2E2D File Offset: 0x001D102D
	public void OnMatrixHover(int curIndex, string value)
	{
		GolemHackingCodeKeyItem layoutItemByIndex = this.Layout.GetLayoutItemByIndex(curIndex);
		if (layoutItemByIndex == null)
		{
			return;
		}
		layoutItemByIndex.OnMatrixHover(value);
	}

	// Token: 0x06007001 RID: 28673 RVA: 0x001D2E48 File Offset: 0x001D1048
	public void OnMatrixUnHover()
	{
		foreach (GolemHackingCodeKeyItem golemHackingCodeKeyItem in this.Layout.GetLayoutItemList())
		{
			golemHackingCodeKeyItem.OnMatrixUnHover();
		}
	}

	// Token: 0x040035E5 RID: 13797
	protected GolemHackingGameProxy Proxy;

	// Token: 0x040035E6 RID: 13798
	protected GenericLayout<GolemHackingCodeKeyItem, GolemHackingCodeGridInfo> Layout;

	// Token: 0x0200745D RID: 29789
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402838F RID: 164751
		PanelKeyGroup,
		// Token: 0x04028390 RID: 164752
		BtnCodeKey
	}
}
