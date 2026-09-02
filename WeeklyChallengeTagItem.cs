using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D24 RID: 11556
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyChallengeTagItem : GridProxyAbstract<string>
{
	// Token: 0x0601752F RID: 95535 RVA: 0x00677DB8 File Offset: 0x00675FB8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06017530 RID: 95536 RVA: 0x00677E00 File Offset: 0x00676000
	[NullableContext(1)]
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		base.GetText(0).ShowTextNew(data);
	}

	// Token: 0x02008FEA RID: 36842
	private enum EComponents
	{
		// Token: 0x040304AE RID: 197806
		TagText
	}
}
