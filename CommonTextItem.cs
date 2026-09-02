using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200189A RID: 6298
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonTextItem : GridProxyAbstract<TableTextArgNew>
{
	// Token: 0x0600B4C9 RID: 46281 RVA: 0x00302508 File Offset: 0x00300708
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

	// Token: 0x0600B4CA RID: 46282 RVA: 0x00302550 File Offset: 0x00300750
	public void SetTextByTextId(string textId, [ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), textId, args);
	}

	// Token: 0x0600B4CB RID: 46283 RVA: 0x00302568 File Offset: 0x00300768
	public override void Refresh(TableTextArgNew data, bool isSelected, int gridIndex)
	{
		string textKey = data.TextKey;
		if (textKey != null)
		{
			this.SetTextByTextId(textKey, data.Params);
		}
	}

	// Token: 0x02007C16 RID: 31766
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402A638 RID: 173624
		public const int Text = 0;
	}
}
