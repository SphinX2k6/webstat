using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001ADF RID: 6879
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssGoalItem : GridProxyAbstract<GoalPanelData>
{
	// Token: 0x0600C5F7 RID: 50679 RVA: 0x00344A94 File Offset: 0x00342C94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C5F8 RID: 50680 RVA: 0x00344AFD File Offset: 0x00342CFD
	[NullableContext(1)]
	public override void Refresh(GoalPanelData data, bool isSelected, int gridIndex)
	{
		base.GetText(0).SetText(data.Title, true);
		base.GetText(1).SetText(data.Desc ?? "", true);
	}

	// Token: 0x02007DB5 RID: 32181
	private enum EGoalComponent
	{
		// Token: 0x0402ACFD RID: 175357
		Desc,
		// Token: 0x0402ACFE RID: 175358
		GoalText
	}
}
