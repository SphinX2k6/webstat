using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002C05 RID: 11269
public class TowerStarsComplexItem : GridProxyAbstract<ValueTuple<bool, TowerTarget>>
{
	// Token: 0x060167BF RID: 92095 RVA: 0x0063FFB4 File Offset: 0x0063E1B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060167C0 RID: 92096 RVA: 0x0064001D File Offset: 0x0063E21D
	public override void Refresh(ValueTuple<bool, TowerTarget> data, bool isSelected, int gridIndex)
	{
		base.GetItem(0).SetUIActive(data.Item1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Item2.DesText, data.Item2.Params());
	}

	// Token: 0x02008F03 RID: 36611
	private enum EChildType
	{
		// Token: 0x040300A7 RID: 196775
		StarItem,
		// Token: 0x040300A8 RID: 196776
		DescriptionText
	}
}
