using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001243 RID: 4675
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerSettlementDeTermLayoutItem : GridProxyAbstract<int[]>
{
	// Token: 0x06007C8E RID: 31886 RVA: 0x0020C564 File Offset: 0x0020A764
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007C8F RID: 31887 RVA: 0x0020C5AC File Offset: 0x0020A7AC
	protected override void OnStart()
	{
		this.DeTermLayout = new GenericLayout<BabelTowerSettlementDeTermItem, int>(base.GetHorizontalLayout(0), new Func<BabelTowerSettlementDeTermItem>(this.CreateDeTermItem), this.TemplateActor, false, true);
	}

	// Token: 0x06007C90 RID: 31888 RVA: 0x0020C5D4 File Offset: 0x0020A7D4
	private BabelTowerSettlementDeTermItem CreateDeTermItem()
	{
		return new BabelTowerSettlementDeTermItem();
	}

	// Token: 0x06007C91 RID: 31889 RVA: 0x0020C5DB File Offset: 0x0020A7DB
	public override void Refresh(int[] data, bool isSelected, int gridIndex)
	{
		GenericLayout<BabelTowerSettlementDeTermItem, int> deTermLayout = this.DeTermLayout;
		if (deTermLayout == null)
		{
			return;
		}
		deTermLayout.RefreshByData(new List<int>(data), null, false);
	}

	// Token: 0x06007C92 RID: 31890 RVA: 0x0020C5F5 File Offset: 0x0020A7F5
	public void SetLayoutPadding(FMargin padding)
	{
		base.GetHorizontalLayout(0).SetPadding(padding);
	}

	// Token: 0x04003B97 RID: 15255
	[Nullable(2)]
	public AUIBaseActor TemplateActor;

	// Token: 0x04003B98 RID: 15256
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<BabelTowerSettlementDeTermItem, int> DeTermLayout;

	// Token: 0x020075B4 RID: 30132
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040289B3 RID: 166323
		public const int DeTermHorizontalLayout = 0;
	}
}
