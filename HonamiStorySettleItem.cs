using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F7D RID: 8061
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStorySettleItem : GridProxyAbstract<IHonamiStorySettleItemParams>
{
	// Token: 0x0600F195 RID: 61845 RVA: 0x0042017C File Offset: 0x0041E37C
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

	// Token: 0x0600F196 RID: 61846 RVA: 0x004201E5 File Offset: 0x0041E3E5
	[NullableContext(1)]
	public override void Refresh(IHonamiStorySettleItemParams data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		base.GetText(1).SetText(data.Value, true);
	}

	// Token: 0x0200831A RID: 33562
	private enum EComponentType
	{
		// Token: 0x0402C748 RID: 182088
		NameText,
		// Token: 0x0402C749 RID: 182089
		ValueText
	}
}
