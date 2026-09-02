using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020028BE RID: 10430
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleSkillInputDescItem : GridProxyAbstract<string>
{
	// Token: 0x06014B20 RID: 84768 RVA: 0x005BAF30 File Offset: 0x005B9130
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

	// Token: 0x06014B21 RID: 84769 RVA: 0x005BAF78 File Offset: 0x005B9178
	[NullableContext(1)]
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		base.GetText(0).ShowTextNew(data);
	}

	// Token: 0x02008C04 RID: 35844
	private enum EComponent
	{
		// Token: 0x0402F2A6 RID: 193190
		Desc
	}
}
